using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VendasMarcos.Views;
using MahApps;
using MahApps.Metro;
using MahApps.Metro.Controls;

namespace VendasMarcos.Views
{
    /// <summary>
    /// Lógica interna para TelaLogin.xaml
    /// </summary>
    public partial class TelaLogin : MetroWindow
    {
        public TelaLogin()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private static bool IsValidUser(string usuario, string senha)
        {
            string ip = "127.0.0.1";
            string port = "5432";
            string db = "base_habsoluta";

            string conexaoDB;

            if (usuario == "zeus")
            {
                conexaoDB = $"Server={ip}; Port={port}; Database={db}; User Id={usuario}; Password={senha};";
            }
            else
            {
                conexaoDB = $"Server={ip}; Port={port}; Database={db}; User Id={usuario}; Password=@2t24F5D4n75Z8foE8541Gj54gS5+878a@341R5$sGa4ES5$j%D14s#5d!5";
            }
        }

    }
}
