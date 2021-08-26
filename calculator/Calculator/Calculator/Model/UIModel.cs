using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Calculator.Model
{
    public class UIModel
    {
        public string History { get; set; }
        public string CurrentValue { get; set; }
        public string Result { get; set; }
        public bool IsResultVisible { get; set; }
        public ICommand FunctionsCommand { get => new RelayCommand(BtnFunctionsTap); }
        public ICommand OperationsCommand { get => new RelayCommand(BtnOperationsTap); }
        public ICommand NumbersCommand { get => new RelayCommand(BtnNumbersTap); }

        public UIModel()
        {
            CurrentValue = "0";
        }

        private void BtnFunctionsTap()
        {

        }

        private void BtnOperationsTap()
        {

        }

        private void BtnNumbersTap()
        {

        }

    }
}
