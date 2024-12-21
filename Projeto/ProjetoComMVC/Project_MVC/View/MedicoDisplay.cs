/*
*	<copyright file="Project_MVC.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>gonca</author>
*   <date>12/12/2024 9:34:57 AM</date>
*	<description></description>
**/
using Project_MVC.Model;
using System;
using System.Collections.Generic;

namespace Project_MVC
{
    /// <summary>
    /// Purpose:
    /// Created by: gonca
    /// Created on: 12/12/2024 9:34:57 AM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    class MedicoDisplay
    {
        #region Attributes
        private int crm;
        private string nome;
        private int nif;
        private DateTime dataN;
        private ESPECIALIDADE especialidade;
        private Morada morada;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public MedicoDisplay()
        {
            crm = 0;
            nome = "";
            nif = 0;
            dataN = new DateTime.Now();
            especialidade = ESPECIALIDADE.Cardiologia;
            morada = new Morada();
            GetValues();
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
        public int NIF
        {
            get { return nif; }
            set { nif = value; }
        }      
        public DateTime DataN
        {
            get { return dataN; }
            set { dataN = value; }
        }
        public ESPECIALIDADE Especialidade
        {
            get { return especialidade; }
            set { especialidade = value; }
        }
        public Morada Morada
        {
            get { return morada; }
            set { morada = value; }
        }
        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
        /// <summary>
        /// Método responsável por obter os valores de entrada do utilizador e atribuí-los aos atributos da classe.
        /// </summary>
        /// <remarks>
        /// Este método solicita ao utilizador informações como CRM, Nome, NIF, Data de Nascimento, Especialidade e Morada,
        /// processando as entradas para atribuí-las aos respetivos atributos.
        /// </remarks>
        /// <example>
        /// Exemplo de utilização:
        /// <code>
        /// GetValues();
        /// </code>
        /// O utilizador será solicitado a introduzir os valores via consola.
        /// </example>
        private void GetValues()
        {
            int res;
            do
            {
                Console.WriteLine("CRM:");
                CRM = int.Parse(Console.ReadLine()); //Attention!!! Parsing!
                res = ValidarMedico.ValidarCRM(CRM);
                if (res != 1)
                    Console.WriteLine("$ Erro numero: " + res + " tente novamente");
            } while (res != 1);

            do {
                Console.WriteLine("Nome:");
                Nome = Convert.ToString(Console.ReadLine());
                res = ValidarMedico.ValidarNome(Nome);
                if (res != 1)
                    Console.WriteLine("$ Erro numero: " + res + " tente novamente");
            } while (res != 1);

            do {
                Console.WriteLine("NIF:");
                NIF = int.Parse(Console.ReadLine());         //Attention!!! Parsing!
                res = ValidarMedico.ValidarNIF(NIF);
                if (res != 1)
                    Console.WriteLine("$ Erro numero: " + res + " tente novamente");
            } while (res != 1);

            do {
                Console.WriteLine("Data de Nascimento:");
                DataN = DateTime.Parse(Console.ReadLine()); //Attention!!! Parsing!
                res = ValidarMedico.ValidarData(DataN);
                if (res != 1)
                    Console.WriteLine("$ Erro numero: " + res + " tente novamente");
            } while (res != 1);

            do {
                Console.WriteLine("Especialidade:");
                Console.WriteLine("1:" + ESPECIALIDADE.Neurologia);
                Console.WriteLine("2:" + ESPECIALIDADE.Cardiologia);
                Console.WriteLine("3:" + ESPECIALIDADE.Ginecologia);
                int entrada = int.Parse(Console.ReadLine());
                if (entrada == 1)
                    Especialidade = ESPECIALIDADE.Neurologia;
                else if (entrada == 2)
                    Especialidade = ESPECIALIDADE.Cardiologia;
                else
                    Especialidade = ESPECIALIDADE.Ginecologia;
                if (res != 1)
                    Console.WriteLine("$ Erro numero: " + res + " tente novamente");
            } while (res != 1);


            do
            {
                Console.WriteLine("Morada:");
                Console.WriteLine("Código Postal:");
                int cp = int.Parse(Console.ReadLine()); //Attention!!! Parsing!
                Console.WriteLine("Morada:");
                string morada = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Cidade");
                string cidade = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Número da Porta");
                int np = int.Parse(Console.ReadLine()); //Attention!!! Parsing!

                Morada = Morada.CriarMorada(cp, morada, cidade, np);
                res = ValidarMedico.ValidarMorada(Morada);
                if (res != 1)
                    Console.WriteLine("$ Erro numero: " + res + " tente novamente");
            } while (res != 1);
        }

        /// <summary>
        /// Método público para exibir as informações detalhadas de um médico.
        /// </summary>
        /// <param name="i">Indice caso necessário para listar medicos</param>
        public void ShowMedico(int? i)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Mostrar detalhes
            if(i != null)
                Console.WriteLine("=== Detalhes do "+i+"ª Médico ===");
            else
                Console.WriteLine("=== Detalhes do Médico ===");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Data de Nascimento: {DataN:dd/MM/yyyy}");
            Console.WriteLine($"NIF: {NIF}");
            Console.WriteLine($"CRM: {CRM}");
            Console.WriteLine($"Especialidade: {Especialidade}");
            Console.WriteLine($"Morada: {Morada}");

            Console.WriteLine(new string('-', 40)); 
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey(); 
        }

        /// <summary>
        /// Método público para exibir uma lista de médicos com detalhes de cada um.
        /// </summary>
        /// <param name="medicos">Lista de médicos a ser exibida.</param>
        public void ShowListaMedico(List<Medico> medicos)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("==== Lista com " + medicos.Count + " Médicos ====");
            int cont = 1;
            if (medicos.Count == 0)
                Console.WriteLine("== Lista vazia ==");
            else
            {
                foreach (Medico medico in medicos)
                {
                    ShowMedico(cont);
                    cont++;
                    Console.WriteLine(new string('-', 40));
                }
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~MedicoDisplay()
        {
        }
        #endregion

        #endregion
    }
}
