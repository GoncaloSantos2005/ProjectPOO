/*
*	<copyright file="ObjetosNegocio.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/4/2024 10:55:25 AM</date>
*	<description></description>
**/
using System;
using ProjectException;

namespace ObjetosNegocio
{
    /// <summary>
    /// Purpose:
    /// Created by: gonca
    /// Created on: 12/4/2024 10:55:25 AM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public static class ValidarMedico
    {
        #region Attributes
        #endregion

        #region Methods

        #endregion

        #region Properties
        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
        /// <summary>
        /// Verifica os campos de um objeto médico
        /// </summary>
        /// <param name="nome">Nome do Médico</param>
        /// <returns>
        /// -1: Nome Incorreto
        /// -2: Idade Incorreta
        /// -3: NIF Inválido
        /// -4: Morada Inválida
        /// -5: CRM Inválido
        /// -6: Especialidade Inválida
        /// 
        ///  1: Valido
        /// </returns>
        public static int ValidarCamposMedico(string nome, DateTime dataN, int nif, Morada morada, ESPECIALIDADE especialidade)
        {

            int res = ValidarNome(nome);
            if (res != 1)
                return res;
            
            res = ValidarData(dataN);
            if (res != 1)
                return res;
            
            res = ValidarNIF(nif);
            if (res != 1)
                return res;
            
            res = ValidarMorada(morada);
            if (res != 1)
                return res;
            
            res = ValidarEspecialidade(especialidade);
            if (res != 1)
                return res;

            return 1;     
        }

        /// <summary>
        /// Valida o nome do Médico
        /// </summary>
        /// <param name="nome">Nome do Médico.</param>
        /// <returns>
        /// -1: Nome Incorreto
        /// <returns>
        public static int ValidarNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return -1;
            return 1;
        }

        /// <summary>
        /// Valida a data de nascimento do Médico
        /// </summary>
        /// <param name="dataN">Data de Nascimento do Médico.</param>
        /// <returns>
        /// -2: Idade Incorreta
        /// <returns>
        public static int ValidarData(DateTime dataN)
        {
            if (dataN > DateTime.Now.AddYears(-18))
                return -2;
            return 1;
        }

        /// <summary>
        /// Valida o nif do Médico
        /// </summary>
        /// <param name="nif">NIF do Médico</param>
        /// <returns>
        /// -3: NIF Inválido
        /// <returns>
        public static int ValidarNIF(int nif)
        {
            if (nif <= 0 || nif.ToString().Length != 9)
                return -3;
            return 1;
        }

        /// <summary>
        /// Valida a Morada do Médico
        /// </summary>
        /// <param name="morada">Morada do Médico.</param>
        /// <returns>
        /// -4: Morada Inválida
        /// <returns>
        public static int ValidarMorada(Morada morada)
        {
            if (morada == null)
                return -4;
            return 1;
        }

        /// <summary>
        /// Valida o CRM do Médico
        /// </summary>
        /// <param name="crm">CRM do Médico.</param>
        /// <returns>
        /// -5: CRM Inválido
        /// <returns>
        public static int ValidarCRM(int crm)
        {
            if (crm <= 0)
                return -5;
            return 1;
        }

        /// <summary>
        /// Valida a especialidade do Médico
        /// </summary>
        /// <param name="especialidade">Especialidade do Médico.</param>
        /// <returns>
        /// -6: Especialidade Inválida
        /// <returns>
        public static int ValidarEspecialidade(ESPECIALIDADE especialidade)
        {
            if (!Enum.IsDefined(typeof(ESPECIALIDADE), especialidade))
            {
                return -6;
            }
            return 1;
        }

        /// <summary>
        /// Verifica o objeto Medico
        /// </summary>
        /// <param name="medico">Objeto Medico para validação.</param>
        /// <returns>
        /// -7: Objeto Medico nulo
        ///  1: Valido
        /// </returns>
        public static int ValidarObjetoMedico(Medico medico)
        {
            if (medico == null) return -7;
            return 1;
        }

        #endregion
    }
}
