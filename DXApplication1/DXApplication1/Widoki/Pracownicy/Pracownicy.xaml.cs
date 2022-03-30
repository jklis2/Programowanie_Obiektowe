using DevExpress.Xpf.Core;
using DXApplication1.Serwisy;
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
using System.Windows.Shapes;


namespace DXApplication1.Widoki.Pracownicy
{
    /// <summary>
    /// Interaction logic for Pracownicy.xaml
    /// </summary>
    public partial class Pracownicy : ThemedWindow
    {
        PracownicyService servicePracownicy = new PracownicyService();
        public Pracownicy()
        {
            InitializeComponent();

            comboBoxPracownicy.ItemsSource = servicePracownicy.WszyscyPracownicy();
        }
    }
}
