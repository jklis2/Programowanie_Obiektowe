﻿using DevExpress.Xpf.Core;
using DXApplication1.Widoki.Pracownicy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DXApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DodajPracownika(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            Pracownicy widok = new Pracownicy();
            widok.ShowDialog();
        }
    }
}
