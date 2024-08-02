using MahApps.Metro.Controls;
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
using VendasMarcos.TempModel;

namespace VendasMarcos.Views
{
    public partial class LocalizarClientes : MetroWindow
    {
        private List<ClientesView> clientes;
        private DBContext DBContext = new DBContext();
        public LocalizarClientes()
        {
            InitializeComponent();
            CarregarClientes();
        }

        public void CarregarClientes()
        {
            List<Clientes> clientes = new List<Clientes>();
            using(var context = new DBContext())
            {
                clientes = DBContext.Clientes.ToList();
            }

            ResultsClientesDataGrid.ItemsSource = clientes;
        }

        private void PesquisarClienteButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchClienteBox.Text.ToLower();

            using (var context = new DBContext())
            {
                var filtrarClientes = context.Clientes
                    .Where(c => c.Nome.ToLower().Contains(searchText))
                    .ToList();

                ResultsClientesDataGrid.ItemsSource = filtrarClientes;
            }
        }

        private void FecharJanelaClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
    }
}
