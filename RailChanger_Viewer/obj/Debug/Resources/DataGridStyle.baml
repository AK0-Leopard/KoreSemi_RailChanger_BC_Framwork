   M S B A M L   `   `   `  ����M  IRailChanger_Viewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MaterialDesignThemes.WpfMaterialDesignThemes.Wpf  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962a=   7System.Windows.Controls.Primitives.DataGridColumnHeader  �� 
TargetType &  "MaterialDesignDataGridColumnHeader �� BasedOn �� Property �� Value �� 
TargetType'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� 
TargetName	 �� TargetProperty8  2System.Windows.Media.Animation.EasingColorKeyFrame
 �� KeyTime �� Value ��Name �� Padding �� 
StartPoint �� EndPoint � Offset � Color J� SnapsToDevicePixels)  #System.Windows.Controls.DataGridRow  MaterialDesignDataGridRow?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid � ColumnDefinitions � RowDefinitions?  9System.Windows.Controls.Primitives.DataGridCellsPresenter   
ItemsPanelA  ;System.Windows.Controls.Primitives.DataGridDetailsPresenter   DetailsVisibility$   SelectiveScrollingOrientation;	  5System.Windows.Controls.SelectiveScrollingOrientation 	  Vertical �� ConverterParameter&
   System.Windows.Controls.DataGrid# 
  RowDetailsScrollingConverter �� 	Converter �� RelativeSource �� AncestorType:  4System.Windows.Controls.Primitives.DataGridRowHeader7  1System.Windows.Controls.DataGridHeadersVisibility
   Row! 
  HeadersVisibilityConverter*  $System.Windows.Controls.DataGridCell  MaterialDesignDataGridCell  g� Duration! R� KeyTime" R� Value  System.Windows.Visibility# ��Name$ F�Name% �� Stretch  MaterialDesignDataGrid& �� CornerRadius' ��Name( 
  SelectAllCommand) �� 
ResourceId* �� TypeInTargetAssembly
+   AllG  ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter,  Name-   Column. ��Name/ �� CanContentScroll0 ��Name1 �� ScrollableHeight2 � Maximum3 �� Orientation  MyScrollBar4 �� ViewportHeight5 �� ViewportSize*6 �� #ComputedVerticalScrollBarVisibility7 � Value8 �� Mode9 �� ScrollableWidth: �� ViewportWidth,; �� %ComputedHorizontalScrollBarVisibility< �� Triggers= P� Property> P� Value  bool2VisibilityConverter # MaterialDesignDataGridRowHeader�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      .wpf&clr-namespace:MaterialDesignThemes.Wpf  5      FmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      %�!  '         7   '  �    7  '  g    7  'd�     '
  1    7  &	 d     '  w     7  �� 5      "    6   8   .�5	   
   ��  � ��$ Center=�65   �� 5
   
    � ��$ 30��6#   �� 5   
    �@  SeparatorBrush
 �   �6+   �� 5   
    � ��$ Medium"�6'   �� 5   
    � ��
 �����6'   �� 5   
    � ��$ 15(�6%   �� 5   
    � ��$ Microsoft San Self)�6'   �� 5   
    � �� 5      �� 5      "   6"   .R�5      �  5        5      CommonStates��. 5   "     
Normal��6.     5   "   	MouseOver��. 5   &   �� .��5   *   �� $ columnHeaderBorder��6G   $N	 H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�6r   .g�5   .     $
 0��6B   $
 Gray��6N   5   +   5   '   5   #   5      .+�5!      �� $ columnHeaderBorder��6!   $��1q�5"      $ 11,0,3,0q�5#      ��5$      �� 5%   "   $ 0.5,0&�66   $ 0.5,1&�6I   .��5'   &   � $ 0Q�63   $ #140F27��6>   � 5)   &   $ 1Q�63   $ #140F27��6>   5*   #   ��5,      �� 5-   "   $ 0.5,0&�66   $ 0.5,1&�6I   .��5/   &   � $ 0Q�63   $ #333333��6>   � 51   &   $ 1Q�63   $ #333333��6>   52   #   ._�54      �� #��z��6/   #��z��55      # z 56      57      58      59      5;      5<      �� 5?      "   6   8   .�5@   
   ��  � ��$ 16(�6%   �� 5A   
    � ��
 �����6'   �� 5B   
    �@J�SnapsToDevicePixels . 60   �� 5C   
    �@=�ErrorTemplate 65   Z� �� 5D   
    �@ ValidationErrorTemplate 5E      �� 5F      .R�5G      �� $��1,0,0,0q�6    $��Center=�5H      
���  ��$��!��5J      5K      5M      �� 5N   
    � �� 5O      �� 5P      "  6"   .R�5Q      �� $ 
DGR_Border��6   #��z��5R      #��z��5S       . ��5U      �� 5V      $ 0.5,0&�62   $ 0.5,1&�6E   .��5X   "   � $ 0Q�6/   $ #282536��6:   � 5Z   "   $ 1Q�6/   $ #282536��6:   5[       5]        5^      CommonStates��. 5_   "     
Normal��6.     5`   "   Normal_AlternatingRow��. 5a   &   �� .��5b   *   �� $ 
DGR_Border��6G   $N	 H(Panel.Background).(GradientBrush.GradientStops)[0].(GradientStop.Color)�6j   .g�5d   .     $
 0��6B   $ #1E1A30��6N   5e   +   �� 5f   *   $ 
