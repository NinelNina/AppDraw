using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AppDraw
{
    public partial class Form1 : Form
    {
        float parametr;
        Font currentFont;
        bool changes;
        Color customForecolor;
        Color backColor;
        public Form1()
        {
            InitializeComponent();

            label1.Text = "Текст";
            label2.Text = "Значение параметра";

            groupBox1.Text = "Параметры";

            radioButton1.Text = "Размер";
            radioButton2.Text = "Цвет";
            radioButton3.Text = "Стиль";
            radioButton4.Text = "Шрифт";

            button1.Text = "Сброс";
            button2.Text = "Удалить\nтекст";

            currentFont = textBox1.Font;
            customForecolor = textBox1.ForeColor;

            changes = false;

            label2.Visible = false;
            trackBar1.Enabled = false;
            trackBar1.Visible = false;
            trackBar1.Scroll += trackBar1_Scroll;
            trackBar1.Minimum = 1;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            TextStyleRemove();

            label2.Visible = true;
            trackBar1.Visible = true;
            trackBar1.Enabled = true;

            trackBar1.Value = trackBar1.Minimum;


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            TextStyleRemove();

            label2.Visible = true;
            trackBar1.Visible = true;
            trackBar1.Enabled = true;

            trackBar1.Value = trackBar1.Minimum;

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            TextStyleRemove();

            label2.Visible = true;
            trackBar1.Visible = true;
            trackBar1.Enabled = true;

            trackBar1.Value = trackBar1.Minimum;

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            TextStyleRemove();

            label2.Visible = true;
            trackBar1.Visible = true;
            trackBar1.Enabled = true;

            trackBar1.Value = trackBar1.Minimum;

        }

        private void button1_Click(object sender, EventArgs e)
        { if (changes)
            {
                TextStyleRemove();

                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;

                label2.Visible = false;
                trackBar1.Visible = false;
            }
        }
        
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            parametr = trackBar1.Value;

            changes = true;

            if (radioButton1.Checked)
            {
                trackBar1.Minimum = 1;
                trackBar1.Maximum = 30;

                textBox1.Font = new Font(currentFont.FontFamily, parametr, currentFont.Style);
            }
            else if (radioButton2.Checked)
            {
                List<Color> colors = new List<Color>()
                {
                    Color.Lavender,
                    Color.Cyan,
                    Color.Magenta,
                    Color.Yellow,
                    Color.Red
                };

                trackBar1.Minimum = 0;
                trackBar1.Maximum = colors.Count - 1;

                textBox1.ForeColor = colors[trackBar1.Value];

            }
            else if (radioButton3.Checked)
            {
                FontStyle newFontStyle;

                trackBar1.Minimum = 0;
                trackBar1.Maximum = 3;

                switch (trackBar1.Value)
                {
                    case 0:
                        {
                            newFontStyle = FontStyle.Bold;
                            break;
                        }
                    case 1:
                        {
                            newFontStyle = FontStyle.Italic;
                            break;
                        }
                    case 2:
                        {
                            newFontStyle = FontStyle.Underline;
                            break;
                        }
                    case 3:
                        {
                            newFontStyle = FontStyle.Strikeout;
                            break;
                        }
                    default:
                        {
                            newFontStyle = FontStyle.Bold;
                            break;
                        }
                }

                textBox1.Font = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
            else if (radioButton4.Checked)
            {
                
                InstalledFontCollection installedFont = new InstalledFontCollection();
                FontFamily[] fonts = installedFont.Families;

                trackBar1.Minimum = 0;
                trackBar1.Maximum = fonts.Length - 1;

                textBox1.Font = new Font(fonts[trackBar1.Value], currentFont.Size, currentFont.Style);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            backColor = BackColor;
                     
            BackColor = Color.PeachPuff;

            foreach (char symb in textBox1.Text)
            {
                if(!Char.IsLetterOrDigit(symb))
                {
                    MessageBox.Show("Ошибка! Введены неверные символы.");
                }
            }
        }

        private void TextStyleRemove()
        {
            textBox1.Font = new Font(currentFont.FontFamily, currentFont.Size, currentFont.Style);
            textBox1.ForeColor = customForecolor;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            TextStyleRemove();

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;

            label2.Visible = false;
            trackBar1.Visible = false;
        }
    }
}
