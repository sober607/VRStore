using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace VRShop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //инициализация переменных сессии
        public static string currentLogin;
        public static int currentLoginId;
        public static string currentUserName;
        public MainWindow()
        {
            InitializeComponent();

            //Инициализация дизайна
            AppSettingsWindow.ReadSettings();

            // инициализация первоначальных данных в БД первого запуска (администратор, тестовый товар)
            using (Model1 db = new Model1())
            {
                if (db.Users.ToList().Count < 1)
                {
                    var initialAdmin = new User { Login = "admin", Password = MainWindow.HashPassword("qwerty1!"), AccessLevel = 0 };
                    var initiakAdminData = new ManagerData { UserId = initialAdmin.Id, FullName = "Initial admin account", User = initialAdmin, Email = "admin@local" };
                    db.Users.Add(initialAdmin);
                    db.ManagerData.Add(initiakAdminData);
                    db.SaveChanges();
                    MessageBox.Show("Welcome on first run! Initial admin login 'admin', password 'qwerty1!'");
                }
            }
            }

        //запуск окна регистрации
        private void Registration_WindowOpen(object sender, RoutedEventArgs e)
        {
            Registration regWindow = new Registration();
            regWindow.Show();

        }

        // хэшировние пароля
        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password missing");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        //метод для сверики пароля с хешем
        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("Password missing");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }

        //сверка массива байтов пароля
        private static bool ByteArraysEqual(byte[] a, byte[] b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if (a == null || b == null || a.Length != b.Length)
            {
                return false;
            }

            var areSame = true;
            for (var i = 0; i < a.Length; i++)
            {
                areSame &= (a[i] == b[i]);
            }
            return areSame;
        }

        //действие при нажатии enter
        private void Login_ButtonClick(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                Login_ButtonClick(sender, (RoutedEventArgs)e);
            }

        }


        //авторизация
        private void Login_ButtonClick(object sender, RoutedEventArgs e)
        {

            using (Model1 db = new Model1())
            {

                var loginLinq = db.Users.FirstOrDefault(p => p.Login == loginBoxAuthorisation.Text);

                if (loginLinq == null)
                {
                    MessageBox.Show("Such login does not exist");
                }
                else
                {
                    if (VerifyHashedPassword(loginLinq.Password, passwordBoxAuthorisation.Password))
                    {
                        if ((db.Users.FirstOrDefault(p => p.Login == loginBoxAuthorisation.Text)).AccessLevel == 1)
                        {
                            UserMainWindow userMainWindow = new UserMainWindow();
                            userMainWindow.Show();
                            this.Close();
                            currentLogin = loginBoxAuthorisation.Text;
                            currentLoginId = loginLinq.Id;
                            currentUserName = db.UsersData.FirstOrDefault(p => p.UserId == currentLoginId).FullName;
                        }
                        else
                        {
                            AdminMainWindow adminMainWindow = new AdminMainWindow();
                            adminMainWindow.Show();
                            this.Close();
                            currentLogin = loginBoxAuthorisation.Text;
                            currentLoginId = loginLinq.Id;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Wrong password");
                    }
                }

            }

        }

    }
}