DGR_Border��6G   $N	 H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�6j   .g�5h   .     $
 0��6B   $ #1E1A30��6N   5i   +   5j   '   5k   #     5l   "   Normal_Selected��. 5m   &   �� .��5n   *   �� $ 
DGR_Border��6G   $g	 a(Panel.Background).                         (GradientBrush.GradientStops)[0].(GradientStop.Color)�6j   .g�5p   .     $
 0��6B   $ #6F6D79��6N   5q   +   �� 5r   *   $ 
DGR_Border��6G   $g	 a(Panel.Background).                         (GradientBrush.GradientStops)[1].(GradientStop.Color)�6j   .g�5t   .     $
 0��6B   $ #6F6D79��6N   5u   +   5v   '   5w   #     5x   "   	MouseOver��. 5y   &   �� .��5z   *   �� $ 
DGR_Border��6G   $g	 a(Panel.Background).                         (GradientBrush.GradientStops)[0].(GradientStop.Color)�6j   .g�5|   .     $
 0��6B   $ #6F6D79��6N   5}   +   �� 5~   *   $ 
DGR_Border��6G   $g	 a(Panel.Background).                         (GradientBrush.GradientStops)[1].(GradientStop.Color)�6j   .g�5�   .     $
 0��6B   $ #6F6D79��6N   5�   +   5�   '   5�   #   5�      ._�5�         5�      �� 5�   "   $
��Auto �63   �� 5�   "   $��* �63    5�      �� 5�   "   $��* �60   �� 5�   "   $
��Auto �60   .+�5�        $��1��65   #��z 5�       # z 5�         5�      $��1��67   $��1��5�   "   #y�z 5�   "    5�   "   �� *AreRowDetailsFrozen+# Z # Z  �� " 
 5�   "     5�      $��2��60   $ Vertical=�5�      y�5�      �� *HeadersVisibility+# Z # Z  �� " 
 5�      5�      5�      5�      5�      �� 5�      "   6   8   .�5�   
   ��  � �� 5�      �� 5�      "  6"   .R�5�      �� $ border��6   
������ 
������ $��1q�5�       .  5�        5�      FocusStates��. 5�   "     	Unfocused��6.     5�   "   Focused��6.   5�        5�      CurrentStates��. 5�   "     Regular��6.     5�   "   Current��. 5�   &   �� .��5�   *   �� $ border��6G   $2	 ,(Border.BorderBrush).(SolidColorBrush.Color)�6f   .g�5�   .     $
 0��6B   $ 	LightBlue��6N   5�   +   5�   '   5�   #   5�      ._�5�      �� # z 6+   5�      5�      5�      �� 5�   
    � ��$ 5,0,0,0q�6#   5�      �� 5�      "  d�6   .�5�   
   ��  � ��$ 3q�6$   �� 5�   
    � �� 5�      �� 5�      " d�6"   .R�5�      �  5�        5�      CommonStates��. 5�   "     
