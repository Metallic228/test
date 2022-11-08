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

namespace WpfApp40
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        

        public Frame MainFrame { get; set; }

        public Page1()
        {
            InitializeComponent();
            DGridHotels.ItemsSource = WEWEEntities.GetContext().Material.ToList();
          

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            Class1.MainFrame.Navigate(new AddEditPAge());
            
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Class1.MainFrame.Navigate(new AddEditPAge());
        }

        private void Delete_Click_1(object sender, RoutedEventArgs e)
        {

        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                WEWEEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            }
        }
    }
}
