using System;
using System.Windows;
using MahApps.Metro.Controls;
using System.Windows.Input;
using Npgsql;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Runtime.InteropServices;

namespace VendasMarcos.Views
{
    public partial class TelaLogin : MetroWindow
    {
        private bool isPasswordVisible = false;
        public bool Confirmou { get; private set; }

        private string StringConexao;

        public TelaLogin()
        {
            InitializeComponent();

            //construtores para arredondar a window
            IntPtr hWnd = new WindowInteropHelper(GetWindow(this)).EnsureHandle();
            var attribute = DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE;
            var preference = DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
            DwmSetWindowAttribute(hWnd, attribute, ref preference, sizeof(uint));

            UsuarioTextBox.Focus();
        }

        //lógica para arredondar a window
        public enum DWMWINDOWATTRIBUTE
        {
            DWMWA_WINDOW_CORNER_PREFERENCE = 33
        }
        public enum DWM_WINDOW_CORNER_PREFERENCE
        {
            DWMWCP_DEFAULT = 0,
            DWMWCP_DONOTROUND = 1,
            DWMWCP_ROUND = 2,
            DWMWCP_ROUNDSMALL = 3
        }

        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        internal static extern void DwmSetWindowAttribute(IntPtr hwnd,
                                                         DWMWINDOWATTRIBUTE attribute,
                                                         ref DWM_WINDOW_CORNER_PREFERENCE pvAttribute,
                                                         uint cbAttribute);

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            SubmeterLogin();
        }


        private void SubmeterLogin()
        {
            string usuario = UsuarioTextBox.Text;
            string senha = isPasswordVisible ? SenhaTextBox.Text : SenhaPasswordBox.Password;

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
                AppSettings.ConnectionString = StringConexao;
                this.Close();

                // Abrir MainWindow
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else
            {
                Confirmou = false;
                AppSettings.ConnectionString = "";
                loginInvalido.Visibility = Visibility.Visible;
                MessageBoxResult messageBoxResult = MessageBox.Show(
                    "Usuário ou senha inválidos.",
                    "Aviso",
                    MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
                UsuarioTextBox.Focus();
                UsuarioTextBox.SelectAll();
            }
        }

        private bool IsValidUser(string usuario, string senha)
        {
            string ip = "127.0.0.1";
            string port = "5432";
            string db = "base_habsoluta";



            if (usuario == "zeus")
            {
                StringConexao = $"Server={ip}; Port={port}; Database={db}; User Id={usuario}; Password={senha};";
            }
            else
            {
                StringConexao = $"Server={ip}; Port={port}; Database={db}; User Id={usuario}; Password=senha_padrao;";
            }

            try
            {
                using (var connection = new NpgsqlConnection(StringConexao))
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
                ToViewPassword.Template = FindResource("IconeOlhoOff") as ControlTemplate;
            }
            else
            {
                SenhaTextBox.Text = SenhaPasswordBox.Password;
                SenhaTextBox.Visibility = Visibility.Visible;
                SenhaPasswordBox.Visibility = Visibility.Collapsed;
                SenhaTextBox.Focus();
                ToViewPassword.Template = FindResource("IconeOlhoOn") as ControlTemplate;
            }

            isPasswordVisible = !isPasswordVisible;
        }


        private void TelaLoginKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (UsuarioTextBox.IsFocused)
                {
                    SenhaPasswordBox.Focus();
                    SenhaPasswordBox.SelectAll();

                    SenhaTextBox.Focus();
                    SenhaTextBox.SelectAll();
                }
                else if (SenhaPasswordBox.IsFocused || SenhaTextBox.IsFocused)
                {
                    SubmeterLogin();
                }
            }
        }
    }
}
