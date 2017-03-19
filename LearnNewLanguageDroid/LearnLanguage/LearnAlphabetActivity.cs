using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LearnNewLanguageCore.Language;
using LearnNewLanguageDroid.Views;
using Java.Util;

namespace LearnNewLanguageDroid.LearnLanguage
{
    [Activity(Label = "LearnHiraganaActivity")]
    public class LearnAlphabetActivity : Activity
    {
        private Character _currentCharacter;
        private readonly IAlphabet hiraganaAlphabet = new HiraganaAlphabet();
        private readonly IAlphabet katakanaAlphabet = new KatakanaAlphabet();
        private readonly LatinHiraganaConverter hiraganaConverter = new LatinHiraganaConverter();
        private readonly LatinKatakanaConverter katakanaConverter = new LatinKatakanaConverter();


        private TextView _latinLbl;
        private TextView _detectedLbl;
        private PaintSurfaceView _practicingCanvas;

        public CharacterRandomizer _randomizer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LearnAlphabet);
            _randomizer = new CharacterRandomizer(string.Join("", hiraganaAlphabet.Characters.Select(c => c.Symbol)) + string.Join("", katakanaAlphabet.Characters.Select(c => c.Symbol)));

            _latinLbl = FindViewById<TextView>(Resource.Id.latinNotation);
            _detectedLbl = FindViewById<TextView>(Resource.Id.detectedCharacter);
            _practicingCanvas = FindViewById<PaintSurfaceView>(Resource.Id.practicingCanvas);
            var nextBtn = FindViewById<Button>(Resource.Id.nextCharacter);
            var remindBtn = FindViewById<Button>(Resource.Id.remindMeCharacter);
            var selectWanted = FindViewById<Button>(Resource.Id.selectWantedBtn);
            selectWanted.Click += SelectWanted_Click;

            prepareNextCharacter();

            nextBtn.Click += NextBtnOnClick;
            remindBtn.Click += RemindBtnOnClick;

            Handler handler = new Handler();
            Timer timer = new Timer(true);
            TimerTask timerTask = new CheckLetterTask(this);
            timer.Schedule(timerTask, 1000, 1000);
        }

        private void SelectWanted_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(SelectWantedCharactersActivity));
            intent.PutExtra("AllCharacters", _randomizer.Characters);
            intent.PutExtra("WantedCharacters", _randomizer.FilteredCharacters);
            StartActivityForResult(intent, (int)ActivityResult.WantedCharacters);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == (int)ActivityResult.WantedCharacters)
            {
                string wantedCharacters = data.Extras.GetString(ActivityResult.WantedCharacters.ToString());
                _randomizer.FilteredCharacters = wantedCharacters;
                _practicingCanvas.Whitelist = wantedCharacters;
            }
        }

        private void RemindBtnOnClick(object sender, EventArgs eventArgs)
        {
            remindMeHowCharacterLooks();
        }

        private void remindMeHowCharacterLooks()
        {
            Toast.MakeText(this, _currentCharacter.ToString(), ToastLength.Long).Show();
        }

        private void prepareNextCharacter()
        {
            clearCanvas();
            setNextCharacter();
            showLatinNotation();
        }

        private void showLatinNotation()
        {
            var katakana = katakanaAlphabet.Characters.Any(c => c.Symbol == _currentCharacter.Symbol);
            _latinLbl.Text = string.Format("{0}: {1}",
                katakana ? "Katakana" : "Hiragana",
                katakana
                    ? katakanaConverter.ConvertToLatin(_currentCharacter)
                    : hiraganaConverter.ConvertToLatin(_currentCharacter));
        }

        private void setNextCharacter()
        {
            _currentCharacter = (Character)_randomizer.GetRandomCharacter();
        }

        private void clearCanvas()
        {
            _practicingCanvas.ClearCanvas();
            _practicingCanvas.Invalidate();
        }

        private void NextBtnOnClick(object sender, EventArgs eventArgs)
        {
            prepareNextCharacter();
        }

        public void Pass()
        {
            RunOnUiThread(() =>
            {
                prepareNextCharacter();
            });
        }

        public bool Passed()
        {
            RunOnUiThread(() =>
            {
                _detectedLbl.Text = string.Format("Detected: {0}", _practicingCanvas.currentText);
            });
            return _currentCharacter.Symbol.Equals(_practicingCanvas.currentText.Length == 0 ? '\n' : _practicingCanvas.currentText[0]);
        }
    }
    public class CheckLetterTask : TimerTask
    {
        public CheckLetterTask(LearnAlphabetActivity activity)
        {
            _activity = activity;
        }

        private LearnAlphabetActivity _activity;

        public override void Run()
        {
            if (_activity.Passed())
                _activity.Pass();
        }
    }

    public class CallOnce
    {
        private bool _called;
        private Action _action;

        public CallOnce(Action action)
        {
            _action = action;
        }

        public void Call()
        {
            if (!_called)
            {
                _called = true;
                _action();
            }
        }

    }
}