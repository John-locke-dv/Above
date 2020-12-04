using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Microsoft.AspNetCore.Http;
using PdD2.DAOs;
using Tp2.Models;
using System.Data.Common;

namespace Tp2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MiMain();
            var connString = "Server=localhost;Database=base1;Uid=root;Pwd=;";
             DBConnection.getInstance().connect(connString);
            CreateHostBuilder(args).Build().Run();
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void MiMain()
        {

            UsuariosDAO.getInstancia()
                .Add(new Usuario(1,"john", "wick"))
                .Add(new Usuario(2,"123", "123"))
                .Add(new Usuario(3, "pep", "pep"));



            
        }
    }
}
