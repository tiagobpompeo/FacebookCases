using System;
using FacebookLogin.Model;

namespace FacebookLogin.Contracts
{
    public interface IFacebookManager
    {
        void Login(Action<FacebookUser, string> OnLoginComplete);
        void Logout();
    }
}
