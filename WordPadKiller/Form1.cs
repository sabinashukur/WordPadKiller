using System.Net;
using System.Text;

namespace WordPadKiller
{
    public partial class Form1 : Form
    {
        List<string> fonts = new() { "Calibri", "Cascadia Mono SemiLight", "Ink Free", "Mistral", "Segoe Script", "Times New Roman" };
        List<string> sizes = new() { "8", "9", "10", "10.5", "11", "11.5", "12", "12.5", "13", "13.5", "14", "14.5", "15", "18" };
        List<Color> colors = new() { Color.Black, Color.Red, Color.Brown, Color.Blue, Color.Yellow, Color.Violet, Color.Pink, Color.Cyan };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbox_Fonts.DataSource = fonts;
            cbox_Sizes.DataSource = sizes;
            cbox_Colors.DataSource = colors;
            richTextBox1.ForeColor = Color.Black;

        }
        bool isClickedB = false;
        bool isClickedU = false;
        bool isClickedI = false;
        int clickCountB = 0;
        int clickCountU = 0;
        int clickCountI = 0;
        private void btn_Bold_Click(object sender, EventArgs e)
        {
            isClickedB = true;
            if (isClickedB && clickCountB == 0)
            {
                var font = cbox_Fonts.SelectedItem as string;
                var size = cbox_Sizes.SelectedItem as string;
                var currentFontStyle = richTextBox1.SelectionFont.Style;
                Font f = new(font, float.Parse(size), currentFontStyle | FontStyle.Bold);
                richTextBox1.SelectionFont = f;
                clickCountB++;
            }
            else if (clickCountB == 1)
            {
                var font = cbox_Fonts.SelectedItem as string;
                var size = cbox_Sizes.SelectedItem as string;

                var currentFontStyle = richTextBox1.SelectionFont.Style;

                Font f = new(font, float.Parse(size), (FontStyle)(currentFontStyle - FontStyle.Bold));
                richTextBox1.SelectionFont = f;
                clickCountB--;
            }
        }



        private void btn_Underline_Click(object sender, EventArgs e)
        {
            isClickedU = true;
            if (isClickedU && clickCountU == 0)
            {
                var font = cbox_Fonts.SelectedItem as string;
                var size = cbox_Sizes.SelectedItem as string;
                var currentFontStyle = richTextBox1.SelectionFont.Style;
                Font f = new(font, float.Parse(size), currentFontStyle | FontStyle.Underline);
                richTextBox1.SelectionFont = f;
                clickCountU++;
            }
            else if (clickCountU == 1)
            {
                var font = cbox_Fonts.SelectedItem as string;
                var size = cbox_Sizes.SelectedItem as string;

                var currentFontStyle = richTextBox1.SelectionFont.Style;

                Font f = new(font, float.Parse(size), (FontStyle)(currentFontStyle - FontStyle.Underline));

                richTextBox1.SelectionFont = f;
                clickCountU--;
            }
        }

        private void btn_Italic_Click(object sender, EventArgs e)
        {
            isClickedI = true;
            if (isClickedI && clickCountI == 0)
            {
                var font = cbox_Fonts.SelectedItem as string;
                var size = cbox_Sizes.SelectedItem as string;
                var currentFontStyle = richTextBox1.SelectionFont.Style;
                Font f = new(font, float.Parse(size), currentFontStyle | FontStyle.Italic);
                richTextBox1.SelectionFont = f;
                clickCountI++;
            }
            else if (clickCountI == 1)
            {
                var font = cbox_Fonts.SelectedItem as string;
                var size = cbox_Sizes.SelectedItem as string;
                var currentFontStyle = richTextBox1.SelectionFont.Style;

                Font f = new(font, float.Parse(size), (FontStyle)(currentFontStyle - FontStyle.Italic));

                richTextBox1.SelectionFont = f;
                clickCountI--;
            }

        }

        private void btn_Left_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void btn_Center_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;

        }

        private void btn_Right_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;

        }

        private void cbox_Colors_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = cbox_Colors.SelectedIndex;
            richTextBox1.SelectionColor = colors[index];
        }

        private void cbox_Sizes_SelectedIndexChanged(object sender, EventArgs e)
        {

            var font = cbox_Fonts.SelectedItem as string;
            var size = cbox_Sizes.SelectedItem as string;
            var currentFontStyle = richTextBox1.SelectionFont.Style;
            Font f = new(Name = font, float.Parse(size), currentFontStyle);
            richTextBox1.SelectionFont = f;
        }

        private void cbox_Fonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var font = cbox_Fonts.SelectedItem as string;
            var size = cbox_Sizes.SelectedItem as string;
            if (size != null)
            {
                Font f = new(Name = font, float.Parse(size));
                richTextBox1.SelectionFont = f;
            }
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            var fileName = textBox1.Text;
            richTextBox1.Rtf = File.ReadAllText($"{fileName}.txt");
            textBox1.Text = null;

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            var fileName = textBox2.Text;
            File.WriteAllText($"{fileName}.txt", richTextBox1.Rtf);
            richTextBox1.Text = null;
            textBox2.Text = null;
        }
    }
}