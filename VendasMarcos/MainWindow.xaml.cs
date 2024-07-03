using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using MahApps;
using MahApps.Metro;
using MahApps.Metro.Controls;
using VendasMarcos.Models;
using VendasMarcos.Views;

namespace VendasMarcos
{
    public partial class MainWindow : MetroWindow
    {
        BaseContext baseContext { get; set; } = new BaseContext(); // aqui você está instanciando um objeto que faz conexão com o banco, de maneira básica, se tu chamar isso em toda tela tá tranquilo, já que tu tá aprendendo a usar o ef
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LocalizarClienteButton_Click(object sender, RoutedEventArgs e)
        {
            LocalizarClientes localizarClientes = new LocalizarClientes();
            localizarClientes.ShowDialog();
        }

        private void LocalizarProdutoButton_Click(object sender, RoutedEventArgs e)
        {
            LocalizarProdutos localizarProdutos = new LocalizarProdutos();
            localizarProdutos.ShowDialog();
        }

        private void FecharAplicacaoEsc_KeyDown(object sender, KeyEventArgs e)
        {
                ShowExitConfirmation();
        }

        private void FecharAplicacaoX_Closing(object sender, CancelEventArgs e)
        {
            ShowExitConfirmation();
        }
        private void ShowExitConfirmation()
        {
            MessageBoxResult messageBoxResult = MessageBox.Show(
                "Deseja finalizar a aplicação agora?",
                "Confirmação de saída",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}