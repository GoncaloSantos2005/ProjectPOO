/*
*	<copyright file="ObjetosNegocio.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/4/2024 11:27:31 AM</date>
*	<description></description>
**/
using System;
using ProjectException;
using ObjetosNegocio;
using TrabalhoPOO_Simples;

namespace DadosNegocio
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
        ///  1: Valido
        /// </returns>
        public static int ValidarLista()
        {
            if (Medicos.ObterTodos() == null) return -11;
            if (Medicos.Contador == 0)
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
            foreach(Medico m in Medicos.ObterTodos())
            {
                if (m.CRM.Equals(crm))
                    return -13;
            }
            return 1;
        }

        #endregion

        #endregion
    }
}
