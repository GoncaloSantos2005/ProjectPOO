/*
*	<copyright file="MinhasCamadas.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/2/2024 12:20:26 PM</date>
*	<description></description>
**/
using MinhasCamadas.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinhasCamadas
{
    /// <summary>
    /// Purpose: Regras de Negócio para Medico
    /// Created by: gonca
    /// Created on: 12/2/2024 12:20:26 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public static class RegrasMedicos
    {
        #region Attributes
        #endregion

        #region Methods

        #region Properties
        #endregion


        #region Overrides
        #endregion

        #region OtherMethods
        /// <summary>
        /// Tenta criar um objeto do tipo Medico
        /// </summary>
        /// <param name="perm">Permissao do utilizador.</param>
        /// <param name="nome">Nome do médico</param>
        /// <param name="dataN">Data de Nascimento do médico</param>
        /// <param name="nif">NIF do médico</param>
        /// <param name="morada">Morada do médico</param>
        /// <param name="crm">CRM do médico</param>
        /// <param name="especialidade">Especialidade do médico</param>
        /// <returns>
        ///  null: Sem permissão
        ///  MedicoException: Exceção    
        ///  RegrasMedicosException: Exceção    
        ///  RegrasMedicosException: -21    
        ///  
        ///  Medico medico: Objeto Criado
        /// </returns>
        public static Medico TentaCriarMedico(PERMISSOES perm, string nome, DateTime dataN, int nif, Morada morada, int crm, ESPECIALIDADE especialidade)
        {
            switch (perm) 
            {
                case PERMISSOES.None:
                    throw new RegrasMedicosException(-21);
                case PERMISSOES.Low:
                case PERMISSOES.High:
                    try
                    {
                        int res = ValidarListaMedicos.VerificarCRMDuplicado(crm);
                        if (res != 1)
                        
                            throw new ListaMedicosException(res);

                            Medico medico = Medico.CriaMedico(nome, dataN, nif, morada, crm, especialidade);
                            return medico;
                        
                    }
                    catch (MedicoException me)
                    {
                        throw me;
                    }
                    catch (RegrasMedicosException rme)
                    {
                        throw rme;
                    }
                    
                default:
                    throw new RegrasMedicosException(-21);
            }
        }

        /// <summary>
        /// Tenta adicionar um médico aos dados
        /// </summary>
        /// <param name="perm">Permissão do utilizador.</param>
        /// <param name="medico">Objeto médico a ser adicionado <see cref="Medico"/></param>
        /// <returns>
        /// -21: Sem permissão
        /// ListaMedicosException: Exceção
        /// RegrasMedicosException: -21  
        ///  1: Valido
        /// </returns>
        public static int TentarAdicionarMedico(PERMISSOES perm, Medico medico)
        {
            switch (perm)
            {
                case PERMISSOES.None:
                    return -21;
                case PERMISSOES.Low:
                case PERMISSOES.High:
                    try 
                    {
                        int res = Medicos.AdicionarMedico(medico);   
                        if (res != 1)
                            return res; 
                    }
                    catch (ListaMedicosException lme)
                    {
                        throw lme;
                    }
                    return 1;
                default:
                    return -21;
            }
        }
        /// <summary>
        /// Tenta adicionar um médico aos dados
        /// </summary>
        /// <param name="perm">Permissao do utilizador.</param>
        /// <param name="crm">CRM medico a ser removido</param>
        /// <returns>
        /// -21: Sem permissão
        /// ListaMedicosException: Exceção
        ///  1: Valido
        /// </returns>
        public static int TentaRemoverMedico(PERMISSOES perm, int crm)
        {
            switch (perm)
            {
                case PERMISSOES.None:
                case PERMISSOES.Low:
                    return -21;
                
                case PERMISSOES.High:
                    try
                    {
                       int res = Medicos.RemoverMedico(crm);
                        if (res != 1)
                            return res;
                    }
                    catch (ListaMedicosException lme)
                    {
                        throw lme;
                    }
                    break;
                default:
                    return -21;
            }
            return 1;
        }

        /// <summary>
        /// Tenta editar um objeto do tipo Medico
        /// </summary>
        /// <param name="perm">Permissao do utilizador.</param>
        /// <param name="medico">Objeto Medico <see cref="Medico"/> a ser editado</param>
        /// <param name="nome">Nome do médico</param>
        /// <param name="dataN">Data de Nascimento do médico</param>
        /// <param name="nif">NIF do médico</param>
        /// <param name="morada">Morada do médico</param>
        /// <param name="especialidade">Especialidade do médico</param>
        /// <returns>
        ///  Consultar código de erros
        ///  ListaMedicosException: Exceção    
        ///  RegrasMedicosException: -21    
        ///  -21
        ///  Medico medico: Objeto Editado
        /// </returns>
        public static Medico TentarEditarMedico(PERMISSOES perm, Medico medico, string nome, DateTime dataN, int nif, Morada morada, ESPECIALIDADE especialidade)
        {
            int res = ValidarMedico.ValidarObjetoMedico(medico);
            if (res != 1)
                throw new MedicoException(res);
            switch (perm)
            {
                case PERMISSOES.None:
                case PERMISSOES.Low:
                    throw new RegrasMedicosException(-21);
                case PERMISSOES.High:
                    try
                    {
                        medico.EditaMedico(nome, dataN, nif, morada, especialidade);
                        return medico;
                    }
                    catch (ListaMedicosException lme)
                    {
                        throw lme;
                    }
                default:
                    throw new RegrasMedicosException(-21);
            }            
        }
        /// <summary>
        /// Tenta atualizar um objeto do tipo Medico na lista
        /// </summary>
        /// <param name="perm">Permissao do utilizador.</param>
        /// <param name="medico">Objeto Medico <see cref="Medico"/> a ser editado</param>
        /// <returns>
        ///  Consultar códigos de erros
        ///  -21
        ///  ListaMedicosException: Exceção    
        ///  1: Sucesso
        /// </returns>
        public static int TentarAtualizarMedico(PERMISSOES perm, Medico medico)
        {
            int res = ValidarMedico.ValidarObjetoMedico(medico);
            if (res != 1)
                return res;
            switch (perm)
            {
                case PERMISSOES.None:
                    return -21;
                case PERMISSOES.Low:
                case PERMISSOES.High:
                    try
                    {
                        Medicos.AtualizarMedico(medico);
                    }
                    catch (ListaMedicosException lme)
                    {
                        throw lme;
                    }
                    break;
                default:
                    return -21;
            }
            return 1;
        }

        /// <summary>
        /// Filtra uma lista de Médicos consoante a especialidade 
        /// </summary>
        /// <param name="especialidade">Especialidade a ser filtrada</param>
        /// <param name="permissoes">Permissao do utilizador.</param>
        /// <returns>
        ///  RegrasMedicosException: Exceção -21 
        ///  List<MiniMedico>: Lista com conteudo reduzido
        ///  List<Medico>: Lista com conteudo total
        ///  
        /// </returns>
        public static List<object> PesquisaMedicos(ESPECIALIDADE especialidade, PERMISSOES permissoes)
        {
            switch (permissoes)
            {
                case PERMISSOES.None:
                    throw new RegrasMedicosException(-21);
                    
                case PERMISSOES.Low:
                    return Medicos.ObterMiniMedicoFiltro(especialidade).Cast<object>().ToList();

                case PERMISSOES.High:
                    return Medicos.ObterMedicoFiltro(especialidade).Cast<object>().ToList();

                default:
                    throw new RegrasMedicosException(-21);
            }
        }
        #endregion
        #endregion
    }
}
