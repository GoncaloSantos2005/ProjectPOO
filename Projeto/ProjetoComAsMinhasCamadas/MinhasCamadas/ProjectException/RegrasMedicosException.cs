﻿/*
*	<copyright file="MinhasCamadas.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/2/2024 12:21:52 PM</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;

namespace MinhasCamadas
{
    /// <summary>
    /// Purpose: Exceção personalizada para erros relacionados com regras de médicos.
    /// Created by: gonca
    /// Created on: 12/2/2024 12:21:52 PM
    /// </summary>
    /// <remarks>Esta classe é usada para lançar exceções específicas quando ocorre um erro relacionado com as Regras de consulta, escrita, edição, remoção entre Medicos e Medico.</remarks>
    public class RegrasMedicosException : Exception
    {
        /// <summary>
        /// Código de erro associado à exceção.
        /// </summary>
        private int errorCode;

        /// <summary>
        /// Dicionário que contém mensagens de erro associadas a códigos específicos.
        /// </summary>
        private static readonly Dictionary<int, string> RegrasMedicosErrorMessage = new Dictionary<int, string>()
        {
            { -21, "Sem Permissão" },
        };
        /// <summary>
        /// Construtor que inicializa a exceção com um código de erro.
        /// </summary>
        /// <param name="error">Código de erro associado.</param>
        public RegrasMedicosException(int error) : base(RegrasMedicosErrorMessage.ContainsKey(error) ? RegrasMedicosErrorMessage[error] : "Erro desconhecido")
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
