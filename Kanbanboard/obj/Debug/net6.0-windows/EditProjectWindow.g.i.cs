﻿#pragma checksum "..\..\..\EditProjectWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2A35CA3285CE752500428A85CDCAC75CA71CED57"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Kanbanboard;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Kanbanboard {
    
    
    /// <summary>
    /// EditProjectWindow
    /// </summary>
    public partial class EditProjectWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\EditProjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ProjectNameInput;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\EditProjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ProjectDescriptionInput;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\EditProjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker ProjectStartDate;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\EditProjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker ProjectEndDate;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\EditProjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditProjectButton;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\EditProjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelEditProjectButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Kanbanboard;component/editprojectwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\EditProjectWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ProjectNameInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.ProjectDescriptionInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.ProjectStartDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.ProjectEndDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.EditProjectButton = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\EditProjectWindow.xaml"
            this.EditProjectButton.Click += new System.Windows.RoutedEventHandler(this.AddProjectButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CancelEditProjectButton = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\EditProjectWindow.xaml"
            this.CancelEditProjectButton.Click += new System.Windows.RoutedEventHandler(this.CancelAddProjectButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

