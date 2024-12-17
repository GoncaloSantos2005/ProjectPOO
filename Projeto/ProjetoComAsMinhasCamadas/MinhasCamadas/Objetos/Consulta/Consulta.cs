/*
*	<copyright file="MinhasCamadas.Objetos.Consulta.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/17/2024 2:49:06 PM</date>
*	<description></description>
**/
using MinhasCamadas.ProjectException;
using MinhasCamadas.Validacoes;
using System;

namespace MinhasCamadas.Objetos.Consulta
{
    public enum TIPOCONSULTA
    {
        Planeamento_Familiar = 0,
        Saude_Adultos = 1,
        Saude_Materna = 2,
        Saude_Infantil = 3,
        Reforco = 4,
        Teleconsulta = 5,
    }

    public enum ESTADO
    {
        Agendada = 0,
        Concluida = 1,
        NaoRealizada = 2,
        Em_Processo = 3,
    }
    /// <summary>
    /// Purpose:
    /// Created by: gonca
    /// Created on: 12/17/2024 2:49:06 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    [Serializable]
    public class Consulta
    {
        #region Attributes
        static int totalConsultas;
        int idConsulta;
        DateTime dataInicio;
        DateTime dataFim;
        int nif; //paciente
        int crm; //medico
        int numeroStaff; //staff
        int? idDiagnostico;
        TIPOCONSULTA tipoConsulta;
        ESTADO estado;

        
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Consulta()
        {
        }
        public Consulta(DateTime dataI, DateTime dataF, int nif, int crm, int numeroS, int? idDiagnostico, TIPOCONSULTA tp, ESTADO es)
        {
            this.dataInicio = dataI;
            this.dataFim = dataF;
            this.nif = nif;
            this.crm = crm;
            this.numeroStaff = numeroS;
            this.idDiagnostico = idDiagnostico;
            this.tipoConsulta = tp;
            this.estado = es;
        }

        #endregion

        #region Properties
        public static int TotalConsultas {
            get {  return totalConsultas; }
            set { totalConsultas = value; }
        }
        public int IdConsulta
        {
            get { return idConsulta; }
            set { idConsulta = value; }
        }
        public DateTime DataInicio
        {
            get { return dataInicio; }
            set { dataInicio = value; }
        }
        public DateTime DataFim
        {
            get { return dataFim; }
            set { dataFim = value; }
        }
        public int NIF //paciente
        {
            get { return nif; }
            set { nif = value; }
        }
        public int CRM //medico
        {
            get { return crm; }
            set { crm = value; }
        }
        int NumeroStaff //staff
        {
            get { return numeroStaff; }
            set { numeroStaff = value; }
        }
        int? IdDiagnostico
        {
            get { return idDiagnostico; }
            set { idDiagnostico = value; }
        }
        public TIPOCONSULTA TipoConsulta
        {
            get { return tipoConsulta; }
            set { tipoConsulta = value; }
        }
        public ESTADO Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
        /// <summary>
        /// Cria um objeto da classe <see cref="Consulta"/> com os parâmetros fornecidos.
        /// </summary>
        /// <param name="dataI">Data de início da consulta.</param>
        /// <param name="dataF">Data de fim da consulta.</param>
        /// <param name="nif">NIF do paciente.</param>
        /// <param name="crm">CRM do médico.</param>
        /// <param name="numeroStaff">Número do staff responsável.</param>
        /// <param name="idDiagnostico">ID do diagnóstico associado (opcional).</param>
        /// <param name="tp">Tipo da consulta.</param>
        /// <param name="es">Estado da consulta.</param>
        /// <returns>Um objeto do tipo <see cref="Consulta"/>.</returns>
        /// <exception cref="ConsultaException">
        /// <exception cref="Exception">
        /// Lançada quando os parâmetros fornecidos não são válidos.
        /// </exception>
        public static Consulta CriaConsulta(DateTime dataI, DateTime dataF, int nif, int crm, int numeroStaff, int? idDiagnostico, TIPOCONSULTA tp, ESTADO es)
        {
            int res = ValidarListaMedicos.ExisteCRM(crm);
            if (res != 1)
                throw new ListaMedicosException(res);
            res = ValidarConsulta.ValidarCamposConsulta(dataI, dataF, nif, crm, numeroStaff, idDiagnostico, tp, es);
                if (res != 1)
                throw new ConsultaException(res);
            try
            {
                Consulta c = new Consulta(dataI, dataF,nif,crm,numeroStaff,idDiagnostico,tp,es);
                res = ValidarConsulta.ValidarObjetoConsulta(c);
                if (res != 1)
                {
                    totalConsultas++;
                    return c;
                }
                throw new ConsultaException(res);
            }
            catch (ConsultaException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        /// <summary>
        /// Método para adicionar um diagnostico a uma consulta
        /// </summary>
        /// <param name="id">Id do Diagnostioc</param>
        /// <returns>1: sucesso</returns>
        /// <exception cref="ConsultaException"></exception>
        public int AdicionarDiagnostico(int id)
        {
            int res = ValidarConsulta.ValidarIDDepartamento(id);
            if (res != 1)
                throw new ConsultaException(res);

            //Falta implementar o verificar existencia do Diagnostico

            this.IdDiagnostico = id;
            return 1;
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Consulta()
        {
        }
        #endregion

        #endregion
    }
}
