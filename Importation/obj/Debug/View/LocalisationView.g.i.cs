﻿#pragma checksum "..\..\..\View\LocalisationView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "73A8924334D74900D24556DA3FA405EF6554CBA4137C324863022E2CE1C7D799"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Importation;
using Importation.View;
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
using UCGeneraFi;


namespace Importation.View {
    
    
    /// <summary>
    /// LocalisationView
    /// </summary>
    public partial class LocalisationView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\..\View\LocalisationView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UCGeneraFi.ucTxtBox txtfile;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\View\LocalisationView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Openfile;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\View\LocalisationView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgImporter;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\View\LocalisationView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnImport;
        
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
            System.Uri resourceLocater = new System.Uri("/Importation;component/view/localisationview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\LocalisationView.xaml"
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
            this.txtfile = ((UCGeneraFi.ucTxtBox)(target));
            return;
            case 2:
            this.Openfile = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\View\LocalisationView.xaml"
            this.Openfile.Click += new System.Windows.RoutedEventHandler(this.Openfile_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.dgImporter = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.btnImport = ((System.Windows.Controls.Button)(target));
            
            #line 97 "..\..\..\View\LocalisationView.xaml"
            this.btnImport.Click += new System.Windows.RoutedEventHandler(this.BtnImport_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

