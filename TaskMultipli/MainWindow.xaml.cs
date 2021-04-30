﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace TaskMultipli
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnEsegui_Click(object sender, RoutedEventArgs e)
        {
            int a = int.Parse(txtNumero.Text);

            Progress.Minimum = 0;
            Progress.Maximum = 100;
            Progress.Value = 0;

            TrovaMultipli(a);
            //Task<int> t1 = Task.Factory.StartNew(() => TrovaMultipli(a),
            //    CancellationToken.None,
            //    TaskCreationOptions.LongRunning,
            //    TaskScheduler.Default
            //    );
            //lblOutput.Content = $"{t1.Result}";

        }

        private async Task<int> TrovaMultipli(int a)
        {
            int multipli = 0;
            await Task.Run(() =>
            {
                for (int c = 0; c < 200000000; c++)
                {
                    if (c % a == 0)
                    {
                        multipli++;
                    }
                    if (c % 2000000 == 0)
                    {
                        Progress.Dispatcher.Invoke(() =>
                        {
                            Progress.Value++;
                        });
                    }
                }
            });
            
            lblOutput.Dispatcher.Invoke(() =>
            {
                lblOutput.Content = multipli;
            });
            return multipli;
        }

        private void btnPrimi_Click(object sender, RoutedEventArgs e)
        {
            lblPrimi.Content = "";
            bool nprimo = true;
            int a = int.Parse(txtNumero.Text);
            for (int c = 2; c <= a / 2; c++)
            {
                if (a % c == 0)
                    nprimo = false;
            }
            if (nprimo == false)
            {
                lblPrimi.Content = "Non è un numero primo";
            }
            else
            {
                lblPrimi.Content = "E' un numero primo ";
            }

        }
    }
}
