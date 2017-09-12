using XamarinFormsDemo.Interfaces;

namespace XamarinFormsDemo.Services
{
    public class CalculateService : ICalculateService
    {
        public int Addition(int firstValue, int secondValue)
        {
            while (secondValue != 0)
            {
                int carry = firstValue & secondValue;
                firstValue = firstValue ^ secondValue;
                secondValue = carry << 1;
            }
            return firstValue;
        }
    }
}
