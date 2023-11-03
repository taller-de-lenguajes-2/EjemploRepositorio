using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
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
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(queryString, connection);
                connection.Open();
            
                using(SQLiteDataReader reader = command.ExecuteReader())
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
            SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
            var director = new Director();
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM directors WHERE id = '{idDirector}';";
            command.CommandText = "SELECT * FROM directors WHERE id = @idDirector";
            command.Parameters.Add(new SQLiteParameter("@idDirector", idDirector));
            connection.Open();
            using(SQLiteDataReader reader = command.ExecuteReader())
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
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {

                connection.Open();
                var command = new SQLiteCommand(query, connection);

                command.Parameters.Add(new SQLiteParameter("@name", director.Name));
                command.Parameters.Add(new SQLiteParameter("@gender", director.Gender));
                command.Parameters.Add(new SQLiteParameter("@uid", director.Uid));

                command.ExecuteNonQuery();

                connection.Close();   
            }
        }
        
        public void Update (Director director)
        {
            SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = $"UPDATE directors SET name = '{director.Name}', gender = '{director.Gender}', uid = '{director.Uid}' WHERE id = '{director.Id}';";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Remove(int id)
        {
            SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM directors WHERE id = '{id}';";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}