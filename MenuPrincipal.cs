using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSDPRN3_SMH_2302B1
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }
        //Accceder al catálogo de pacientes
        private void catalogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario de catálogo de pacientes
            CatalogoPacientes catalogoPacientes = new CatalogoPacientes();
            // Establecer el formulario principal actual como el contenedor MDI padre
            catalogoPacientes.MdiParent = this;
            // Mostrar el formulario de catálogo de pacientes en pantalla
            catalogoPacientes.Show();
        }

        //Acceder al catálogo de Estado Civil
        private void catalogoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario de catálogo de Estado Civil
            CatalogoEstadoCivil_SMH catalogoEdoCivil = new CatalogoEstadoCivil_SMH();
            // Establecer el formulario principal actual como el contenedor MDI padre
            catalogoEdoCivil.MdiParent = this;
            // Mostrar el formulario de catálogo de Estado Civil en pantalla
            catalogoEdoCivil.Show();
        }

        //Acceder al catálogo de Medicos
        private void catalogoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario de catálogo de médicos
            CatalogoMedicos_SMH catalogoMedicos = new CatalogoMedicos_SMH();
            // Establecer el formulario principal actual como el contenedor MDI padre
            catalogoMedicos.MdiParent = this;
            // Mostrar el formulario de catálogo de médicos en pantalla
            catalogoMedicos.Show();
        }

        //Acceder al catálogo de especialidades
        private void catalogoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario de catálogo de especialidades
            CatalogoEspecialidades_SMH catalogoEspecialidades_SMH = new CatalogoEspecialidades_SMH();
            // Establecer el formulario principal actual como el contenedor MDI padre
            catalogoEspecialidades_SMH.MdiParent = this;
            // Mostrar el formulario de catálogo de especialidades en pantalla
            catalogoEspecialidades_SMH.Show();
        }
        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
