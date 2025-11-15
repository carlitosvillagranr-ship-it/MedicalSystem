using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSDPRN3_SMH_2302B1
{
    internal class Paciente_SMH
    {
        public int Id_paciente { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public EstadoCivil_SMH EstadoCivil { get; set; }
        
    }
    //public int Id_paciente { get; internal set; }

}
