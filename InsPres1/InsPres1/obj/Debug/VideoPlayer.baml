   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.0.0, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   C ?InsPres1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:InsPres1InsPres1 5   	      InsPres1.VideoPlayer   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   (localclr-namespace:InsPres1     5   	   -   5        $��VideoPlayerWindow��5
   	   (   "MahApps.Metro.Controls.MetroWindow    ShowTitleBar  .  � WindowState$ 	Maximized=�5   	    � Title$ 	VideoName��5   	   $	��550��6   $	��725��6(   
���   � � 	Resources 5         Play 	 Pause  RepeatG  RepeatB  Stop��%^  &	        &	 l     &	 �     &	 L    &	 �    �� 5   
   $��Resources/play.png��6   $��Center=�69   $��Center=�6T   $��35��6q   $��35��6}   �� 5   
   $��Resources/pause.png��6   $��Center=�6;   $��Center=�6V   $��35��6s   $��35��6   �� 5   
   $��Resources/repeat_grey.png��6    $��Center=�6C   $��Center=�6^   $��20��6{   $��20��6�   �� 5   
   $ ��Resources/repeat_black.png��6    $��Center=�6D   $��Center=�6_   $��20��6|   $��20��6�   �� 5   
   $��Resources/stop.png��6   $��Center=�69   $��Center=�6T   $��25��6q   $��25��6}   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $	��10* �6   �� 5      $	��100 �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��40* �6   �� 5      $��* �6   .+�5    
   r� -   5         r�Name$ mediaElement��5%      $��0��5!      $��0��5"      $��2��5#      $��3��5$       r� UnloadedBehavior$ Manual=�5&       r� LoadedBehavior$ Manual=�5'      5,      � 5.   
   -   5        $��cntlGrid��5.      $��1��6   $��2��6/   $��-2.31,0,2.309,0q�6<    5/      �� 50      $
��0.8* �6    �� 51      $��* �6    �� 52      $
��0.1* �6     54      �� 55      $��80 �6#   �� 56      $��60 �6#   �� 57      $��60 �6#   �� 58      $��* �6#   �� 59      $��50 �6#   .+�5;      d� -   5        $��Play_Pause_button��5<      $��0��5=        SquareButtonStyle#���  5>      $��1q�5?   ,   #��[  5@      $��1��5A      $��Center=�5B      $��Center=�5C      $��70��5D      	 � UseLayoutRounding	 .  6   �� 5G      -   5        $��Stop_button��5G      $��1��6(   #���  68   $��1q�6y   #��[ 6�   $��1��6�   $��10,12.053,10,5.052q�6�   d� 5H      -   5        $��Repeat_button��5H      $��2��60   $��1��6@   #���  6M   #��[ 6�   $��10,12.053,10,5.052q�6�   �� 5I      -   5        $��Position_slider��5I      $��1��6-   $��3��6=     MetroSlider#��[ 6Q   $��10,7.68,0,9.998q�6  �� 5J      -   5        $��Volume_slider��5J      $��3��6*   
 J� RenderTransformOrigin$
 0.472,1.826&�6�   $��0,16.105,10,10q�6�   $��1��6�   $��Right=�6  $��85��6)   � Value 6d   ��  �� ElementName$ mediaElement�� �� Path$ Volume� �� Mode$ TwoWay=�6)  �� 5K      -	   5         ��Name$ 	textBlock��5K      $
��Wrap=�6+   $��k��6?   $��0��6H   $��0��6X   $��Right=�6e   $��Center=�6�   ���	#FFFFFDFD6�   �� 5L      -
   5        $ 
textBlock1��5L      $��4��6,   $��0��6<   $
��Wrap=�6J   $��	TextBlock��6^   
�������$��Center=�6�   $
��Left=�6�   $��5,0,0,0q�6�   �� 5M      -   5        $ 
textBlock2��5M      $��4��6,   $��1��6<   $��0,0.543,0.503,0q�6I   $
��Wrap=�6c   
�������$
 -0.285,0.176&�6�   $��10.667(�6�   �� 6�   $�     Volume��6�   �� 6�   �� 6�   $�0 100 %��6�   �� 6�   �� 6  6  5N      5O      5Q      