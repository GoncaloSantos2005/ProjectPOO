/*
*	<copyright file="MinhasCamadas.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/2/2024 11:24:28 AM</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;

namespace MinhasCamadas
{
    /// <summary>
    /// Purpose: Exceção personalizada para erros relacionados com lista de médicos.
    /// Created by: gonca
    /// Created on: 12/2/2024 11:24:28 AM
    /// </summary>
    /// <remarks>Esta classe é usada para lançar exceções específicas quando ocorre um erro relacionado com a criação ou manipulação de objetos do tipo Médicos.</remarks>
    public class ListaMedicosException : Exception
    {
        /// <summary>
        /// Código de erro associado à exceção.
        /// </summary>
        private int errorCode;

        /// <summary>
        /// Dicionário que contém mensagens de erro associadas a códigos específicos.
        /// </summary>
        private static readonly Dictionary<int, string> LMedicosErrorMessage = new Dictionary<int, string>()
        {
            { -11, "Lista nula" },
            { -12, "Lista vazia" },
            { -13, "CRM duplicado" },
            { -14, "CRM não existente" },
        };

        /// <summary>
        /// Construtor que inicializa a exceção com um código de erro.
        /// </summary>
        /// <param name="error">Código de erro associado.</param>
        public ListaMedicosException(int error) : base(LMedicosErrorMessage.ContainsKey(error) ? LMedicosErrorMessage[error] : "Erro desconhecido")
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
