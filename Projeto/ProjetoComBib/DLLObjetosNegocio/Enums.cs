/*
*	<copyright file="ObjetosNegocio.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/9/2024 11:41:19 AM</date>
*	<description></description>
**/
using System;
using ProjectException;

namespace ObjetosNegocio
{
    /// <summary>
    /// Purpose:
    /// Created by: gonca
    /// Created on: 12/9/2024 11:41:19 AM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>


    public enum PERMISSOES
    {
        None = 0,
        Low = 1,
        High = 2,
    }
    public enum ESPECIALIDADE
    {
        Ginecologia = 0,
        Neurologia = 1,
        Cardiologia = 2,
    }

    public class Enums
    {
        #region Attributes
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Enums()
        {
        }

        #endregion

        #region Properties
        #endregion



        #region Overrides
        #endregion

        #region OtherMethods
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Enums()
        {
        }
        #endregion

        #endregion
    }
}
