#pragma checksum "..\..\..\..\View\Pages\AuthorizationPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "72B4F8127FDF4FD379291BE9E1AE3F00DF06A00D22C74B9CD18A15A618E377B9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using TravelAgency2018.Pages;


namespace TravelAgency2018.View.Pages {
    
    
    /// <summary>
    /// AuthorizationPage
    /// </summary>
    public partial class AuthorizationPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\View\Pages\AuthorizationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UserInputLoginTextBox;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\View\Pages\AuthorizationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox UserInputPasswordBox;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\View\Pages\AuthorizationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock CaptchaTextBlock;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\View\Pages\AuthorizationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Line FirstCaptchaLine;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\View\Pages\AuthorizationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Line SecondCaptchaLine;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\View\Pages\AuthorizationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ReloadCaptchaButton;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\View\Pages\AuthorizationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CaptchaInputTextBox;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\View\Pages\AuthorizationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LoginButton;
        
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
            System.Uri resourceLocater = new System.Uri("/TravelAgency2018;component/view/pages/authorizationpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Pages\AuthorizationPage.xaml"
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
            this.UserInputLoginTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.UserInputPasswordBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 3:
            this.CaptchaTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.FirstCaptchaLine = ((System.Windows.Shapes.Line)(target));
            return;
            case 5:
            this.SecondCaptchaLine = ((System.Windows.Shapes.Line)(target));
            return;
            case 6:
            this.ReloadCaptchaButton = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\..\View\Pages\AuthorizationPage.xaml"
            this.ReloadCaptchaButton.Click += new System.Windows.RoutedEventHandler(this.ReloadCaptchaButtonOnClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.CaptchaInputTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.LoginButton = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\..\View\Pages\AuthorizationPage.xaml"
            this.LoginButton.Click += new System.Windows.RoutedEventHandler(this.LoginButtonOnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

