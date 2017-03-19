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
    public class SelectedCharactersGroup : Java.Lang.Object, ISelectedCharactersItem
    {
        public string GroupName { get; set; }
        public List<SelectedCharacter> Characters { get; set; }
    }
}