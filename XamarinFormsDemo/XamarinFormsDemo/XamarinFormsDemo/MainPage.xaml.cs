using System;
using Xamarin.Forms;
using XamarinFormsDemo.ViewModels;

namespace XamarinFormsDemo
{
    /// <summary>
    /// Back end class for MainPage.xaml
    /// </summary>
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new AdditionViewModel();
        }        
    }
}
