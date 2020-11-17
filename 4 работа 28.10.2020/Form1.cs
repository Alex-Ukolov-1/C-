using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace _4_работа
{
    public partial class Form1 : Form
    {
        class PERSON
        {
            private string name;

            public string Name
            {
                get => Convert.ToString(MessageBox.Show("вы не добивили элемент!"));
                set
                {
                    try
                    {
                        MessageBox.Show("вы не добивили элемент!");
                    }
                    catch
                    {
                        MessageBox.Show("вы добавили эллемент!");
                    }
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            using (var sr = new StreamReader(@"C:\Новая папка\с# Воронина\4 работа\bin\Debug\Download.txt", Encoding.GetEncoding(1251)))
            {
                var str = sr.ReadToEnd();
                textBox6.Text = (string.Format(str.ToString()));
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            const string message = "ВЫ ХОТИТЕ СОХРАНИТЬ ФАЙЛ?!";
            const string caption = "Форма сохранения";

            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            string sourcePath = @"C:\Новая папка\с# Воронина\4 работа\bin\Debug";
            string targetPath = @"C:\Новая папка\с# Воронина";

            string text = String.Format(textBox1.Text);
            try
            {
                Convert.ToString(textBox1.Text);
            }

            catch
            {
                MessageBox.Show("не получилось вставить строку");
            }
            string textt = String.Format(textBox2.Text);
            try
            {
                Convert.ToInt32(textBox2.Text);
            }

            catch
            {
                MessageBox.Show("не получилось конвертировать ......");
            }

            string texttt = String.Format(textBox3.Text);
            string b = "" + String.Format(text) + String.Format(textt) + String.Format(texttt);
            string[] st = new string[] { b };

            foreach (var node in st)
            {
                File.AppendAllText("Download.txt", node + "\n", Encoding.GetEncoding(1251));
            }

            
        }
    }
}
