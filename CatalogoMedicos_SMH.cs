using MySql.Data.MySqlClient;
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
    public partial class CatalogoMedicos_SMH : Form
    {
        public CatalogoMedicos_SMH()
        {
            InitializeComponent();
        }
        //Guardar registro
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Asigna cada propiedad de la clase Medico con su respectiva caja de texto
                string nombre = txtNombre_SMH.Text;
                string apellidoPaterno = txtPaterno_SMH.Text;
                string apellidoMaterno = txtMaterno_SMH.Text;
                string cedula = txtCedula_SMH.Text;
                //Valida que los campos no estén vacios
                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellidoPaterno) || string.IsNullOrWhiteSpace(cedula))
                {
                    throw new InvalidOperationException("Por favor, complete todos los campos obligatorios.");
                }

                // Crear una instancia de la clase Medico y asignar los valores
                Medico_SMH medico = new Medico_SMH();
                medico.Nombre = nombre;
                medico.ApellidoPaterno = apellidoPaterno;
                medico.ApellidoMaterno = apellidoMaterno;
                medico.Cedula = cedula;

                // Crear una instancia de la clase Conexion_SMH
                string connectionString = "Server=localhost;Database=PRN3_S2_B1_23_SMH;Uid=root;Pwd=;";
                Conexion_SMH conexion = new Conexion_SMH(connectionString);

                // Llamar al método para insertar el médico en la base de datos
                conexion.InsertMedico(medico);

                MessageBox.Show("Médico guardado con éxito.");
                LimpiarCampos(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el registro del médico: " + ex.Message);
            }
        }
        private void LimpiarCampos()
        {
            txtNombre_SMH.Text = string.Empty;
            txtPaterno_SMH.Text = string.Empty;
            txtMaterno_SMH.Text = string.Empty;
            txtCedula_SMH.Text = string.Empty;
        }
        //Actualizar registro
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
                    string query = "SELECT * FROM Medicos_SMH";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    //recupera y almacena la informacion en la tabla del data grid
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    DGVmedico_SMH.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }
        //eliminar registro
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica si hay al menos una fila seleccionada en el DataGridView
                if (DGVmedico_SMH.SelectedRows.Count > 0)
                {
                    // Obtén el Id_medico de la fila seleccionada
                    int idMedico = Convert.ToInt32(DGVmedico_SMH.SelectedRows[0].Cells["Id_medico"].Value);
                    // Crea una instancia de la clase Conexion_SMH para manejar la conexión a la base de datos
                    string connectionString = "Server=localhost;Database=PRN3_S2_B1_23_SMH;Uid=root;Pwd=;";
                    Conexion_SMH conexion = new Conexion_SMH(connectionString);

                    // Llama al método EliminarMedico(idMedico) en la instancia de Conexion_SMH
                    conexion.EliminarMedico(idMedico);

                    // Elimina la fila seleccionada del DataGridView
                    DGVmedico_SMH.Rows.RemoveAt(DGVmedico_SMH.SelectedRows[0].Index);

                    MessageBox.Show("Médico eliminado con éxito.");
                }
                else
                {
                    MessageBox.Show("Selecciona un médico para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el médico: " + ex.Message);
            }
        }
        //MODIFICAR REGISTRO
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los valores modificados desde los TextBox
                string nuevaCedula = txtCedulaN_SMH.Text;

                if (string.IsNullOrWhiteSpace(nuevaCedula))
                {
                    MessageBox.Show("La cédula del médico no puede estar vacía.");
                    return;
                }

                int idMedico;

                if (!int.TryParse(txtID_SMH.Text, out idMedico))
                {
                    MessageBox.Show("El ID del médico debe ser un número entero válido.");
                    return;
                }

                string connectionString = "Server=localhost;Database=PRN3_S2_B1_23_SMH;Uid=root;Pwd=;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE Medicos_SMH SET Cedula = @cedula WHERE Id_medico = @id";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        
                        command.Parameters.AddWithValue("@cedula", nuevaCedula);
                        command.Parameters.AddWithValue("@id", idMedico);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registro de médico actualizado correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("No se encontró un registro de médico con el ID proporcionado.");
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
