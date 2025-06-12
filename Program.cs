using System;
using System.Data;
using System.Globalization;
using Dapper;
using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Computer myComputer = new Computer()
            {
                Motherboard = "Ajsja",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 944.87m,
                VideoCard = "R 2aw60"
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

          
            
            
        }
    }
}