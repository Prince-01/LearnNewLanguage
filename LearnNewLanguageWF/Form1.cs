using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LearnNewLanguageCore.Language;

namespace LearnNewLanguageWF
{
    public partial class Form1 : Form
    {
        private readonly HiraganaAlphabet _alphabet;
        private bool _draw;
        private Character _currentCharacter;
        private LatinHiraganaConverter _hiraganaConverter;

        public Form1()
        {
            _alphabet = new HiraganaAlphabet();
            _hiraganaConverter = new LatinHiraganaConverter();
            InitializeComponent();
        }

        private void populateBtn_Click(object sender, EventArgs e)
        {

        }

        private void drawSymbolPanel_MouseDown(object sender, MouseEventArgs e)
        {
            _draw = true;
        }

        private void drawSymbolPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_draw)
                return;

            var graphics = drawSymbolPanel.CreateGraphics();

            graphics.FillEllipse(new SolidBrush(Color.Brown), e.X, e.Y, 15, 15);
        }

        private void drawSymbolPanel_MouseUp(object sender, MouseEventArgs e)
        {
            _draw = false;
        }

        private void redrawBtn_Click(object sender, EventArgs e)
        {
            drawSymbolPanel.Invalidate();
        }

        private void nextLetterBtn_Click(object sender, EventArgs e)
        {
            drawSymbolPanel.Invalidate();

            _currentCharacter =
                _alphabet.Characters.ElementAt(new Random().Next(_alphabet.Characters.Count()));
            showSymbolLbl.Text = "";
            latinNotation.Text = _hiraganaConverter.ConvertToLatin(_currentCharacter);
        }

        private void showSymbolBtn_Click(object sender, EventArgs e)
        {
            showSymbolLbl.Text = _currentCharacter.ToString();
        }
    }
}
