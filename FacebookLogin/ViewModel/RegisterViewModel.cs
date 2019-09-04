using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FacebookLogin.Contracts;
using FacebookLogin.Model;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace FacebookLogin.ViewModel
{
    public class RegisterViewModel : BaseViewModel
    {
        #region Facebook
        private readonly IFacebookManager _facebookManager;
        #endregion

        #region Commands
        public ICommand FacebookLoginCommand
        {
            get
            {
                return new RelayCommand(FacebookLogin);
            }
        }
       
        public ICommand FacebookLogoutCommand
        {
            get
            {
                return new RelayCommand(FacebookLogout);
            }
        }     
        
        #endregion



        #region Constructor
        //sem IoC
        public RegisterViewModel(){
           
            _facebookManager = DependencyService.Get<IFacebookManager>();        
           
        }
        #endregion



        #region Methods
        private void FacebookLogout()
        {
            _facebookManager.Logout();
            
        }

        private void FacebookLogin()
        {
            _facebookManager.Login(OnLoginComplete);
        }

        private void OnLoginComplete(FacebookUser facebookUser, string message)
        {
            if (facebookUser != null)
            {
                //FacebookUser = facebookUser;
                //NameWithComma = "Olá, " + FacebookUser.FirstName;
                //IsLogedInFacebook = true;
                //IsLoggedFacebookVisibility = false;
                //TextEntryRegister = "Continuar";
            }
            else
            {
                Console.WriteLine("Nao Logou");
            }
        }

        private async void OpenFacebook()
        {
            //await navigationService.NavigateOnRegister("LoginFacebook");
        }
        #endregion

    }




    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
            {
                return;
            }

            backingField = value;
            OnPropertyChanged(propertyName);
        }


    }

}
