﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int b = textBox1.Lines.Length;
            int k = textBox1.Lines.Length - 1;
            int[] arr;
            arr = new int[b];
            for (int i = 0; i < b; i++)
            {
                arr[i] = Convert.ToInt32(textBox1.Lines[i]);
                if (k >= i)
                {
                    int min = 99999;
                    int number = 0;
                    for (int j = 0; j < b; j++)
                    {
                        if (arr[j] < min)
                        {
                            min = arr[j];
                            number = j;
                        }
                    }
                    label1.Text = "число " + min + " номер " + number;
                }
            }
        }
    }
}
