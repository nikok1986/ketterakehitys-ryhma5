﻿#pragma checksum "..\..\..\AddProject.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AF9A533F5BB8B2830C3FB4E3F5F4ECBD3B117C8E"
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
    /// AddProject
    /// </summary>
    public partial class AddProject : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\AddProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ProjectNameInput;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\AddProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ProjectDescriptionInput;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\AddProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker ProjectStartDate;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\AddProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker ProjectEndDate;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\AddProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox AddedProjectsList;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\AddProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddUser;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\AddProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ProjectInfoButton;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\AddProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddProjectButton;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\AddProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelAddProjectButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Kanbanboard;component/addproject.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AddProject.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
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
            this.AddedProjectsList = ((System.Windows.Controls.ComboBox)(target));
            
            #line 34 "..\..\..\AddProject.xaml"
            this.AddedProjectsList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.AddedProjectsList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.AddUser = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\AddProject.xaml"
            this.AddUser.Click += new System.Windows.RoutedEventHandler(this.EditProject_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ProjectInfoButton = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\AddProject.xaml"
            this.ProjectInfoButton.Click += new System.Windows.RoutedEventHandler(this.ShowProjectInfo_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.AddProjectButton = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\AddProject.xaml"
            this.AddProjectButton.Click += new System.Windows.RoutedEventHandler(this.AddProjectButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.CancelAddProjectButton = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\AddProject.xaml"
            this.CancelAddProjectButton.Click += new System.Windows.RoutedEventHandler(this.CancelAddProjectButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
