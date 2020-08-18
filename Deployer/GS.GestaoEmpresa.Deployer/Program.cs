using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GS.GestaoEmpresa.Deployer
{
    public class Program
    {
        private static readonly string BaseDeployDirectory = @"\\192.168.15.250\Publico\Almoxarifado\03 - Sistema de Gestao";
        private static readonly string[] ListOfDeployDiretories =
        {
            $"{BaseDeployDirectory}\\Instalacao",
            $"{BaseDeployDirectory}\\InstalacaoJunio",
            $"{BaseDeployDirectory}\\InstalacaoLelya",
            $"{BaseDeployDirectory}\\InstalacaoAna",
        };

        public static void Main(string[] args)
        {
            var directory = AppDomain.CurrentDomain.BaseDirectory.Replace("Deployer\\GS.GestaoEmpresa.Deployer\\bin\\Debug\\netcoreapp3.1\\", "Binarios");

            var listOfFiles = Directory.GetFiles(directory)
                .Where(x => x.EndsWith(".dll") ||
                            x.EndsWith(".exe"))
                .ToList();

            foreach (var deployDirectory in ListOfDeployDiretories.ToList())
            foreach (var file in listOfFiles)
            {
                var fileName = Path.GetFileName(file);
                File.Copy(file, Path.Combine(deployDirectory, fileName), true);
            }

            Console.WriteLine("Deployed Sucessfully!");
        }
    }
}
