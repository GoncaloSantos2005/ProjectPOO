/*
*	<copyright file="Project_MVC.Model.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/17/2024 12:02:14 PM</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;

namespace Project_MVC.Model
{
    /// <summary>
    /// Purpose:
    /// Created by: gonca
    /// Created on: 12/17/2024 12:02:14 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    [Serializable]
    public class MedicosHistory
    {
        #region Attributes
        List<IMedicosListModel> hist;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public MedicosHistory()
        {
            hist = new List<IMedicosListModel>();
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
        ~MedicosHistory()
        {
        }
        #endregion

        #endregion
    }
}
