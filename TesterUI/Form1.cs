﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TesterUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            /********************prev config********************
             ****** moneyBox1.IsNumerical = true;
             ****** moneyBox1.ThousandsSeparator = false;
            /***************************************************/



            string text = moneyBox1.Text;
            decimal value = moneyBox1.Value;
            MessageBox.Show("text: "+ text+ " value: "+value);
        }
    }
}
