﻿using MahApps.Metro.Controls;
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

namespace VendasMarcos.Views
{
    public partial class LocalizarClientes : MetroWindow
    {
        public LocalizarClientes()
        {
            InitializeComponent();
        }

        private void PesquisarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PesquisarClienteButton_Click(object sender, RoutedEventArgs e)
        {

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
