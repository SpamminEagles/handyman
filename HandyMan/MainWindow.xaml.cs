﻿using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HandyMan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            Scripts.Central.Setup();
        }

        ~MainWindow()
        {
            //Nothin' yet
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void MB_Dictionary_Click(object sender, RoutedEventArgs e)
        {
            Uri src = new Uri("Frames/Dictionary.xaml", UriKind.Relative);
            Frame.Source = src;
        }

        private void MB_Notebook_Click(object sender, RoutedEventArgs e)
        {

        }

        private void quit_Click(object sender, RoutedEventArgs e)
        {
            Scripts.Central.Shutdown();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            HandyMan.Scripts.Central.Shutdown();
        }

        private void SaveDic_Click(object sender, RoutedEventArgs e)
        {
            Scripts.Central.SaveDictionaries(Types.Languages.Russian);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
