   M S B A M L   `   `   `  ����F  BTourPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ViewModels
ViewModels  5   	       TourPlanner.AddTourLog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ViewModels     5   	     � Title$  
AddTourLog��5   	   $	��450��6   $	��800��6)    � DataContext 5	         ViewModels.TourLogVM  5
   
   6   .��5      �� $��Center=�6   $��Center=�6.   .+�5   
   � $��5q�6    � RowDefinitions 5      �� 5      $
��Auto �6    60   �� 5      $
��Auto �6    60   �� 5      $
��Auto �6    60   �� 5      $
��Auto �6    60   �� 5      $
��Auto �6    60    � ColumnDefinitions 5      �� 5      $
��Auto �6#   62   �� 5      $	��300 �6#   61   .+�5      �� $��0��6   $��0��6%   $��25��65   $
��Left=�6A   $��5q�6\   $��12(�6g   $��Duration (hh:mm:ss)��6u   6�   �� 5      $��0��6   $��1��6#   $��5q�63   ��6>   �� *
Duration+6Z   �� 5      $��1��6   $��0��6%   $��25��65   $
��Left=�6A   $��5q�6\   $��12(�6g   $��Distance (km)��6u   6�   �� 5      $��1��6   $��1��6#   $��5q�63   ��6>   �� *
Distance+6Z   �� 5       $��2��6   $��0��6%   $��25��65   $
��Left=�6A   $��5q�6\   $��12(�6g   $��Rating (1-5)��6u   6�   �� 5#      $��2��6   $��1��6$   $	��290��6U   $��25��6a    �� SelectedValue 64   �� *Rating+.@�5$      �� .��6   16"   �� 5%      .��6   26"   �� 5&      .��6   36"   �� 5'      .��6   46"   �� 5(      .��6   56"   5)      �� 5+      $��3��6   $��0��6%   $��25��65   $
��Left=�6A   $��5q�6\   $��12(�6g   $��Avergage Speed (km/h)��6u   6�   �� 5,      $��3��6   $��1��6#   $��5q�63   ��6>   �� *	Avg_speed+6[   5-      �� 5/   
   $��Center=�6    �� Orientation$ 
Horizontal=�62   .+�50      �� $��10q�6   $	��Add��6!   ��6/   �� *AddTourLogCommand+6W   �� 51      $��10q�6   $��Clear��6!   ��61   �� *ClearTourLogCommand+6[   52      53      54      