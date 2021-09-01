using System;
using System.Linq;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        private bool HasDot;
        private bool HasEqualBeenPressed;
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

        private void EqualTapped(object sender, EventArgs e)
        {
            Label newHistory = new Label();
            newHistory.Text = LblCurrentValue.Text + LblResult.Text;
            newHistory.FontSize = 20;
            newHistory.TextColor = Color.Gray;

            HistoryContainter.Children.Add(newHistory);

            HasEqualBeenPressed = true;
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
                case "AC":
                    HistoryContainter.Children.Clear();
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
                    string textCurrentValue = LblCurrentValue.Text;
                    if (!(textCurrentValue.EndsWith("+") || textCurrentValue.EndsWith("-") ||
                            textCurrentValue.EndsWith("×") || textCurrentValue.EndsWith("÷")))
                    {
                        if (!(textCurrentValue.Contains("+") || textCurrentValue.Contains("-") ||
                            textCurrentValue.Contains("×") || textCurrentValue.Contains("÷")))
                        {
                            LblCurrentValue.Text = (decimal.Parse(textCurrentValue) / 100).ToString();
                        }
                        else
                        {
                            LblCurrentValue.Text =
                                textCurrentValue.Insert(textCurrentValue.LastIndexOfAny(new char[] { '+', '-', '×', '÷' }) + 1, "%");
                        }
                    }                    
                    break;
            }
        }

        private void OperationsTapped(object sender, EventArgs e)
        {
            Button opTapped = sender as Button;
            if (!HasEqualBeenPressed)
            {
                if (!(LblCurrentValue.Text.EndsWith("+") || LblCurrentValue.Text.EndsWith("-")
                    || LblCurrentValue.Text.EndsWith("×") || LblCurrentValue.Text.EndsWith("÷")))
                {
                    LblCurrentValue.Text += opTapped.Text;
                    HasDot = false;
                }
                else
                {
                    LblCurrentValue.Text = LblCurrentValue.Text.Remove(LblCurrentValue.Text.Length - 1);
                    LblCurrentValue.Text += opTapped.Text;
                }
            }
            else
            {
                LblCurrentValue.Text = LblResult.Text.Remove(0, 2);
                LblCurrentValue.Text += opTapped.Text;
                HasEqualBeenPressed = false;
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

            if (!HasEqualBeenPressed)
            {
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
            else
            {
                LblCurrentValue.Text = btnPressed.Text;
                HasEqualBeenPressed = false;          
            }

        }
    }
}
