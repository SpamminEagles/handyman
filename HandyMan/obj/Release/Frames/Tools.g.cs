﻿#pragma checksum "..\..\..\Frames\Tools.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "386BBDF13301564F12B16EF52E78E105B16373C5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HandyMan.Frames;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace HandyMan.Frames {
    
    
    /// <summary>
    /// Tools
    /// </summary>
    public partial class Tools : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Frames\Tools.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Frames\Tools.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton LatToCyrRBOn;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Frames\Tools.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton LatToCyrRBOff;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HandyMan;component/frames/tools.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Frames\Tools.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.LatToCyrRBOn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 15 "..\..\..\Frames\Tools.xaml"
            this.LatToCyrRBOn.Checked += new System.Windows.RoutedEventHandler(this.LatToCyrRBOn_Checked);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\Frames\Tools.xaml"
            this.LatToCyrRBOn.Loaded += new System.Windows.RoutedEventHandler(this.LatToCyrRBOn_Loaded);
            
            #line default
            #line hidden
            return;
            case 3:
            this.LatToCyrRBOff = ((System.Windows.Controls.RadioButton)(target));
            
            #line 16 "..\..\..\Frames\Tools.xaml"
            this.LatToCyrRBOff.Checked += new System.Windows.RoutedEventHandler(this.LatToCyrRBOff_Checked);
            
            #line default
            #line hidden
            
            #line 16 "..\..\..\Frames\Tools.xaml"
            this.LatToCyrRBOff.Loaded += new System.Windows.RoutedEventHandler(this.LatToCyrRBOff_Loaded);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

