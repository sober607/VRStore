   M S B A M L   `   `   `  ����A  =VRShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VRShopVRShop  5   	       VRShop.AppSettingsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:VRShop     5   	   X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5	   	     � Title$  Application settings��5   	   $	��248��6&   $	��341��63    � 	Resources 5
       �� 
TargetType �� Property   txtColor �� Value&   System.Windows.Controls.DataGrid  backgroundColor��%@  '��       '�� F     '  �     '� �     �� 5   
   " ��6   .�5      ��  � ��# �   6+   5      �� 5   
   " ��6   .�5      ��  � ��# �   6+   5      �� 5   
   "  6   .�5      ��  � ��# �   6+   5      �� 5   
   " �6   .�5      ��  � ��# �  6+   5      5      .��5      � .+�5   
   �� $
��Left=�6   $	��218��60   $	��Top=�6=   $	��332��6U   .@�5      �� $��
Background��6   ��5      �� 5      .+�5      �� 
 �� Top$ 84��6    $/��)Please choose preffered background colour��60   #  Xceed.Wpf.Toolkit.ColorPicker  5      -   5          Name$ colorPicker��5   M   $ 84��6+    �� Left$	 262��6;      DisplayColorAndName . 	   SelectedColor	 6}   �� *MyColorProperty+6�   �� 5       -   5        $
��Save��5    !   $	 112��60   $	 115��6B   $��75��6S   6^   5!      5$      �� 5&      $
��Font��6   ��5(      �� 5)      $��0,0,7,4q�6   .+�5*      �� -   5        
 ��Name$
 FontChooserLabel��5*       $ 56��6:   $ 10��6J   $)��#Please choose preffered font colour��6[     5+      -   5        $ colorFontPicker��5+   M   $ 60��6+   $	 213��6;    . 	 6�   �� *MyColorProperty+6�   �� 5,      -   5        $
��Save��5,   !   $	 102��60   $	 106��6B   $��75��6S   6^   5-      5/      52      55      56      