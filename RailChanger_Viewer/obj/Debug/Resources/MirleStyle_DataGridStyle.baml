   M S B A M L   `   `   `  ����M  IRailChanger_Viewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MaterialDesignThemes.WpfMaterialDesignThemes.Wpf  5   )   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962a=   7System.Windows.Controls.Primitives.DataGridColumnHeader  �� 
TargetType &  "MaterialDesignDataGridColumnHeader �� BasedOn �� Property �� Value �� 
TargetType'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� 
TargetName	 �� TargetProperty8  2System.Windows.Media.Animation.EasingColorKeyFrame
 �� KeyTime �� Value ��Name �� Padding J� SnapsToDevicePixels)  #System.Windows.Controls.DataGridRow  MaterialDesignDataGridRow �� 
StartPoint �� EndPoint � Offset � Color?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid � ColumnDefinitions � RowDefinitions?  9System.Windows.Controls.Primitives.DataGridCellsPresenter   
ItemsPanelA  ;System.Windows.Controls.Primitives.DataGridDetailsPresenter   DetailsVisibility$   SelectiveScrollingOrientation;	  5System.Windows.Controls.SelectiveScrollingOrientation 	  Vertical �� ConverterParameter&
   System.Windows.Controls.DataGrid# 
  RowDetailsScrollingConverter �� 	Converter �� RelativeSource �� AncestorType:  4System.Windows.Controls.Primitives.DataGridRowHeader7  1System.Windows.Controls.DataGridHeadersVisibility
   Row! 
  HeadersVisibilityConverter�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5   )   .wpf&clr-namespace:MaterialDesignThemes.Wpf  5   )   FmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   )   %]  '         7   '  �    7  �� 5      "    6   8   .�5   
   ��  � ��$ Center=�65   �� 5	   
    � ��$ 30��6#   �� 5
   
    �@  SeparatorBrush
 �   �6+   �� 5   
    � ��$ Medium"�6'   �� 5   
    � ��
 �����6'   �� 5   
    � ��$ 15(�6%   �� 5   
    � ��$ Microsoft San Self)�6'   �� 5   
    � �� 5      �� 5      "   6"   .R�5      �  5        5      CommonStates��. 5   "     
Normal��6.     5   "   	MouseOver��. 5   &   �� .��5   *   �� $ columnHeaderBorder��6G   $N	 H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�6r   .g�5   .     $
 0��6B   $
 Gray��6N   5   +   5   '   5   #   5      .+�5       �� $ columnHeaderBorder��6!   $	��1.5q�5!      $ 11,0,3,0q�5"      ���#140F27���#333333._�5%      �� #��z��5&   !   #��z��5'   !   # z 5(   !   5)      5*      5+      5-      5.      �� 51      "   6   8   .�52   
   ��  � ��$ 16(�6%   �� 53   
    � ��
 �����6'   �� 54   
    �@J�SnapsToDevicePixels . 60   �� 55   
    �@=�ErrorTemplate 65   Z� �� 56   
    �@ ValidationErrorTemplate 57      �� 58      .R�59      �� $��1,0,0,0q�6    $��Center=�5:      
���  ��$��!��5<      5=      5?      �� 5@   
    � �� 5A      �� 5B      "  6"   .R�5C      �� $ 
DGR_Border��6   #��z��5D      #��z��5E       . ��5G      �� 5H      $ 0.5,0&�62   $ 0.5,1&�6E   .��5J   "   � $ 0Q�6/   $ #282536��6:   � 5L   "   $ 1Q�6/   $ #282536��6:   5M       5O        5P      CommonStates��. 5Q   "     
Normal��6.     5R   "   Normal_AlternatingRow��. 5S   &   �� .��5T   *   �� $ 
DGR_Border��6G   $N	 H(Panel.Background).(GradientBrush.GradientStops)[0].(GradientStop.Color)�6j   .g�5V   .     $
 0��6B   $ #1E1A30��6N   5W   +   �� 5X   *   $ 
DGR_Border��6G   $N	 H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�6j   .g�5Z   .     $
 0��6B   $ #1E1A30��6N   5[   +   5\   '   5]   #     5^   "   Normal_Selected��. 5_   &   �� .��5`   *   �� $ 
DGR_Border��6G   $g	 a(Panel.Background).                         (GradientBrush.GradientStops)[0].(GradientStop.Color)�6j   .g�5b   .     $
 0��6B   $ #6F6D79��6N   5c   +   �� 5d   *   $ 
DGR_Border��6G   $g	 a(Panel.Background).                         (GradientBrush.GradientStops)[1].(GradientStop.Color)�6j   .g�5f   .     $
 0��6B   $ #6F6D79��6N   5g   +   5h   '   5i   #     5j   "   	MouseOver��. 5k   &   �� .��5l   *   �� $ 
DGR_Border��6G   $g	 a(Panel.Background).                         (GradientBrush.GradientStops)[0].(GradientStop.Color)�6j   .g�5n   .     $
 0��6B   $ #6F6D79��6N   5o   +   �� 5p   *   $ 
DGR_Border��6G   $g	 a(Panel.Background).                         (GradientBrush.GradientStops)[1].(GradientStop.Color)�6j   .g�5r   .     $
 0��6B   $ #6F6D79��6N   5s   +   5t   '   5u   #   5v      ._�5x         5y      �� 5z   "   $
��Auto �63   �� 5{   "   $��* �63    5}      �� 5~   "   $��* �60   �� 5   "   $
��Auto �60   .+�5�        $��1��65   #��z 5�       # z 5�         5�      $��1��67   $��1��5�   "   #y�z 5�   "    5�   "   �� *AreRowDetailsFrozen+# Z # Z  �� " 
 5�   "     5�      $��2��60   $ Vertical=�5�      y�5�      �� *HeadersVisibility+# Z # Z  �� " 
 5�      5�      5�      5�      5�      5�      