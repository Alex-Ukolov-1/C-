﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace work_5
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
            string connectionString = @"Data Source=DESKTOP-HQTDFSB;Initial Catalog=AMONIC_AIRLINES;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand cmd = cnn.CreateCommand();
            cnn.Open();
            cmd.CommandText = @"Insert into Users (Дата_рождения,ACTIVE,role) values (" + "'" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text +  "'" + ")";
            cmd.ExecuteNonQuery();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 1) ;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length < 1) ;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length < 1) ;
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
