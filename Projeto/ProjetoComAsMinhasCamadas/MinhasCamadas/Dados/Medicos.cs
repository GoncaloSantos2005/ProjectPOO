﻿/*
*	<copyright file="MinhasCamadas.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/2/2024 11:13:59 AM</date>
*	<description></description>
**/
using MinhasCamadas.Objetos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MinhasCamadas
{
    /// <summary>
    /// Purpose: Guarda numa List um conjunto de Medico
    /// Created by: gonca
    /// Created on: 12/2/2024 11:13:59 AM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    [Serializable]
    public class Medicos
    {
        #region Attributes
        static List<Medico> _medicos = new List<Medico>();
        [NonSerialized]
        static int _contador=0;
        #endregion

        #region Methods

        #region Properties
        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
        /// <summary>
        /// Retorna todos os médicos da lista.
        /// </summary>
        /// <returns>Lista de objetos <see cref="Medico"/>.</returns>
        /// <example>ESTE METODO É SÓ UTILIZADO PARA TESTAR A LISTA</example>
        public static List<Medico> ObterTodos()
        {
            return _medicos;
        }

        /// <summary>
        /// Verifica se existe algum CRM na lista
        /// </summary>
        /// <param name="crm"></param>
        /// <returns>true: Existe
        /// false: Não existe</returns>
        public static bool ExisteCRM(int crm)
        {
            foreach(Medico medico in _medicos)
            {
                if (medico.CRM.Equals(crm))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Adiciona um Médico à lista dos Medicos
        /// </summary>
        /// <param name="medico">Objeto a adicionar do tipo <see cref="Medico"/>.</param>
        /// <returns>
        /// Ver lista de erros possível
        /// 1: sucesso
        /// </returns>
        public static int AdicionarMedico(Medico medico)
        {
            int resultado = ValidarMedico.ValidarObjetoMedico(medico);
            if (resultado != 1)
                return resultado;
            
            resultado = ValidarListaMedicos.VerificarCRMDuplicado(medico.CRM);
            if (resultado != 1)
                return resultado;

            _medicos.Add(medico);
            _contador++;
            //GuardarMedicosFicheiro()
            return resultado;
        }

        /// <summary>
        /// Remove um Médico da lista através do CRM
        /// </summary>
        /// <param name="crm">Identificador do objeto Medico.</param>
        /// <returns>
        /// Ver lista de erros possível
        /// ListaMedicosException: Exceção 
        /// 1: sucesso
        /// </returns>
        public static int RemoverMedico(int crm)
        {
            try
            {
                _medicos.Remove(FindMedico(crm));
                _contador--;
            }
            catch (ListaMedicosException ex) 
            {
                throw ex;
            }
            return 1;
        }

        /// <summary>
        /// Atualiza um Médico da lista
        /// </summary>
        /// <param name="medicoAtualizado">Objeto a atualizar do tipo <see cref="Medico"/>.</param>
        /// <returns>
        /// Ver lista de erros possível
        /// ListaMedicosException: Exceção 
        /// 1: sucesso
        /// </returns>
        public static int AtualizarMedico(Medico medicoAtualizado)
        {
            try
            {
                Medico medico = FindMedico(medicoAtualizado.CRM);
                medico.Nome = medicoAtualizado.Nome;
                medico.DataN = medicoAtualizado.DataN;
                medico.NIF = medicoAtualizado.NIF;
                medico.Morada = medicoAtualizado.Morada;
                medico.Especialidade = medicoAtualizado.Especialidade;
            }
            catch (ListaMedicosException ex)
            {
                throw ex;
            }
            return 1;
        }

        /// <summary>
        /// Encontra um Médico na lista através do CRM
        /// </summary>
        /// <param name="crm">Identificador do Médico</param>
        /// <returns>
        /// Ver lista de erros possível
        ///  ListaMedicosException: Exceção    
        /// medico: Objeto encontrado
        /// </returns>
        private static Medico FindMedico(int crm)
        {
            int res;
            try { 
                res = ValidarMedico.ValidarCRM(crm);
                if (res != 1)
                    throw new ListaMedicosException(res);
                Medico medico = null;

                foreach(Medico m in _medicos)
                {
                    if (m.CRM.Equals(crm))
                    {
                        medico = m;
                        break;
                    }
                }
                res = ValidarMedico.ValidarObjetoMedico(medico);
                if (res == 1)
                    return medico;
                throw new ListaMedicosException(-14);
            }
            catch (ListaMedicosException)
            {
                throw;    
            }
            
        }


        /// <summary>
        /// Encontra uma lista de Médicos com uma certa especialidade
        /// </summary>
        /// <param name="esp">Especialidade a ser filtrada</param>
        /// <returns>
        /// Ver lista de erros possível
        /// lista: Lista do tipo <see cref="Medico"/> com os resultados encontrados.
        /// </returns>
        public static List<Medico> ObterMedicoFiltro(ESPECIALIDADE esp)
        {
            List<Medico> lista = null;
            int contador_ = 0;
            foreach (Medico m in _medicos)
            {
                if (m.Especialidade.Equals(esp))
                {
                    lista.Add(m);
                    contador_ ++;
                }
            }
            if (contador_ == 0)
                throw new ListaMedicosException(-14);

            return lista;
        }

        /// <summary>
        /// Encontra uma lista de Médicos com uma certa especialidade e retorna um conjunto de atributos reduzidos do Médico <see cref="MiniMedico"/>
        /// </summary>
        /// <param name="esp">Especialidade a ser filtrada</param>
        /// <returns>
        /// Ver lista de erros possível
        /// lista: Lista do tipo <see cref="MiniMedico"/> com os resultados encontrados e reduzidos.
        /// </returns>
        public static List<MiniMedico> ObterMiniMedicoFiltro(ESPECIALIDADE esp)
        {
            List<Medico> listaFiltro = ObterMedicoFiltro(esp);

            if(listaFiltro.Count == 0)
            {
                throw new ListaMedicosException(-14);
            }

            List<MiniMedico> lista = new List<MiniMedico>();

            foreach(Medico medico in listaFiltro)
            {                
                lista.Add(new MiniMedico(medico.Nome, medico.CRM));
            }
            return lista;
        }

        /// <summary>
        /// Obtem uma informação reduzida de um Médico
        /// </summary>
        /// <param name="crm">CRM do Médico a ser encontrado</param>
        /// <returns>
        /// Ver lista de erros possível
        /// ListaMedicosException: Exceção
        /// Objeto MiniMedico: Objeto com a informação reduzida do Médico <see cref="MiniMedico"/>
        /// </returns>
        public static MiniMedico ObterMedico(int crm)
        {
            try {
                Medico medico = FindMedico(crm);
                MiniMedico mini = new MiniMedico(medico.Nome, medico.CRM);
                int res = ValidarMedico.ValidarMiniObjeto(mini);
                if (res != 1)
                    throw new MedicoException(res);
                return mini;
            } catch (ListaMedicosException) 
            { 
                throw;
            } 
        }

        /// <summary>
        /// Organiza a Lista de Medicos Alfabeticamente
        /// </summary>
        /// <returns>
        /// Ver lista de erros possível
        /// MedicoException: Exceção
        /// 1: Sucesso
        /// </returns>
        public static int OrganizarMedicosAlfabeticamente()
        {   
            int resultado = ValidarListaMedicos.ValidarLista(_medicos);

            if (resultado != 1)
                return resultado;
            try {
            _medicos.Sort(); //usa o metodo implementado em Medico para organizar alfabeticamente
            }catch(MedicoException me)
            {
                throw me;
            }
            return 1;
        }

        /// <summary>
        /// Retorna o número total de médicos na lista.
        /// </summary>
        public static int Contador
        {
            get { return _contador; }
        }
        #endregion

        #region Files
        /// <summary>
        /// Guarda a lista de médicos num ficheiro.
        /// </summary>
        /// <param name="fileName">O nome do ficheiro onde os dados serão guardados.</param>
        /// <returns>1 em caso de sucesso, 0 caso contrário.</returns>
        public static int GuardarMedicosFicheiro(string fileName)
        {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, _medicos);
                    stream.Close();
                    return 1;
                }
                catch (IOException e)
                {
                    throw e;
                }
        }

        /// <summary>
        /// Lê a lista de médicos de um ficheiro.
        /// </summary>
        /// <param name="fileName">O nome do ficheiro de onde os dados serão lidos.</param>
        /// <returns>
        ///   1: Sucesso,
        /// -151: Ficheiro não encontrado.
        /// </returns>
        public static int LerMedicosFicheiro(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    _medicos = (List<Medico>)bin.Deserialize(stream);
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
