using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace NumericTextbox
{
    public partial class MoneyBox : TextBox
    {
        public MoneyBox()
        {
            InitializeComponent();
        }

        public MoneyBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
