   M S B A M L   `   `   `  ���� F  BDisplayMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:OrderForm	OrderForm      OrderForm.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:OrderForm     -     � Title$  
MainWindow��$
��1920��$
��1080�� � WindowStartupLocation$ Manual=� � WindowStyle$
 None=� � ShowInTaskbar .   � Topmost . $��	0,100,0,0q�.���  � RowDefinitions �� -    ��Name$ Top_Row��$��7* ��� -   $ Bot_Row��$	��89* �.+�    OrderForm.InformationPanel  -     Name$ 
InfoPanels��$��0��$��
0,0,0,1740q�$��2��� $��1�� � ColumnDefinitions �� $	��95* ��� -   	 ��Name$	 HeadersGrid��$��5* �.+��� -   
 ��Name$
 FoodList��$��0��$��1��$��5,0,0,0q����� .R�� $��MyList��$��0,0,0,0q� J� Opacity$ 1Q�� -    �Name$ HeadersPanel��$��Right=�$��1��