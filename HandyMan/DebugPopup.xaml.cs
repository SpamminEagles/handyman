﻿using System.Windows;


namespace HandyMan
{
    /// <summary>
    /// Interaction logic for DebugPopup.xaml
    /// </summary>
    public partial class DebugPopup : Window
    {
        //string TextToShow;
        public DebugPopup(string param = "DEBUG!!")
        {
            InitializeComponent();
            //TextToShow = param;
        }

        /*private void label_Loaded(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = TextToShow;
        }*/
    }
}
