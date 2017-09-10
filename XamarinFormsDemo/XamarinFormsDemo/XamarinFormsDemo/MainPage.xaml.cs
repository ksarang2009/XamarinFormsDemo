using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFormsDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var btnCalculate = this.FindByName<Button>("btnCalculate");
            btnCalculate.Clicked += btnCalculate_Clicked;
        }

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
