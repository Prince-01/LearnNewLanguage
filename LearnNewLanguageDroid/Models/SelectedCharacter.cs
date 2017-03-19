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

namespace LearnNewLanguageDroid.Models
{
    public class SelectedCharacter : Java.Lang.Object, ISelectedCharactersItem
    {
        public SelectedCharacter(char symbol, bool selected)
        {
            Symbol = symbol;
            Selected = selected;
        }

        public char Symbol { get; set; }
        public bool Selected { get; set; }
    }
}