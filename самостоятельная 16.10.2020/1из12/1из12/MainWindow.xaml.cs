﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _1из12
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void red1_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Page1();
        }

        private void red2_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Page2();
        }

        private void red3_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Page3();
        }
    }
}
