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
using VendasMarcos.Models;
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
        public string Usuario { get; set; }
        public string Senha { get; set; }

        public TelaLogin(string usuario, string senha)
        {
            Usuario = usuario;
            Senha = senha;
        }

        public TelaLogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
