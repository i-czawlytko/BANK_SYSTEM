   M S B A M L   `   `   `  ����B  >BankADO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:BankADOBankADO  5   	       BankADO.AddWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:BankADO     5   	     � Title$  	AddWindow��5   	   $	��150��6   $	��350��6(   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� -   5         ��Name$ nameBox��5      $��5q�6#   $��1��6.   $��0��6>   �� 5   
   -   5        $ lastnameBox��5      $��5q�6'   $��1��62   $��1��6B   �� 5   
   -   5        $ dateBox��5      $��5q�6#   $��1��6.   $��2��6>   �� 5   
   -   5         ��Name$ 	nameBlock��5      $��5q�6'   $
��str1��62   $��0��6>   $��0��6N   �� 5   
   -   5        $ lastnameBlock��5      $��5q�6+   $
��str2��66   $��0��6B   $��1��6R   �� 5   
   -   5        $ 	dateBlock��5      $��5q�6'   $
��str3��62   $��0��6>   $��2��6N   �� 5   
   -   5         ��Name$ okBtn��5      $��3��6    $��0��6-   $
��10,5q�6=   $��OK��6K   �� 5   
   -   5        $ 	cancelBtn��5      $��3��6$   $��1��61   $
��10,5q�6A   $��Отмена��6O   5      5       