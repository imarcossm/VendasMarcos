   M S B A M L   `   `   `  ����G  CVendasMarcos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:VendasMarcos.ViewsVendasMarcos.Views  5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	   *    $VendasMarcos.Views.LocalizarProdutos   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:VendasMarcos.Views     5   	   8metro,http://metro.mahapps.com/winfx/xaml/controls  5   	   Emah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   -   5          � Title$  Produtos��5
   	   $	��450��5   	   $
��1000��5   	   $	��400��5   	   $	��650��5   	   
������� � ShowInTaskbar$ False��5   	      MahApps.Brushes.Accent(  "MahApps.Metro.Controls.MetroWindow   	GlowBrush# �   5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5    
   �� -   5         ��Name$ BuscarProdutoBox��5       $��0��5!      $��0��5"      $��0,0,10,0q�5#      $��Center=�5$      *  $MahApps.Metro.Controls.TextBoxHelper   	Watermark$! Digite o nome do produto...��5%         WatermarkWrapping$
 Wrap=�6L   �� 5'   
   -   5        	 ��Name$	 PesquisarProdutoButton��5'      $
��Bold"�5(      $��12(�5)      $��0��5*      $��1��5+      $��	Pesquisar��5,      $��Center=�5-      
 �� 	ClickMode$
 Hover=�5.      5/      &   System.Windows.Controls.DataGrid  51   
   -   5          Name$ ResultsProdutosDataGrid��51      $��1��52      $��2��53         AutoGenerateColumns$ False��54         CanUserAddRows$ False��55         CanUserDeleteRows$ False��56         CanUserResizeRows$ False��57         
IsReadOnly$
 True��58      $��0 10 0 0q�59         Columns 5:      0  *System.Windows.Controls.DataGridTextColumn  5;      ,  &System.Windows.Controls.DataGridColumn   Header$ Código��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6P      MinWidth$ 75Q�6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Codigo+6[     5<      $
 Nome��6%   $ * 6L    63   �� *Nome+6L     5=      $ 
Quantidade��6%   $ * 6R    69   �� *refq+6R     5>      $ Preço��6%   $	 150 6S    64   �� *
precovenda+6S   5@      5A      5B      