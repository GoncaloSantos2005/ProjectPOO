/*
*	<copyright file="MinhasCamadas.Objetos.Consulta.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/17/2024 7:51:35 PM</date>
*	<description></description>
**/
using System;

namespace MinhasCamadas.Objetos.Consulta
{
    /// <summary>
    /// Purpose:
    /// Created by: gonca
    /// Created on: 12/17/2024 7:51:35 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class MiniConsulta
    {
        #region Attributes
        int idConsulta;
        int crm;
        int nif;
        DateTime dataInicio;
        DateTime dataFim;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public MiniConsulta()
        {
        }
        public MiniConsulta(int id, int c, int n, DateTime di, DateTime df)
        {
            this.idConsulta = id;
            this.crm = c;
            this.nif = n;
            this.dataInicio = di;
            this.dataFim = df;
        }

        #endregion

        #region Properties
        public int IdConsulta
        {
            get { return idConsulta; }
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
        #endregion



        #region Overrides
        #endregion

        #region OtherMethods
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~MiniConsulta()
        {
        }
        #endregion

        #endregion
    }
}
