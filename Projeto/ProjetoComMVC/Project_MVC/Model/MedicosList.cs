/*
*	<copyright file="Project_MVC.Model.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/12/2024 6:08:50 PM</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Project_MVC.Model
{
    /// <summary>
    /// Purpose:
    /// Created by: gonca
    /// Created on: 12/12/2024 6:08:50 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>

    [Serializable]
    public class MedicosList : IMedicosListModel
    {
        private List<Medico> listMedicos;
        [NonSerialized]
        private int _contador = 0;

        #region Attributes
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public MedicosList()
        {
            listMedicos = new List<Medico>();
        }

        #endregion

        #region Properties
        public int Contador
        {
            get { return _contador; }
        }

        public List<Medico> ListMedicos
        {
            get { return listMedicos; }
            set { listMedicos = value; }
        }
        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
        /// <summary>
        /// Adiciona um Médico à lista dos Medicos
        /// </summary>
        /// <param name="medico">Objeto a adicionar do tipo <see cref="Medico"/>.</param>
        /// <returns>
        /// Ver lista de erros possível
        /// 1: sucesso
        /// </returns>
        public int AdicionarMedico(Medico medico)
        {
            int resultado = ValidarMedico.ValidarObjetoMedico(medico);
            if (resultado != 1)
                return resultado;

            resultado = ValidarListaMedicos.VerificarCRMDuplicado(medico.CRM);
            if (resultado != 1)
                return resultado;

            listMedicos.Add(medico);
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
        public int RemoverMedico(int crm)
        {
            try
            {
                listMedicos.Remove(FindMedico(crm));
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
        public int AtualizarMedico(Medico medicoAtualizado)
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
        private Medico FindMedico(int crm)
        {
            int res;
            try
            {
                res = ValidarMedico.ValidarCRM(crm);
                if (res != 1)
                    throw new ListaMedicosException("Não foi possível encontrar o Médico", res);
                Medico medico = null;

                foreach (Medico m in listMedicos)
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
                throw new ListaMedicosException("Não foi possível encontrar o Médico", -14);
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
        public List<Medico> ObterMedicoFiltro(ESPECIALIDADE esp)
        {
            List<Medico> lista = null;
            int contador_ = 0;
            foreach (Medico m in listMedicos)
            {
                if (m.Especialidade.Equals(esp))
                {
                    lista.Add(m);
                    contador_++;
                }
            }
            if (contador_ == 0)
                throw new ListaMedicosException("", -14);

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
        public List<MiniMedico> ObterMiniMedicoFiltro(ESPECIALIDADE esp)
        {
            List<Medico> listaFiltro = ObterMedicoFiltro(esp);

            if (listaFiltro.Count == 0)
            {
                throw new ListaMedicosException("", -14);
            }

            List<MiniMedico> lista = new List<MiniMedico>();

            foreach (Medico medico in listaFiltro)
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
        public MiniMedico ObterMedico(int crm)
        {
            try
            {
                Medico medico = FindMedico(crm);
                return new MiniMedico(medico.Nome, medico.CRM);
            }
            catch (ListaMedicosException)
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
        public int OrganizarMedicosAlfabeticamente()
        {
            int resultado = ValidarListaMedicos.ValidarLista(listMedicos);

            if (resultado != 1)
                return resultado;
            try
            {
                listMedicos.Sort(); //usa o metodo implementado em Medico para organizar alfabeticamente
            }
            catch (MedicoException me)
            {
                throw me;
            }
            return 1;
        }

        #endregion

        #region Files
        /// <summary>
        /// Guarda a lista de médicos num ficheiro.
        /// </summary>
        /// <param name="fileName">O nome do ficheiro onde os dados serão guardados.</param>
        /// <returns>1 em caso de sucesso, 0 caso contrário.</returns>
        public int GuardarMedicosFicheiro(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, listMedicos);
                    stream.Close();
                    return 1;
                }
                catch (IOException e)
                {
                    throw e;
                }
            }
            return -31;
        }

        /// <summary>
        /// Lê a lista de médicos de um ficheiro.
        /// </summary>
        /// <param name="fileName">O nome do ficheiro de onde os dados serão lidos.</param>
        /// <returns>
        ///   1: Sucesso,
        /// -31: Ficheiro não encontrado
        /// </returns>
        public int LerMedicosFicheiro(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    listMedicos = (List<Medico>)bin.Deserialize(stream);
                    stream.Close();
                    return 1;
                }
                catch (IOException e)
                {
                    throw e;
                }
            }
            return -31;
        }

        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~MedicosList()
        {
        }
        #endregion

        #endregion
    }
}
