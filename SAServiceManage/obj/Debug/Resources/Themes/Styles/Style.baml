   M S B A M L   `   `   `  ����\  XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089S OHandyControl, Version=3.3.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b^ ZICSharpCode.AvalonEdit, Version=6.1.2.30, Culture=neutral, PublicKeyToken=9cc39be672370310  �� MergedDictionaries �� Source   CirclePanelButton  ButtonCustom �� BasedOn �� 
TargetType �� Property �� Value �� 
TargetType'   !HandyControl.Controls.SimplePanel  CirclePanelDemoGeometry  PrimaryBrush  CirclePanelRightGeometry �� Stretch �� Triggers	 P� Property
 P� Value  TabItemTransparent  TabItemInLine  ListBoxItemTransparent  ListBoxItemBaseStyle 	 Boolean2VisibilityConverter �� 	Converter)  #HandyControl.Controls.BorderElement 
 ListBoxItemNew ��Name �� Padding J� SnapsToDevicePixels �� Orientation  NewGeometry  DangerBrush �� Triggers'  !HandyControl.Controls.EdgeElement �� Path �� RelativeSource  ListBoxTransparent  ListBoxBaseStyle 0 ,FluidMoveBehaviorWrapPanelItemsPanelTemplate  BehaviorXY200(  "HandyControl.Controls.PanelElement   FluidMoveBehavior  MessageBoxCustom&   HandyControl.Controls.MessageBox"  HandyControl.Controls.Window  TextBlockFabricIcons  FabricIcons"  HandyControl.Controls.Sprite  Custom1Transition W� From	 W� To g� Duration �� TargetProperty W� EasingFunction0  *System.Windows.Media.Animation.ElasticEase   Oscillations  Custom2Transition  Custom3Transition  TextEditorCustom'  !ICSharpCode.AvalonEdit.TextEditor  EditorLineNumbersForeground  EditorForeground  RegionBrush � 	Resources/	  )ICSharpCode.AvalonEdit.Rendering.TextView $  EditorNonPrintableCharacterBrush ! EditorLinkTextForegroundBrush ! EditorLinkTextBackgroundBrush-
  'ICSharpCode.AvalonEdit.Editing.TextArea  EditorSelectionBrush  EditorSelectionBorder >� Brush >� 	Thickness K� ZIndex �� 
TargetName   Path4GeometryItem �� AncestorType  �� Binding! �� Value ! DemoGroupItemStyle,  &HandyControl.Controls.SimpleStackPanel#  HandyControl.Controls.Divider"   LineStrokeDashArray#   Content " ToggleButtonStyle1$ �� RadiusY% `� UpdateSourceTrigger& `� 	Converter=  7HandyControl.Tools.Converter.RectangleCircularConverter' �� RadiusX+  %HandyControl.Controls.RectangleAttach # SecondaryBorderBrush $ SecondaryRegionBrush % BorderBrush & Key( �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame) O� KeyTime* O� Value+   EasingFunction.  (System.Windows.Media.Animation.PowerEase7  1System.Windows.Media.Animation.EasingFunctionBase,   
EasingMode- �Name. � ColumnDefinitions/ �� CornerRadius0 J� Opacity1 J� RenderTransformOrigin2 J� Effect3  -System.Windows.Media.Effects.DropShadowEffect3   
BlurRadius4   Color5   	Direction6   Opacity7   RenderingBias8   ShadowDepth9 ��Name: �� ContentStringFormat; �� ContentStringFormat< N� EnterActions= N� ExitActions ' PrimaryTextBrush�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      5      0hc'https://handyorg.github.io/handycontrol  5      ?
avalonedit.http://icsharpcode.net/sharpdevelop/avalonedit  5        5      �� 5   
   $ ../Basic/Geometries.xaml?�6   �� 5   
   $ ../Basic/Fonts.xaml?�6   %�3  &	        7  7  7  &	 �    7  &	 �    7  7 	 &	
 �    7  7  7  &	 �    7  7  &	 %    7  &	 {    7 &	 {
    7  '  �
    7 &	 0   &	    &	 �   &	 �    &	  �    &	!     &	"     �� 5      8   " ��6N   .�5   
   ��  �@�UseLayoutRounding .  6.   �� 5   
    � ��$ 77��6#   �� 5   
    � ��$ 36.06��6"   �� 5   
    � �� 5      �� 5      " ��6"   .R�5         .+�5      F� 8�� #���  6O   $��77��6u   $��36.06��6�   F� 5      8�� $ Uniform=�6P   $��12q�6b   
�������6n   5       5      P� 5      	 �@J�IsMouseOver
 . . �5      ��  �@J�Opacity$ .9Q�68   5      P� 5      	 � ��
 . . �5      ��  �@J�Opacity$ .6Q�68   5      P� 5      	 � {�
 .  . �5      ��  �@J�Opacity$	 0.4Q�68   5      5!      5#      5$      �� 5&      8   " ��6P   .�5'   
   ��  � ��
 ���� 6'   5(      �� 5*      8   " ��6[   .�5+   
   ��  � y� 6'   �� *	IsVisible+8  �� 5,   
    �@ CornerRadius$ 4��6:   �� 5-   
    � ��
 ���� 6'   5.      �� 50      8   " ��6U   .�51   
   ��  � �� 52      �� 53      " ��6"   .R�54      �� $ Bd��6   #��z��6)   #��z��6U   #��z��6�   # z��6�    . ._�55      �� $ 
Horizontal=�6%   .+�56      �� #��z��6/   # z 6r   #��z��6�   F� 57      $��Center=�6#   8�� $ Uniform=�6b   $��10,0,0,0q�6t   $��30��6�   $��14��6�   #���  6�   58      59      5:      5<       5=   
   P� 5>      	 �@ ShowEdgeContent
 . . �5?      ��  � �� 5@      �� 5A      " ��6*   .R�5B      �� $ Bd��6%   #��z��61   #��z��6]   #��z��6�   # z��6�    . ._�5C   "   �� $ 
Horizontal=�6-   .+�5D   &   �� $��16��65   $��16��6@   ��6L   �� $" (hc:EdgeElement.LeftContent)� �� *TemplatedParent+�� 5E   &   $��6,0,0,0q�67   #��z��6H   # z 6�   #��z��6�   F� 5F   &   $��Center=�6+   8�� $ Uniform=�6j   $��10,0,0,0q�6|   $��30��6�   $��14��6�   #���  6�   5G   #   5H      5I      5K      5L      5N      �� 5P      8   " ��6S   .�5Q   
   ��  � ��
 ���� 6'   �� 5R   
    � ��8  6/   5S      �� 5U      .R�5V   
   � $��Center=�6   $��Center=�61   8   6L   5W      �� 5Y      "  6%   8   .�5Z   
   ��  �@ NonClientAreaBackground �#262e2f64   �� 5[   
   " �@ OtherButtonHoverBackground �#88858067   �� 5\   
    �@ OtherButtonForeground
 �����62   �� 5]   
   " �@ OtherButtonHoverForeground
 �����67   �� 5^   
    �@ NonClientAreaForeground
 �����64   �� 5_   
    �@ CloseButtonForeground
 �����62   �� 5`   
    �@�Icon$8 2/HandyControlDemo;component/Resources/Img/icon.ico��6!   5a      �� 5c      " ��6)   .�5d   
   ��  � ��8   6'   �� 5e   
    � ��$ 14(�6%   5f      �� 5h      "  6   8   .�5i   
   ��  � ��$ 25q�6$   5j      �� 5l      .��5m   
   W� $ 50X�6   $ 0X�6$   $ 0:0:0.4D�6+   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6>    5n        5o      $ 1��6   5q      5r      �� 5t      .��5u   
   W� $ 10X�6   $ 0X�6$   $ 0:0:0.4D�6+   $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6>    5v        5w      $ 1��6   5y      5z      �� 5|      .��5}   
   W� $ .8X�6   $ 1X�6$   $ 0:0:0.4D�6+   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6>    5~        5      $ 1��6   5�      5�      �� 5�      "  6%   .�5�   
   ��  �@ 
