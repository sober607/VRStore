   M S B A M L   `   `   `  ����A  =VRShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VRShopVRShop  5   	       VRShop.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:VRShop     5   	     � Title$  VR Shop authorisation��5   	   $	��450��6'   $	��800��64    � 	Resources 5	       �� 
TargetType �� Property   txtColor �� Value&   System.Windows.Controls.DataGrid  backgroundColor��%@  '��       '�� F     '  �     '� �     �� 5
   
   " ��6   .�5      ��  � ��# �   6+   5      �� 5   
   " ��6   .�5      ��  � ��# �   6+   5      �� 5   
   "  6   .�5      ��  � ��# �   6+   5      �� 5   
   " �6   .�5      ��  � ��# �  6+   5      5      .��5      � -   5         � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5       6!   .+�5"   
   �� -   5         ��Name$ shopLogo��5"   1   $��0��6   $��3��6   $2��,pack://siteoforigin:,,,/logo-theme-black.png��6C   5$      �� 5%   
   $��Authorisation��6   $��1��6(   $
��Left=�68   $��	46,10,0,0q�6S   $��1��6f   $	��Top=�6s   $��49��6�   $	��186��6�   $
��Bold"�6�   $��25(�6�   �� 5&   
   -   5         ��Name$ loginBoxAuthorisation��5&      $��1��61   $
��Left=�6A   $��23��6\   $��
46,106,0,0q�6h   $��1��6|   	 �� TextWrapping$
	 Wrap=�6�   
 �� 	MaxLength$
 20��6�   $	��Top=�6�   $	��120��6�    �� MaxLines$ 1��6�    �� MinLines$ 1��6�   G� 5'   
   -   5         G�Name$ passwordBoxAuthorisation��5'      $��1��68   $
��Left=�6H   $��23��6c   $��	46,10,0,0q�6o   $��2��6�    G� 	MaxLength$ 20��6�   $	��Top=�6�   $	��120��6�   �� 5(   
   $��Login��6   $
��Left=�6    $��169,106,0,0q�6;   $��1��6P   $	��Top=�6]   �� 5)   
   $��Password��6   $
��Left=�6#   $��	169,7,0,0q�6>   $��2��6Q   $	��Top=�6^   �� 5*   
   -   5        $��Enter��5*      $��1��6!   $
��Left=�61   $��	67,60,0,0q�6L   $��2��6_   $	��Top=�6l   $��75��6�   6�   �� 5+   
   -   5        $��New registration��5+      $��2��6,   $��Center=�6<   $��0,60,0,0q�6Y   $��2��6k   $	��Top=�6x   $	��103��6�   6�   5,      5-      