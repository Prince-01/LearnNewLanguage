using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using LearnNewLanguageCore.Language;
using LearnNewLanguageDroid.Views;
using LearnNewLanguageDroid.Models;

namespace LearnNewLanguageDroid.LearnLanguage
{
    [Activity(Label = "SelectWantedCharacters")]
    public class SelectWantedCharactersActivity : Activity
    {
        private List<SelectedCharacter> _characters;
        private ExpandableListView _charactersList;
        private Button _saveCharactersBtn;
        private List<SelectedCharactersGroup> listDataHeader;
        private SelectCharactersAdapter _adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SelectWantedCharacters);

            var allCharacters = Intent.GetStringExtra("AllCharacters");
            var wantedCharacters = Intent.GetStringExtra("WantedCharacters");
            _characters = allCharacters.Select(c => new SelectedCharacter(c, wantedCharacters.Contains(c))).ToList();

            prepareListData();

            _adapter = new SelectCharactersAdapter(listDataHeader);
            _adapter.Inflater = (LayoutInflater)
                GetSystemService(LayoutInflaterService);
            _charactersList = FindViewById<ExpandableListView>(Resource.Id.selectCharactersLst);
            _charactersList.SetAdapter(_adapter);

            _saveCharactersBtn = FindViewById<Button>(Resource.Id.saveWantedCharactersBtn);
            _saveCharactersBtn.Click += SaveWantedCharactersBtn_Click;
        }

        private void SaveWantedCharactersBtn_Click(object sender, EventArgs e)
        {
            var resultCode = Result.Ok;
            Intent resultIntent = new Intent(string.Empty);
            resultIntent.PutExtra(ActivityResult.WantedCharacters.ToString(), string.Join("", _characters.Where(c => c.Selected).Select(c => c.Symbol)));
            SetResult(resultCode, resultIntent);
            Finish();
        }

        private void prepareListData()
        {
            listDataHeader = new List<SelectedCharactersGroup>();

            // Adding child data
            listDataHeader.Add(new SelectedCharactersGroup
            {
                GroupName = "Hiragana",
                Characters = _characters.Where(c => new HiraganaAlphabet().Characters.Any(kc => kc.Symbol == c.Symbol)).ToList()
            });
            listDataHeader.Add(new SelectedCharactersGroup
            {
                GroupName = "Katakana",
                Characters = _characters.Where(c => new KatakanaAlphabet().Characters.Any(kc => kc.Symbol == c.Symbol)).ToList()
            });
        }
    }
}
