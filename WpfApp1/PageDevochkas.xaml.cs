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
    /// Логика взаимодействия для PageDevochkas.xaml
    /// </summary>
    public partial class PageDevochkas : Page
    {
        private TictonicEntities context = new TictonicEntities();

        public PageDevochkas()
        {
            InitializeComponent();
            DevochkasDG.ItemsSource = context.Devochkas.ToList();
        }

        private void DevochkasDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Devochkas selected = DevochkasDG.SelectedItem as Devochkas;
            if (selected != null)
            {
                TextBox1.Text = selected.Name_;
                CheckBox1.IsChecked = selected.Dad;
                TextBox2.Text = Convert.ToString(selected.Age);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox1.Text != "" && TextBox2.Text != "")
            {
                if (int.TryParse(TextBox2.Text, out int result) && result > 0)
                {
                    Devochkas girl = new Devochkas();
                    girl.Name_ = TextBox1.Text;
                    girl.Dad = (bool) CheckBox1.IsChecked;
                    girl.Age = result;

                    context.Devochkas.Add(girl);
                    context.SaveChanges();
                    DevochkasDG.ItemsSource = context.Devochkas.ToList();

                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    CheckBox1.IsChecked = false;
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
            if (DevochkasDG.SelectedItem != null)
            {
                if (TextBox1.Text != "" && TextBox2.Text != "")
                {
                    if (int.TryParse(TextBox2.Text, out int result) && result > 0)
                    {
                        Devochkas selected = (Devochkas)DevochkasDG.SelectedItem;
                        var obj = context.Devochkas.First(x => x.ID == selected.ID);

                        obj.Name_ = TextBox1.Text;
                        obj.Dad = (bool) CheckBox1.IsChecked;
                        obj.Age = result;

                        context.SaveChanges();
                        DevochkasDG.ItemsSource = context.Devochkas.ToList();

                        TextBox1.Text = "";
                        TextBox2.Text = "";
                        CheckBox1.IsChecked = false;
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
            if (DevochkasDG.SelectedItem != null)
            {
                context.Devochkas.Remove((Devochkas)DevochkasDG.SelectedItem);
                context.SaveChanges();
                DevochkasDG.ItemsSource = context.Devochkas.ToList();

                TextBox1.Text = "";
                TextBox2.Text = "";
                CheckBox1.IsChecked = false;
            }
            else
            {
                MessageBox.Show("Выбери объект!");
            }
        }
    }
}
