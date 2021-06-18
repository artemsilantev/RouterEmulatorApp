﻿#pragma checksum "..\..\..\Views\RouterWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "78C94EBC819B61D07473619F3909936B1CCCD8662602721219E1143AE593637A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using RouterEmulatorApp.Views;
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


namespace RouterEmulatorApp.Views {
    
    
    /// <summary>
    /// RouterWindow
    /// </summary>
    public partial class RouterWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\Views\RouterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelAddress;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Views\RouterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridRoutingTable;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Views\RouterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonAddNote;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Views\RouterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxNetwork;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Views\RouterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxPrefix;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Views\RouterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxGateway;
        
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
            System.Uri resourceLocater = new System.Uri("/RouterEmulatorApp;component/views/routerwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\RouterWindow.xaml"
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
            this.labelAddress = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.dataGridRoutingTable = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.buttonAddNote = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\Views\RouterWindow.xaml"
            this.buttonAddNote.Click += new System.Windows.RoutedEventHandler(this.ButtonAddNote_OnClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.textBoxNetwork = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.textBoxPrefix = ((System.Windows.Controls.TextBox)(target));
            
            #line 41 "..\..\..\Views\RouterWindow.xaml"
            this.textBoxPrefix.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBoxPrefix_OnPreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 6:
            this.textBoxGateway = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

