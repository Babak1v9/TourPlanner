   M S B A M L   `   `   `  ����F  BTourPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ViewModels
ViewModels  5   	       TourPlanner.EditTour   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ViewModels     5   	     � Title$  EditTour��5   	   $	��450��6   $	��800��6'    � DataContext 5	         ViewModels.EditTourVM  5
   
   6   .��5      �� $��Center=�6   $��Center=�6.   .+�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    60   �� 5      $
��Auto �6    60   �� 5      $
��Auto �6    60   �� 5      $
��Auto �6    60   �� 5      $
��Auto �6    60    � ColumnDefinitions 5      �� 5      $
��Auto �6#   62   �� 5      $	��300 �6#   61   .+�5      �� $��0��6   $��0��6%   $��Right=�65   $��5q�6Q   $��12(�6\   $
��Name��6j   6x   �� 5      $��0��6   $��1��6#   $��5q�63   ��6>   �� *CurrentItem.name+6b   �� 5      $��1��6   $��0��6%   $��Right=�65   $��5q�6Q   $��12(�6\   $��Description��6j   6   �� 5      $��1��6   $��1��6#   $��5q�63   ��6>   �� *CurrentItem.description+6i   �� 5       $��2��6   $��0��6%   $��Right=�65   $��5q�6Q   $��12(�6\   $
��From��6j   6x   �� 5!      $��2��6   $��1��6#   $��5q�63   ��6>   �� *CurrentItem.from+6b   �� 5#      $��3��6   $��0��6%   $��Right=�65   $��5q�6Q   $��12(�6\   $��To��6j   6v   �� 5$      $��3��6   $��1��6#   $��5q�63   ��6>   �� *CurrentItem.to+6`   5%      �� 5'   
   $��Center=�6    �� Orientation$ 
Horizontal=�62   .+�5(      �� $��5q�6   $
��Edit��6    ��6/   �� *EditCommand+6Q   �� 5)      $��5q�6   $��Clear��6    ��60   �� *ClearCommand+6S   5*      5+      5,      