IsReadOnly . 6'   �� 5�   
    � ��$ Consolas)�6'   �� 5�   
    � ��$ 4q�6#   �� 5�   
    �@ ShowLineNumbers . 6,   �� 5�   
    �@ LineNumbersForeground# �  62   �� 5�   
    � ��# �  6'   �� 5�   
    � ��# �  6'   �� 5�   
    � �� 5�      �� 5�      "  6"    5�      ���� 5�      '	        " 	 6    .�5�      �� " �@	 NonPrintableCharacterBrush# �  6K   �� 5�       �@	 LinkTextForegroundBrush# �  6H   �� 5�       �@	 LinkTextBackgroundBrush# �  6H   5�      �� 5�      '
        " 
 6    .�5�      ��  �@�FocusVisualStyle 6A   Z� �� 5�       �@
 SelectionBrush# �  6?   �� 5�       �@
 SelectionBorder 5�   "   >� 5�   &   # �  6*   $ 1Q�6Z   5�      �� 5�       �@
 SelectionCornerRadius$ 0Q�6F   �� 5�       �@
 SelectionForeground# � ��6D   �� 5�       � �� 5�   "   �� 5�   &   " 
 66   .R�5�   *   ]� |�.  .+�5�   .   �� $
��Left=�6;   |�.  ��6c   �� *LeftMargins+ �� *TemplatedParent+��5�   2   �� 5�   6   .R�5�   :   �� $ 
Horizontal=�6E   5�   7   5�   /   �� 5�   .   $ -1��6?   |�.  ��6Q   �� *
TextView+ �� *TemplatedParent+6�   5�   +   5�   '   5�      5�      5�      .R�5�      �� #��z��6   #��z��6G   #��z��6s   ._�5�      �� $��PART_ScrollViewer��6'   #��z��6@   $
��Left=�6d   $	��Top=�6�   ��. |�.  $
��Auto=�6  $
��Auto=�6A  ��6�   �� *
TextArea+ �� *TemplatedParent+6A  5�       5�      P� 5�      	 �@ WordWrap
 . . �5�      �� $ PART_ScrollViewer��6%    � ��$ Disabled=�6m   5�      5�      5�      5�      �� 5�      " F�6&   .�5�   
   ��  � ��$ 10q�6#   �� 5�   
    � �� 6!   �� *	Info.Data+ �� $ BorderL��� 5�   
    � ��# �  6!   �� 5�   
    � ��$ 20��6"   �� 5�   
    � ��$ 20��6#   �� 5�   
    � ��$ Center=�60   �� 5�   
    � ��$ Center=�6.   �� 5�   
    �@��Stretch$ Uniform=�6$    5�   
   �� 5�        6   �� *	Info.Line+ �� $ BorderL�! True6l   .a�5�      ��  � �� 6)   Z� �� 5�       � ��# �  6+   5�      5�      �� 5�      " ��6'   .�5�   
   ��  � �� 5�      �� 5�      " ��6"   .R�5�        .+�5�        $
