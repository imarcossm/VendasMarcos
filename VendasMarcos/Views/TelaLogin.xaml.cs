using System;
using System.Windows;
using MahApps.Metro.Controls;
using System.Windows.Input;
using Npgsql;

namespace VendasMarcos.Views
{
    public partial class TelaLogin : MetroWindow
    {

        public bool Confirmou { get; private set; }

        public TelaLogin()
        {
            InitializeComponent();
            UsuarioTextBox.Focus();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string usuario = UsuarioTextBox.Text;
            string senha = SenhaPasswordBox.Password;

            if (IsValidUser(usuario, senha))
            {
                Confirmou = true;
                this.Close();
            }
            else
            {
                Confirmou = false;
                loginInvalido.Visibility = Visibility.Visible;
                MessageBox.Show("Usuário ou senha inválidos.");
            }
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
                conexaoDB = $"Server={ip}; Port={port}; Database={db}; User Id={usuario}; Password=senha_padrao;";
            }

            try
            {
                using (var connection = new NpgsqlConnection(conexaoDB))
                {
                    connection.Open();

                    string query = $"SELECT 1 FROM usuarios WHERE login = @usuario AND pass = md5(@senha);";
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("usuario", usuario);
                        cmd.Parameters.AddWithValue("senha", senha);

                        var result = cmd.ExecuteScalar();
                        return result != null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao conectar ao banco de dados: {ex.Message}");
                return false;
            }
        }

        private void UsuarioTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SenhaPasswordBox.Focus(); // Muda o foco para a PasswordBox
                e.Handled = true;
            }
        }

        private void SenhaPasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Define o foco no botão de login sem chamar o método de clique
                LoginButton.Focus();
                e.Handled = true;
            }
        }

 
    }
}
