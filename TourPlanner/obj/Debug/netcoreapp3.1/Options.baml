   M S B A M L   `   `   `  ����F  BTourPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ViewModels
ViewModels  5   	       TourPlanner.Options   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ViewModels     5   	     � Title$  Options��5   	   $	��450��6   $	��800��6&    � DataContext 5	         ViewModels.OptionsVM  5
   
   6   .��5      �� $��Center=�6   $��Center=�6.   .+�5   
   � 5      � 5   
    � RowDefinitions 5      �� 5      $
��Auto �6    60   �� 5      $
��Auto �6    60   �� 5      $
��Auto �6    60   �� 5      $
��Auto �6    60   �� 5      $
��Auto �6    60    � ColumnDefinitions 5      �� 5      $
��Auto �6#   62   �� 5      $	��300 �6#   61   .+�5      �� $��0��6   $��0��6%   $��Right=�65   $��5q�6Q   $��12(�6\   $��	RouteType��6j   6}   �� 5      $��0��6   $��1��6$   $	��290��6`   $��25��6l   $��5q�6x    �� SelectedIndex 64   �� *SelectedRouteType+.@�5      �� .��6   	fastest6(   �� 5       .��6   
shortest6)   �� 5!      .��6   pepdestrian6,   �� 5"      .��6   	bicycle6(   5#      �� 5%      $��1��6   $��0��6%   $��Right=�65   $��5q�6Q   $��12(�6\   $
��Unit��6j   6x   �� 5'      $��1��6   $��1��6$   $	��290��6[   $��25��6g   $��5q�6s    64   �� *SelectedUnit+.@�5(      �� .��6   
Kilometers6+   �� 5)      .��6   Miles6&   5*      �� 5,      $��2��6   $��0��6%   $��Right=�65   $��5q�6Q   $��12(�6\   $��Language��6j   6|   �� 5.      $��2��6   $��1��6$   $	��290��6_   $��25��6k   $��5q�6w    64   �� *SelectedLanguage+.@�5/      �� .��6   en_US6&   �� 50      .��6   en_GB6&   �� 51      .��6   fr_CA6&   �� 52      .��6   fr_FR6&   �� 53      .��6   de_DE6&   �� 54      .��6   es_ES6&   �� 55      .��6   es_MX6&   �� 56      .��6   ru_RU6&   57      59      �� 5;   
   $��Center=�6    �� Orientation$ 
Horizontal=�62   .+�5<      �� $��5q�6   $
��Save��6    ��6/   �� *SaveCommand+6Q   �� 5=      $��5q�6   $��Cancel��6    ��61   �� *CancelCommand+6U   5>      5?      5@      