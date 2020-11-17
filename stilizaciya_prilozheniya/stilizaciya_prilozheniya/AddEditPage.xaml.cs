using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace stilizaciya_prilozheniya
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Page1 _currentHotel = new Page1();

        private SqlConnection sqlConnection = null;
        public AddEditPage(Page1 selected)
        {
            InitializeComponent();


            if (selected != null)
                _currentHotel = selected;

            DataContext = _currentHotel;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (a.Text.Length < 20) ;
        }

        private void TextBox_TextChanged2(object sender, TextChangedEventArgs e)
        {
            if (b.Text.Length < 20) ;
        }

        private void TextBox_TextChanged3(object sender, TextChangedEventArgs e)
        {
            if (c.Text.Length < 20) ;
        }

        private void TextBox_TextChanged4(object sender, TextChangedEventArgs e)
        {
            if (d.Text.Length < 20) ;
        }

        private void button123(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if(_currentHotel==null)
                errors.AppendLine("вы не ввели в 1 textbox");
            if(_currentHotel==null)
                errors.AppendLine("вы не ввели в 2 textbox");
            if (_currentHotel == null)
                errors.AppendLine("вы не ввели в 3 textbox");
            if (_currentHotel == null)
                errors.AppendLine("вы не ввели в 4 textbox");

            if(errors.Length>0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentHotel.CacheMode == null)
            {
                string connectionString = @"Data Source=DESKTOP-HQTDFSB;Initial Catalog=аква_парк;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connectionString);
                SqlCommand cmd = cnn.CreateCommand();
                cnn.Open();
                cmd.CommandText = @"Insert into Оплата_труда (Код_сотрудника,колвочасов,зарплата,график) values (" + "'" + a.Text + "','" + b.Text + "','" + c.Text + "','" + d.Text + "'" + ")";
                cmd.ExecuteNonQuery();
            }
        }

    }
}
