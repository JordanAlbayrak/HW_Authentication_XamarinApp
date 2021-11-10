using System.Threading;
using Android.App;
using Android.Content.PM;
using Android.OS;

namespace multyPage_XamarinAssign.Droid
{
    [Activity(Label = "multyPage_XamarinAssign", Icon = "@mipmap/icon", Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode |
                               ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class SplashAct : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartActivity(typeof(MainActivity));
            Thread.Sleep(3000);
            Finish();
        }
        
        public override void OnBackPressed()
        {
            //base.OnBackPressed();
        }
    }
}