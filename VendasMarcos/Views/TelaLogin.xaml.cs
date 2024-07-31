using System;
using System.Windows;
using MahApps.Metro.Controls;
using System.Windows.Input;
using Npgsql;

namespace VendasMarcos.Views
{
    public partial class TelaLogin : MetroWindow
    {
        private bool isPasswordVisible = false;
        public bool Confirmou { get; private set; }

        public TelaLogin()
        {
            InitializeComponent();
            UsuarioTextBox.Focus();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            SubmeterLogin();
        }


        private void SubmeterLogin()
        {
            string usuario = UsuarioTextBox.Text;
            string senha = SenhaPasswordBox.Password;

            if (isPasswordVisible)
            {
                senha = SenhaTextBox.Text;
            }
            else
            {
                senha = SenhaPasswordBox.Password;
            }

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
                UsuarioTextBox.Focus();
                UsuarioTextBox.SelectAll();
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

        private void PasswordVisibility_Click(object sender, RoutedEventArgs e)
        {
            if (isPasswordVisible)
            {
                SenhaPasswordBox.Password = SenhaTextBox.Text;
                SenhaTextBox.Visibility = Visibility.Collapsed;
                SenhaPasswordBox.Visibility = Visibility.Visible;
                SenhaPasswordBox.Focus();
            }
            else
            {
                SenhaTextBox.Text = SenhaPasswordBox.Password;
                SenhaTextBox.Visibility = Visibility.Visible;
                SenhaPasswordBox.Visibility = Visibility.Collapsed;
                SenhaTextBox.Focus();
            }

            isPasswordVisible = !isPasswordVisible;
        }

        private void TelaLoginKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                if(UsuarioTextBox.IsFocused)
                {
                    SenhaPasswordBox.Focus();
                    SenhaPasswordBox.SelectAll();

                    SenhaTextBox.Focus();
                    SenhaTextBox.SelectAll();
                }
                else if(SenhaPasswordBox.IsFocused || SenhaTextBox.IsFocused)
                {
                    SubmeterLogin();
                }
            }
        }
    }
}
