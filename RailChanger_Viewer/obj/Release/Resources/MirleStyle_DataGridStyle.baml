   M S B A M L   `   `   `  ���� M  IRailChanger_Viewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MaterialDesignThemes.WpfMaterialDesignThemes.Wpf  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962a=   7System.Windows.Controls.Primitives.DataGridColumnHeader  �� 
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
  HeadersVisibilityConverter�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     .wpf&clr-namespace:MaterialDesignThemes.Wpf  FmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  %	  '         7   '  B    7  �� "    8   .���  � ��$ Center=���  � ��$ 30����  �@  SeparatorBrush
 �   ���  � ��$ Medium"���  � ��
 �������  � ��$ 15(���  � ��$ Microsoft San Self)���  � �� �� "   .R��    CommonStates��.   
Normal��  	MouseOver��. �� .���� $ columnHeaderBorder��$N	 H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�.g�  $
 0��$
 Gray��.+��� $ columnHeaderBorder��$	��1.5q�$ 11,0,3,0q����#140F27���#333333._��� #��z��#��z��# z �� "   8   .���  � ��$ 16(���  � ��
 �������  �@J�SnapsToDevicePixels . ��  �@=�ErrorTemplate Z� ��  �@ ValidationErrorTemplate �� .R��� $��1,0,0,0q�$��Center=�
���  ��$��!����  � �� �� "  .R��� $ 
DGR_Border��#��z��#��z�� . ���� $ 0.5,0&�$ 0.5,1&�.��� $ 0Q�$ #282536��� $ 1Q�$ #282536��   CommonStates��.   
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
��Auto �.+�  $��1��#��z # z   $��1��$��1��#y�z  �� *AreRowDetailsFrozen+# Z # Z  �� " 
   $��2��$ Vertical=�y��� *HeadersVisibility+# Z # Z  �� " 
 