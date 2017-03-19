using Android.App;
using Android.Widget;
using Android.OS;

namespace LearnNewLanguageDroid
{
    [Activity(Label = "LearnNewLanguageDroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            var btn = FindViewById<Button>(Resource.Id.btnLearnAlphabet);
            btn.Click += delegate
            {
                StartActivity(typeof(LearnLanguage.LearnAlphabetActivity));
            };
            // Set our view from the "main" layout resource
            // 
        }
    }
}

