﻿#pragma checksum "..\..\..\AddTask.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8DAEC719A46B4AEA265F1669CF85AE63324BA83B"
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
    /// AddTask
    /// </summary>
    public partial class AddTask : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\AddTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TaskNameInput;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\AddTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TaskDescriptionInput;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\AddTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker TaskStartDate;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\AddTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker TaskEndDate;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\AddTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox AddedUserStoryList;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\AddTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox AddedUserList;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\AddTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox AddedSprintList;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\AddTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TaskDifficulty;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\AddTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TaskCategory;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\AddTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TaskPrioritySelector;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\AddTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddTaskButton;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\AddTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelAddTaskButton;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\AddTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TaskDurationTextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/Kanbanboard;component/addtask.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AddTask.xaml"
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
            this.TaskNameInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TaskDescriptionInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TaskStartDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.TaskEndDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.AddedUserStoryList = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.AddedUserList = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.AddedSprintList = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.TaskDifficulty = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.TaskCategory = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.TaskPrioritySelector = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.AddTaskButton = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\..\AddTask.xaml"
            this.AddTaskButton.Click += new System.Windows.RoutedEventHandler(this.AddTaskButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.CancelAddTaskButton = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\..\AddTask.xaml"
            this.CancelAddTaskButton.Click += new System.Windows.RoutedEventHandler(this.CancelAddTaskButton_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.TaskDurationTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

