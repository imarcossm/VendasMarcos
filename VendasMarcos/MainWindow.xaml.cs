using System.Windows;
using MahApps;
using MahApps.Metro;
using VendasMarcos.Models;
using VendasMarcos.Views;

namespace VendasMarcos
{
    public partial class MainWindow
    {
        BaseContext baseContext {  get; set; } = new BaseContext(); // aqui você está instanciando um objeto que faz conexão com o banco, de maneira básica, se tu chamar isso em toda tela tá tranquilo, já que tu tá aprendendo a usar o ef
        public MainWindow()
        {
            InitializeComponent();
            var usuariosPersistentes = baseContext.Usuarios.ToList(); //aqui está sendo usado o objeto para consultar, veja que usa um .Usuarios, isso porque o modelo da tabela usuarios foi mapeada, se quiser usar produtos, por exemplo, precisa mapear também, já mostro
            //ProdutosDataGrid.ItemsSource = usuariosPersistentes; //ali encima tu fez uma lista com todos os usuários do banco, agora tu pode jogar isso diretamente para a tabela usando o ItemsSource
            //la na datagrid, onde tem as colunas, é onde voce define o que será exibido, por isso eu alterei o Biding. A tabela recebe a lista desse modelo, mas só mostra o que voce definiu ali dentro


            //ah mas como eu insiro um novo usuário por aqui? primeiro tu instancia um objeto usuario, coloca as atribuições dele e depois dá um baseContext.Usuarios.Add(novoUsuario); para remover e o mesmo esquema baseContext.Usuarios.Remove(UsuarioExistente);
        }

        private void LocalizarClienteButton_Click(object sender, RoutedEventArgs e)
        {
            LocalizarClientes localizarClientes = new LocalizarClientes();
            localizarClientes.ShowDialog();
        }

        private void LocalizarProdutoButton_Click(object sender, RoutedEventArgs e)
        {
            LocalizarProdutos localizarProdutos = new LocalizarProdutos();
            localizarProdutos.Show();
        }
    }
}
