/*
*	<copyright file="Project_MVC.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/2/2024 12:21:52 PM</date>
*	<description></description>
**/
using System;

namespace Project_MVC
{
    /// <summary>
    /// Purpose: Exceção personalizada para erros relacionados com regras de médicos.
    /// Created by: gonca
    /// Created on: 12/2/2024 12:21:52 PM
    /// </summary>
    /// <remarks>Esta classe é usada para lançar exceções específicas quando ocorre um erro relacionado com as Regras de consulta, escrita, edição, remoção entre Medicos e Medico.</remarks>
    /// <example>Exemplo de utilização:
    /// <code>
    /// try
    /// {
    ///     throw new RegrasMedicosException("Não tem permissões para consulta.");
    /// }
    /// catch (RegrasMedicosException ex)
    /// {
    ///     Console.WriteLine($"Erro: {ex.Message}");
    /// }
    /// </code></example>
    public class RegrasMedicosException : Exception
    {
        /// <summary>
        /// Constrói uma nova instância da exceção <see cref="RegrasMedicosException"/>.
        /// </summary>
        /// <param name="message">A mensagem de erro que descreve o motivo do erro.</param>
        public RegrasMedicosException(string message) : base(message) { }

        /// <summary>
        /// Constrói uma nova instância da exceção <see cref="RegrasMedicosException"/>.
        /// </summary>
        /// <param name="message">A mensagem de erro que descreve o motivo do erro.</param>
        /// <param name="code">O código originário do erro.</param>
        /// <returns>
        /// -1: Nome Inválido
        /// -2: Idade Incorreta
        /// -3: NIF Inválido
        /// -4: Morada Inválida
        /// -5: CRM Inválido
        /// -6: Especialidade Inválida
        /// -7: Objeto Medico nulo
        /// 
        /// -11: Lista nula
        /// -12: Lista vazia
        /// -13: CRM Duplicado
        /// -14: Médico não encontrado
        /// 
        /// -21: Sem Permissão 
        /// -22:
        /// 
        /// 
        /// -31: Ficheiro não encontrado
        ///  1: Valido
        /// </returns>
        public RegrasMedicosException(string message, int code) : base(message)
        {
            Console.WriteLine("Código do Erro:" + code + " Message:" + message);
        }
    }
}
