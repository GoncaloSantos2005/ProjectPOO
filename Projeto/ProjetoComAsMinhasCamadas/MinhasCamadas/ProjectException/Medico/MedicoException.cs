/*
*	<copyright file="MinhasCamadas.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/2/2024 10:16:12 AM</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;

namespace MinhasCamadas
{
    /// <summary>
    /// Purpose: Exceção personalizada para erros relacionados com médicos.
    /// Created by: gonca
    /// Created on: 12/2/2024 10:16:12 AM
    /// </summary>
    /// <remarks>Esta classe é usada para lançar exceções específicas quando ocorre um erro relacionado com a criação ou manipulação de objetos do tipo Médico.</remarks>
    public class MedicoException : Exception
    {
        /// <summary>
        /// Código de erro associado à exceção.
        /// </summary>
        private int errorCode;

        /// <summary>
        /// Dicionário que contém mensagens de erro associadas a códigos específicos.
        /// </summary>
        private static readonly Dictionary<int, string> MedicoErrorMessage = new Dictionary<int, string>()
        {
            { -1, "Nome Inválido" },
            { -2, "Idade Incorreta" },
            { -3, "NIF Inválido" },
            { -4, "Morada Inválida" },
            { -5, "CRM não existente" },
            { -6, "Especialidade Inválida" },
            { -7, "Objeto Medico nulo" },
        };
        /// <summary>
        /// Construtor que inicializa a exceção com um código de erro.
        /// </summary>
        /// <param name="error">Código de erro associado.</param>
        public MedicoException(int error) : base(MedicoErrorMessage.ContainsKey(error) ? MedicoErrorMessage[error] : "Erro desconhecido")
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

