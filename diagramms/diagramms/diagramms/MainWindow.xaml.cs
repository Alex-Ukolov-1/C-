using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace diagramms
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private аква_паркEntities _context = new аква_паркEntities();
       
        public MainWindow()
        {
            InitializeComponent();
            chartpayments.ChartAreas.Add(new ChartArea("main"));

            var currentSeries = new Series("payments")
            {
                IsValueShownAsLabel = true
            };
            chartpayments.Series.Add(currentSeries);

            ComboUsers.ItemsSource = _context.Билет.ToList();
            COMBOCHARTTYPES.ItemsSource = Enum.GetValues(typeof(SeriesChartType));
        }

        private void UpdateChart(object sender,SelectionChangedEventArgs e)
        {
            if(ComboUsers.SelectedItem is Билет currentUser && COMBOCHARTTYPES.SelectedItem is SeriesChartType currentType)
            {
                Series currentSeries = chartpayments.Series.FirstOrDefault();
                currentSeries.ChartType = currentType;
                currentSeries.Points.Clear();


                var categorieslist = _context.Билет.ToList();
                foreach(var cathegory in categorieslist)
                {
                    currentSeries.Points.AddXY(cathegory.Код_заказа, _context.Билет.ToList().Where(p => p.Сотрудники== currentUser && p.Заказ== cathegory).Sum(p => p.Код_сотрудника * p.Код_заказа));
                }
            }
        }
    }
}
