/*
*	<copyright file="MinhasCamadas.Dados.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/17/2024 5:34:25 PM</date>
*	<description></description>
**/
using MinhasCamadas.Objetos.Consulta;
using MinhasCamadas.ProjectException;
using MinhasCamadas.ProjectException.Medico;
using MinhasCamadas.Validacoes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MinhasCamadas.Dados
{
    /// <summary>
    /// Purpose:
    /// Created by: gonca
    /// Created on: 12/17/2024 5:34:25 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    [Serializable]
    public class TodasConsultas
    {
        #region Attributes
        static List<Consulta> _consultas = new List<Consulta>();
        [NonSerialized]
        static int _contador = 0;
        #endregion

        #region Methods

        #region Properties
        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
        /// <summary>
        /// Verifica se existe o id da consulta na lista
        /// </summary>
        /// <param name="id">Id da Consulta</param>
        /// <returns>true: Existe
        /// false: Não existe</returns>
        public static bool ExisteConsulta(int id)
        {
            foreach (Consulta consulta in _consultas)
            {
                if (consulta.IdConsulta.Equals(id))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Adiciona uma Consulta à lista das Consultas
        /// </summary>
        /// <param name="consulta">Objeto a adicionar do tipo <see cref="Consulta"/>.</param>
        /// <returns>
        /// <para>Erro: Ver lista de erros possível</para>
        /// <para>Sucesso: 1</para>
        /// </returns>
        /// CONTINUAR A PARTIR DAQUI
        public static int AdicionarConsulta(Consulta consulta)
        {
            int resultado = ValidarConsulta.ValidarObjetoConsulta(consulta);
            if (resultado != 1)
                return resultado;

            _consultas.Add(consulta);
            _contador++;
            return resultado;
        }

        /// <summary>
        /// Remove uma Consulta da lista através do id
        /// </summary>
        /// <param name="id">Identificador da Consulta.</param>
        /// <returns>
        /// <para>Ver lista de erros possível</para>
        /// <para>1: sucesso</para>
        /// </returns>
        /// <exception cref="ListaConsultaException"></exception>
        public static int RemoverConsulta(int id)
        {
            try
            {
                _consultas.Remove(FindConsulta(id));
                _contador--;
            }
            catch (ListaConsultaException ex)
            {
                throw ex;
            }
            return 1;
        }

        /// <summary>
        /// Método que procura uma Consulta através do Id da mesma
        /// </summary>
        /// <param name="id">Id da Consulta a ser procurada</param>
        /// /// <returns>
        /// <para>✅ Sucesso: Retorna um objeto do tipo <see cref="Consulta"/></para>
        /// <para>❌ Erro: Ver lista de erros possível</para>
        /// </returns>
        /// <exception cref="ConsultaException"></exception>
        /// <exception cref="ListaConsultaException"></exception>
        private static Consulta FindConsulta(int id)
        {
            int res;
            try
            {
                res = ValidarConsulta.ValidarIdConsulta(id);
                if (res != 1)
                    throw new ConsultaException(res);

                Consulta consulta = null;
                foreach (Consulta c in _consultas)
                {
                    if (c.IdConsulta.Equals(id))
                    {
                        consulta = c;
                        break;
                    }
                }
                res = ValidarConsulta.ValidarObjetoConsulta(consulta);
                if (res == 1)
                    return consulta;
                throw new ConsultaException(res);
            }
            catch (ListaConsultaException)
            {
                throw;
            }
        }

        /// <summary>
        /// Método que procura uma Consulta pelo id
        /// </summary>
        /// <param name="id">Id da Consulta a ser procurada</param>
        /// <returns>
        /// <para><b>✅ Sucesso:</b> Retorna um objeto do tipo <see cref="MiniConsulta"/> com as informações necessárias</para>
        /// <para><b>❌ Erro:</b> Ver lista de erros</para></returns>
        /// <exception cref="ConsultaException"></exception>
        /// <exception cref="ListaConsultaException"></exception>
        /// 
        public static MiniConsulta ObterConsulta(int id)
        {
            try
            {
                Consulta c = FindConsulta(id);
                MiniConsulta mini = new MiniConsulta(c.IdConsulta, c.CRM, c.NIF, c.DataInicio, c.DataFim);
                int res = ValidarConsulta.ValidarObjetoMiniConsulta(mini);
                if (res != 1)
                    throw new ConsultaException(res);
                return mini;
            }
            catch (ConsultaException)
            {
                throw;
            }
            catch (ListaConsultaException)
            {
                throw;
            }
        }

        /// <summary>
        /// Encontra todas as consultas associadas a um paciente com base no seu NIF.
        /// </summary>
        /// <param name="nif">NIF do paciente.</param>
        /// <returns>Uma lista com os IDs das consultas encontradas.</returns>
        /// <exception cref="ConsultaException">
        /// Lançada quando o NIF fornecido não é válido.
        /// </exception>
        public static List<int> EncontraTodasConsultasPaciente(int nif)
        {
            int res = ValidarConsulta.ValidarNIF(nif);
            if (res != 1)
                throw new ConsultaException(res);
            List<int> consultas = new List<int>();
            foreach (Consulta c in _consultas)
            {
                if (c.NIF.Equals(nif))
                {
                    consultas.Add(c.IdConsulta);
                }
            }
            return consultas;
        }

        /// <summary>
        /// Encontra todas as consultas associadas a um medico com base no seu CRM.
        /// </summary>
        /// <param name="crm">CRM do médico.</param>
        /// <returns>Uma lista com os IDs das consultas encontradas.</returns>
        /// <exception cref="ConsultaException">
        /// Lançada quando o CRM fornecido não é válido.
        /// </exception>
        public static List<int> EncontraTodasConsultasMedico(int crm)
        {
            int res = ValidarConsulta.ValidarCRM(crm);
            if (res != 1)
                throw new ConsultaException(res);
            List<int> consultas = new List<int>();
            foreach (Consulta c in _consultas)
            {
                if (c.CRM.Equals(crm))
                {
                    consultas.Add(c.IdConsulta);
                }
            }
            return consultas;
        }

        /// <summary>
        /// Verifica se existe uma Consulta com vários parâmetros dentro da <see cref="MiniConsulta"/>
        /// </summary>
        /// <param name="mini">Objeto do tipo <see cref="MiniConsulta"/> com a informação </param>
        /// <returns><para>Encontrou: 1</para>
        /// <para>Não encontrou: 0</para></returns>
        public static int FindConsultaParam(MiniConsulta mini)
        {
            int res = 0;
            foreach(Consulta c in _consultas)
            {
                if(c.DataInicio.Equals(mini.DataInicio) && c.DataFim.Equals(mini.DataFim) && c.CRM.Equals(mini.CRM) && c.NIF.Equals(mini.CRM))
                {
                    return 1;
                }
            }
            return res;
        }

        #endregion

        #region Files
        /// <summary>
        /// Guarda a lista de consultas num ficheiro.
        /// </summary>
        /// <param name="fileName">O nome do ficheiro onde os dados serão guardados.</param>
        /// <returns>1 em caso de sucesso</returns>
        public static int GuardarConsultasFicheiro(string fileName)
        {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, _consultas);
                    stream.Close();
                    return 1;
                }
                catch (IOException e)
                {
                    throw e;
                }
        }

        /// <summary>
        /// Lê a lista de consultas de um ficheiro.
        /// </summary>
        /// <param name="fileName">O nome do ficheiro de onde os dados serão lidos.</param>
        /// <returns>
        ///   1: Sucesso,
        /// -151: Ficheiro não encontrado
        /// </returns>
        public static int LerConsultasFicheiro(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    _consultas = (List<Consulta>)bin.Deserialize(stream);
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

        #endregion
    }
}
