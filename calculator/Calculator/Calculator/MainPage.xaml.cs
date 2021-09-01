using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        private bool HasDot;
        public MainPage()
        {
            InitializeComponent();
            InitButtonsStyle();
        }

        private void InitButtonsStyle()
        {
            foreach (Button button in GridNumbers.Children.OfType<Button>())
            {
                button.FontSize = 25;
                button.HeightRequest = 60;
                button.CornerRadius = 30;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void FunctionsTapped(object sender, EventArgs e)
        {
            Button funPressed = sender as Button;
            switch (funPressed.Text)
            {
                case "C":
                    LblCurrentValue.Text = "0";
                    BtnClear.Text = "AC";
                    LblResult.IsVisible = false;
                    HasDot = false;
                    break;
                case "⌫":
                    if (LblCurrentValue.Text.Length > 1)
                    {
                        LblCurrentValue.Text = LblCurrentValue.Text.Remove(LblCurrentValue.Text.Length - 1);
                    }
                    else
                    {
                        LblCurrentValue.Text = "0";
                        BtnClear.Text = "AC";
                        LblResult.IsVisible = false;
                        HasDot = false;
                    }
                    break;
                case "%":
                    LblCurrentValue.Text += "%";
                    break;
            }
        }

        private void OperationsTapped(object sender, EventArgs e)
        {
            Button opTapped = sender as Button;
            if (!(LblCurrentValue.Text.EndsWith("+") || LblCurrentValue.Text.EndsWith("-")
                    || LblCurrentValue.Text.EndsWith("×") || LblCurrentValue.Text.EndsWith("÷")))
            {
                LblCurrentValue.Text += opTapped.Text;
                HasDot = false;
            }
        }

        private void NumbersTapped(object sender, EventArgs e)
        {
            Button btnPressed = sender as Button;
            if (BtnClear.Text.Equals("AC"))
            {
                BtnClear.Text = "C";
                LblResult.IsVisible = true;
            }

            if ((LblCurrentValue.Text.EndsWith("+") || LblCurrentValue.Text.EndsWith("-")
                    || LblCurrentValue.Text.EndsWith("×") || LblCurrentValue.Text.EndsWith("÷")) && btnPressed.Text == ".")
            {
                LblCurrentValue.Text += "0.";
                HasDot = true;
            }

            if (LblCurrentValue.Text != "0")
            {
                if (btnPressed.Text == "." && !HasDot)
                {
                    LblCurrentValue.Text += btnPressed.Text;
                    HasDot = true;
                }
                else if (btnPressed.Text != ".")
                {
                    LblCurrentValue.Text += btnPressed.Text;
                }
            }
            else
            {
                if (btnPressed.Text != "0" && btnPressed.Text != ".")
                {
                    LblCurrentValue.Text = btnPressed.Text;
                }
                else if (btnPressed.Text == ".")
                {
                    LblCurrentValue.Text += btnPressed.Text;
                    HasDot = true;
                }
            }

        }
    }
}
