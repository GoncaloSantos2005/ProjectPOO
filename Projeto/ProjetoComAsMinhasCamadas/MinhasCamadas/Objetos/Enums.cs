using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasCamadas.Objetos
{
    [Serializable]
    public enum ESPECIALIDADE
    {
        Ginecologia = 0,
        Neurologia = 1,
        Cardiologia = 2,
    }
    [Serializable]
    public enum PERMISSOES
    {
        None = 0,
        Low = 1,
        High = 2,
    }
    [Serializable]
    public enum TIPOCONSULTA
    {
        Planeamento_Familiar = 0,
        Saude_Adultos = 1,
        Saude_Materna = 2,
        Saude_Infantil = 3,
        Reforco = 4,
        Teleconsulta = 5,
    }
    [Serializable]
    public enum ESTADO
    {
        Agendada = 0,
        Concluida = 1,
        NaoRealizada = 2,
        Em_Processo = 3,
    }
    public class Enums
    {

    }
}
