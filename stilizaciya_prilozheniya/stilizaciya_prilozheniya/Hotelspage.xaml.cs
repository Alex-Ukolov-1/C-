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

namespace stilizaciya_prilozheniya
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
       

        public Page1()
        {
            InitializeComponent();
            datafridhotels.ItemsSource = аква_паркEntities.GetContext().Оплата_труда.ToList();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Class1.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Page1));
        }

        private void BthAdd_click(object sender, RoutedEventArgs e)
        {
            Class1.MainFrame.Navigate(new AddEditPage(null));
        }



        private void Delete(object sender, RoutedEventArgs e)
        {
            var hotelsforremoving = datafridhotels.SelectedItems.Cast<Оплата_труда>().ToList();
            if(MessageBox.Show($"Вы точно хотети удалить следующие{hotelsforremoving.Count()} элементов?!","внимание",
                MessageBoxButton.YesNo,MessageBoxImage.Question)==MessageBoxResult.Yes)
            {
                try
                {
                    аква_паркEntities.GetContext().Оплата_труда.RemoveRange((IEnumerable<Оплата_труда>)hotelsforremoving);
                    аква_паркEntities.GetContext().SaveChanges();
                    MessageBox.Show("данные удалены");
                    datafridhotels.ItemsSource= аква_паркEntities.GetContext().Оплата_труда.ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void datafridhotels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Page_isVisiblechanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility==Visibility.Visible)
            {
                аква_паркEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                datafridhotels.ItemsSource= аква_паркEntities.GetContext().Оплата_труда.ToList();
            }
        }
    }
}
