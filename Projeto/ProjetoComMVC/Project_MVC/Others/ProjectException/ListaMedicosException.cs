/*
*	<copyright file="Project_MVC.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/2/2024 11:24:28 AM</date>
*	<description></description>
**/
using System;

namespace Project_MVC
{
    /// <summary>
    /// Purpose: Exceção personalizada para erros relacionados com lista de médicos.
    /// Created by: gonca
    /// Created on: 12/2/2024 11:24:28 AM
    /// </summary>
    /// <remarks>Esta classe é usada para lançar exceções específicas quando ocorre um erro relacionado com a criação ou manipulação de objetos do tipo Médicos.</remarks>
    /// <example>Exemplo de utilização:
    /// <code>
    /// try
    /// {
    ///     throw new ListaMedicosException("O objeto referenciado é nulo");
    /// }
    /// catch (ListaMedicosException ex)
    /// {
    ///     Console.WriteLine($"Erro: {ex.Message}");
    /// }
    /// </code></example>
    public class ListaMedicosException : Exception
    {
        /// <summary>
        /// Constrói uma nova instância da exceção <see cref="ListaMedicosException"/>.
        /// </summary>
        /// <param name="message">A mensagem de erro que descreve o motivo do erro.</param>
        public ListaMedicosException(string message) : base(message) { }

        /// <summary>
        /// Constrói uma nova instância da exceção <see cref="ListaMedicosException"/>.
        /// </summary>
        /// <param name="message">A mensagem de erro que descreve o motivo do erro.</param>
        /// <param name="code">O código originário do erro.</param>
        /// /// <return>
        /// -11: CRM Inválido
        /// -12: Lista nula
        /// -13: Lista vazia
        /// -14: Médico não encontrado
        ///  1: Valido
        /// </return>
        public ListaMedicosException(string message, int code) : base(message)
        {
            Console.WriteLine("Código do Erro:" + code + " Message:" + message);
        }
    }
}
