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
using MahApps.Metro.Controls;

namespace VendasMarcos.Views
{
    /// <summary>
    /// Lógica interna para LocalizarProdutos.xaml
    /// </summary>
    public partial class LocalizarProdutos : MetroWindow
    {
        public LocalizarProdutos()
        {
            InitializeComponent();
        }

        private void PesquisarProdutoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FecharJanelaProdutos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
    }
}
