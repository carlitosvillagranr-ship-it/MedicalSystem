using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSDPRN3_SMH_2302B1
{
    internal class Medico_SMH
    {
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Cedula { get; set; }
        public ICollection<Especialidad_SMH> MedicosEspecialidades { get; set; }
    }
}