" 2, 2R�6>   $
��16,0q�6Y   $��	0,16,0,10q�6h   # 6%   �� *Name+6h   �� 5�      #��z��6)   5�      5�      5�      5�      �� 5�      " d�6'   .�5�   
   ��  �@�FocusVisualStyle 5�      �� 5�      .�5�      ��  � �� 5�      �� 5�      .R�5�   "   �� $ 5�   &   `� 5�   *   $% Default=�67   & 5�   .     5�   2   .1�5�   .   �� $ ActualWidth�66   �� 5�   .   $ ActualHeight�66   5�   +   ' 5�   &   `� 5�   *   $% Default=�67   & 5�   .     5�   2   .1�5�   .   �� $ ActualWidth�66   �� 5�   .   $ ActualHeight�66   5�   +   ��5�   &   �� 5�   *   " ��60   .�5�   .   ��  �@ Circular . 6\    5�   .   �� 5�   2   " ��68   .�5�   6   ��  � ��$ -2q�6O   �� 5�   6    �@J�Opacity$	 0.6Q�6P   �� 5�   6    �@J�SnapsToDevicePixels . 6\   �� 5�   6    � ��# � # 6O   �� 5�   6    � ��$ 2��6X   �� 5�   6    �@��StrokeDashArray$	 1 1R�6X   5   3   5  +   5  #   5     5     5     5
     �� 5  
    � ��# � $ 6'   �� 5  
    � ��# � % 6(   �� 5  
    � ��$ 0q�6,   �� 5  
    � ��$ Center=�65   �� 5  
    � ��$ 6,0,0,0q�6$   �� 5  
    � ��$ 36��6"   �� 5  
    � ��$ 22��6#   �� 5  
    � �� 5     �� 5     " d�6"    5     ���� 5     StoryboardChecked& .��5     U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[0].(TranslateTransform.X)�6<   $( thumb��6�   .\�5  "     $) 0:0:0.2��67   $* 14Q�6I   + 5  &     5  *   $, EaseOut=�64   5  #   5     U� 5     $ Opacity�6<   $( lightBorder��6`   .\�5  "     $) 0:0:0.2��67   $* 1Q�6I   5      U� 5!     $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6<   $( innerBorder��6�   .\�5"  "     $) 0:0:0.2��67   $* 0Q�6I   + 5#  &     5$  *   $, EaseOut=�64   5&  #   5'     U� 5(     $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6<   $( innerBorder��6�   .\�5)  "     $) 0:0:0.2��67   $* 0Q�6I   + 5*  &     5+  *   $, EaseOut=�64   5-  #   5.     5/     �� 50     StoryboardUnChecked& .��51     U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[0].(TranslateTransform.X)�6<   $( thumb��6�   .\�52  "     $) 0:0:0.2��67   $* 0Q�6I   + 53  &     54  *   $, EaseOut=�64   56  #   57     U� 58     $ Opacity�6<   $( lightBorder��6`   .\�59  "     $) 0:0:0.2��67   $* 0Q�6I   5:     U� 5;     $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6<   $( innerBorder��6�   .\�5<  "     $) 0:0:0.2��67   $* 1Q�6I   + 5=  &     5>  *   $, EaseOut=�64   5@  #   5A     U� 5B     $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6<   $( innerBorder��6�   .\�5C  "     $) 0:0:0.2��67   $* 1Q�6I   + 5D  &     5E  *   $, EaseOut=�64   5G  #   5H     5I     5J     .R�5K     (� .��5L     � $- templateRoot��6   
