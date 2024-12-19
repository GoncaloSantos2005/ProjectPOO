/*
*	<copyright file="MinhasCamadas.ProjectException.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/17/2024 4:41:35 PM</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;

namespace MinhasCamadas.ProjectException
{
    /// <summary>
    /// Purpose:
    /// Created by: gonca
    /// Created on: 12/17/2024 4:41:35 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class ConsultaException : Exception
    {
        /// <summary>
        /// Código de erro associado à exceção.
        /// </summary>
        private int errorCode;

        /// <summary>
        /// Dicionário que contém mensagens de erro associadas a códigos específicos.
        /// </summary>
        private static readonly Dictionary<int, string> ConsultaErrorMessage = new Dictionary<int, string>()
        {
            { -100, "Id da Consulta Inválido" },
            { -101, "Data de Início Inválida" },
            { -102, "Data de Fim Inválida" },
            { -103, "NIF Inválido" },
            { -104, "CRM Inválido" },
            { -105, "Número do Staff Inválido" },
            { -106, "ID de Departamento Inválido" },
            { -107, "Tipo de Consulta Inválido" },
            { -108, "Estado de Consulta Inválido" },
            { -109, "Objeto Consulta nulo" },
            { -110, "Objeto MiniConsulta nulo" }
        };

        /// <summary>
        /// Construtor que inicializa a exceção com um código de erro.
        /// </summary>
        /// <param name="error">Código de erro associado.</param>
        public ConsultaException(int error) : base(ConsultaErrorMessage.ContainsKey(error) ? ConsultaErrorMessage[error] : "Erro desconhecido")
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
