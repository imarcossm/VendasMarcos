﻿#pragma checksum "..\..\..\..\Views\LocalizarProdutos.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "19BD7CBA3644D1FC22B64E1EDA975179240BFC52"
//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro;
using MahApps.Metro.Accessibility;
using MahApps.Metro.Actions;
using MahApps.Metro.Automation.Peers;
using MahApps.Metro.Behaviors;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Converters;
using MahApps.Metro.Markup;
using MahApps.Metro.Theming;
using MahApps.Metro.ValueBoxes;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using VendasMarcos.Views;


namespace VendasMarcos.Views {
    
    
    /// <summary>
    /// LocalizarProdutos
    /// </summary>
    public partial class LocalizarProdutos : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\..\Views\LocalizarProdutos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BuscarProdutoBox;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Views\LocalizarProdutos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PesquisarProdutoButton;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\Views\LocalizarProdutos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ResultsProdutosDataGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/VendasMarcos;component/views/localizarprodutos.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\LocalizarProdutos.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 16 "..\..\..\..\Views\LocalizarProdutos.xaml"
            ((VendasMarcos.Views.LocalizarProdutos)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.FecharJanelaProdutos_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BuscarProdutoBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.PesquisarProdutoButton = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\..\Views\LocalizarProdutos.xaml"
            this.PesquisarProdutoButton.Click += new System.Windows.RoutedEventHandler(this.PesquisarProdutoButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ResultsProdutosDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