Normal��6.     5�   "   	MouseOver��. 5�   &   �� .��5�   *   �� $ DefaultPath��6G   $)	 #(Path.Fill).(SolidColorBrush.Color)�6k   .g�5�   .   �� $
 0:0:0.2��6B   $ 	LightGray��6T   5�   +   5�   '   5�   #     5�   "   Pressed��6.     5�   "   Disabled��6.   5�        5�      CheckStates��. 5�   "     Checked��. 5�   &   �� .��5�   *   T� $  0D�6H   $ DefaultPath��5�   *   $	 
Visibility�5�   *   ..�5�   .   i� $! 0��6E   " 5�   2    5�   6   	Collapsed=�6L   5�   /   5�   +   T� 5�   *   $  0D�6H   $ CheckedPath��5�   *   $	 
Visibility�5�   *   ..�5�   .   i� $! 0��6E   " 5�   2    5�   6   Visible=�6J   5�   /   5�   +   �� 5�   *   $ CheckedPath��6G   $)	 #(Path.Fill).(SolidColorBrush.Color)�6k   .g�5�   .   �� $
 0:0:0.5��6B   $ #282536��6T   5�   +   5�   '   5�   #     5�   "   	Unchecked��6.   5�      .+�5�      �� $# contentPresenter��6+   #��z��5�      #��z��5�      #��z��5�      #��z��5      #��z��5     F� 5     $$ DefaultPath��6   $	��Top=�5     "����        р�� ��j �    ��� 	
�������$
% Fill=�5     F� 5	     $$ CheckedPath��6   $	��Top=�5
     "����        р��     ���j ��� 	
�������$
% Fill=�5     $y�	Collapsed=�5     5     5     5     5     �� 5     "  
 6   8   .�5  
   ��  � ��# � ��6'   �� 5  
    � ��
 �����6'   �� 5  
     �@
 RowDetailsVisibilityMode$ VisibleWhenSelected=�65   �� 5  
    � �� . 6:   �� 5  
    �@��PanningMode$
 Both=�65   �� 5  
    �@��IsFlicksEnabled .  63   �� 5  
    � �� 5     �� 5     " 
 6"   .R�5      �� #��z��6   ���#333333$��5q�5"     $& 0��5#     # z��5$      . ._�5&     �� $' DG_ScrollViewer��6'   |�.  ��5'     �� 5(  "   " ��62   .R�5)  &   �  5*  *   �� 5+  .   $
��Auto �6?   �� 5,  .   $��* �6?   �� 5-  .   $
��Auto �6?    5/  *   �� 50  .   $
��Auto �6<   �� 51  .   $��* �6<   �� 52  .   $
��Auto �6<   .+�54  *   �� #��Z( 56     |�.  ��54  1   �� *CellsPanelHorizontalOffset+ �� " 
 ��58     C� *�� $") DataGridSelectAllButtonStyle��"* 
 +y�5:     �� *HeadersVisibility+# Z+ # Z  �� " 
   5>  *   $!, PART_ColumnHeadersPresenter��6I   $��1��5?  +   y�5@  +   �� *HeadersVisibility+# Z- # Z  �� " 
 �� 5D  *   $!. PART_ScrollContentPresenter��6A   $��1��5E  #   $��2��5F  #   #/ z��5G  #   �� 5H  *   $0 PART_VerticalScrollBar��64   $��1��5I     $��2��5J     #2 z1 5K     $3 Vertical=�5L     #���  5M     #5 z4 5N     #y�z6 5O     7 5P     �� *VerticalOffset+$8 OneWay=� �� *TemplatedParent+� 5S  *   $��2��6/   $��1��6<    5T  .   �� 5U  2   ��6C   �� **(NonFrozenColumnsViewportHorizontalOffset+ �� " 
 �� 5V  2   $��* �6C   .+�5X  .   �� $0 PART_HorizontalScrollBar��68   $��1��5Y     #2 z9 5Z     $3 
Horizontal=�5[     #5 z: 5\     #y�z; 5]     7 5^     �� *HorizontalOffset+$8 OneWay=� �� *TemplatedParent+5a  +   5b  '   5c  #   .��5e     �� # z 6-   5f     5h     5i     5k     < 5l  
   P� 5m     = �@��
IsGrouping> . . �5n     ��  � �� . 6B   5o     5q     �� 5s     6#   �� 5v     "   6   8   .�5w  
   ��  � ��$ 25��6"   �� 5x  
    � �� 5y     �� 5z     "  6"   .R�5{     � 5|     5}     5     5�     5�     