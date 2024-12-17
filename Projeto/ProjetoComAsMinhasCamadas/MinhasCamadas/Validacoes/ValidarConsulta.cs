/*
*	<copyright file="MinhasCamadas.Validacoes.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/17/2024 3:02:28 PM</date>
*	<description></description>
**/
using MinhasCamadas.Objetos.Consulta;
using System;

namespace MinhasCamadas.Validacoes
{
    /// <summary>
    /// Purpose:
    /// Created by: gonca
    /// Created on: 12/17/2024 3:02:28 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class ValidarConsulta
    {
        #region Attributes
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public ValidarConsulta()
        {
        }

        #endregion

        #region Properties
        #endregion



        #region Overrides
        #endregion

        #region OtherMethods
        /// <summary>
        /// Verifica os campos de uma consulta
        /// </summary>
        /// <param name="dataI">Data de Início da Consulta</param>
        /// <param name="dataF">Data de Fim da Consulta</param>
        /// <param name="nif">NIF do Paciente</param>
        /// <param name="crm">CRM do Médico</param>
        /// <param name="numeroS">Número do Staff</param>
        /// <param name="idD">ID do Departamento</param>
        /// <param name="tp">Tipo de Consulta</param>
        /// <param name="es">Estado da Consulta</param>
        /// <returns>
        /// -101: Data de Início Inválida
        /// -102: Data de Fim Inválida
        /// -103: NIF Inválido
        /// -104: CRM Inválido
        /// -105: Número do Staff Inválido
        /// -106: ID de Departamento Inválido
        /// -107: Tipo de Consulta Inválido
        /// -108: Estado de Consulta Inválido
        /// -109: Ojeto Consulta nulo
        /// 
        ///  1: Válido
        /// </returns>
        public static int ValidarCamposConsulta(DateTime dataI, DateTime dataF, int nif, int crm, int numeroS, int? idD, TIPOCONSULTA tp, ESTADO es)
        {
            int res = ValidarDataInicio(dataI);
            if (res != 1)
                return res;

            res = ValidarDataFim(dataI, dataF);
            if (res != 1)
                return res;

            res = ValidarNIF(nif);
            if (res != 1)
                return res;

            res = ValidarCRM(crm);
            if (res != 1)
                return res;

            res = ValidarNumeroStaff(numeroS);
            if (res != 1)
                return res;

            res = ValidarIDDepartamento(idD);
            if (res != 1)
                return res;

            res = ValidarTipoConsulta(tp);
            if (res != 1)
                return res;

            res = ValidarEstado(es);
            if (res != 1)
                return res;

            return 1;
        }

        /// <summary>
        /// Valida a data de início da consulta
        /// </summary>
        /// <param name="dataI">Data de Início da Consulta.</param>
        /// <returns>
        /// -101: Data de Início Inválida
        ///  1: Válido
        /// </returns>
        public static int ValidarDataInicio(DateTime dataI)
        {
            if (dataI < DateTime.Now)
                return -1;
            return 1;
        }

        /// <summary>
        /// Valida a data de fim da consulta
        /// </summary>
        /// <param name="dataI">Data de Início da Consulta.</param>
        /// <param name="dataF">Data de Fim da Consulta.</param>
        /// <returns>
        /// -102: Data de Fim Inválida
        ///  1: Válido
        /// </returns>
        public static int ValidarDataFim(DateTime dataI, DateTime dataF)
        {
            if (dataF <= dataI)
                return -2;
            return 1;
        }

        /// <summary>
        /// Valida o nif do Paciente
        /// </summary>
        /// <param name="nif">NIF do Paciente.</param>
        /// <returns>
        /// -103: NIF inválido
        ///  1: Válido
        /// </returns>
        public static int ValidarNIF(int nif)
        {
            if (nif.ToString().Length<9 || nif <= 0)
                return -3;
            return 1;
        }

        /// <summary>
        /// Valida o crm do Médico
        /// </summary>
        /// <param name="crm">CRM do Médico.</param>
        /// <returns>
        /// -104: CRM inválido
        ///  1: Válido
        /// </returns>
        public static int ValidarCRM(int crm)
        {
            if (crm < 0)
                return -3;
            return 1;
        }

        /// <summary>
        /// Valida o número do staff
        /// </summary>
        /// <param name="numeroS">Número do Staff.</param>
        /// <returns>
        /// -105: Número do Staff Inválido
        ///  1: Válido
        /// </returns>
        public static int ValidarNumeroStaff(int numeroS)
        {
            if (numeroS <= 0)
                return -5;
            return 1;
        }

        /// <summary>
        /// Valida o ID do departamento
        /// </summary>
        /// <param name="idD">ID do Departamento.</param>
        /// <returns>
        /// -106: ID de Departamento Inválido
        ///  1: Válido
        /// </returns>
        public static int ValidarIDDepartamento(int? idD)
        {
            if (idD <= 0)
                return -6;
            return 1;
        }

        /// <summary>
        /// Valida o tipo da consulta
        /// </summary>
        /// <param name="tp">Tipo de Consulta.</param>
        /// <returns>
        /// -107: Tipo de Consulta Inválido
        ///  1: Válido
        /// </returns>
        public static int ValidarTipoConsulta(TIPOCONSULTA tp)
        {
            if (!Enum.IsDefined(typeof(TIPOCONSULTA), tp))
                return -7;
            return 1;
        }

        /// <summary>
        /// Valida o estado da consulta
        /// </summary>
        /// <param name="es">Estado da Consulta.</param>
        /// <returns>
        /// -108: Estado de Consulta Inválido
        ///  1: Válido
        /// </returns>
        public static int ValidarEstado(ESTADO es)
        {
            if (!Enum.IsDefined(typeof(ESTADO), es))
                return -8;
            return 1;
        }

        /// <summary>
        /// Verifica o objeto Consulta
        /// </summary>
        /// <param name="consulta">Objeto Consulta para validação.</param>
        /// <returns>
        /// -109: Objeto Consulta nulo
        ///  1: Valido
        /// </returns>
        public static int ValidarObjetoConsulta(Consulta consulta)
        {
            if (consulta == null) return -7;
            return 1;
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~ValidarConsulta()
        {
        }
        #endregion

        #endregion
    }
}
