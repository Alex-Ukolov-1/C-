using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace prakticheskaya3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public struct Flight
        {
            public int num_r; 
            public string punkt_vd; 
            public int time_v; 
            public int n_places; 
        }

        
        public struct Tickets
        {
            public int num_t; 
            public int num_r; 
            public int place; 
            public string date_v;
            public string punkt_pr; 
            public string data_pr;
            public int time_pr; 
            public double price;
            public string time_prod; 
        }

       
        Dictionary<int, Flight> avia = new Dictionary<int, Flight>();

      
        List<Tickets> tickets = new List<Tickets>();

        public void Read_Avia()
        {
            StreamReader sr = new StreamReader("Flight.txt", Encoding.Default);
            string s = "";
            string[] fields;
            Flight sa; 
          
            while (s != null)
            {
                s = sr.ReadLine(); 
                if (s != null)
                {
                    fields = s.Split(',');

                   
                    sa.num_r = Convert.ToInt32(fields[0]);
                    sa.punkt_vd = fields[1];
                    sa.time_v = Convert.ToInt32(fields[2]);
                    sa.n_places = Convert.ToInt32(fields[3]);

                    avia.Add(sa.num_r, sa);

                  
                    listbox1.Items.Add(s);
                }
            }
        }

        public void Read_Tickets()
        {
            StreamReader sr = new StreamReader("Tickets.txt", Encoding.Default);
            string s;
            string[] fields;
            Tickets tk; 
            s = sr.ReadLine();
          
            do
            {
                
                fields = s.Split(',');

               
                tk.num_t = Convert.ToInt32(fields[0]);
                tk.num_r = Convert.ToInt32(fields[1]);
                tk.place = Convert.ToInt32(fields[2]);
                tk.date_v = fields[3];
                tk.punkt_pr = fields[4];
                tk.data_pr = fields[5];
                tk.time_pr = Convert.ToInt32(fields[6]);
                tk.price = Convert.ToDouble(fields[7]);
                tk.time_prod = fields[8];

                tickets.Add(tk);
                listbox2.Items.Add(s);
                s = sr.ReadLine();
            }
            while (s != null);
        }

        public MainWindow()
        {
            InitializeComponent();
            Read_Avia();
            Read_Tickets();
        }
           
        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            
            int max, tmp;

            bool f_first = true;
            max = 0;
            foreach (var a in avia)
            {
                foreach (var t in tickets)
                {
                    if (a.Value.num_r == t.num_r)
                    {
                        if (f_first)
                        {
                            max = t.time_pr - a.Value.time_v;
                            f_first = false;
                        }
                        else
                        {
                            tmp = t.time_pr - a.Value.time_v;
                            if (max < tmp)
                                max = tmp;
                        }
                    }
                } 
            }

            listbox3.Items.Clear();
            foreach (var a in avia)
            {
                foreach (var t in tickets)
                {
                    if (a.Value.num_r == t.num_r)
                    {
                        tmp = t.time_pr - a.Value.time_v;
                        if (tmp == max)
                        {
                            string s;
                            s = a.Value.num_r.ToString() + ", " +
                                a.Value.punkt_vd + "," +
                                a.Value.time_v.ToString() + ", " +
                                a.Value.n_places.ToString() + " - " +
                                t.num_t.ToString() + ", " +
                                t.punkt_pr + ", " +
                                t.time_pr.ToString() + ", " +
                                t.place.ToString();
                            listbox3.Items.Add(s);
                        }
                    }
                }
            }
            label2.Content = "Рейсы с максимальной продолжительностью полета: " + max.ToString();

            
            int tm, k;

            tm = Int32.Parse(textbox1.Text); 
            k = 0; 

            foreach (var a in avia)
            {
                foreach (var t in tickets)
                {
                    if ((a.Value.num_r == t.num_r) && (tm == a.Value.time_v))
                        k++;
                }
            }
            label3.Content = "Число пассажиров, которые ждут отправления: " + k.ToString();
        }
    }
}

