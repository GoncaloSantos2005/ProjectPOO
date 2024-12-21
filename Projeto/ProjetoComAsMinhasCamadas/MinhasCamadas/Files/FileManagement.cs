/*
*	<copyright file="MinhasCamadas.Files.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/19/2024 12:03:15 PM</date>
*	<description></description>
**/
using MinhasCamadas.Dados;
using MinhasCamadas.Objetos.Consulta;
using MinhasCamadas.ProjectException;
using MinhasCamadas.ProjectException.Consulta;
using MinhasCamadas.ProjectException.Medico;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MinhasCamadas.Files
{
    /// <summary>
    /// Purpose:
    /// Created by: gonca
    /// Created on: 12/19/2024 12:03:15 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    [Serializable]
    public class FileManagement
    {
        #region Attributes
        Medicos _medicos;
        TodasConsultas _todasConsultas;

        [NonSerialized]
        static readonly string _LogFilePath = "logs.txt";
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public FileManagement()
        {
            _medicos = new Medicos();
            _todasConsultas = new TodasConsultas(); 
        }

        #endregion

        #region Properties
        #endregion



        #region Overrides
        #endregion

        #region OtherMethods
        #region FileOperations
        /// <summary>
        /// Guarda todas as listas (médicos, consultas, etc.) num único ficheiro.
        /// </summary>
        /// <param name="fileName">O nome do ficheiro onde os dados serão guardados.</param>
        /// <returns>
        /// <para><b>1:</b> Sucesso.  </para>
        /// <b>-151:</b> Ficheiro não encontrado.
        /// </returns>
        public static int GuardarTudoFicheiro(string fileName)
        {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    BinaryFormatter bin = new BinaryFormatter();
                    FileManagement dados = new FileManagement();
                    bin.Serialize(stream, dados);
                    return 1;
                }
                catch (IOException e)
                {
                    throw e;
                }
        }

        /// <summary>
        /// Lê todas as listas (médicos, consultas, etc.) de um único ficheiro.
        /// </summary>
        /// <param name="fileName">O nome do ficheiro de onde os dados serão lidos.</param>
        /// <returns>
        /// <para><b>1:</b> Sucesso.  </para>
        /// <b>-1511:</b> Ficheiro não encontrado.
        /// </returns>
        public static int LerTudoFicheiro(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    FileManagement dados = new FileManagement();
                    dados = (FileManagement)bin.Deserialize(stream); 
                    stream.Close();
                    return 1;
                }
                catch (IOException e)
                {
                    throw e;
                }
            }
            return -151; 
        }
        #endregion

        /// <summary>
        /// Grava uma exceção no ficheiro de log com informações detalhadas.
        /// </summary>
        /// <param name="ex">Exceção a ser registada.</param>
        /// <returns>
        /// <b>1:</b> Log registado com sucesso.  
        /// <b>-1:</b> Falha ao registar o log.
        /// </returns>
        public static int Log(Exception ex)
        {
            try
            {
                // Verifica se a exceção contém um código de erro
                int errorCode = 0;
                if (ex is ConsultaException consultaEx)
                    errorCode = consultaEx.ErrorCode;
                else if (ex is ListaConsultaException listaCEx)
                    errorCode = listaCEx.ErrorCode;
                else if (ex is MedicoException medicoEx)
                    errorCode = medicoEx.ErrorCode;
                else if (ex is ListaMedicosException listaMedicosEx)
                    errorCode = listaMedicosEx.ErrorCode;
                else if (ex is RegrasMedicosException RmedicoEx)
                    errorCode = RmedicoEx.ErrorCode;
                else if (ex is RegrasConsultaException RconsultaEx)
                    errorCode = RconsultaEx.ErrorCode;

                using (StreamWriter writer = new StreamWriter(_LogFilePath, true)) //vai adicionar ao texto ja existente
                {
                    writer.WriteLine($"[{DateTime.Now}] [Tipo: {ex.GetType().Name}] [Código: {errorCode}] [Mensagem: {ex.Message}]");
                }
                return 1;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Regista uma exceção no ficheiro de log e notifica o utilizador.
        /// </summary>
        /// <param name="ex">Exceção a ser registada.</param>
        /// <returns>
        /// <b>1:</b> Log registado com sucesso.  
        /// <b>-1:</b> Falha ao registar o log.
        /// </returns>
        /// <exception cref="Exception">
        /// A exceção original será novamente lançada após o registo.
        /// </exception>
        public static int CriarLog(Exception ex)
        {
            int res123 = Log(ex);
            if (res123 == 1)
            {
                return res123;
            }
            else
            {
                return res123;
            }
            throw ex;
        }

        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~FileManagement()
        {
        }
        #endregion

        #endregion
    }
}
