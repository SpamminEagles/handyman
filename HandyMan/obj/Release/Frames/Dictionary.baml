   M S B A M L   `   `   `  ���� C  ?HandyMan, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HandyMan.FramesHandyMan.Frames       HandyMan.Frames.Dictionary   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /localclr-namespace:HandyMan.Frames       N� Title$  
Dictionary��$	��820��$	��571�� N� ShowsNavigationUI .  .���� ���	#00000000���	#00000000.@��� $��Search��$��50��$��22�����	#00000000���	#1CFFFFFF.��� ���	#FF1F2B53$��	0,10,0,-2q� � RowDefinitions �� $��1* ��� $��1* ��� $	��12* � � ColumnDefinitions �� $��1* ��� $��1* �.+��� -    ��Name$ DicSearchForeign��$��
55,14,0,36q� �� TextWrapping$
 Wrap=�$��*��$	��200��$��20��$	��200��$��20��$
��Left=�$	��200��$��0�����	#FFD8D883
�������$��2�� �� SelectionBrush Z� ��Z� �� -    ��Name$ DicStartSearchForeign��$��Search��$��260,13,107,1q�$��20��$��52��$��Center=�$��0�����	#FFB900FF��Z� ��Z� �� -   $ DicSearchMother��$y�Hidden=�$��46,18,126,0q�$
 Wrap=�$��*��$��1��$	��200��$��20�����	#FFD8D883
������� Z� ��Z� �� -   $ DicStartSearchMother��$y�Hidden=�$��Search��$��1��$��	0,18,69,0q�$��Right=�$��52�����	#FFB900FF��Z� ��Z� �� -   $��TitleDicForeign��$��
126,10,0,0q�$��1��$
��Wrap=�$��Foreign language��$
��Left=�$	��143��$��16(�$��Segoe UI Semibold)�$��0��
��������� -   $��Title��$��147,10,126,0q�$��1��$
��Wrap=�$��Mother Language��$��1��$��16(�$��Segoe UI Semibold)�
��������� -   $��ForLanListSearch��$��3��$��0�����	#33DCDCDC�� -   $��MothLanListSearch��$��3��$��1�����	#33DCDCDC�� $��Add data��$��2.334,0,-6,0.333q�$��22�����	#00000000���	#4CFFFFFF.��� ���	#A5FFFFFF.+��� ���	#FFE8E8FF$
��Left=�$	��100��$��	10,10,0,0q�$	��Top=�$	��794���� $��Create an entry!��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��100��$	��794��$��48(�� $��26,182,643,255q�.+��� ���	#FFE8E8FF$
��Left=�$	��103��$	��Top=�$	��168��	� -	   $��	RBPOSNoun��{�.  $
��Noun��$
��Left=�$��	10,41,0,0q�$	��Top=�	� -
   $��	RBPOSVerb��{�.  $
��Verb��$
��Left=�$��	10,61,0,0q�$	��Top=�	� -   $��RBPOSAdjective��{�.  $��	Adjective��$
��Left=�$��	10,76,0,0q�$	��Top=��� $��1) Part of speech:��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��159���� -   $
��Left=�$��174,128,0,0q�$	��Top=�$	��120��.@��� -   $��
AddRussian��$��Russian���� $��	Language:��$
��Left=�$��
26,124,0,0q�$	��Top=�$	��134��� -   $��	ANounGrid��$y�Hidden=�$��200,182,10,50q����	#FFE8E8FF.+��� $��
Add a Noun��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��124��$��18(��� $��2) Word:��$
��Left=�$��	10,49,0,0q�$	��Top=�$��65���� -   $ 
AWNTextBox��$
��Left=�$��23��$��	10,80,0,0q�$
 Wrap=�$	��Top=�$	��210���� $��Irregular plural��$
��Left=�$��
255,80,0,0q�$	��Top=��� $��3) Any unusal properties?��$
��Left=�$��
255,49,0,0q�$	��Top=��� -   $ NounPluralName��$
��Left=�$��23��$��
392,80,0,0q�$
 Wrap=�$	��Top=�$	��188���� -   $ MeaningNoun��$
��Left=�$��23��$��255,163,0,0q�$
 Wrap=�$	��Top=�$	��325���� -    ��Name$ label��$��4) Meaning(s):��$
��Left=�$��255,132,0,0q�$	��Top=�$	��120��� -   $��	AVerbGrid��$y�Hidden=�$��200,182,10,50q����	#FFE8E8FF.+��� $��
Add a verb��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��124��$��18(��� $��2) Continous form:��$
��Left=�$��	10,49,0,0q�$	��Top=�$	��124���� -   $ AWVTextBoxCon��$
��Left=�$��23��$��	10,80,0,0q�$
 Wrap=�$	��Top=�$	��210���� $��3) Conjugation��$
��Left=�$��
255,49,0,0q�$	��Top=�� .+�	� -   	 	�Name$	 	RBConReg1��$��	Regular I��$
��Left=�$��
261,79,0,0q�$	��Top=�$��80��	� -   $	 	RBConReg2��$��	RBConReg2��$
��Left=�$��
261,99,0,0q�$	��Top=�$��80��	� -   $	 
RBConIrreg��$��	Irregular��$
��Left=�$��261,119,0,0q�$	��Top=�$��80���� -   $ ConConS1��{�.  $
��Left=�$��23��$��
464,79,0,0q�$
 Wrap=�$	��Top=�$	��130���� -   $ ConConS2��{�.  $
��Left=�$��23��$��464,107,0,0q�$
 Wrap=�$	��Top=�$	��130���� -   $ ConConP3��{�.  $
��Left=�$��23��$��464,135,0,0q�$
 Wrap=�$	��Top=�$	��130���� $	��S/1��$
��Left=�$��
421,79,0,0q�$	��Top=��� $	��S/2��$
��Left=�$��421,107,0,0q�$	��Top=��� $	��P/3��$
��Left=�$��421,135,0,0q�$	��Top=��� $��4) Perfect form��$
��Left=�$��
10,161,0,0q�$	��Top=��� -   $ PerConS1��$
��Left=�$��23��$��464,191,0,0q�$
 Wrap=�$	��Top=�$	��130���� -   $ PerConS2��$
��Left=�$��23��$��464,219,0,0q�$
 Wrap=�$	��Top=�$	��130���� $	��S/1��$
��Left=�$��421,191,0,0q�$	��Top=��� $	��S/2��$
��Left=�$��421,219,0,0q�$	��Top=��� $	��P/3��$
��Left=�$��421,247,0,0q�$	��Top=��� -   $ PerConP3��$
��Left=�$��23��$��464,250,0,0q�$
 Wrap=�$	��Top=�$	��130���� $��5) Conjugation��$
��Left=�$��261,161,0,0q�$	��Top=�$��92���� -   $ AWVTextBoxPer��$
��Left=�$��23��$��
10,190,0,0q�$
 Wrap=�$	��Top=�$	��210���� -   $ MeaningVerb��$
��Left=�$��23��$��
10,276,0,0q�$
 Wrap=�$	��Top=�$	��325���� -    $ 
label_Copy��$��6) Meaning(s):��$
��Left=�$��
10,245,0,0q�$	��Top=�$	��120��� -!   $��AAdjectiveGrid��$y�Hidden=�$��200,182,10,50q����	#FFE8E8FF.+��� $��Add an adjecive��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��232��$��18(��� $��2) Word:��$
��Left=�$��	10,49,0,0q�$	��Top=�$��65���� -"   $ 
AWATextBox��$
��Left=�$��23��$��	10,80,0,0q�$
 Wrap=�$	��Top=�$	��210���� $��3) Forms��$
��Left=�$��
255,49,0,0q�$	��Top=��� -#   $ MasculineTB��$
��Left=�$��23��$��
392,83,0,0q�$
 Wrap=�$	��Top=�$	��188���� $��	Masculine��$
��Left=�$��
255,80,0,0q�$	��Top=��� -$   $ 
FeminineTB��$
��Left=�$��23��$��393,114,0,0q�$
 Wrap=�$	��Top=�$	��188���� $��Feminine��$
��Left=�$��255,111,0,0q�$	��Top=��� -%   $ NeuterTB��$
��Left=�$��23��$��393,145,0,0q�$
 Wrap=�$	��Top=�$	��188���� $��Neuter��$
��Left=�$��255,142,0,0q�$	��Top=��� -&   $ MeaningAdjective��$
��Left=�$��23��$��255,253,0,0q�$
 Wrap=�$	��Top=�$	��325���� -'   $ label_Copy1��$��4) Meaning(s):��$
��Left=�$��255,222,0,0q�$	��Top=�$	��120���� -(   $ SaveEntryButton��{�.  $
��Save��$
��Left=�$��729,130,0,0q�$	��Top=�$��75���� $��Practice��$��60.667��$��22��$
��Left=�$��8,-0.5,-12,0.5q����	#00000000���	#4CFFFFFF.��� ���	#A7FFFFFF.+��� -)   $ label1��$��Feature coming soon!��$
��Left=�$��	71,71,0,0q�$	��Top=�$��65��$	��331��