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
using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace WpfApp40
{
    /// <summary>
    /// Логика взаимодействия для AddEditPAge.xaml
    /// </summary>
    public partial class AddEditPAge : Page
    {
        private Material _currentMaterial = new Material();
        public AddEditPAge()
        {
            InitializeComponent();
            MaterialTypeID.ItemsSource = WEWEEntities.GetContext().MaterialType.ToList();
            DataContext = _currentMaterial;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
           
                if (string.IsNullOrWhiteSpace(_currentMaterial.Title))
                    errors.AppendLine("Укажите название материала");
                if (_currentMaterial.CountInPack <= 0)
                    errors.AppendLine("Не может быть равно 0");
                if (_currentMaterial.Unit == null)
                    errors.AppendLine("выберите единицу измерения");
                if (_currentMaterial.CountInStock < 0)
                    errors.AppendLine("Кол-во на складе меньше 0");
                if (_currentMaterial.MinCount < 0)
                    errors.AppendLine("Минимально кол-во может быть меньше 0");
                if (_currentMaterial.Cost < 0)
                    errors.AppendLine("Цена может быть меньше 0");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
         
            if (_currentMaterial.ID == 0)
                WEWEEntities.GetContext().Material.Add(_currentMaterial);
            try
            {
                WEWEEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
      

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Class1.MainFrame.Navigate(new Page1());
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                txtEditor.Text = File.ReadAllText(openFileDialog.FileName);
        }

        private void TxtEditor_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Unit_Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MaterialTypeID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
