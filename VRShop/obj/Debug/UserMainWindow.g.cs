﻿#pragma checksum "..\..\UserMainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "301F9CE8430183AA946316CA16A9C7581318CC5A55F7357987EB0115FA09661D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using VRShop;


namespace VRShop {
    
    
    /// <summary>
    /// UserMainWindow
    /// </summary>
    public partial class UserMainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 50 "..\..\UserMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image shopLogo;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\UserMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Menu mainUserMenu;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\UserMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox productsList;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\UserMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddToBasketButton;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\UserMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox OrderQty;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\UserMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid UserBasketDatagrid;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\UserMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Total_Order_Amount_Label;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\UserMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label UserView_ProductName;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\UserMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label UserView_ProductDescription;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\UserMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image UserView_ProductImage;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\UserMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label UserView_ProductPrice;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/VRShop;component/usermainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UserMainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.shopLogo = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.mainUserMenu = ((System.Windows.Controls.Menu)(target));
            return;
            case 3:
            this.productsList = ((System.Windows.Controls.ListBox)(target));
            
            #line 59 "..\..\UserMainWindow.xaml"
            this.productsList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGridProductsCell_SelectedForView);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AddToBasketButton = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\UserMainWindow.xaml"
            this.AddToBasketButton.Click += new System.Windows.RoutedEventHandler(this.AddToBasketButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.OrderQty = ((System.Windows.Controls.TextBox)(target));
            
            #line 68 "..\..\UserMainWindow.xaml"
            this.OrderQty.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 70 "..\..\UserMainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Qty_Increase);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 71 "..\..\UserMainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Qty_Decrease);
            
            #line default
            #line hidden
            return;
            case 8:
            this.UserBasketDatagrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 9:
            this.Total_Order_Amount_Label = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            
            #line 85 "..\..\UserMainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.User_Confirm_Order);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 86 "..\..\UserMainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Open_Settings);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 97 "..\..\UserMainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Open_History_Of_Orders_Button);
            
            #line default
            #line hidden
            return;
            case 13:
            this.UserView_ProductName = ((System.Windows.Controls.Label)(target));
            return;
            case 14:
            this.UserView_ProductDescription = ((System.Windows.Controls.Label)(target));
            return;
            case 15:
            this.UserView_ProductImage = ((System.Windows.Controls.Image)(target));
            return;
            case 16:
            this.UserView_ProductPrice = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

