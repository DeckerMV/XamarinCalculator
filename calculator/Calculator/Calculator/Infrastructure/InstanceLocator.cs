using System;
using System.Collections.Generic;
using System.Text;
using Calculator.Model;

namespace Calculator.Infrastructure
{
    public class InstanceLocator
    {
        public MainModel Main { get; set; }

        public InstanceLocator()
        {
            Main = new MainModel();
        }
    }
}
