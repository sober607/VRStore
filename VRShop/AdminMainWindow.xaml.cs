﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
    /// Логика взаимодействия для AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        public static byte[] photoConvertedDataTemp;
        public int productIdToEdit;


        public AdminMainWindow()
        {
            InitializeComponent();
            using (Model1 db = new Model1())
            {
                dataGridAdminView1.ItemsSource = db.Products.ToList();
                dataGridAdminOrders.ItemsSource = db.OrderedProducts.ToList();
                dataGridUsersList.ItemsSource = db.UsersData.Where(p => p.User.AccessLevel == 1).ToList();
                dataGridAdminsList.ItemsSource = db.ManagerData.Where(p => p.User.AccessLevel == 0).ToList();
            }



        }

        //удаление выбранного продукта
        private void Delete_Item_Admin_Button(object sender, RoutedEventArgs e)
        {
            var productForDelete = dataGridAdminView1.SelectedItem as Product;
            using (Model1 db = new Model1())
            {

                if (dataGridAdminView1.SelectedItem != null)
                {

                    db.Products.Remove(db.Products.Find(productForDelete.Id));
                    db.SaveChanges();
                    dataGridAdminView1.ItemsSource = db.Products.ToList();
                }
            }
        }

        //конвертация картинки в массив байтов для загрузки в БД
        private byte[] ConvertImageToByteArray(string fileName)
        {
            Bitmap bitMap = new Bitmap(fileName);
            ImageFormat bmpFormat = bitMap.RawFormat;
            var imageToConvert = System.Drawing.Image.FromFile(fileName);
            using (MemoryStream ms = new MemoryStream())
            {
                imageToConvert.Save(ms, bmpFormat);
                return ms.ToArray();
            }
        }

        //выбор картинки для добавления
        public void Button_Upload_Photo(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "";
            dlg.Filter = "Image files (*.jpg,*.png,*.bmp)|*.jpg;*.png;*.bmp|All Files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                string selectedFileName = dlg.FileName;
                photoConvertedDataTemp = ConvertImageToByteArray(selectedFileName);

            }

        }

        //добавление нового продукта
        public void Add_Product_Button_Click(object sender, RoutedEventArgs e)
        {
            double temp; // временная переменная для цены
            if (Double.TryParse(ProductPriceTextBox_Admin.Text, out temp))
            {
                using (Model1 db = new Model1())
                {

                    Product newProduct = new Product { ProductName = ProductNameTextBox_Admin.Text, ProductDescripton = ProductDescriptionTextBox_Admin.Text, Price = temp, ProductImg = photoConvertedDataTemp };
                    db.Products.Add(newProduct);
                    db.SaveChanges();
                    dataGridAdminView1.ItemsSource = db.Products.ToList();
                    ProductNameTextBox_Admin.Text = null;
                    ProductDescriptionTextBox_Admin.Text = null;
                    ProductPriceTextBox_Admin.Text = null;
                    photoConvertedDataTemp = null;
                    ProductImage_Admin.Source = null;
                    MessageBox.Show("Successfully added");
                }
            }
            else
            {
                MessageBox.Show("Wrong input format");
            }

        }

        private void DataGridCell_SelectedForEdit(object sender, RoutedEventArgs e)
        {
            using (Model1 db = new Model1())
            {
                Product selectedProductAdmin = (Product)dataGridAdminView1.SelectedItem;
                productIdToEdit = selectedProductAdmin.Id;
                ProductNameTextBox_Admin.Text = selectedProductAdmin.ProductName;
                ProductDescriptionTextBox_Admin.Text = selectedProductAdmin.ProductDescripton;
                ProductPriceTextBox_Admin.Text = Convert.ToString(selectedProductAdmin.Price);
                ProductImage_Admin.Source = ConvertByteArrayToImage(selectedProductAdmin.ProductImg);
            }


        }

        private void Edit_Product_Button_Edit(object sender, RoutedEventArgs e)
        {
            using (Model1 db = new Model1())
            {
                Product productToEdit = db.Products.FirstOrDefault(p => p.Id == productIdToEdit);
                productToEdit.ProductName = ProductNameTextBox_Admin.Text;
                productToEdit.ProductDescripton = ProductDescriptionTextBox_Admin.Text;
                if (photoConvertedDataTemp != null)
                { productToEdit.ProductImg = photoConvertedDataTemp; }
                productToEdit.Price = Convert.ToInt32(ProductPriceTextBox_Admin.Text);
                db.SaveChanges();
                MessageBox.Show("Successful edit");
            }
        }

        public static BitmapImage ConvertByteArrayToImage(byte[] array)
        {
            if (array != null)
            {
                using (var ms = new MemoryStream(array, 0, array.Length))
                {
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = ms;
                    image.EndInit();
                    return image;
                }
            }
            return null;
        }

        private void DataGridCell_SelectedToShowUser(object sender, RoutedEventArgs e)
        {
            using (Model1 db = new Model1())
            {
                var selectedOrderedProductPosition = (OrderedProduct)dataGridAdminOrders.SelectedItem;
                dataGridUserDataOfOrderedProduct.ItemsSource = db.UsersData.Where(p => p.UserId == selectedOrderedProductPosition.UserId).ToList();
            }
        }

        //удаление клиентов
        private void Button_Delete_Selected_User(object sender, RoutedEventArgs e)
        {

            using (Model1 db = new Model1())
            {
                var selectedUserForDelete = (UserData)dataGridUsersList.SelectedItem;
                if (selectedUserForDelete != null)
                {
                    UserData userProfileToDelete = db.UsersData.FirstOrDefault(p => p.User.Id == selectedUserForDelete.UserId);
                    db.UsersData.Remove(userProfileToDelete);
                    db.Users.Remove(db.Users.FirstOrDefault(p => p.Id == selectedUserForDelete.UserId));
                    db.SaveChanges();
                    dataGridUsersList.ItemsSource = db.UsersData.Where(p => p.User.AccessLevel == 1).ToList();
                    MessageBox.Show("Successfully deleted");
                }
            }


        }

        private void Button_Delete_Selected_Admin(object sender, RoutedEventArgs e)
        {
            using (Model1 db = new Model1())
            {
                var selecteAdminForDelete = (ManagerData)dataGridAdminsList.SelectedItem;
                if (selecteAdminForDelete != null)
                {
                    ManagerData adminDataToDelete = db.ManagerData.FirstOrDefault(p => p.UserId == selecteAdminForDelete.UserId);
                    db.ManagerData.Remove(adminDataToDelete);
                    db.Users.Remove(db.Users.FirstOrDefault(p => p.Id == selecteAdminForDelete.UserId));
                    db.SaveChanges();
                    MessageBox.Show("Successfully manager deleted");
                    dataGridAdminsList.ItemsSource = db.ManagerData.Where(p => p.User.AccessLevel == 0).ToList();
                }
            }
        }

        private void Add_Admin_Button_Click(object sender, RoutedEventArgs e)
        {
            var emailPattern = new Regex(@"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$");
            if (!emailPattern.IsMatch(emailTexboxForAdding.Text))
            {
                MessageBox.Show("Wrong email format");
                return;
            }
            using (Model1 db = new Model1())
            {
                var newAdmin = new User { Login = loginTexboxForAdding.Text, Password = MainWindow.HashPassword(passwordTexboxForAdding.Password), AccessLevel = 0 };
                db.Users.Add(newAdmin);
                db.SaveChanges();
                var newAdminData = new ManagerData { UserId = newAdmin.Id, Email = emailTexboxForAdding.Text, FullName = fullNameTexboxForAdding.Text, DateOfBirth = Convert.ToString(DOBTexboxForAdding.SelectedDate), BeginningDateOfWork = Convert.ToString(DateTime.Now.Date) };
                db.ManagerData.Add(newAdminData);
                db.SaveChanges();
                MessageBox.Show("Admin registration finished");
                dataGridAdminsList.ItemsSource = db.ManagerData.Where(p => p.User.AccessLevel == 0).ToList();
            }
        }


    }
}
