   M S B A M L   `   `   `  ����F  BDisplayMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:OrderForm	OrderForm  5   	       OrderForm.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:OrderForm     5   	   -   5          � Title$  
MainWindow��5      $
��1920��6   $
��1080��6"    � WindowStartupLocation$ Manual=�61    � WindowStyle$
 None=�6g    � ShowInTaskbar .   � Topmost . .��5      �  � RowDefinitions 5   
   �� 5      -   5         ��Name$ Top_Row��5      $��7* �6.   �� 5      -   5        $ Bot_Row��5      $	��89* �6-   .+�5   
       OrderForm.InformationPanel  -   5          Name$ 
InfoPanels��5   !   $��0��65   $��
0,0,0,1740q�6B   $��2��6V   �� 5   
   -   5         ��Name$ FoodList��5   $   $��1��6   ��5      �� 5      .R�5      � $��MyList��6    $��35,0,0,0q�6/   	 J� Opacity$	 1Q�6A   5      5      5      5       