   M S B A M L   `   `   `  ����B  >Replace, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ReplaceReplace  5   	       Replace.ReplaceWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Replace     5   	     � Title$  ReplaceWindow��5   	   $	��450��6   $	��800��6,   .��5	      �� .+�5
   
   ��  �� Left$	 100��6   
 �� Top$	 100��6"   $ ��String you want to convert��63   �� 5   
   -   5        $��	edtString��5   M   $	 100��6   $	 130��6$   $��30��65   $	��300��6A   6M   �� 5   
   $	 100��6   $	 175��6"   $#��Character you want to replace��63   �� 5   
   -   5        $��edtCharReplace��5   M   $	 100��6   $	 200��6$   $��30��65   $	��300��6A   6M   �� 5   
   $	 100��6   $	 240��6"   $&�� Character replaces old character��63   �� 5   
   -   5        $��edtReplacer��5   M   $	 100��6   $	 275��6$   $��30��65   $	��300��6A   6M   �� 5   
   -   5        $��
BtnConvert��5   4   $	 100��6   $	 320��6#   $��Convert��6F   6X   �� 5   
   -   5        $��	txtResult��5   3   $	 100��6   $	 350��6"   $��This is result��6D   5      5      