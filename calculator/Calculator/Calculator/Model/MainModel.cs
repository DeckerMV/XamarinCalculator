using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Model
{
    public class MainModel
    {
        public UIModel UI { get; set; }

        public MainModel()
        {
            UI = new UIModel();
        }

    }
}
