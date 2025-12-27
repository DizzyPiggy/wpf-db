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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для PageCars.xaml
    /// </summary>
    public partial class PageCars : Page
    {
        private TictonicEntities context = new TictonicEntities();

        public PageCars()
        {
            InitializeComponent();
            CarsDG.ItemsSource = context.Cars.ToList();
        }

        private void CarsDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cars selected = CarsDG.SelectedItem as Cars;
            if (selected != null)
            {
                TextBox1.Text = selected.Brand;
                TextBox2.Text = Convert.ToString(selected.Power_);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox1.Text != "" && TextBox2.Text != "")
            {
                if (int.TryParse(TextBox2.Text, out int result) && result > 0)
                {
                    Cars car = new Cars();
                    car.Brand = TextBox1.Text;
                    car.Power_ = result;
                    
                    context.Cars.Add(car);
                    context.SaveChanges();
                    CarsDG.ItemsSource = context.Cars.ToList();

                    TextBox1.Text = "";
                    TextBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("Power принимает только натуральные числа!");
                }
            }
            else
            {
                MessageBox.Show("Значения не могут быть пустыми!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (CarsDG.SelectedItem != null)
            {
                if (TextBox1.Text != "" && TextBox2.Text != "")
                {
                    if (int.TryParse(TextBox2.Text, out int result) && result > 0)
                    {
                        Cars selected = (Cars)CarsDG.SelectedItem;
                        var obj = context.Cars.First(x => x.ID == selected.ID);

                        obj.Brand = TextBox1.Text;
                        obj.Power_ = result;

                        context.SaveChanges();
                        CarsDG.ItemsSource = context.Cars.ToList();

                        TextBox1.Text = "";
                        TextBox2.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Power принимает только натуральные числа!");
                    }
                }
                else
                {
                    MessageBox.Show("Значения не могут быть пустыми!");
                }
            }
            else
            {
                MessageBox.Show("Выбери объект!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CarsDG.SelectedItem != null)
            {
                context.Cars.Remove((Cars)CarsDG.SelectedItem);
                context.SaveChanges();
                CarsDG.ItemsSource = context.Cars.ToList();

                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Выбери объект!");
            }
        }
    }
}
