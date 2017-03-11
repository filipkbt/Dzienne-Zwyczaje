using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DzienneZwyczaje_1._0.ModelDanych;
using Windows.Storage;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace DzienneZwyczaje_1._0
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        
       
        public MainPage()
        {
           

            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {


            var zwyczaje = await App.ModelDanych.PobierzZwyczaje();
            
            this.DataContext = zwyczaje;
         

          
        }

      
        private void DodajZwyczaj_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DodajZwyczaj));
            ClickDzwiek.Play();

            
        }

       
     

      

        private void UkonczoneBtn_Click(object sender, RoutedEventArgs e)
        {
            ClickDzwiek.Play();
        }

        private void UsunBtn_Click(object sender, RoutedEventArgs e)
        {
            ClickDzwiek.Play();
        }
    }
}
