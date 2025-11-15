using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DSDPRN3_SMH_2302B1
{
    public partial class CatalogoEstadoCivil_SMH : Form
    {
        private const string ConnectionString = "Server=localhost;Database=PRN3_S2_B1_23_SH;Uid=root;Pwd=;";
        public CatalogoEstadoCivil_SMH()
        {
            InitializeComponent();
           

        }
        
        //GUARADR REGISTRO
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //int idEstadoCivil = int.Parse(txtIdEstadoCivil.Text);
                string nombreEstadoCivil = txtNombre_SMH.Text;
                if (string.IsNullOrWhiteSpace(nombreEstadoCivil))//valida que no esté vacío
                {
                    throw new InvalidOperationException("El campo no puede estar vacío. Por favor, ingrese un nombre válido.");
                }

                //Crea una instancia del estado civil
                EstadoCivil_SMH estadoCivil = new EstadoCivil_SMH();
                estadoCivil.EstadoCivil_nombre = nombreEstadoCivil;

                //Creqa la conexion 
                string connectionString = "Server=localhost;Database=PRN3_S2_B1_23_SMH;Uid=root;Pwd=;";
                Conexion_SMH conexion = new Conexion_SMH(connectionString);
                conexion.InsertEstadoCivil(estadoCivil);//manda a llamar al metodo de la conexion para insertar el campo

                MessageBox.Show("Estado civil guardado con éxito.");
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el estado civil: " + ex.Message);
            }
        }
        private void LimpiarCampos()
        {
            txtNombre_SMH.Text  = string.Empty;
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
                    string query = "SELECT * FROM EstadoCivil_SMH";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    //recupera y almacena la informacion en la tabla del data grid
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    DGVedoCivil_SMH.DataSource = dt;
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
                if (DGVedoCivil_SMH.SelectedRows.Count > 0)
                {
                    // Obtén el Id_EstadoCivil de la fila seleccionada
                    int idEstadoCivil = Convert.ToInt32(DGVedoCivil_SMH.SelectedRows[0].Cells["Id_EstadoCivil"].Value);

                    // Crea una instancia de la clase Conexion_SMH para manejar la conexión a la base de datos
                    string connectionString = "Server=localhost;Database=PRN3_S2_B1_23_SMH;Uid=root;Pwd=;";
                    Conexion_SMH conexion = new Conexion_SMH(connectionString);

                    // Llama al método EliminarEstadoCivil(idEstadoCivil) en la instancia de Conexion_SMH
                    conexion.EliminarEstadoCivil(idEstadoCivil);

                    // Elimina la fila seleccionada del DataGridView
                    DGVedoCivil_SMH.Rows.RemoveAt(DGVedoCivil_SMH.SelectedRows[0].Index);

                    MessageBox.Show("Estado Civil eliminado con éxito.");
                }
                else
                {
                    MessageBox.Show("Selecciona un estado civil para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el estado civil: " + ex.Message);
            }
        }

        //MODIFICAR REGISTRO
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el nuevo nombre del estado civil desde el TextBox
                string nuevoEstadoCivil = txtNvRegistro_SMH.Text;
                if (string.IsNullOrWhiteSpace(nuevoEstadoCivil))
                {
                    MessageBox.Show("El nuevo nombre del estado civil no puede estar vacío.");
                    return;
                }

                if (!int.TryParse(txtID_SMH.Text, out int idEstadoCivil))
                {
                    MessageBox.Show("El ID del estado civil debe ser un número entero válido.");
                    return;
                }

                string connectionString = "Server=localhost;Database=PRN3_S2_B1_23_SMH;Uid=root;Pwd=;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE EstadoCivil_SMH SET EstadoCivil_nombre = @nombre WHERE Id_EstadoCivil = @id";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombre", nuevoEstadoCivil);
                        command.Parameters.AddWithValue("@id", idEstadoCivil);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registro actualizado correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("No se encontró un registro con el ID proporcionado.");
                        }
                    }
                }

                CargarDatosEnDataGridView();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error de MySQL: " + ex.Message);
                // Aquí puedes agregar más detalles sobre la excepción si es necesario
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }

        
}

    


