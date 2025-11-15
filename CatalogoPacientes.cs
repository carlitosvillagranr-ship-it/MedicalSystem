using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//faltaba la directiva para usar las interfaces
using MySql.Data.MySqlClient;

namespace DSDPRN3_SMH_2302B1
{
    //Definición de la clase Form1, la cual hereda metodos y propiedades de Form
    public partial class CatalogoPacientes : System.Windows.Forms.Form
    {
        public CatalogoPacientes()//constrcutor de la clase
        {
            //método para inicializar los componentes de la interfaz visual
            InitializeComponent();
        }
        //GUARDAR REGISTRO 
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear una instancia de Paciente con los datos del formulario
                Paciente_SMH paciente = new Paciente_SMH
                {
                    Nombre = txtNombre_SMH.Text,
                    ApellidoPaterno = txtPaterno_SMH.Text,
                    ApellidoMaterno = txtPaterno_SMH.Text,
                    Direccion = txtDireccion_SMH.Text,
                    Telefono = txtTelefono_SMH.Text,
                    Celular = txtCelular_SMH.Text,
                    Edad = int.Parse(txtEdad_SMH.Text),
                    // Sexo
                    Sexo = RdMujer_SMH.Checked ? "M" : "H", 
                    // Asigna "M" si se selecciona mujer, "H" si se selecciona hombre
                    Email = txtCorreo_SMH.Text,
                    //EstadoCivil = new EstadoCivil_SMH { Id_EstadoCivil = int.Parse(txtIdEstadoCivil.Text) }//se tiene un combo box con la coleccion (Soltero, Casado,Divorciado,Viudo,Concubinato)
                    //Los ID son los siguientes:(Soltero=1, Casado=2,Divorciado=3,Viudo=4,Concubinato=5)
                };
                string connectionString = "Server=localhost;Database=PRN3_S2_B1_23_SMH;Uid=root;Pwd=;";
                Conexion_SMH conexion = new Conexion_SMH(connectionString);
                conexion.InsertPaciente(paciente);
                MessageBox.Show("Paciente guardado con éxito.");
                LimpiarCampos();
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error de conexión: {error.ToString()}");
            }
        }
        private void LimpiarCampos()
        {
            txtNombre_SMH.Text = string.Empty;
            txtPaterno_SMH.Text = string.Empty;
            txtMaterno_SMH.Text = string.Empty;
            txtDireccion_SMH.Text = string.Empty;
            txtCorreo_SMH.Text= string.Empty;
            txtTelefono_SMH.Text = string.Empty;
            txtCelular_SMH.Text = string.Empty;
            txtEdad_SMH.Text = string.Empty;    
        }
        //ACTUALIZAR REGISTRO 
        private void button2_Click(object sender, EventArgs e)
        {
           CargarDatosEnDataGridView();
        }
        private void CargarDatosEnDataGridView()
        {
            try
            {
                string connectionString = "Server=localhost;Database=PRN3_S2_B1_23_SMH;Uid=root;Pwd=;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    //abre la operacion y realiza la seleccion de todas las columnas
                    connection.Open();
                    string query = "SELECT * FROM Pacientes_SMH";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);//
                    //recupera y almacena la informacion en la tabla del data grid
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    DGVpacientes_SMH.DataSource = dt;
                    // Establece las filas del DataGridView en modo de solo lectura
                    DGVpacientes_SMH.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }
        //ELIMINAR REGISTRO
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica si hay al menos una fila seleccionada en el DataGridView
                if (DGVpacientes_SMH.SelectedRows.Count > 0)
                {
                    // Obtén el Id_paciente de la fila seleccionada
                    int idPaciente = Convert.ToInt32(DGVpacientes_SMH.SelectedRows[0].Cells["Id_paciente"].Value);

                    // Crea una instancia de la clase Conexion_SMH para manejar la conexión a la base de datos
                    string connectionString = "Server=localhost;Database=PRN3_S2_B1_23_SMH;Uid=root;Pwd=;";
                    Conexion_SMH conexion = new Conexion_SMH(connectionString);

                    // Llama al método EliminarPaciente(idPaciente) en la instancia de Conexion_SMH
                    conexion.EliminarPaciente(idPaciente);

                    // Elimina la fila seleccionada del DataGridView
                    DGVpacientes_SMH.Rows.RemoveAt(DGVpacientes_SMH.SelectedRows[0].Index);

                    MessageBox.Show("Paciente eliminado con éxito.");
                }
                else
                {
                    MessageBox.Show("Selecciona un paciente para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el paciente: " + ex.Message);
            }
        }
        //MODIFICAR UN REGISTRO
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los valores modificados desde los controles
                int idPaciente;
                if (!int.TryParse(txtID_SMH.Text, out idPaciente))
                {
                    MessageBox.Show("El ID del paciente debe ser un número entero válido.");
                    return;
                }
                string nuevaDireccion = txtDomicilioN_SMH.Text;
                string nuevoTelefono = txtTelefonoN_SMH.Text;
                string nuevoCelular = txtCelularN_SMH.Text;
                string nuevoEmail = txtCorreoN_SMH.Text;

                //int idEstadoCivil = ObtenerIdEstadoCivilSeleccionado(); 

                string connectionString = "Server=localhost;Database=PRN3_S2_B1_23_SMH;Uid=root;Pwd=;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE Pacientes_SMH SET Direccion = @direccion, Telefono = @telefono," +
                        " Celular = @celular, Email = @email WHERE Id_paciente = @id";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        
                        command.Parameters.AddWithValue("@direccion", nuevaDireccion);
                        command.Parameters.AddWithValue("@telefono", nuevoTelefono);
                        command.Parameters.AddWithValue("@celular", nuevoCelular);
                        command.Parameters.AddWithValue("@email", nuevoEmail);
                        command.Parameters.AddWithValue("@id", idPaciente);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registro de paciente actualizado correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("No se encontró un registro de paciente con el ID proporcionado.");
                        }
                    }
                }
                CargarDatosEnDataGridView(); // Actualiza los datos en el DataGridView
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error de MySQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
