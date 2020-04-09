using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для UserMainWindow.xaml
    /// </summary>
    public partial class UserMainWindow : Window
    {
        public int newOrderId;
        public UserMainWindow()
        {
            InitializeComponent();

            Random random = new Random();
            using (Model1 db = new Model1())
            {
                productsList.ItemsSource = db.Products.ToList();
                UserBasketDatagrid.ItemsSource = db.OrderedProducts.Where(p => p.OrderConfirmed == false).ToList();
                
                newOrderId = random.Next();
                var checkExistingNewOrderId = db.OrderedProducts.FirstOrDefault(p => p.OrderId == newOrderId);
                while (checkExistingNewOrderId != null)
                {
                    newOrderId = random.Next();
                }


            }
            

            this.Closed += UserWindow_Closed;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Calculate_Total_Amount()
        {
            Total_Order_Amount_Label.Content = 0;
            using (Model1 db = new Model1())
            {
                foreach (OrderedProduct t in db.OrderedProducts.Where(p => p.OrderConfirmed == false).ToList())
                {
                    Total_Order_Amount_Label.Content = Convert.ToDouble(Total_Order_Amount_Label.Content) + t.Sum;
                }
            }
        }

        private void AddToBasketButton_Click(object sender, RoutedEventArgs e)
        {

            var row_list = (Product)productsList.SelectedItem;
            //MessageBox.Show("You Selected: " + row_list.Product.Id);
            //var row_list = (Product)dataGridAdminView.SelectedItem;
            //MessageBox.Show("You Selected: " + row_list.Id + " " + row_list.ProductName);
            using (Model1 db = new Model1())
            {

                OrderedProduct newOrderedProduct = new OrderedProduct { OrderId = newOrderId, ProductId = row_list.Id, ProductName = row_list.ProductName, ProductQty = Convert.ToInt32(OrderQty.Text), Price = row_list.Price, Sum = row_list.Price * Convert.ToInt32(OrderQty.Text), UserId = MainWindow.currentLoginId, Date = DateTime.Now.ToShortDateString(), OrderConfirmed = false };

                db.OrderedProducts.Add(newOrderedProduct);
                db.SaveChanges();
                UserBasketDatagrid.ItemsSource = db.OrderedProducts.Where(p => p.OrderConfirmed == false).ToList();

                Calculate_Total_Amount();
            };





        }

        //действия при закрытии пользовательского окна.
        private void UserWindow_Closed(object sender, EventArgs e)
        {
            using (Model1 db = new Model1())
            {
                var notConfirmedOrders = db.OrderedProducts.Where(p => p.OrderConfirmed == false);
                db.OrderedProducts.RemoveRange(notConfirmedOrders);
                db.SaveChanges();
            }
        }


        private void Qty_Increase(object sender, RoutedEventArgs e)
        {
            OrderQty.Text = ((Convert.ToInt32(OrderQty.Text)) + 1).ToString();
        }

        private void Qty_Decrease(object sender, RoutedEventArgs e)
        {
            OrderQty.Text = ((Convert.ToInt32(OrderQty.Text)) - 1).ToString();
        }

        // асинхронный генератор счетов txt
        private async void InvoiceGenerator()
        {
            string writePath = $"invoice{newOrderId}.txt";
            FileInfo fileInf = new FileInfo(writePath);
            if (fileInf.Exists)
            {
                fileInf.Delete();
            }
            try
            {

                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    await sw.WriteLineAsync($"\t \t \t Invoice #{newOrderId}");
                    await sw.WriteLineAsync($"\t \t \t " + DateTime.Now);
                    await sw.WriteLineAsync($"\t\t\t Customer name: {MainWindow.currentUserName} \n");
                    await sw.WriteLineAsync($"|Product name \t|Price\t|Quantity\t|Summ");
                }
                using (Model1 db = new Model1())
                {
                    foreach (OrderedProduct o in db.OrderedProducts.Where(p => p.OrderConfirmed == false))
                    {
                        using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                        {
                            await sw.WriteLineAsync("--\t\t\t\t");
                            await sw.WriteLineAsync("|" + o.ProductName + "\t\t|" + o.Price + "\t|" + o.ProductQty + "\t|" + o.Sum);


                        }
                    }



                }
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    await sw.WriteLineAsync("--------------------");
                    await sw.WriteLineAsync($"\t\t\t\tTotal amount: {Total_Order_Amount_Label.Content} USD");


                }


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            System.Diagnostics.Process.Start(writePath);
        }

        // нажатие кнопки подтвердить заказ, Генератор инвойса, перевод заказа в статус подтврежденного
        private void User_Confirm_Order(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Order {newOrderId} has been placed. Wait for call");
            InvoiceGenerator();
            using (Model1 db = new Model1())
            {
                foreach (OrderedProduct t in db.OrderedProducts.Where(p => p.OrderConfirmed == false))
                {
                    t.OrderConfirmed = true;
                }
                db.SaveChanges();
                UserBasketDatagrid.ItemsSource = db.OrderedProducts.Where(p => p.OrderConfirmed == false).ToList();
                // var requestConfirmOrderLinq= db.OrderedProducts.Where(p=>p.)
            }
        }

        private void DataGridProductsCell_SelectedForView(object sender, RoutedEventArgs e)
        {
            using (Model1 db = new Model1())
            {
                Product selectedProductUser = (Product)productsList.SelectedItem;

                UserView_ProductName.Content = selectedProductUser.ProductName;
                UserView_ProductDescription.Content = selectedProductUser.ProductDescripton;
                UserView_ProductPrice.Content = Convert.ToString(selectedProductUser.Price) + " USD";
                UserView_ProductImage.Source = AdminMainWindow.ConvertByteArrayToImage(selectedProductUser.ProductImg);
            }


        }

        private void Open_Settings(object sender, RoutedEventArgs e)
        {
            AppSettingsWindow appSettingsWindow = new AppSettingsWindow();
            appSettingsWindow.Show();

        }

        private void Open_History_Of_Orders_Button(object sender, RoutedEventArgs e)
        {
            UserHistoryOfOrders userHistoryOfOrdersWindow = new UserHistoryOfOrders();
            userHistoryOfOrdersWindow.Show();
        }
    }


}

