/*
*	<copyright file="MinhasCamadas.Validacoes.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/17/2024 7:40:56 PM</date>
*	<description></description>
**/
using MinhasCamadas.Dados;
using MinhasCamadas.Objetos.Consulta;
using System;
using System.Collections.Generic;

namespace MinhasCamadas.Validacoes
{
    /// <summary>
    /// Purpose:
    /// Created by: gonca
    /// Created on: 12/17/2024 7:40:56 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class ValidarListaConsulta
    {
        #region Attributes
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public ValidarListaConsulta()
        {
        }

        #endregion

        #region Properties
        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
        /// <summary>
        /// Verifica se a lista tem alguma informação
        /// </summary>
        /// <returns>
        /// -111: Lista nula
        /// -112: Lista vazia
        ///  1: Valido
        /// </returns>
        public static int ValidarLista(List<Consulta> consultas)
        {
            if (consultas == null) return -111;
            if (consultas.Count == 0)
                return -112;
            return 1; // Lista válida
        }

        /// <summary>
        /// Verifica se já existe alguma consulta com os mesmos parâmetros
        /// </summary>
        /// <param name="miniConsulta">Consulta minimizada</param>
        /// <returns>
        ///  <para>Erro: Consultar dicionário de erros</para>
        ///  <para>Não existe: 1</para>
        ///  Existe: 0
        /// </returns>
        public static int VerificarExisteConsulta(MiniConsulta miniConsulta)
        {
            int res = ValidarConsulta.ValidarObjetoMiniConsulta(miniConsulta);
            if (res != 1)
                return res;
            res = TodasConsultas.FindConsultaParam(miniConsulta);
            if (res == 1)
                return 0;
            return 1;
            
        }

        /// <summary>
        /// Compara se a data fornecida está dentro do intervalo de datas da MiniConsulta.
        /// </summary>
        /// <param name="dataAComparar">Data a ser comparada.</param>
        /// <param name="mini">Objeto <see cref="MiniConsulta"/> com o intervalo (DataInicio e DataFim).</param>
        /// <returns>
        /// <para><b>DataNoIntervalo:</b> -113, a data está dentro do intervalo.</para>
        /// - <b>1:</b> se a data estiver fora do intervalo.
        /// </returns>
        public static int ComparaIntervalosData(DateTime dataAComparar, MiniConsulta mini)
        {
            int res = ValidarConsulta.ValidarObjetoMiniConsulta(mini);
            if (res != 1)
                return res;

            if (dataAComparar >= mini.DataInicio && dataAComparar <= mini.DataFim)
            {
                return -113;
            }
            return 1;
        }

        /// <summary>
        /// 1ª Verificação para ver se é possível criar uma nova consulta com base no objeto fornecido.
        /// </summary>
        /// <param name="mini">Objeto do tipo <see cref="MiniConsulta"/> a ser verificado.</param>
        /// <returns>
        /// <para><b>-114:</b> A consulta está duplicada.</para>
        /// <para><b>1:</b> A consulta pode ser criada com sucesso.</para>
        /// </returns>
        public static int PodeCriarConsulta(MiniConsulta mini)
        {
            int res = TodasConsultas.FindConsultaParam(mini);
            if (res == 1) // consulta duplicada
                return -114;
            return 1;
        }

        /// <summary>
        /// 2ª Verificação para ver se o paciente tem disponibilidade com base no intervalo de datas da MiniConsulta.
        /// </summary>
        /// <param name="mini">Objeto do tipo <see cref="MiniConsulta"/> com as informações da consulta.</param>
        /// <returns>
        /// <para><b>1:</b> O paciente tem disponibilidade (sem sobreposições).</para>
        /// <para><b>-113,-115,-116:</b> A data de início ou fim da consulta está dentro do intervalo de outra consulta.</para>
        /// </returns>
        public static int EncontraDisponbibilidadePaciente(MiniConsulta mini)
        {
            int res;
            List<int> consultas = TodasConsultas.EncontraTodasConsultasPaciente(mini.NIF);
            if (consultas.Count == 0)
                return 1; // tem disp
            foreach (int idConsulta in consultas)
            {
                //Dinicio
                res = ValidarListaConsulta.ComparaIntervalosData(mini.DataInicio, TodasConsultas.ObterConsulta(idConsulta));
                if (res == -113)
                    return -115; //para informar que o problema está na DataIncio
                if (res != 1)
                    return res;
                //Dfim
                res = ValidarListaConsulta.ComparaIntervalosData(mini.DataFim, TodasConsultas.ObterConsulta(idConsulta));
                if (res == -113)
                    return -116; //para informar que o problema está na DataFim
                if (res != 1)
                    return res;
            }
            return 1; //não existe sobreposições
        }

        /// <summary>
        /// 3ª Verificação para ver se o medico tem disponibilidade com base no intervalo de datas da MiniConsulta.
        /// </summary>
        /// <param name="mini">Objeto do tipo <see cref="MiniConsulta"/> com as informações da consulta.</param>
        /// <returns>
        /// <para><b>1:</b> O medico tem disponibilidade (sem sobreposições).</para>
        /// <para><b>-113,-115,-116:</b> A data de início ou fim da consulta está dentro do intervalo de outra consulta.</para>
        /// </returns>
        public static int EncontraDisponbibilidadeMedico(MiniConsulta mini)
        {
            int res;
            List<int> consultas = TodasConsultas.EncontraTodasConsultasMedico(mini.CRM);
            if (consultas.Count == 0)
                return 1; // tem disp
            foreach (int idConsulta in consultas)
            {
                //Dinicio
                res = ValidarListaConsulta.ComparaIntervalosData(mini.DataInicio, TodasConsultas.ObterConsulta(idConsulta));
                if (res == -113)
                    return -115; //para informar que o problema está na DataIncio
                if (res != 1)
                    return res;
                //Dfim
                res = ValidarListaConsulta.ComparaIntervalosData(mini.DataFim, TodasConsultas.ObterConsulta(idConsulta));
                if (res == -113)
                    return -116; //para informar que o problema está na DataFim
                if (res != 1)
                    return res;
            }
            return 1; //não existe sobreposições
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~ValidarListaConsulta()
        {
        }
        #endregion

        #endregion
    }
}
