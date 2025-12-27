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
    /// Логика взаимодействия для PageUsers.xaml
    /// </summary>
    public partial class PageUsers : Page
    {
        private TictonicEntities context = new TictonicEntities();

        public PageUsers()
        {
            InitializeComponent();
            UsersDG.ItemsSource = context.Users.ToList();
        }

        private void UsersDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Users selected = UsersDG.SelectedItem as Users;
            if (selected != null)
            {
                TextBox1.Text = selected.Name_;
                TextBox2.Text = selected.Password_;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox1.Text != "" && TextBox2.Text != "")
            {
                Users user = new Users();
                user.Name_ = TextBox1.Text;
                user.Password_ = TextBox2.Text;

                context.Users.Add(user);
                context.SaveChanges();
                UsersDG.ItemsSource = context.Users.ToList();

                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Значения не могут быть пустыми!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (UsersDG.SelectedItem != null)
            {
                if (TextBox1.Text != "" && TextBox2.Text != "")
                {
                    Users selected = (Users)UsersDG.SelectedItem;
                    var obj = context.Users.First(x => x.ID == selected.ID);

                    obj.Name_ = TextBox1.Text;
                    obj.Password_ = TextBox2.Text;

                    context.SaveChanges();
                    UsersDG.ItemsSource = context.Users.ToList();

                    TextBox1.Text = "";
                    TextBox2.Text = "";
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
            if (UsersDG.SelectedItem != null)
            {
                context.Users.Remove((Users)UsersDG.SelectedItem);
                context.SaveChanges();
                UsersDG.ItemsSource = context.Users.ToList();

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
