   M S B A M L   `   `   `  ����K  GFileManager_Lab2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:FileManager_Lab2FileManager_Lab2  5   	       FileManager_Lab2.Window1   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   0localclr-namespace:FileManager_Lab2     5   	     � Title$  Text Editor��5   	   $��503.008��6   $	��900��6/   .��5      �  � RowDefinitions 5	   
   �� 5
      $
��auto �6   �� 5      $��* �6   .+�5   
   ��  �� CornerRadius$ 7,15,7,4��6   $��5q�6)   ._�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      ��  � ToolTip$
 Open��6   $
��Open��6(   .��5      �� $��Resource/open.png��6   69   5      �� 5      $	 New��6   $	��New��6'   .��5      �� $��Resource/New.png��6   68   5      �� 5      $
 Save��6   $
��Save��6(   .��5      �� $��Resource/save.png��6   69   5      �� 5      $ 
Save as...��6   $��SaveAs��6.   .��5      �� $��Resource/saveAs.png��6   6;   5      �� 5      $
 Sort��6   $��local:WordsSort.WordSort��6(   .��5      �� $��Resource/sort.png��6   69   5      �� 5      $&�� local:ImageLinkCommand.ImageLink��6   .��5       �� $��Resource/image.png��6   6:   5!      �� 5"      $��3q�6   $ 10��6.   $��10,4,0,4q�6@   ��5#      �� 5$      .��5%      �  � Color$ White��6+    � Offset$	 0.0Q�69   � 5&      $ DarkBlue��6+   $	 0.5Q�6<   5'      ._�5)      �  � ColumnDefinitions 5+      �� 5,      $
��auto �6/   �� 5-      $��* �6/   .+�50      �� -   5        $��TextBoxFind��50   "   $
��5,20q�65   $	��150��6C   .��6O   52      �� 54      $
��Find��6!   $��1��60   $
 Find��6@   $
��10,5q�6O   .��55      �� $��Resource/find1.png��6$   56      57      58      5;      5<      �� 5>   
   -   5        $��TextBox1��5B      $��7q�5>      " �� VerticalScrollBarVisibility$ Visible=�5?      $��1��5@      	 �� AcceptsReturn	 . 5D      5F      5G      