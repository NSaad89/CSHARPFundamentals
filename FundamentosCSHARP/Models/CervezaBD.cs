using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace FundamentosCSHARP.Models
{
    class CervezaBD
    {
        private string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=FundamentosCSHARP;Data Source=LAPTOP-47CP43CH";

        public List<Cerveza> Get()
        {
            List<Cerveza> cervezas = new List<Cerveza>();

            string query = "SELECT * " + "FROM CERVEZA";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int Cantidad = reader.GetInt32(4);
                    string Nombre = reader.GetString(1);

                    Cerveza cerveza = new Cerveza(Cantidad, Nombre);

                    string Marca = reader.GetString(2);
                    int Alcohol = reader.GetInt32(3);

                    cervezas.Add(cerveza);
                }

                reader.Close();
                connection.Close();
            }

            return cervezas;
        }

        public void Add(Cerveza cerveza)
        {

            string query = "INSERT INTO CERVEZA VALUES (@nombre, @marca, @alcohol, @cantidad);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@nombre", cerveza.Nombre);
                command.Parameters.AddWithValue("@marca", cerveza.Marca);
                command.Parameters.AddWithValue("@alcohol", cerveza.Alcohol);
                command.Parameters.AddWithValue("@cantidad", cerveza.Cantidad);

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }

        }

        public void Edit(Cerveza cerveza, int Id)
        {

            string query = "UPDATE CERVEZA SET nombre=@nombre, marca=@marca, alcohol=@alcohol, cantidad=@cantidad "+
                            "WHERE id=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@nombre", cerveza.Nombre);
                command.Parameters.AddWithValue("@marca", cerveza.Marca);
                command.Parameters.AddWithValue("@alcohol", cerveza.Alcohol);
                command.Parameters.AddWithValue("@cantidad", cerveza.Cantidad);
                command.Parameters.AddWithValue("@id", Id);

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }

        }

        public void Delete(int Id)
        {

            string query = "DELETE FROM CERVEZA WHERE id=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", Id);

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }

        }

    }
}
