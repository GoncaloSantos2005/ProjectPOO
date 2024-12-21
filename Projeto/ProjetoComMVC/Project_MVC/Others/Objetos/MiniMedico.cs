/*
*	<copyright file="Project_MVC.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/2/2024 12:29:51 PM</date>
*	<description></description>
**/
using System;

namespace Project_MVC
{
    /// <summary>
    /// Purpose: Class criada para dar suporte a <see cref="Medico"/>, para mostrar apenas alguns atributos.
    /// Created by: gonca
    /// Created on: 12/2/2024 12:29:51 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    
    public class MiniMedico
    {
        #region Attributes
        string nome;
        int crm;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public MiniMedico()
        {
        }

        public MiniMedico(string nome, int crm)
        {
            this.nome = nome;
            this.crm = crm;   
        }

        #endregion

        #region Properties
        public int CRM
        {
            get { return crm; }
            set { crm = value; }
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
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
        ~MiniMedico()
        {
        }
        #endregion

        #endregion
    }
}
