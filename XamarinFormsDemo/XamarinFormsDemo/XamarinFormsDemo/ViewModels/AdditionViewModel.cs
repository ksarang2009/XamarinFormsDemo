using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFormsDemo.ViewModels
{
    public class AdditionViewModel : INotifyPropertyChanged
    {
        public AdditionViewModel()
        {
            AdditionCommand = new Command(CalculateAddition);
        }

        string firstParameter = string.Empty;
        string secondParameter = string.Empty;
        int firstValue, secondValue;
        string result;

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string FirstParameter
        {
            get { return firstParameter; }
            set
            {
                firstParameter = value;
            }
        }

        public string SecondParameter
        {
            get { return secondParameter; }
            set
            {
                secondParameter = value;
            }
        }

        public string Result
        {
            get { return result; }
            set { result = value; }
        }
        
        public Command AdditionCommand { get; set; }

        void CalculateAddition()
        {
            try
            {
                if (int.TryParse(firstParameter, out firstValue) && int.TryParse(secondParameter, out secondValue))
                {
                    while (secondValue != 0)
                    {
                        int carry = firstValue & secondValue;
                        firstValue = firstValue ^ secondValue;
                        secondValue = carry << 1;
                    }
                    result = firstValue.ToString();
                }
                else
                {
                    result = "Invalid input.";
                }                
            }
            catch (Exception)
            {
                Result = string.Empty;
            }
            finally
            {
                OnPropertyChanged(nameof(Result));
            }
        }
    }
}
