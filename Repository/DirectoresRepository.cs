using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Parcial2.Models;

namespace Parcial2.Repositorios
{
    public class DirectoresRepository : IDirectoresRepository
    {
        private string cadenaConexion = "Data Source=DB/movie.db;Cache=Shared";

        public List<Director> GetAll()
        {
            var queryString = @"SELECT * FROM directors;";
            List<Director> directores = new List<Director>();
            using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
            {
                SqliteCommand command = new SqliteCommand(queryString, connection);
                connection.Open();
            
                using(SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var director = new Director();
                        director.Id = Convert.ToInt32(reader["id"]);
                        director.Name = reader["name"].ToString();
                        director.Gender = Convert.ToInt32(reader["gender"]);
                        director.Uid = Convert.ToInt32(reader["uid"]);
                        directores.Add(director);
                    }
                }
                connection.Close();
            }
            return directores;
        }

        public Director GetById(int idDirector)
        {
            SqliteConnection connection = new SqliteConnection(cadenaConexion);
            var director = new Director();
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM directors WHERE id = '{idDirector}';";
            connection.Open();
            using(SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    director.Id = Convert.ToInt32(reader["id"]);
                    director.Name = reader["name"].ToString();
                    director.Gender = Convert.ToInt32(reader["gender"]);
                    director.Uid = Convert.ToInt32(reader["uid"]);
                }
            }
            connection.Close();

            return (director);
        }

        public void Create(Director director)
        {
            var query = $"INSERT INTO directors (name, gender, uid) VALUES (@name,@gender,@uid)";
            using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
            {

                connection.Open();
                var command = new SqliteCommand(query, connection);

                command.Parameters.Add(new SqliteParameter("@name", director.Name));
                command.Parameters.Add(new SqliteParameter("@gender", director.Gender));
                command.Parameters.Add(new SqliteParameter("@uid", director.Uid));

                command.ExecuteNonQuery();

                connection.Close();   
            }
        }
        
        public void Update (Director director)
        {
            SqliteConnection connection = new SqliteConnection(cadenaConexion);
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = $"UPDATE directors SET name = '{director.Name}', gender = '{director.Gender}', uid = '{director.Uid}' WHERE id = '{director.Id}';";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Remove(int id)
        {
            SqliteConnection connection = new SqliteConnection(cadenaConexion);
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM directors WHERE id = '{id}';";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}