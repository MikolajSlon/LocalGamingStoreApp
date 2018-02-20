﻿using LGSA.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace LGSA.View
{
    /// <summary>
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class ProductView : UserControl
    {
        public ProductView()
        {
            InitializeComponent();
        }

        private async void AddButtonClick(object sender, RoutedEventArgs e)
        {
            var dialog = new AddProductDialog();
            dialog.DataContext = DataContext;
            dialog.Owner = Window.GetWindow(this);
            bool? addOffer = dialog.ShowDialog();

            if (addOffer == true)
            {
                await (this.DataContext as ProductViewModel).AddProduct();
            }
        }
    }
}
