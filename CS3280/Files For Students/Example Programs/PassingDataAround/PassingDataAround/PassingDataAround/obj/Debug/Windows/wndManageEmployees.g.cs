﻿#pragma checksum "..\..\..\Windows\wndManageEmployees.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "097EC7E9AC1B91525694C7488D488388708C28C7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace PassingDataAround {
    
    
    /// <summary>
    /// wndManageEmployees
    /// </summary>
    public partial class wndManageEmployees : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\Windows\wndManageEmployees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFirstName;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\Windows\wndManageEmployees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtLastName;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Windows\wndManageEmployees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSalary;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Windows\wndManageEmployees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdAddNewEmployee;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Windows\wndManageEmployees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblMessage;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Windows\wndManageEmployees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFirstNameStatic;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Windows\wndManageEmployees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtLastNameStatic;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Windows\wndManageEmployees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSalaryStatic;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Windows\wndManageEmployees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdAddNewEmployeeStatic;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Windows\wndManageEmployees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblMessageStatic;
        
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
            System.Uri resourceLocater = new System.Uri("/PassingDataAround;component/windows/wndmanageemployees.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\wndManageEmployees.xaml"
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
            this.txtFirstName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtLastName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtSalary = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.cmdAddNewEmployee = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\Windows\wndManageEmployees.xaml"
            this.cmdAddNewEmployee.Click += new System.Windows.RoutedEventHandler(this.cmdAddNewEmployee_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lblMessage = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.txtFirstNameStatic = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtLastNameStatic = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txtSalaryStatic = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.cmdAddNewEmployeeStatic = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\Windows\wndManageEmployees.xaml"
            this.cmdAddNewEmployeeStatic.Click += new System.Windows.RoutedEventHandler(this.cmdAddNewEmployeeStatic_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.lblMessageStatic = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

