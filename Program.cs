using System;
using System.Data;
using System.Globalization;
using Dapper;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=True;User Id=SA;Password=SQLConnect1!";

            IDbConnection dbConnection = new SqlConnection(connectionString);

            string sqlCommand = "SELECT GETDATE()";

            DateTime rightNow = dbConnection.QuerySingle<DateTime>(sqlCommand);

            Console.WriteLine(rightNow.ToString());

            Computer myComputer = new Computer()
            {
                Motherboard = "Z690",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 943.87m,
                VideoCard = "RTX 2060"
            };

            string sql = @"INSERT INTO TutorialAppSchema.Computer (
                Motherboard,
                HasWifi,
                HasLTE,
                ReleaseDate,
                Price,
                VideoCard
            ) VALUES ('" + myComputer.Motherboard
                   + "','" + myComputer.HasWifi
                   + "','" + myComputer.HasLTE
                   + "','" + myComputer.ReleaseDate
                   + "','" + myComputer.Price.ToString("0.00", CultureInfo.InvariantCulture)
                   + "','" + myComputer.VideoCard
           + "')";

            Console.WriteLine(sql);
            int result = dbConnection.Execute(sql);
            Console.WriteLine($"Number of rows affected: {result}");


            string sqlSelect = @"
            SELECT 
                Computer.Motherboard,
                Computer.HasWifi,
                Computer.HasLTE,
                Computer.ReleaseDate,
                Computer.Price,
                Computer.VideoCard
             FROM TutorialAppSchema.Computer";

            IEnumerable<Computer> computers = dbConnection.Query<Computer>(sqlSelect);

            Console.WriteLine("'Motherboard','HasWifi','HasLTE','ReleaseDate','Price','VideoCard'");

            foreach (Computer singleComputer in computers)
            {
                Console.WriteLine("'" + singleComputer.Motherboard
                   + "','" + singleComputer.HasWifi
                   + "','" + singleComputer.HasLTE
                   + "','" + singleComputer.ReleaseDate
                   + "','" + singleComputer.Price.ToString("0.00", CultureInfo.InvariantCulture)
                   + "','" + singleComputer.VideoCard
           + "'");

            }
        }
    }
}