������  . . 5M     �� 5N  "   $
��Auto �63   �� 5O  "   $��* �63   .+�5Q     �� $ 
backBorder��6%   #��� % 69   $/ 11��6d   $��22��6v   $��36��6�   �� 5R     $ lightBorder��6%   #��z��6:   #��z��6f   ���#17AB0D$��0��6�   $/ 11��6�   $��22��6�   $0 0Q�6�   $��36��6�   �� 5S     $ innerBorder��6%   #��z��6:   $��0��6d   $/ 11��6t   $��20��6�   $��1q�6�   $1 0.8,0.5&�6�   z�5T  "   V� 5U  &   .~�5V  *   �� 5W  '   5Y        5Z     $��0��6-   $��1q�6=   .+�5[  "   �� $ thumb��6)   
�������$/ 10��6K   $
��Left=�6]   $��20��6x   $1 0.5,0.5&�6�   $��20��6�   2 5\  &     5]  *   $3 8Q�6;   $4 	#88000000��6J   $	5 270Q�6\   $	6 0.2Q�6l   $7 Performance=�6z   $	8 1.5Q�6�   z�5_  &   V� 5`  *   .~�5a  .   T� 5b  +   5d  #   5e     �� 5f     $9 contentPresenter��6/   #��z��6I   #��z��6}   $��1��6�   #; z: 6�   |�.  #��z��6�   #��z��6B  ��. # z 6�  $y�	Collapsed=�6�  #��z��6�  5g     5h      5i     P� 5j     	 � ��
 . . �5k     �� $ contentPresenter��6;    � y�$ Visible=�6Y   5l     P� 5m     	 �@d�	IsChecked$

 TrueY�67   < 5n     �� 5o  "   .��5p  &   �� .��5q  *   U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[0].(TranslateTransform.X)�6H   $( thumb��6�   .\�5r  .     $) 0:0:0.2��6C   * 146U   + 5s  2     5t  6   $, EaseOut=�6@   5v  /   5w  +   U� 5x  *   $ Opacity�6H   $( lightBorder��6l   .\�5y  .     $) 0:0:0.2��6C   * 16U   5z  +   U� 5{  *   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6H   $( innerBorder��6�   .\�5|  .     $) 0:0:0.2��6C   * 06U   + 5}  2     5~  6   $, EaseOut=�6@   5�  /   5�  +   U� 5�  *   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6H   $( innerBorder��6�   .\�5�  .     $) 0:0:0.2��6C   * 06U   + 5�  2     5�  6   $, EaseOut=�6@   5�  /   5�  +   5�  '   5�  #   = 5�     �� 5�  "   .��5�  &   �� .��5�  *   U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[0].(TranslateTransform.X)�6H   $( thumb��6�   .\�5�  .     $) 0:0:0.2��6C   * 06U   + 5�  2     5�  6   $, EaseOut=�6@   5�  /   5�  +   U� 5�  *   $ Opacity�6H   $( lightBorder��6l   .\�5�  .     $) 0:0:0.2��6C   * 06U   5�  +   U� 5�  *   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6H   $( innerBorder��6�   .\�5�  .     $) 0:0:0.2��6C   * 16U   + 5�  2     5�  6   $, EaseOut=�6@   5�  /   5�  +   U� 5�  *   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6H   $( innerBorder��6�   .\�5�  .     $) 0:0:0.2��6C   * 16U   + 5�  2     5�  6   $, EaseOut=�6@   5�  /   5�  +   5�  '   5�  #   5�     P� 5�     	 � {�
 .  . �5�     ��  �@J�Opacity$	 0.4Q�68   5�     5�     5�      5�  
   �� 5�     " ��6   .�5�     ��  � ��# � ' 6/   �� 5�      � ��$ 12(�6-   �� 5�      �@�FocusVisualStyle 5�     �� 5�     .�5�     ��  � �� 5�  "   �� 5�  &   .R�5�  *   �� $$ 4��64   $' 4��6@   ��5�  .   �� 5�  2   " ��68   .�5�  6   ��  � ��$ -2q�6O   �� 5�  6    �@J�Opacity$	 0.6Q�6P   �� 5�  6    �@J�SnapsToDevicePixels . 6\   �� 5�  6    � ��# � # 6O   �� 5�  6    � ��$ 2��6X   �� 5�  6    �@��StrokeDashArray$	 1 1R�6X   5�  3   5�  +   5�  '   5�     5�     5�     5�     5�     5�     