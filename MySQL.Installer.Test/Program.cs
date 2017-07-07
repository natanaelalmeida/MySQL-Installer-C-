using MySQL.Installer.Util.Infra;
using MySQL.Installer.Util.Install;
using System;

namespace MySQL.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Validations.IsProgramInstalled("MySQL Installer - Community"))
            {
                Console.WriteLine("Instalando MySQL Installer...");
                var teste = new MySQLInstaller("mysql-installer-community-5.7.18.1.msi");
                teste.Init();
                if(teste.IsSuccessInstallation())
                    Console.WriteLine("Instalação efetuada com sucesso!");
                else
                    Console.WriteLine("Falha na instalação!");
            }

            Console.ReadKey();
        }
    }
}
