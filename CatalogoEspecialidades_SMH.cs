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
    public partial class CatalogoEspecialidades_SMH : Form
    {
        public CatalogoEspecialidades_SMH()
        {
            InitializeComponent();
        }
        //GUARDAR REGISTRO 
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreEspecialidad = txtNombre_SMH.Text;
                string descripcionEspecialidad = txtDescripcion_SMH.Text;

                if (string.IsNullOrWhiteSpace(nombreEspecialidad))
                {
                    throw new InvalidOperationException("El nombre de la especialidad no puede estar vacío.");
                }
                if (string.IsNullOrWhiteSpace(descripcionEspecialidad))
                {
                    throw new InvalidOperationException("La descripción no puede estar vacía.");
                }

                // Crear una instancia de la clase Especialidad_SMH y asignar los valores
                Especialidad_SMH especialidad = new Especialidad_SMH();
                especialidad.Nombre = nombreEspecialidad;
                especialidad.Descripcion = descripcionEspecialidad;

                // Crear una instancia de la clase Conexion_SMH con tu cadena de conexión
                string connectionString = "Server=localhost;Database=PRN3_S2_B1_23_SMH;Uid=root;Pwd=;";
                Conexion_SMH conexion = new Conexion_SMH(connectionString);

                // Llamar al método para insertar la especialidad en la base de datos
                conexion.InsertEspecialidad(especialidad);

                MessageBox.Show("Especialidad guardada con éxito.");
                LimpiarCampos(); // Implementa tu método para limpiar campos si es necesario
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la especialidad: " + ex.Message);
            }
        }
        private void LimpiarCampos()
        {
            txtNombre_SMH.Text = string.Empty;
            txtDescripcion_SMH.Text = string.Empty;
        }

        //ACTUALIZAR REGISTRO
        private void button1_Click(object sender, EventArgs e)
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
                    string query = "SELECT * FROM Especialidades_SMH";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    //recupera y almacena la informacion en la tabla del data grid
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    DGVesp_SMH.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }
        //ELIMINAR REGISTRO
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica si hay al menos una fila seleccionada en el DataGridView
                if (DGVesp_SMH.SelectedRows.Count > 0)
                {
                    // Obtén el Id_Especialidad de la fila seleccionada
                    int idEspecialidad = Convert.ToInt32(DGVesp_SMH.SelectedRows[0].Cells["Id_Especialidad"].Value);

                    // Crea una instancia de la clase Conexion_SMH para manejar la conexión a la base de datos
                    string connectionString = "Server=localhost;Database=PRN3_S2_B1_23_SMH;Uid=root;Pwd=;";
                    Conexion_SMH conexion = new Conexion_SMH(connectionString);

                    // Llama al método EliminarEspecialidad(idEspecialidad) en la instancia de Conexion_SMH
                    conexion.EliminarEspecialidad(idEspecialidad);

                    // Elimina la fila seleccionada del DataGridView
                    DGVesp_SMH.Rows.RemoveAt(DGVesp_SMH.SelectedRows[0].Index);

                    MessageBox.Show("Especialidad eliminada con éxito.");
                }
                else
                {
                    MessageBox.Show("Selecciona una especialidad para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la especialidad: " + ex.Message);
            }
        }

        //MODIFICAR REGISTRO
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los valores modificados desde los TextBox
                string nuevoNombre = txtNombreN_SMH.Text;
                string nuevaDescripcion = txtDescripcionN_SMH.Text;
                int idEspecialidad = int.Parse(txtID_SMH.Text);

                if (string.IsNullOrWhiteSpace(nuevoNombre))
                {
                    MessageBox.Show("El nombre de la especialidad no puede estar vacío.");
                    return;
                }

                if (!int.TryParse(txtID_SMH.Text, out idEspecialidad))
                {
                    MessageBox.Show("El ID de la especialidad debe ser un número entero válido.");
                    return;
                }

                string connectionString = "Server=localhost;Database=PRN3_S2_B1_23_SMH;Uid=root;Pwd=;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE Especialidades_SMH SET Especialidad_nombre = @nombre, Descripcion_Especialidad = @descripcion WHERE Id_Especialidad = @id";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombre", nuevoNombre);
                        command.Parameters.AddWithValue("@descripcion", nuevaDescripcion);
                        command.Parameters.AddWithValue("@id", idEspecialidad);

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
