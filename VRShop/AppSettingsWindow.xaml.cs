using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace VRShop
{
    /// <summary>
    /// Логика взаимодействия для AppSettingsWindow.xaml
    /// </summary>
    public partial class AppSettingsWindow : Window
    {
        public AppSettingsWindow()
        {
            InitializeComponent();
        }

        //смена цвета фона, текста во всех окнах программы, где прописан SolidColorBrush
        private void ColorPicker_SelectedColorChanged_1(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (colorPicker.SelectedColor.HasValue)
            {
                foreach (Window window in App.Current.Windows)
                {
                    window.Background = new SolidColorBrush(colorPicker.SelectedColor.Value);


                }

                
            }

            if (colorFontPicker.SelectedColor.HasValue)
            {
                Application.Current.Resources["txtColor"] = new SolidColorBrush(colorFontPicker.SelectedColor.Value);
                
            }

        }

        //чтение настроек цвета и фона из реестра
        public static bool ReadSettings()
        {
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey reg0 = currentUserKey.OpenSubKey(@"Software\VRShopapp");
            if (reg0 != null)
            {

                RegistryKey softwareKey = currentUserKey.OpenSubKey(@"Software\VRShopapp");

                //1. цвет фона
                string hexBackground = Convert.ToString(softwareKey.GetValue("BackGroundColor"));
                

                //2. Цвет текста
                string hexText = Convert.ToString(softwareKey.GetValue("TextColor"));
                

                //Object fontstyle = GetStyleType();

                //Object GetStyleType()
                //{
                //    if (Convert.ToString(softwareKey.GetValue("TextStyleFont.Style")) == "Bold")
                //    {
                //        return FontWeights.Bold;
                //    }
                //    else if (Convert.ToString(softwareKey.GetValue("TextStyleFont.Style")) == "Italic")
                //    {
                //        return FontStyles.Italic;
                //    }
                //    else if (Convert.ToString(softwareKey.GetValue("TextStyleFont.Style")) == "Regular")
                //    {
                //        return FontWeights.Regular;
                //    }
                //    else if (Convert.ToString(softwareKey.GetValue("TextStyleFont.Style")) == "Strikeout")
                //    {
                //        return FontStyle.Strikeout;
                //    }
                //    else
                //    {
                //        return FontWeights.Regular;
                //    }


                //}
                // установка считанных значений
                foreach (Window window in App.Current.Windows)
                {
                    window.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(hexBackground));

                }

                Application.Current.Resources["backgroundColor"] = (SolidColorBrush)(new BrushConverter().ConvertFrom(hexBackground));
                Application.Current.Resources["txtColor"] = (SolidColorBrush)(new BrushConverter().ConvertFrom(hexText));
                //this.Font = new SolidColorBrush(Color.FromRgb(redText, greedText, blueText));
                //this.FontStyle = new FontStyle(fontName, textSize, fontstyle);
                reg0.Close();
            }

            return (true);
        }

        //сохранение в реестр выбранных настроек цвета фона и шрифта
        private void SaveSettings(object sender, RoutedEventArgs e)
        {
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey softwareKey = currentUserKey.OpenSubKey(@"Software", true);
            RegistryKey appkey = softwareKey.CreateSubKey("VRShopapp");
            if (colorPicker.SelectedColor.HasValue == true)
            {
                appkey.SetValue("BackGroundColor", colorPicker.SelectedColor.Value.ToString());
                
            }
            if (colorFontPicker.SelectedColor.HasValue == true)
            {
                appkey.SetValue("TextColor", colorFontPicker.SelectedColor.Value.ToString());
                
            }
            //appkey.SetValue("TextStyleFont.Name", label1.Font.Name.ToString());
            //appkey.SetValue("TextStyleFont.Size", label1.Font.Size.ToString());
            //appkey.SetValue("TextStyleFont.Style", label1.Font.Style.ToString());
            appkey.Close();
        }
    }
}
