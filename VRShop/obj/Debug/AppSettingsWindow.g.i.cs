﻿#pragma checksum "..\..\AppSettingsWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "83FDDA45581E6838FF3EEB7745A1B357BD1BD94C5A2449C9A3D92B87B2680B00"
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
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;


namespace VRShop {
    
    
    /// <summary>
    /// AppSettingsWindow
    /// </summary>
    public partial class AppSettingsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\AppSettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.ColorPicker colorPicker;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\AppSettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label FontChooserLabel;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\AppSettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.ColorPicker colorFontPicker;
        
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
            System.Uri resourceLocater = new System.Uri("/VRShop;component/appsettingswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AppSettingsWindow.xaml"
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
            this.colorPicker = ((Xceed.Wpf.Toolkit.ColorPicker)(target));
            
            #line 31 "..\..\AppSettingsWindow.xaml"
            this.colorPicker.SelectedColorChanged += new System.Windows.RoutedPropertyChangedEventHandler<System.Nullable<System.Windows.Media.Color>>(this.ColorPicker_SelectedColorChanged_1);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 32 "..\..\AppSettingsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveSettings);
            
            #line default
            #line hidden
            return;
            case 3:
            this.FontChooserLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.colorFontPicker = ((Xceed.Wpf.Toolkit.ColorPicker)(target));
            
            #line 43 "..\..\AppSettingsWindow.xaml"
            this.colorFontPicker.SelectedColorChanged += new System.Windows.RoutedPropertyChangedEventHandler<System.Nullable<System.Windows.Media.Color>>(this.ColorPicker_SelectedColorChanged_1);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 44 "..\..\AppSettingsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveSettings);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

