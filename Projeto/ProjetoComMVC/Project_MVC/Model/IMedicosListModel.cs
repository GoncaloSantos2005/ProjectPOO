using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_MVC.Model
{
    public interface IMedicosListModel
    {
        List<Medico> ListMedicos { get; set; }
        int Contador { get; }
        int AdicionarMedico(Medico medico);
        int RemoverMedico(int crm);
        int AtualizarMedico(Medico medicoAtualizado);
        //Medico FindMedico(int crm);
        List<Medico> ObterMedicoFiltro(ESPECIALIDADE esp);
        List<MiniMedico> ObterMiniMedicoFiltro(ESPECIALIDADE esp);
        MiniMedico ObterMedico(int crm);
        int OrganizarMedicosAlfabeticamente();
        int LerMedicosFicheiro(string fileName);
        int GuardarMedicosFicheiro(string fileName);
    }
}
