using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VRShop
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {

        public Registration()
        {
            InitializeComponent();
            
        }

        //проверка силы пароля
        public int Password_Strength(string password)
        {
           
            if (string.IsNullOrEmpty(password))
            {
                return 0;
            }

            // Переменная для хранения результата
            int result = 0;

            if (password.Length > 5)
            {
                result++;
            }

            if (Regex.Match(password, @"[0-9]+").Success)
            {
                result++;
            }

            if (Regex.Match(password, @"[A-Z]+").Success)
            {
                result++;
            }

            if (Regex.Match(password, "[a-z]").Success)
            {
                result++;
            }

            if (Regex.Match(password, @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]").Success)
            {
                result++;
            }

            return result;


        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            
            var emailPattern = new Regex(@"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$");
            int regLinesCheck = 0;

            //Проверка корректности ввода и занесение в базу пользователя
            if (loginBox.Text.Length < 1)
            {
                MessageBox.Show("Please enter prefered login");
            }
            else
            {
                regLinesCheck++;
                if (Password_Strength(passBox.Password) <4)
                {
                    MessageBox.Show("Password is too weak");
                }
                else
                {
                    regLinesCheck++;
                    if (!emailPattern.IsMatch(emailBox.Text))
                    {
                        MessageBox.Show("Wrong email format");
                    }
                    else
                    {
                        regLinesCheck++;
                        if (customerNameBox.Text.Length < 1)
                        {
                            MessageBox.Show("Please enter name");
                        }
                        else
                        {
                            regLinesCheck++;
                        }
                    }
                }




            }


            if (regLinesCheck == 4)
            {
                using (Model1 db = new Model1())
                {
                    //проверка на существование логина
                    if (db.Users.Any(p => p.Login == loginBox.Text))
                    {
                        MessageBox.Show("User with this login already exist. Please change login");
                    }
                    else
                    {

                        var newUser = new User { Login = loginBox.Text, Password = MainWindow.HashPassword(passBox.Password), AccessLevel = 1 };

                        db.Users.Add(newUser);
                        db.SaveChanges();
                        var newUserData = new UserData { UserId = newUser.Id, Email = emailBox.Text, FullName = customerNameBox.Text };
                        db.UsersData.Add(newUserData);
                        db.SaveChanges();
                        MessageBox.Show("Registration successful");
                        this.Close();
                    }
                }

            }
            else
            {
                MessageBox.Show("Please fill all fields correctly");
            }
        }

        //нажатие enter
        private void Reg_ButtonClick(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                Registration_Click(sender, (RoutedEventArgs)e);
            }

        }
    }
}
