using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Drawing;
using System.Security.Cryptography;

namespace DSDPRN3_SMH_2302B1
{
    internal class Conexion_SMH
    {
        //Implementa la cadena de conexión a la base de datos MySQL.
        private string connectionString = "Server=localhost;Database=PRN3_S2_B1_23_SMH;Uid=root;Pwd=;";
        public Conexion_SMH(string connectionString)
        {
            this.connectionString = connectionString;

        }

        //1.Conexiones para el catalogo PACIENTES
        public void InsertPaciente(Paciente_SMH paciente)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO Pacientes_SMH (Nombre, ApellidoPaterno, ApellidoMaterno, Direccion, " +
                        "Telefono, Celular, Edad, Sexo, Email) " +//Id_EstadoCivil
                    "VALUES (@Nombre, @ApellidoPaterno, @ApellidoMaterno, @Direccion, " +
                    "@Telefono, @Celular, @Edad, @Sexo, @Email)"; //@Id_EstadoCivil

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", paciente.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", paciente.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@Direccion", paciente.Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", paciente.Telefono);
                    cmd.Parameters.AddWithValue("@Celular", paciente.Celular);
                    cmd.Parameters.AddWithValue("@Edad", paciente.Edad);
                    cmd.Parameters.AddWithValue("@Sexo", paciente.Sexo);
                    cmd.Parameters.AddWithValue("@Email", paciente.Email);
                    //cmd.Parameters.AddWithValue("@Id_EstadoCivil", paciente.EstadoCivil.Id_EstadoCivil); // Asume que tienes un objeto EstadoCivil en la clase Paciente
                    
                    cmd.ExecuteNonQuery();

                    connection.Close();
                    MessageBox.Show($"Datos del paciente guardados correctamente");
                }
                catch (Exception error)
                {
                    MessageBox.Show($"Error de conexión: {error.Message}");
                }
            }
        }
        public void EliminarPaciente(int idPaciente)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM Pacientes_SMH WHERE Id_paciente = @Id_paciente";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Id_paciente", idPaciente);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el paciente: {ex.Message}");
                }
            }
        }
        

        //2.Conexiones para el catalogo ESTADO CIVIL
        public void InsertEstadoCivil(EstadoCivil_SMH estadoCivil)
        {

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    //Abre la conexion
                    connection.Open();
                    //Ejecuta el query
                    string query = "INSERT INTO EstadoCivil_SMH (EstadoCivil_nombre) VALUES (@EstadoCivil_nombre)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //cmd.Parameters.AddWithValue("@Id_EstadoCivil", estadoCivil.Id_EstadoCivil);
                    cmd.Parameters.Add("@EstadoCivil_nombre",MySqlDbType.VarChar).Value= estadoCivil.EstadoCivil_nombre;
                    //Obten los resultados del comando implementado
                    cmd.ExecuteNonQuery();

                    connection.Close();
                    MessageBox.Show($"Datos guardados correctamente");
                }
                catch (Exception error)
                {

                    MessageBox.Show($"Error de conexion: {error.Message}");
                }
                
            }
        }
        public void EliminarEstadoCivil(int idEstadoCivil)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM EstadoCivil_SMH WHERE Id_EstadoCivil = @Id_EstadoCivil";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Id_EstadoCivil", idEstadoCivil);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el estado civil: {ex.Message}");
                }
            }
        }



        //3.Conexiones para el catalogo MEDICOS
        public void InsertMedico(Medico_SMH medico)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO Medicos_SMH (Nombre, ApellidoPaterno, ApellidoMaterno, Cedula)" +
                                   "VALUES (@Nombre, @ApellidoPaterno, @ApellidoMaterno, @Cedula)";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Nombre", medico.Nombre);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", medico.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", medico.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@Cedula", medico.Cedula);
                    cmd.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception error)
                {
                    throw new Exception($"Error al insertar el registro: {error.Message}");
                }
            }
        }
        public void EliminarMedico(int idMedico)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM Medicos_SMH WHERE Id_medico = @Id_medico";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Id_medico", idMedico);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el médico: {ex.Message}");
                }
            }
        }


        //4.Conexiones para el catalogo ESPECIALIDADES
        public void InsertEspecialidad(Especialidad_SMH especialidad)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO Especialidades_SMH (Especialidad_nombre, Descripcion_Especialidad) " +
                                   "VALUES (@Especialidad_nombre, @Descripcion_Especialidad)";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Especialidad_nombre", especialidad.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion_Especialidad", especialidad.Descripcion);

                    cmd.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception error)
                {
                    throw new Exception($"Error al insertar la especialidad: {error.Message}");
                }
            }
        }
        public void EliminarEspecialidad(int idEspecialidad)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM Especialidades_SMH WHERE Id_Especialidad = @Id_Especialidad";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Id_Especialidad", idEspecialidad);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar la especialidad: {ex.Message}");
                }
            }
        }
    }
}
