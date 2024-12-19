/*
*	<copyright file="MinhasCamadas.ProjectException.Medico.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/18/2024 3:23:45 PM</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;

namespace MinhasCamadas.ProjectException.Medico
{
    /// <summary>
    /// Purpose:
    /// Created by: gonca
    /// Created on: 12/18/2024 3:23:45 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class ListaConsultaException : Exception
    {
        /// <summary>
        /// Código de erro associado à exceção.
        /// </summary>
        private int errorCode;

        /// <summary>
        /// Dicionário que contém mensagens de erro associadas a códigos específicos.
        /// </summary>
        private static readonly Dictionary<int, string> LConsultasErrorMessage = new Dictionary<int, string>()
        {
            { -111, "Lista nula" },
            { -112, "Lista vazia" },
            { -113, "A data está dentro do intervalo de outra consulta" },
            { -114, "A consulta está duplicada" },
            { -115, "A data do Inicio está dentro do intervalo de outra consulta" },
            { -116, "A data do Fim está dentro do intervalo de outra consulta" },
        };

        /// <summary>
        /// Construtor que inicializa a exceção com um código de erro.
        /// </summary>
        /// <param name="error">Código de erro associado.</param>
        public ListaConsultaException(int error) : base(LConsultasErrorMessage.ContainsKey(error) ? LConsultasErrorMessage[error] : "Erro desconhecido")
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

