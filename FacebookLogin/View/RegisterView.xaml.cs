using System;
using System.Collections.Generic;
using FacebookLogin.ViewModel;
using Xamarin.Forms;

namespace FacebookLogin.View
{
    public partial class RegisterView : ContentPage
    {
        public RegisterView()
        {
            InitializeComponent();

            BindingContext = new RegisterViewModel();
        }
    }
}
