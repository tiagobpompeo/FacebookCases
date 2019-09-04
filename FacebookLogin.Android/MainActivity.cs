using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ImageCircle.Forms.Plugin.Droid;
using Xamarin.Forms;
using FacebookLogin.Contracts;
using Android.Content;
using FacebookLogin.Droid.Services;
using Xamarin.Facebook;
using FacebookLogin.Droid.CustomRenderers;

namespace FacebookLogin.Droid
{
    [Activity(Label = "FacebookLogin", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        public event EventHandler<ActivityResultEventArgs> ActivityResult = delegate { };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);
            FacebookSdk.SdkInitialize(this);
            InitializeServicesFacebook();
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            ImageCircleRenderer.Init();         
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);        
            LoadApplication(new App());
        }

        private void InitializeServicesFacebook()
        {
            #region Facebook
            DependencyService.Register<IFacebookManager, FacebookManager>();
            #endregion
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
           
            #region FacebookService
            var manager = DependencyService.Get<IFacebookManager>();
            if (manager != null)
            {
                (manager as FacebookManager)._callbackManager.OnActivityResult(requestCode, (int)resultCode, data);
            }
            #endregion
        }




    }
}