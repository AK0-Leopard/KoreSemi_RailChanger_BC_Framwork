   M S B A M L   `   `   `  ���� M  IRailChanger_Viewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MaterialDesignThemes.WpfMaterialDesignThemes.Wpf  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962a=   7System.Windows.Controls.Primitives.DataGridColumnHeader  �� 
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
+   AllG  ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter,  Name-   Column. ��Name/ �� CanContentScroll0 ��Name1 �� ScrollableHeight2 � Maximum3 �� Orientation  MyScrollBar4 �� ViewportHeight5 �� ViewportSize*6 �� #ComputedVerticalScrollBarVisibility7 � Value8 �� Mode9 �� ScrollableWidth: �� ViewportWidth,; �� %ComputedHorizontalScrollBarVisibility< �� Triggers= P� Property> P� Value  bool2VisibilityConverter # MaterialDesignDataGridRowHeader�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     .wpf&clr-namespace:MaterialDesignThemes.Wpf  FmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  %\  '         7   '  �    7  '  �	    7  'd�     '
  �    7  &	 �    '  �    7  �� "    8   .���  � ��$ Center=���  � ��$ 30����  �@  SeparatorBrush
 �   ���  � ��$ Medium"���  � ��
 �������  � ��$ 15(���  � ��$ Microsoft San Self)���  � �� �� "   .R��    CommonStates��.   
Normal��  	MouseOver��. �� .���� $ columnHeaderBorder��$N	 H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�.g�  $
 0��$
 Gray��.+��� $ columnHeaderBorder��$��1q�$ 11,0,3,0q����� $ 0.5,0&�$ 0.5,1&�.��� $ 0Q�$ #140F27��� $ 1Q�$ #140F27������ $ 0.5,0&�$ 0.5,1&�.��� $ 0Q�$ #333333��� $ 1Q�$ #333333��._��� #��z��#��z��# z �� "   8   .���  � ��$ 16(���  � ��
 �������  �@J�SnapsToDevicePixels . ��  �@=�ErrorTemplate Z� ��  �@ ValidationErrorTemplate �� .R��� $��1,0,0,0q�$��Center=�
���  ��$��!����  � �� �� "  .R��� $ 
DGR_Border��#��z��#��z�� . ���� $ 0.5,0&�$ 0.5,1&�.��� $ 0Q�$ #282536��� $ 1Q�$ #282536��   CommonStates��.   
Normal��  Normal_AlternatingRow��. �� .���� $ 
DGR_Border��$N	 H(Panel.Background).(GradientBrush.GradientStops)[0].(GradientStop.Color)�.g�  $
 0��$ #1E1A30���� $ 
DGR_Border��$N	 H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�.g�  $
 0��$ #1E1A30��  Normal_Selected��. �� .���� $ 
DGR_Border��$g	 a(Panel.Background).                         (GradientBrush.GradientStops)[0].(GradientStop.Color)�.g�  $
 0��$ #6F6D79���� $ 
DGR_Border��$g	 a(Panel.Background).                         (GradientBrush.GradientStops)[1].(GradientStop.Color)�.g�  $
 0��$ #6F6D79��  	MouseOver��. �� .���� $ 
DGR_Border��$g	 a(Panel.Background).                         (GradientBrush.GradientStops)[0].(GradientStop.Color)�.g�  $
 0��$ #6F6D79���� $ 
DGR_Border��$g	 a(Panel.Background).                         (GradientBrush.GradientStops)[1].(GradientStop.Color)�.g�  $
 0��$ #6F6D79��._�   �� $
��Auto ��� $��* � �� $��* ��� $
��Auto �.+�  $��1��#��z # z   $��1��$��1��#y�z  �� *AreRowDetailsFrozen+# Z # Z  �� " 
   $��2��$ Vertical=�y��� *HeadersVisibility+# Z # Z  �� " 
 �� "   8   .���  � �� �� "  .R��� $ border��
������ 
������ $��1q� .    FocusStates��.   	Unfocused��  Focused��  CurrentStates��.   Regular��  Current��. �� .���� $ border��$2	 ,(Border.BorderBrush).(SolidColorBrush.Color)�.g�  $
 0��$ 	LightBlue��._��� # z ��  � ��$ 5,0,0,0q��� "  d�.���  � ��$ 3q���  � �� �� " d�.R��    CommonStates��.   
Normal��  	MouseOver��. �� .���� $ DefaultPath��$)	 #(Path.Fill).(SolidColorBrush.Color)�.g��� $
 0:0:0.2��$ 	LightGray��  Pressed��  Disabled��  CheckStates��.   Checked��. �� .��T� $  0D�$ DefaultPath��$	 
Visibility�..�i� $! 0��"  	Collapsed=�T� $  0D�$ CheckedPath��$	 
Visibility�..�i� $! 0��"  Visible=��� $ CheckedPath��$)	 #(Path.Fill).(SolidColorBrush.Color)�.g��� $
 0:0:0.5��$ #282536��  	Unchecked��.+��� $# contentPresenter��#��z��#��z��#��z��#��z��#��z��F� $$ DefaultPath��$	��Top=�"����        р�� ��j �    ��� 	
�������$
% Fill=�F� $$ CheckedPath��$	��Top=�"����        р��     ���j ��� 	
�������$
% Fill=�$y�	Collapsed=��� "  
 8   .���  � ��# � ����  � ��
 �������   �@
 RowDetailsVisibilityMode$ VisibleWhenSelected=���  � �� . ��  �@��PanningMode$
 Both=���  �@��IsFlicksEnabled .  ��  � �� �� " 
 .R��� #��z�����#333333$��5q�$& 0��# z�� . ._��� $' DG_ScrollViewer��|�.  ���� " ��.R��  �� $
��Auto ��� $��* ��� $
��Auto � �� $
��Auto ��� $��* ��� $
��Auto �.+��� #��Z( |�.  ���� *CellsPanelHorizontalOffset+ �� " 
 ��C� *�� $") DataGridSelectAllButtonStyle��"* 
 +y��� *HeadersVisibility+# Z+ # Z  �� " 
   $!, PART_ColumnHeadersPresenter��$��1��y��� *HeadersVisibility+# Z- # Z  �� " 
 �� $!. PART_ScrollContentPresenter��$��1��$��2��#/ z���� $0 PART_VerticalScrollBar��$��1��$��2��#2 z1 $3 Vertical=�#���  #5 z4 #y�z6 7 �� *VerticalOffset+$8 OneWay=� �� *TemplatedParent+� $��2��$��1�� �� ���� **(NonFrozenColumnsViewportHorizontalOffset+ �� " 
 �� $��* �.+��� $0 PART_HorizontalScrollBar��$��1��#2 z9 $3 
Horizontal=�#5 z: #y�z; 7 �� *HorizontalOffset+$8 OneWay=� �� *TemplatedParent+.���� # z < P� = �@��
IsGrouping> . . ���  � �� . �� �� "   8   .���  � ��$ 25����  � �� �� "  .R�� 