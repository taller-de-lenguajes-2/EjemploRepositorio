// See https://aka.ms/new-console-template for more information
using Microsoft.Data.Sqlite;
using Parcial2.Models;

Console.WriteLine("Hello, World!");

string cadenaConexion = @"Data Source=DB/movie.db;Cache=Shared";

var queryString = @"SELECT * FROM directors;";
List<Director> directores = new List<Director>();
using (SqliteConnection connection = new SqliteConnection(@"Data Source=DB/movie.db;Cache=Shared"))
{
    connection.Open();
    SqliteCommand command = new SqliteCommand(queryString, connection);
    

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

    
