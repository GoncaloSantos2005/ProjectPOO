/*
*	<copyright file="MinhasCamadas.Dados.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/17/2024 5:34:25 PM</date>
*	<description></description>
**/
using MinhasCamadas.Objetos.Consulta;
using System;
using System.Collections.Generic;

namespace MinhasCamadas.Dados
{
    /// <summary>
    /// Purpose:
    /// Created by: gonca
    /// Created on: 12/17/2024 5:34:25 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    [Serializable]
    public static class TodasConsultas
    {
        #region Attributes
        static List<Consulta> consultas = new List<Consulta>();
        [NonSerialized]
        static int _contador = 0;
        #endregion

        #region Methods

        #region Properties
        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
        /// <summary>
        /// Verifica se existe o id da consulta na lista
        /// </summary>
        /// <param name="id">Id da Consulta</param>
        /// <returns>true: Existe
        /// false: Não existe</returns>
        public static bool ExisteConsulta(int id)
        {
            foreach (Consulta consulta in consultas)
            {
                if (consulta.IdConsulta.Equals(id))
                    return true;
            }
            return false;
        }
        #endregion

        #endregion
    }
}
