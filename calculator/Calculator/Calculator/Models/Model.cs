using Calculator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Calculator
{
    public class Model : INotifyPropertyChanged
    {
        private string currentValue;
        private string result;

        public string CurrentValue
        {
            get => currentValue;
            set
            {
                if (!value.Contains("%"))
                {
                    currentValue = value;
                }
                else
                {
                    //TO-DO:
                    //Figure out a way to get the percentaje of the current expression value.
                }
                OnPropertyChanged(nameof(Result));
            }
        }

        public string Result
        {
            get => "= " + Calculations.CalculateInput(currentValue);
            set => result = value;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Model()
        {
            currentValue = "0";
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (propertyName != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
