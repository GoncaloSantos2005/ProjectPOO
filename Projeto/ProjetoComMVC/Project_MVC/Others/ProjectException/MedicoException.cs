/*
*	<copyright file="Project_MVC.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/2/2024 10:16:12 AM</date>
*	<description></description>
**/
using System;

namespace Project_MVC
{
    /// <summary>
    /// Purpose: Exceção personalizada para erros relacionados com médicos.
    /// Created by: gonca
    /// Created on: 12/2/2024 10:16:12 AM
    /// </summary>
    /// <remarks>Esta classe é usada para lançar exceções específicas quando ocorre um erro relacionado com a criação ou manipulação de objetos do tipo Médico.</remarks>
    /// <example>Exemplo de utilização:
    /// <code>
    /// try
    /// {
    ///     throw new MedicoException("O CRM do médico é inválido.");
    /// }
    /// catch (MedicoException ex)
    /// {
    ///     Console.WriteLine($"Erro: {ex.Message}");
    /// }
    /// </code></example>
    public class MedicoException : Exception
    {
        /// <summary>
        /// Constrói uma nova instância da exceção <see cref="MedicoException"/>.
        /// </summary>
        /// <param name="message">A mensagem de erro que descreve o motivo do erro.</param>
        public MedicoException(string message) : base(message) { }

        /// <summary>
        /// Constrói uma nova instância da exceção <see cref="MedicoException"/>.
        /// </summary>
        /// <param name="message">A mensagem de erro que descreve o motivo do erro.</param>
        /// <param name="code">O código originário do erro.</param>
        /// <returns>
        /// -1: Nome Incorreto
        /// -2: Idade Incorreta
        /// -3: NIF Inválido
        /// -4: Morada Inválida
        /// -5: CRM Inválido
        /// -6: Especialidade Inválida
        ///  1: Valido
        /// </returns>
        public MedicoException(string message, int code) : base(message)
        {
            Console.WriteLine("Código do Erro:" + code + " Message:" + message);
        }
    }
}
