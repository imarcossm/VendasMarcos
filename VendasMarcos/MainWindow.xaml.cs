﻿using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using MahApps;
using MahApps.Metro;
using MahApps.Metro.IconPacks;
using MahApps.Metro.Controls;
using VendasMarcos.Models;
using VendasMarcos.Views;

namespace VendasMarcos
{
    public partial class MainWindow : MetroWindow
    {
        BaseContext baseContext { get; set; } = new BaseContext();
        private bool _isClosingConfirmed = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LocalizarClienteButton_Click(object sender, RoutedEventArgs e)
        {
            LocalizarClientes localizarClientes = new LocalizarClientes();
            localizarClientes.Owner = this;
            localizarClientes.ShowDialog();
        }

        private void LocalizarProdutoButton_Click(object sender, RoutedEventArgs e)
        {
            LocalizarProdutos localizarProdutos = new LocalizarProdutos();
            localizarProdutos.Owner = this;
            localizarProdutos.ShowDialog();
        }


        private void MetroWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                e.Handled = true;
                if(!_isClosingConfirmed )
                {
                    ShowExitConfirmation();
                }
            }
        }

        private void MetroWindow_Closing(object sender, CancelEventArgs e)
        {
            if (!_isClosingConfirmed)
            {
                e.Cancel = true;
                ShowExitConfirmation();
            }
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
                _isClosingConfirmed = true;
                Application.Current.Shutdown();
            }
        }
    }
}