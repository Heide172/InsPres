   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.0.0, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   C ?InsPres1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:InsPres1InsPres1 5   	   9!clr-namespace:InsPres1.PropertiesInsPres1.Properties 5   	      InsPres1.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   (localclr-namespace:InsPres1     5   	   1res!clr-namespace:InsPres1.Properties     5   	   U QGongSolutions.WPF.DragDrop, Version=1.1.0.0, Culture=neutral, PublicKeyToken=nullddurn:gong-wpf-dragdrop  5	   	   (   "MahApps.Metro.Controls.MetroWindow    ShowTitleBar  . $	��350��5   
   $	��525��6   
������� � 	Resources 5       	  wrpnl��%2   &	        �� 5   
   .R�5      � 5      5         LeftWindowCommands 5      +   %MahApps.Metro.Controls.WindowCommands  5   
   $
��Left=�6"   .@�5      �� $��InsPres��6   $��Center=�6'   $��16(�6B   $��10,0,5,0q�6P   �� 5      -   5        $��settings��5      5      5      .��5      �  � RowDefinitions 5   
   �� 5       $��25 �6   �� 5!      $
��4.2* �6   �� 5"      $��* �6    � ColumnDefinitions 5$   
   �� 5%      $
��0.5* �6   �� 5&      $
��7.5* �6   �� 5'      $��* �6   .+�5)   
   �� -   5         ��Name$ button��5)      #  InsPres1.Properties.Resources   OkButtonText#��Z 6!   $��17��6Q   $��2��6^   $��1��5*      $��Bottom=�6   $y�Hidden=�65   �� 5,   
   $��0��6   $��0��6!   $��3��6.   $��0q�6B   ._�5-      o� -   5        $
��menu��5-   0   $��1��6   $��0��6#   $��25��6<   ���#41b1dc$��LeftToRight=�6z   .@�5.      m�    FileMenuHeader#��Z 6   $��10(�6L   $��0q�6Z    J� RenderTransformOrigin$ 
0.31,0.494&�6e   $
��Left=�6�   .@�5/      m� -   5        	   NewMenuHeader#��Z	 5/      6O   m� 50      -   5        
   OpenMenuHeader#��Z
 50      6P   m� 51      -   5           SaveMenuHeader#��Z 51      6P   m� 52      -   5           SaveAsMenuHeader#��Z 52      6R   53      m� 54      -   5           EditMenuHeader#��Z 54      $��10(�6L   $��0q�6Z   $ 
0.31,0.494&�6e   $
��Left=�6�   6�   55      56      �� 58   
   -	   5        $��Panel1��58      #��[  59      $��1��5:      $��1��5;      $��1��5<      )  #GongSolutions.Wpf.DragDrop.DragDrop   IsDragSource .    IsDropTarget . $��Disabled=�5?      ��5B      �� 5C       �� 
TargetType" ��6   .�5D      ��  �� Property �@�FocusVisualStyle �� Value 69   Z�  �� Triggers 5F      P� 5H       P� Property �@��
IsSelected P� Value . . �5I      ��  � ��
 �����6;   �� 5J       � ��$ 1q�6@   �� 5K       � ��
 �   �6<   5L      :� 5M       :� RoutedEvent$ DragOver��6'   5O      5R      5T      5X      5]      