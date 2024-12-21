/*
*	<copyright file="Project_MVC.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/1/2024 6:21:02 PM</date>
*	<description></description>
**/
using System;

namespace Project_MVC
{
    public enum ESPECIALIDADE
    {
        Ginecologia = 0,
        Neurologia = 1,
        Cardiologia = 2,
    }
    /// <summary>
    /// Purpose: Class responsável por manipular Medico
    /// Created by: gonca
    /// Created on: 12/1/2024 6:21:02 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>

    [Serializable]
    public class Medico : Pessoa, IComparable<Medico>
    {
        #region Attributes
        int crm;
        ESPECIALIDADE especialidade;       

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Medico()
        {
        }
        
        public Medico(string nome, DateTime dataN, int nif, Morada morada, int crm, ESPECIALIDADE especialidade)
        {
            base.Nome = nome;
            base.DataN = dataN;
            base.NIF = nif;
            base.Morada = morada;
            this.crm = crm;
            this.especialidade = especialidade;                     
        }

        #endregion

        #region Properties
        public int CRM
        {
            get { return crm; }
            set { crm = value; }
        }

        public ESPECIALIDADE Especialidade
        {
            get { return especialidade; }
            set { especialidade = value; }
        }
        #endregion

        #region Overrides
        /// <summary>
        /// @brief Método que retorna uma representação textual do objeto.
        /// </summary>
        /// <returns>
        /// Uma string formatada contendo o CRM, o Nome, o NIF, a Data de Nascimento e a Especialidade.
        /// </returns>
        public override string ToString()
        {
            return "CRM:" + crm + " Nome:" + Nome + " NIF:" + NIF + " Data Nascimento:" + DataN + " Especialidade:" + especialidade;
        }
        #endregion

        #region IComparable<Medico> 
        /// <summary>
        /// Compara os nomes dos médicos para ordenar alfabeticamente.
        /// </summary>
        /// <param name="outroMedico">Outro objeto Medico para comparação.</param>
        /// <returns>
        /// -1 se este nome for menor,
        /// 0 se igual, 
        /// 1 se maior.
        /// </returns>
        public int CompareTo(Medico outroMedico)
        {
            int res = ValidarMedico.ValidarObjetoMedico(outroMedico);
            if (res != 1)
                throw new MedicoException("Operação de Comparar foi interrompida! ", res);

            string nome1 = this.Nome.ToLower();
            string nome2 = outroMedico.Nome.ToLower();

            //retorna o min de caracteres das 2 strings
            int minLength = Math.Min(nome1.Length, nome2.Length);

            for (int i = 0; i < minLength; i++)
            {
                if (nome1[i] < nome2[i])
                    return -1; // `this.Nome` vem antes de `outroMedico.Nome`
                else if (nome1[i] > nome2[i])
                    return 1;  // `this.Nome` vem depois de `outroMedico.Nome`
            }

            // Se os prefixos são iguais, comparar pelo comprimento
            if (nome1.Length < nome2.Length)
                return -1; // Nome mais curto vem primeiro
            else if (nome1.Length > nome2.Length)
                return 1;  // Nome mais longo vem depois

            return 0; // Os nomes são iguais
        }
        #endregion

        #region OtherMethods
        /// <summary>
        /// Edita um objeto da classe <see cref="Medico"/> após validar os parâmetros fornecidos.
        /// </summary>
        /// <param name="novoNome">Nome do médico.</param>
        /// <param name="novaDataN">Data de nascimento do médico.</param>
        /// <param name="novoNif">Número de Identificação Fiscal (NIF).</param>
        /// <param name="novaMorada">Objeto do tipo <see cref="Morada"/> com a morada do médico.</param>
        /// <param name="novaEspecialidade">Especialidade do médico.</param>
        /// <returns>Objeto do tipo <see cref="Medico"/> já com os atributos editados.</returns>
        /// <exception cref="MedicoException">
        /// Lançada quando os parâmetros fornecidos não são válidos.
        /// </exception>
        public Medico EditaMedico(string novoNome, DateTime novaDataN, int novoNif, Morada novaMorada, ESPECIALIDADE novaEspecialidade)
        {
            int resultado = ValidarMedico.ValidarCamposMedico(novoNome, novaDataN, novoNif, novaMorada, novaEspecialidade);
            if (resultado != 1)
            {
                throw new MedicoException("Médico não editado", resultado);
            }

            this.Nome = novoNome;
            this.DataN = novaDataN;
            this.NIF = novoNif;
            this.Morada = novaMorada;
            this.Especialidade = novaEspecialidade;

            return this;
        }

        /// <summary>
        /// Cria um objeto da classe <see cref="Medico"/> após validar os parâmetros fornecidos.
        /// </summary>
        /// <param name="nome">Nome do médico.</param>
        /// <param name="dataN">Data de nascimento do médico.</param>
        /// <param name="nif">Número de Identificação Fiscal (NIF).</param>
        /// <param name="morada">Objeto do tipo <see cref="Morada"/> com a morada do médico.</param>
        /// <param name="crm">CRM do médico.</param>
        /// <param name="especialidade">Especialidade do médico.</param>
        /// <returns>Um objeto do tipo <see cref="Medico"/>.</returns>
        /// <exception cref="MedicoException">
        /// Lançada quando os parâmetros fornecidos não são válidos.
        /// </exception>
        public static Medico CriaMedico(string nome, DateTime dataN, int nif, Morada morada, int crm, ESPECIALIDADE especialidade)
        {
            int resultado = ValidarMedico.ValidarCamposMedico(nome, dataN, nif, morada, especialidade);
            if (resultado != 1)
            {
                throw new MedicoException("Médico não criado", resultado);
            }
            return new Medico(nome, dataN, nif, morada, crm, especialidade);
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Medico()
        {
        }
        #endregion

        #endregion
    }
}
