/*
*	<copyright file="Project_MVC.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/1/2024 6:21:23 PM</date>
*	<description></description>
**/
using System;

namespace Project_MVC
{
    /// <summary>
    /// Purpose: Class pai de algumas Class no projeto
    /// Created by: gonca
    /// Created on: 12/1/2024 6:21:23 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    [Serializable]
    public class Pessoa
    {
        #region Attributes
        string nome;
        DateTime dataN;
        int nif;
        Morada morada;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Pessoa()
        {
        }
        public Pessoa(string n, DateTime data, int ni, Morada m)
        {
            nome = n;
            dataN = data;
            morada = m;
            nif = ni;
        }

        #endregion

        #region Properties
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public DateTime DataN
        {
            get { return dataN; }
            set { dataN = value; }
        }

        public Morada Morada
        {
            get { return morada; }
            set { morada = value; }
        }

        public int NIF
        {
            get { return nif; }
            set { nif = value; }
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
        ~Pessoa()
        {
        }
        #endregion

        #endregion
    }
}
