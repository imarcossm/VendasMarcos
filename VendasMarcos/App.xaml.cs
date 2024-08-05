using System.Configuration;
using System.Data;
using System.Windows;
using VendasMarcos.Views;

namespace VendasMarcos
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            TelaLogin telaLogin = new TelaLogin();
            bool? result = telaLogin.ShowDialog();

            if (result.HasValue && result.Value)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else
            {
                // Se o login falhar ou o usuário fechar a tela de login, encerra a aplicação
                this.Shutdown();
            }
        }
    }

}
