// See https://aka.ms/new-console-template for more information
using System.Data.SQLite;
using Parcial2.Models;
using Parcial2.Repositorios;

Console.WriteLine("Hello, World!");

string cadenaConexion = @"Data Source=DB/movie.db;Cache=Shared";

var queryString = @"SELECT * FROM directors;";
List<Director> directores = new List<Director>();
var repositorio = new DirectoresRepository();
directores = repositorio.GetAll();

var director = repositorio.GetById(directores[0].Id);
repositorio.Create(director);
directores = repositorio.GetAll();
int a =4;

// using (SQLiteConnection connection = new SQLiteConnection(@"Data Source=DB/movie.db;Cache=Shared"))
// {
//     connection.Open();
//     SQLiteCommand command = new SQLiteCommand(queryString, connection);
    

//     using(SQLiteDataReader reader = command.ExecuteReader())
//     {
//         while (reader.Read())
//         {
//             var director = new Director();
//             director.Id = Convert.ToInt32(reader["id"]);
//             director.Name = reader["name"].ToString();
//             director.Gender = Convert.ToInt32(reader["gender"]);
//             director.Uid = Convert.ToInt32(reader["uid"]);
//             directores.Add(director);
//         }
//     }
//     connection.Close();
// }

    
