/*
*	<copyright file="MinhasCamadas.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/4/2024 11:27:31 AM</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;

namespace MinhasCamadas
{
    /// <summary>
    /// Purpose:
    /// Created by: gonca
    /// Created on: 12/4/2024 11:27:31 AM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public static class ValidarListaMedicos
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
        /// Verifica se a lista tem alguma informação
        /// </summary>
        /// <returns>
        /// -11: Lista nula
        /// -12: Lista vazia
        /// -13: CRM Duplicado
        /// -14: CRM não existente      
        ///  1: Valido
        /// </returns>
        public static int ValidarLista(List<Medico> medicos_)
        {            
            if (medicos_ == null) return -11;
            if (medicos_.Count == 0)
                return -12;
            return 1; // Lista válida
        }

        /// <summary>
        /// Verifica se existe algum CRM já na lista
        /// </summary>
        /// <param name="crm">campo crm para validação.</param>
        /// <returns>
        /// -13: CRM duplicado
        ///  1: Valido
        /// </returns>
        public static int VerificarCRMDuplicado(int crm)
        {
            if (Medicos.ExisteCRM(crm))
                return -13;
            return 1;
        }

        /// <summary>
        /// Verifica se existe algum CRM já na lista
        /// </summary>
        /// <param name="crm">campo crm para validação.</param>
        /// <returns>
        /// -14: Não existe CRM
        ///  1: Valido
        /// </returns>
        public static int ExisteCRM(int crm)
        {
            if (Medicos.ExisteCRM(crm))
                return 1;
            return -14;
        }

        #endregion

        #endregion
    }
}
