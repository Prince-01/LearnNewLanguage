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

        private readonly List<IAlphabet> _alphabets = new List<IAlphabet>
        {
            new HiraganaAlphabet(),
            new KatakanaAlphabet()
        };

        private TextView _latinLbl;
        private TextView _detectedLbl;
        private PaintSurfaceView _practicingCanvas;

        public CharacterRandomizer _randomizer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LearnAlphabet);
            var chars = new List<Character>();
            _alphabets.ForEach(a => chars.AddRange(a.Characters));
            _randomizer = new CharacterRandomizer(chars);

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

            var handler = new Handler();
            var timer = new Timer(true);
            var timerTask = new CheckLetterTask(this);
            timer.Schedule(timerTask, 1000, 1000);
        }

        private void SelectWanted_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(SelectWantedCharactersActivity));
            intent.PutExtra("AllCharacters", string.Join("", _randomizer.Characters.Select(fc => fc.Symbol)));
            intent.PutExtra("WantedCharacters", string.Join("", _randomizer.FilteredCharacters.Select(fc => fc.Symbol)));
            StartActivityForResult(intent, (int)ActivityResult.WantedCharacters);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == (int)ActivityResult.WantedCharacters)
            {
                string wantedCharacters = data.Extras.GetString(ActivityResult.WantedCharacters.ToString());
                _randomizer.FilteredCharacters = _randomizer.Characters.Where(c => wantedCharacters.Contains(c.Symbol));
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
            _latinLbl.Text = string.Format("{0}: {1}",
                _currentCharacter.Alphabet.Name,
                _currentCharacter.InternationalNotation);
        }

        private void setNextCharacter()
        {
            _currentCharacter = _randomizer.GetRandomCharacter();
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
            RunOnUiThread(prepareNextCharacter);
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

        private readonly LearnAlphabetActivity _activity;

        public override void Run()
        {
            if (_activity.Passed())
                _activity.Pass();
        }
    }

    public class CallOnce
    {
        private bool _called;
        private readonly Action _action;

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