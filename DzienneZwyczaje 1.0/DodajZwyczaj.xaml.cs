using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace DzienneZwyczaje_1._0
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DodajZwyczaj : Page
    {
        public DodajZwyczaj()
        {
            this.InitializeComponent();
            LadujComboBox();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

        private void LadujComboBox()
        {
            for (int i = 1; i <= 365; i++)
                maxComboBox.Items.Add(i);
        }
        private void dodajBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NazwaTextBox.Text != "" && maxComboBox.SelectedItem != null)
            {
                App.ModelDanych.DodajZwyczaj(NazwaTextBox.Text, OpisTextBox.Text,(int)maxComboBox.SelectedValue);
                Frame.Navigate(typeof(MainPage));
                ClickDzwiek.Play();
            }
            else
            {
                
                MessageDialog msgbox = new MessageDialog("Wypełnij pola z nazwą zwyczaju oraz ilością dni !","Nie wypełniłeś poprawnie pól.");
              
             
                msgbox.ShowAsync();
            }

        }

        private void powrotBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
            ClickDzwiek.Play();
        }

       
    }
}
