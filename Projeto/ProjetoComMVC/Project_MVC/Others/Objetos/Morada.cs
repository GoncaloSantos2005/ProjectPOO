/*
*	<copyright file="Project_MVC.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/1/2024 6:22:26 PM</date>
*	<description></description>
**/
using System;

namespace Project_MVC
{
    /// <summary>
    /// Purpose: Class responsável por manipular uma respetiva Morada
    /// Created by: gonca
    /// Created on: 12/1/2024 6:22:26 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    [Serializable]
    public class Morada
    {
        #region Attributes
        int cP;
        string morada_;
        string cidade;
        int nPorta;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Morada()
        {
        }

        public Morada(int cP, string morada_, string cidade, int nPorta)
        {
            this.cP = cP;
            this.morada_ = morada_;
            this.cidade = cidade;
            this.nPorta = nPorta;
        }



        #endregion

        #region Properties
        public int CP
        {
            get { return cP; }
            set { cP = value; }
        }
        public string Morada_
        {
            get { return morada_; }
            set { morada_ = value; }
        }
        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }
        public int NPorta
        {
            get { return nPorta; }
            set { nPorta = value; }
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return $"Endereco: {morada_}, Número: {nPorta}, Cidade: {cidade}, Código Postal: {cP}";
        }
        #endregion

        #region OtherMethods
        public Morada CriarMorada(int cP, string morada_, string cidade, int nPorta)
        {            
            return new Morada(cP, morada_, cidade, nPorta);
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Morada()
        {
        }
        #endregion

        #endregion
    }
}
