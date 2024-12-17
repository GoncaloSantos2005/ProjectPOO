using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MinhasCamadas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "ListaMedicos";
            Medicos.LerMedicosFicheiro(fileName);
            Medicos.ObterTodos();
            #region Testes
            /*
            //Cria medico
            Medico medico = null;
            
            try
            {
                medico = new Medico("João Silva", new DateTime(2000, 5, 12), 123456789, new Morada(), 1234, ESPECIALIDADE.Cardiologia);
                Console.WriteLine("Criado");
            }
            catch (MedicoException ex)
            {
                Console.WriteLine($"Erro ao criar médico: {ex.Message}");
            }
            try
            {
                medico.EditaMedico("Alfredo Lopes", medico.DataN, medico.NIF, medico.Morada, medico.Especialidade);
                Console.WriteLine("Editado");
            }
            catch (MedicoException ex)
            {
                Console.WriteLine($"Erro ao criar médico: {ex.Message}");
            }

            
            try
            {
                // Criar instância de Medicos e adicionar médicos
                Medicos listaMedicos = new Medicos();
                listaMedicos.AdicionarMedico(new Medico("João Silva", new DateTime(1980, 5, 12), 123456789, new Morada(), 1234, ESPECIALIDADE.Cardiologia));
                listaMedicos.AdicionarMedico(new Medico("Maria Santos", new DateTime(1985, 8, 20), 987654321, new Morada(), 5678, ESPECIALIDADE.Neurologia));
                listaMedicos.AdicionarMedico(new Medico("Carlos Costa", new DateTime(1990, 12, 15), 123987456, new Morada(), 9012, ESPECIALIDADE.Cardiologia));

                RegrasMedicos regrasMedicos = new RegrasMedicos();

                // Pesquisa com permissões Low
                Console.WriteLine("== Permissões Low ==");
                var resultadoLow = regrasMedicos.PesquisaMedicos(listaMedicos, ESPECIALIDADE.Cardiologia, PERMISSOES.Low);
                resultadoLow.ForEach(m => Console.WriteLine(m.ToString()));

                // Pesquisa com permissões High
                Console.WriteLine("\n== Permissões High ==");
                var resultadoHigh = regrasMedicos.PesquisaMedicos(listaMedicos, ESPECIALIDADE.Cardiologia, PERMISSOES.High);
                resultadoHigh.ForEach(m => Console.WriteLine(m.ToString()));

                // Pesquisa com permissões None (causa exceção)
                Console.WriteLine("\n== Permissões None ==");
                var resultadoNone = regrasMedicos.PesquisaMedicos(listaMedicos, ESPECIALIDADE.Cardiologia, PERMISSOES.None);
            }
            catch (RegrasMedicosException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            */
            //listaMedicos.AdicionarMedico(new Medico("João Silva", new DateTime(1980, 5, 12), 123456789, new Morada(), 1234, ESPECIALIDADE.Cardiologia));
            //listaMedicos.AdicionarMedico(new Medico("Maria Santos", new DateTime(1985, 8, 20), 987654321, new Morada(), 5678, ESPECIALIDADE.Neurologia));
            //listaMedicos.AdicionarMedico(new Medico("Carlos Costa", new DateTime(1990, 12, 15), 123987456, new Morada(), 9012, ESPECIALIDADE.Cardiologia));
            #endregion

            #region Testes
            /*
            Medico medico1 = null;
            Medico medico2 = null;
            Medico medico3 = null;
            Medico medico4 = null;
            Medico medico5 = null;
            Medico medico6 = null;
            Medico medico7 = null;
            Medico medico8 = null;
            Medico medico9 = null;
            Medico medico10 = null;
            Medico medico11 = null;
            Medico medico12 = null;
            Medico medico13 = null;
            Medico medico14 = null;
            Medico medico15 = null;
            Medico medico16 = null;
            Medico medico17 = null;
            Medico medico18 = null;
            try {
                medico4 = RegrasMedicos.TentaCriarMedico(PERMISSOES.High, "Ana Moreira", new DateTime(1975, 3, 10), 456123789, new Morada(), 3456, ESPECIALIDADE.Ginecologia);
                medico5 = RegrasMedicos.TentaCriarMedico(PERMISSOES.Low, "Pedro Martins", new DateTime(1978, 11, 2), 789456123, new Morada(), 7890, ESPECIALIDADE.Neurologia);
                medico6 = RegrasMedicos.TentaCriarMedico(PERMISSOES.High, "Sofia Almeida", new DateTime(1982, 6, 25), 321654987, new Morada(), 2345, ESPECIALIDADE.Cardiologia);
                medico7 = RegrasMedicos.TentaCriarMedico(PERMISSOES.Low, "Rui Moreira", new DateTime(1977, 9, 14), 741852963, new Morada(), 6123, ESPECIALIDADE.Ginecologia);
                medico8 = RegrasMedicos.TentaCriarMedico(PERMISSOES.High, "Helena Carvalho", new DateTime(1991, 1, 5), 963258741, new Morada(), 4178, ESPECIALIDADE.Ginecologia);
                medico9 = RegrasMedicos.TentaCriarMedico(PERMISSOES.Low, "André Fonseca", new DateTime(1983, 4, 17), 159357486, new Morada(), 8256, ESPECIALIDADE.Neurologia);
                medico10 = RegrasMedicos.TentaCriarMedico(PERMISSOES.High, "Beatriz Matos", new DateTime(1979, 7, 9), 258369147, new Morada(), 3344, ESPECIALIDADE.Neurologia);
                medico11 = RegrasMedicos.TentaCriarMedico(PERMISSOES.Low, "Luís Vieira", new DateTime(1988, 2, 28), 654987321, new Morada(), 9999, ESPECIALIDADE.Cardiologia);
                medico12 = RegrasMedicos.TentaCriarMedico(PERMISSOES.High, "Catarina Rocha", new DateTime(1981, 10, 30), 987321654, new Morada(), 1122, ESPECIALIDADE.Neurologia);
                medico13 = RegrasMedicos.TentaCriarMedico(PERMISSOES.Low, "Fernando Lopes", new DateTime(1976, 12, 1), 123321789, new Morada(), 4567, ESPECIALIDADE.Cardiologia);
                medico14 = RegrasMedicos.TentaCriarMedico(PERMISSOES.High, "Carla Barreto", new DateTime(1984, 5, 19), 321789654, new Morada(), 7766, ESPECIALIDADE.Ginecologia);
                medico15 = RegrasMedicos.TentaCriarMedico(PERMISSOES.Low, "Mário Fernandes", new DateTime(1990, 3, 11), 987654123, new Morada(), 2233, ESPECIALIDADE.Ginecologia);
                medico16 = RegrasMedicos.TentaCriarMedico(PERMISSOES.High, "Diana Faria", new DateTime(1974, 6, 23), 741963852, new Morada(), 4488, ESPECIALIDADE.Cardiologia);
                medico17 = RegrasMedicos.TentaCriarMedico(PERMISSOES.Low, "Paulo Rodrigues", new DateTime(1986, 9, 27), 654123987, new Morada(), 1144, ESPECIALIDADE.Cardiologia);
                medico18 = RegrasMedicos.TentaCriarMedico(PERMISSOES.High, "Isabel Ribeiro", new DateTime(1973, 8, 16), 951357486, new Morada(), 7788, ESPECIALIDADE.Ginecologia);

            }
            catch (MedicoException )
            {
               
            }
            catch (RegrasMedicosException )
            {
                
            }

            try
            {
                int r4 = RegrasMedicos.TentarAdicionarMedico(PERMISSOES.High, medico4);
                if (r4 != 1)
                    Console.WriteLine("Error code: " + r4);

                int r5 = RegrasMedicos.TentarAdicionarMedico(PERMISSOES.High, medico5);
                if (r5 != 1)
                    Console.WriteLine("Error code: " + r5);

                int r6 = RegrasMedicos.TentarAdicionarMedico(PERMISSOES.High, medico6);
                if (r6 != 1)
                    Console.WriteLine("Error code: " + r6);

                int r7 = RegrasMedicos.TentarAdicionarMedico(PERMISSOES.High, medico7);
                if (r7 != 1)
                    Console.WriteLine("Error code: " + r7);

                int r8 = RegrasMedicos.TentarAdicionarMedico(PERMISSOES.High, medico8);
                if (r8 != 1)
                    Console.WriteLine("Error code: " + r8);

                int r9 = RegrasMedicos.TentarAdicionarMedico(PERMISSOES.High, medico9);
                if (r9 != 1)
                    Console.WriteLine("Error code: " + r9);

                int r10 = RegrasMedicos.TentarAdicionarMedico(PERMISSOES.High, medico10);
                if (r10 != 1)
                    Console.WriteLine("Error code: " + r10);

                int r11 = RegrasMedicos.TentarAdicionarMedico(PERMISSOES.High, medico11);
                if (r11 != 1)
                    Console.WriteLine("Error code: " + r11);

                int r12 = RegrasMedicos.TentarAdicionarMedico(PERMISSOES.High, medico12);
                if (r12 != 1)
                    Console.WriteLine("Error code: " + r12);

                int r13 = RegrasMedicos.TentarAdicionarMedico(PERMISSOES.High, medico13);
                if (r13 != 1)
                    Console.WriteLine("Error code: " + r13);

                int r14 = RegrasMedicos.TentarAdicionarMedico(PERMISSOES.High, medico14);
                if (r14 != 1)
                    Console.WriteLine("Error code: " + r14);

                int r15 = RegrasMedicos.TentarAdicionarMedico(PERMISSOES.High, medico15);
                if (r15 != 1)
                    Console.WriteLine("Error code: " + r15);

                int r16 = RegrasMedicos.TentarAdicionarMedico(PERMISSOES.High, medico16);
                if (r16 != 1)
                    Console.WriteLine("Error code: " + r16);

                int r17 = RegrasMedicos.TentarAdicionarMedico(PERMISSOES.High, medico17);
                if (r17 != 1)
                    Console.WriteLine("Error code: " + r17);

                int r18 = RegrasMedicos.TentarAdicionarMedico(PERMISSOES.High, medico18);
                if (r18 != 1)
                    Console.WriteLine("Error code: " + r18);
            }
            catch(ListaMedicosException)
            {

            }
            
            if (medico1 == null || medico2 == null || medico3 == null)
               Console.WriteLine("Médico não criado!");
            
            Medicos.ObterTodos();
            */
            #endregion
            #region Organizar
            /*
            try
            {
                int res = Medicos.OrganizarMedicosAlfabeticamente();
                if (res != 1) Console.WriteLine($"Lista não organizada");
            }
            catch (ListaMedicosException)
            {

            }
            */
            #endregion

            //medico1 = RegrasMedicos.TentarEditarMedico(PERMISSOES.High, medico1, "Goncalo", new DateTime(1986, 5, 12), 111111111, new Morada(), ESPECIALIDADE.Cardiologia);

            //RegrasMedicos.TentarAtualizarMedico(PERMISSOES.High, medico1);



            int res123 = Medicos.GuardarMedicosFicheiro(fileName);
            if (res123 != 1)
                Console.WriteLine("Erro ao gravar no ficheiro");
            Medicos.ObterTodos();

        }
    }
}
