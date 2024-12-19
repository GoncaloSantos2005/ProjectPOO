/*
*	<copyright file="MinhasCamadas.ProjectException.Consulta.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/18/2024 7:40:00 PM</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;

namespace MinhasCamadas.ProjectException.Consulta
{
    /// <summary>
    /// Purpose:
    /// Created by: gonca
    /// Created on: 12/18/2024 7:40:00 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class RegrasConsultaException : Exception
    {
        /// <summary>
        /// Código de erro associado à exceção.
        /// </summary>
        private int errorCode;

        /// <summary>
        /// Dicionário que contém mensagens de erro associadas a códigos específicos.
        /// </summary>
        private static readonly Dictionary<int, string> RConsultasErrorMessage = new Dictionary<int, string>()
        {
            {-141, "Sem Permissão"},
        };

        /// <summary>
        /// Construtor que inicializa a exceção com um código de erro.
        /// </summary>
        /// <param name="error">Código de erro associado.</param>
        public RegrasConsultaException(int error) : base(RConsultasErrorMessage.ContainsKey(error) ? RConsultasErrorMessage[error] : "Erro desconhecido")
        {
            ErrorCode = error;
            Console.WriteLine("\nErro: " + ErrorCode + " -> " + Message);
        }

        /// <summary>
        /// Propriedade para obter ou definir o código de erro associado à exceção.
        /// </summary>
        public int ErrorCode
        {
            get { return errorCode; }
            set { errorCode = value; }
        }
    }
}

