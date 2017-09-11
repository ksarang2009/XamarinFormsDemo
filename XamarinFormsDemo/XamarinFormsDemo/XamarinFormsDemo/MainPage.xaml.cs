using System;
using Xamarin.Forms;

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
            var btnCalculate = this.FindByName<Button>("btnCalculate");
            btnCalculate.Clicked += btnCalculate_Clicked;
        }

        /// <summary>
        /// Handles the Clicked event of the btnCalculate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCalculate_Clicked(object sender, EventArgs e)
        {
            int param1, param2;
            if (int.TryParse(txtParam1.Text, out param1) && int.TryParse(txtParam2.Text, out param2))
            {
                txtResult.Text = Addition(param1, param2).ToString();
                return;
            }

            txtResult.Text = "Invalid input.";
        }

        /// <summary>
        /// Adds the specified param1 & param2.
        /// </summary>
        /// <param name="param1">The param1.</param>
        /// <param name="param2">The param2.</param>
        /// <returns></returns>
        private int Addition(int param1, int param2)
        {
            while (param2 != 0)
            {
                int carry = param1 & param2;
                param1 = param1 ^ param2;
                param2 = carry << 1;
            }
            return param1;
        }
    }
}
