﻿using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml.Linq;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;

namespace AlphaBIM
{
    public partial class AlphaBIM_AddInsWPF1_duan1Window
    {
        private AlphaBIM_AddInsWPF1_duan1ViewModel _viewModel;

        public AlphaBIM_AddInsWPF1_duan1Window(AlphaBIM_AddInsWPF1_duan1ViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = viewModel;

        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space || e.Key == Key.Enter)
            {
                DialogResult = true;
                Close();
            }

            if (e.Key == Key.Escape)
            {
                DialogResult = false;
                Close();
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();

           
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("https://alphabimvn.com/vi");
            }
            catch (Exception)
            {
            }
        }

        #region Copy Title bar

        private void OpenWebSite(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("https://alphabimvn.com/vi");
            }
            catch (Exception)
            {
            }
        }

        private void CustomDevelopment(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("http://bit.ly/3bNeJek");
            }
            catch (Exception)
            {
            }
        }

        private void Feedback(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("mailto:contact@alphabimvn.com");
            }
            catch (Exception)
            {
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Chonnhieutuonglaythetich();
        }
        #endregion
    }
}
