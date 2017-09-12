using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using XamarinFormsDemo.Interfaces;
using XamarinFormsDemo.Services;
using XamarinFormsDemo.Utilities;

namespace XamarinFormsDemo.ViewModels
{
    public class AdditionViewModel : INotifyPropertyChanged
    {
        public AdditionViewModel()
        {
            AdditionCommand = new Command(CalculateAddition);
            calculateService = new CalculateService();
        }

        string firstParameter = string.Empty;
        string secondParameter = string.Empty;
        int firstValue, secondValue;
        string result;
        ICalculateService calculateService;

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
                    result = calculateService.Addition(firstValue, secondValue).ToString();
                }
                else
                {
                    result = Constants.ErrorMessage;
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
