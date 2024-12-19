/*
*	<copyright file="MinhasCamadas.Regras.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/18/2024 7:36:12 PM</date>
*	<description></description>
**/
using MinhasCamadas.Dados;
using MinhasCamadas.Objetos;
using MinhasCamadas.Objetos.Consulta;
using MinhasCamadas.ProjectException;
using MinhasCamadas.ProjectException.Consulta;
using MinhasCamadas.ProjectException.Medico;
using MinhasCamadas.Validacoes;
using System;
using System.Collections.Generic;

namespace MinhasCamadas.Regras
{
    /// <summary>
    /// Purpose:
    /// Created by: gonca
    /// Created on: 12/18/2024 7:36:12 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class RegrasConsulta
    {
        #region Attributes
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public RegrasConsulta()
        {
        }

        #endregion

        #region Properties
        #endregion



        #region Overrides
        #endregion

        #region OtherMethods
        /// <summary>
        /// Tenta criar um objeto do tipo <see cref="Consulta"/>.
        /// </summary>
        /// <param name="perm">Permissão do utilizador.</param>
        /// <param name="dataI">Data de início da consulta.</param>
        /// <param name="dataF">Data de fim da consulta.</param>
        /// <param name="nif">NIF do paciente.</param>
        /// <param name="numeroS">Número do staff associado à consulta.</param>
        /// <param name="crm">CRM do médico para validações específicas.</param>
        /// <param name="idDiagnostico">ID do diagnóstico associado (opcional).</param>
        /// <param name="tp">Tipo da consulta <see cref="TIPOCONSULTA"/>.</param>
        /// <param name="e">Estado da consulta <see cref="ESTADO"/>.</param>
        /// <returns>
        /// <para>Retorna o objeto <see cref="Consulta"/> criado, caso todas as validações sejam bem-sucedidas.</para>
        /// <para><b>Exceções Lançadas:</b></para>
        /// <list type="bullet">
        /// <item><b><see cref="RegrasConsultaException"/>:</b> Código de erro -141 quando o utilizador não tem permissão.</item>
        /// <item><b><see cref="ConsultaException"/>:</b> Lançada caso haja um erro na validação dos campos da consulta.</item>
        /// <item><b><see cref="ListaConsultaException"/>:</b> Lançada caso a consulta seja duplicada, ou existam sobreposições nas datas do paciente ou médico.</item>
        /// </list>
        /// </returns>
        /// <exception cref="RegrasConsultaException">Código de erro -141: Permissão insuficiente.</exception>
        /// <exception cref="ConsultaException">Erro na validação dos campos.</exception>
        /// <exception cref="ListaConsultaException">Erro em validações relacionadas à consulta.</exception>
        public static Consulta TentaCriarConsulta(PERMISSOES perm , DateTime dataI, DateTime dataF, int nif, int numeroS, int crm, int? idDiagnostico, TIPOCONSULTA tp, ESTADO e)
        {
            switch (perm)
            {
                case PERMISSOES.None:
                    throw new RegrasConsultaException(-141);
                case PERMISSOES.Low:
                case PERMISSOES.High:
                    try
                    {
                        int res = ValidarConsulta.ValidarCamposConsulta(dataI, dataF, nif, crm, numeroS, idDiagnostico, tp, e);
                        if (res != 1)
                            throw new ConsultaException(res);

                        MiniConsulta miniConsulta = new MiniConsulta(0,crm,nif,dataI,dataF);

                        //1ª verificação - Se é duplicado
                        res = ValidarListaConsulta.PodeCriarConsulta(miniConsulta);
                        if (res != 1)
                            throw new ListaConsultaException(res);
                        
                        //2ª verificação - Se o Paciente tem alguma sobreposição nas datas
                        res = ValidarListaConsulta.EncontraDisponbibilidadePaciente(miniConsulta);
                        if (res != 1)
                            throw new ListaConsultaException(res);
                        
                        //3ª verificação - Se o Medico tem alguma sobreposição nas datas
                        res = ValidarListaConsulta.EncontraDisponbibilidadeMedico(miniConsulta);
                        if (res != 1)
                            throw new ListaConsultaException(res);

                        Consulta consulta = Consulta.CriaConsulta(dataI,dataF,nif,crm,numeroS,idDiagnostico,tp,e);
                        return consulta;
                    }
                    catch (ListaConsultaException)
                    {
                        throw;
                    }
                    catch (ConsultaException)
                    {
                        throw;
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                default:
                    throw new RegrasMedicosException(-141);
            }
        }

        /// <summary>
        /// Tenta adicionar uma consulta aos dados das Consultas.
        /// </summary>
        /// <param name="perm">Permissão do utilizador.</param>
        /// <param name="consulta">Objeto do tipo <see cref="Consulta"/> a ser adicionado.</param>
        /// <returns>
        /// <para><b>-141:</b> O utilizador não tem permissão para adicionar a consulta.</para>
        /// <para><b>ListaConsultaException:</b> Exceção lançada caso haja problemas com a lista de consultas.</para>
        /// <para><b>1:</b> Consulta adicionada com sucesso.</para>
        /// </returns>
        /// <exception cref="ListaConsultaException">
        /// Lançada quando ocorre um erro relacionado à lista de consultas.
        /// </exception>
        public static int TentarAdicionarConsulta(PERMISSOES perm, Consulta consulta)
        {
            switch (perm)
            {
                case PERMISSOES.None:
                    return -141;
                case PERMISSOES.Low:
                case PERMISSOES.High:
                    try
                    {
                        int res = ValidarConsulta.ValidarObjetoConsulta(consulta);
                        if (res != 1)
                            return res;

                        res = TodasConsultas.AdicionarConsulta(consulta);
                        if (res != 1)
                            return res;
                    }
                    catch (ListaConsultaException)
                    {
                        throw;
                    }
                    return 1;
                default:
                    return -141;
            }
        }

        /// <summary>
        /// Tenta remover uma consulta dos dados do sistema.
        /// </summary>
        /// <param name="perm">Permissão do utilizador.</param>
        /// <param name="idConsulta">ID da consulta a ser removida.</param>
        /// <returns>
        /// <para><b>-141:</b> O utilizador não tem permissão para remover a consulta.</para>
        /// <para><b>ListaMedicosException:</b> Exceção lançada caso haja problemas com a remoção.</para>
        /// <para><b>1:</b> Consulta removida com sucesso.</para>
        /// </returns>
        /// <exception cref="ListaMedicosException">
        /// Lançada quando ocorre um erro relacionado à remoção da consulta.
        /// </exception>
        public static int TentaRemoverConsulta(PERMISSOES perm, int idConsulta)
        {
            switch (perm)
            {
                case PERMISSOES.None:
                case PERMISSOES.Low:
                    return -141;

                case PERMISSOES.High:
                    try
                    {
                        int res = TodasConsultas.RemoverConsulta(idConsulta);
                        if(res != 1)
                            return res;
                    }
                    catch (ListaMedicosException lme)
                    {
                        throw lme;
                    }
                    break;
                default:
                    return -141;
            }
            return 1;
        }

        /// <summary>
        /// Obtém todas as consultas associadas a um paciente com base no NIF fornecido.
        /// </summary>
        /// <param name="perm">Permissão do utilizador.</param>
        /// <param name="nif">Número de Identificação Fiscal (NIF) do paciente.</param>
        /// <returns>
        /// <para><b>-141:</b> O utilizador não tem permissão para obter as consultas.</para>
        /// <para><b>ConsultaException:</b> Exceção lançada caso o NIF seja inválido ou a validação de uma consulta falhe.</para>
        /// <para><b>Lista de MiniConsultas:</b> Devolve uma lista de consultas associadas ao paciente.</para>
        /// </returns>
        /// <exception cref="ConsultaException">
        /// Lançada quando o NIF fornecido é inválido ou uma consulta falha na validação.
        /// </exception>
        /// <exception cref="RegrasConsultaException">
        /// Lançada quando o utilizador não tem permissão suficiente para acessar as consultas.
        /// </exception>
        public static List<MiniConsulta> ObterConsultasPaciente(PERMISSOES perm, int nif)
        {
            List<MiniConsulta> miniConsultas = new List<MiniConsulta>();
            MiniConsulta mini;
            List<int> ids  = new List<int>();

            int res = ValidarConsulta.ValidarNIF(nif);
            if (res != 1)
                throw new ConsultaException(res);

            switch (perm)
            {
                //neste caso, poderia ter mais validaçõs consoante o usuario, mas não tem o login implementado
                case PERMISSOES.None:
                case PERMISSOES.Low:
                case PERMISSOES.High:
                    ids = TodasConsultas.EncontraTodasConsultasPaciente(nif);
                    foreach(int id in ids)
                    {
                        mini = TodasConsultas.ObterConsulta(id);
                        res = ValidarConsulta.ValidarObjetoMiniConsulta(mini);
                        if (res != 1)
                            throw new ConsultaException(res);
                        miniConsultas.Add(mini);
                    }
                    return miniConsultas;
               
                default:
                    throw new RegrasConsultaException(-141);
            }
        }

        /// <summary>
        /// Obtém todas as consultas associadas a um médico com base no CRM fornecido.
        /// </summary>
        /// <param name="perm">Permissão do utilizador.</param>
        /// <param name="crm">CRM do médico.</param>
        /// <returns>
        /// <para><b>-141:</b> O utilizador não tem permissão para acessar as consultas.</para>
        /// <para><b>ConsultaException:</b> Exceção lançada caso o CRM seja inválido ou a validação de uma consulta falhe.</para>
        /// <para><b>Lista de MiniConsultas:</b> Retorna uma lista de consultas associadas ao médico.</para>
        /// </returns>
        /// <exception cref="ConsultaException">
        /// Lançada quando o CRM fornecido é inválido ou uma consulta falha na validação.
        /// </exception>
        /// <exception cref="RegrasConsultaException">
        /// Lançada quando o utilizador não tem permissão suficiente para acessar as consultas.
        /// </exception>
        public static List<MiniConsulta> ObterConsultasMedico(PERMISSOES perm, int crm)
        {
            List<MiniConsulta> miniConsultas = new List<MiniConsulta>();
            MiniConsulta mini;
            List<int> ids = new List<int>();

            int res = ValidarConsulta.ValidarCRM(crm);
            if (res != 1)
                throw new ConsultaException(res);

            switch (perm)
            {
                //neste caso, poderia ter mais validaçõs consoante o usuario, mas não tem o login implementado
                case PERMISSOES.None:
                    throw new RegrasConsultaException(-141);
                case PERMISSOES.Low:
                case PERMISSOES.High:
                    ids = TodasConsultas.EncontraTodasConsultasMedico(crm);
                    foreach (int id in ids)
                    {
                        mini = TodasConsultas.ObterConsulta(id);
                        res = ValidarConsulta.ValidarObjetoMiniConsulta(mini);
                        if (res != 1)
                            throw new ConsultaException(res);
                        miniConsultas.Add(mini);
                    }
                    return miniConsultas;

                default:
                    throw new RegrasConsultaException(-141);
            }
        }


        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~RegrasConsulta()
        {
        }
        #endregion

        #endregion
    }
}
