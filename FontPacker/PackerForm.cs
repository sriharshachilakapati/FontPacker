using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace FontPacker
{
    public partial class PackerForm : Form
    {

        private char[] alphabetsSmall = {
                                          'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                                          'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ' '
                                        };

        private char[] alphabetsCapital = {
                                          'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
                                          'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', ' '
                                          };

        private char[] numbers = {
                                     '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ' '
                                 };

        private char[] arithmeticOperators = {
                                                 '+', '-', '*', '/', '%', '^', ' '
                                             };

        private char[] puntuations = {
                                         ',', '.', '?', '!', '_', ' '
                                     };

        private char[] otherSymbols = {
                                          '`', '~', '!', '@', '#', '$',  '%', '^', '&', '*',  '(', ')', '-', '_', '=',
                                          '+', '[', '{', ']', '}', '\\', '|', ';', ':', '\'', '"', ',', '<', '>', '.',
                                          '/', '?', ' '
                                      };

        public PackerForm()
        {
            InitializeComponent();
        }

        private void fontSelect_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fontSelect.Text = fontDialog1.Font.Name + "    " + fontDialog1.Font.Size + " pt";
                layerDist.Value = (decimal)fontSelect.Font.GetHeight() / 12;
            }

            previewPanel.Refresh();
        }

        private void PackerForm_Load(object sender, EventArgs e)
        {
            fontSelect.Text = fontSelect.Text = fontDialog1.Font.Name + "    " + fontDialog1.Font.Size + " pt";

            colorDialog1.Color = Color.Black;
            colorSelect.Text = colorDialog1.Color.Name;
            colorSelect.ForeColor = colorDialog1.Color;

            colorSelect2.Text = colorDialog1.Color.Name;
            colorSelect2.ForeColor = colorDialog1.Color;

            layerDist.Value = (decimal)fontSelect.Font.GetHeight() / 12;

            previewPanel.Refresh();
        }

        private void previewPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString(previewText.Text, fontDialog1.Font, new SolidBrush(colorSelect.ForeColor), 0, 0, StringFormat.GenericDefault);

            if (chkBox3D.Checked)
            {
                e.Graphics.DrawString(previewText.Text, fontDialog1.Font, new SolidBrush(colorSelect2.ForeColor), (float)layerDist.Value, (float)layerDist.Value, StringFormat.GenericDefault);
            }
        }

        private void colorSelect_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                colorSelect.Text = colorDialog1.Color.Name;
                colorSelect.ForeColor = colorDialog1.Color;
            }

            previewPanel.Refresh();
        }

        private void previewText_TextChanged(object sender, EventArgs e)
        {
            previewPanel.Refresh();
        }

        private void chkBox3D_CheckedChanged(object sender, EventArgs e)
        {
            colorSelect2.Enabled = chkBox3D.Checked;
            layerDist.Enabled = chkBox3D.Checked;

            layerDist.Value = (decimal) fontSelect.Font.GetHeight() / 12;

            previewPanel.Refresh();
        }

        private void colorSelect2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                colorSelect2.Text = colorDialog1.Color.Name;
                colorSelect2.ForeColor = colorDialog1.Color;
            }

            previewPanel.Refresh();
        }

        private void layerDist_ValueChanged(object sender, EventArgs e)
        {
            previewPanel.Refresh();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            XmlWriter fontpack = XmlWriter.Create(saveFileDialog1.FileName);

            fontpack.WriteStartElement("FontPacker");
            {
                fontpack.WriteStartElement("Font");
                {
                    fontpack.WriteStartAttribute("name");
                    {
                        fontpack.WriteString(fontSelect.Font.Name);
                    }
                    fontpack.WriteEndAttribute();

                    // Create Glyphs
                    List<char> glyphs = new List<char>();

                    if (exportCapitalAplha.Checked)
                    {
                        foreach (char glyph in alphabetsCapital)
                        {
                            if (!glyphs.Contains(glyph))
                            {
                                glyphs.Add(glyph);
                            }
                        }
                    }

                    if (exportSmallAlpha.Checked)
                    {
                        foreach (char glyph in alphabetsSmall)
                        {
                            if (!glyphs.Contains(glyph))
                            {
                                glyphs.Add(glyph);
                            }
                        }
                    }

                    if (exportNumbers.Checked)
                    {
                        foreach (char glyph in numbers)
                        {
                            if (!glyphs.Contains(glyph))
                            {
                                glyphs.Add(glyph);
                            }
                        }
                    }

                    if (exportArithOp.Checked)
                    {
                        foreach (char glyph in arithmeticOperators)
                        {
                            if (!glyphs.Contains(glyph))
                            {
                                glyphs.Add(glyph);
                            }
                        }
                    }

                    if (exportPunc.Checked)
                    {
                        foreach (char glyph in puntuations)
                        {
                            if (!glyphs.Contains(glyph))
                            {
                                glyphs.Add(glyph);
                            }
                        }
                    }

                    if (exportOthSym.Checked)
                    {
                        foreach (char glyph in otherSymbols)
                        {
                            if (!glyphs.Contains(glyph))
                            {
                                glyphs.Add(glyph);
                            }
                        }
                    }

                    // The Bitmap to measure the width of a character
                    Bitmap measurer = new Bitmap(100, 100);
                    Graphics g = Graphics.FromImage(measurer);

                    foreach (char glyph in glyphs)
                    {
                        fontpack.WriteStartElement("Glyph");
                        {
                            fontpack.WriteStartAttribute("char");
                            {
                                fontpack.WriteString("" + glyph);
                            }
                            fontpack.WriteEndAttribute();

                            fontpack.WriteStartAttribute("data");
                            {
                                fontpack.WriteString(GetGlyph(glyph, g));
                            }
                            fontpack.WriteEndAttribute();
                        }
                        fontpack.WriteEndElement();
                    }

                    g.Dispose();
                }
                fontpack.WriteEndElement();
            }
            fontpack.WriteEndElement();

            fontpack.Close();
            
            MessageBox.Show("Export Completed successfully", "FontPacker");
        }
        
        /// <summary>
        /// Trims a Glyph so as to reduce the space between characters
        /// </summary>
        /// <param name="img">The original glyph loaded from the font</param>
        /// <returns>The trimmed glyph</returns>
        private Bitmap TrimGlyph(Image img)
        {
            Bitmap toTrim = new Bitmap(img);

            int firstLeft = 0;

            bool leftFound = false;

            for (int x = 0; x < toTrim.Width; x++)
            {
                for (int y = 0; y < toTrim.Height; y++)
                {
                    if (toTrim.GetPixel(x, y).A != 0)
                    {
                        firstLeft = x;
                        leftFound = true;
                        break;
                    }
                }

                if (leftFound)
                {
                    break;
                }
            }

            int firstRight = img.Width;

            bool rightFound = false;

            for (int x = toTrim.Width-1; x >= 0; x--)
            {
                for (int y = 0; y < toTrim.Height; y++)
                {
                    if (toTrim.GetPixel(x, y).A != 0)
                    {
                        firstRight = x;
                        rightFound = true;
                        break;
                    }
                }

                if (rightFound)
                {
                    break;
                }
            }

            Bitmap newBmp = new Bitmap(firstRight - firstLeft, toTrim.Height);

            Graphics g = Graphics.FromImage(newBmp);
            g.DrawImageUnscaled(toTrim, -firstLeft, 0);
            g.Dispose();

            return newBmp;
        }

        private string GetGlyph(char ch, Graphics measures)
        {
            SizeF size = measures.MeasureString("" + ch, fontDialog1.Font);

            int width = (int) size.Width;
            int height = (int) size.Height;

            if (chkBox3D.Checked)
            {
                width += (int) layerDist.Value;
                height += (int)layerDist.Value;
            }

            Bitmap image = new Bitmap(width, height);

            Graphics g = Graphics.FromImage(image);

            g.DrawString(ch + "", fontDialog1.Font, new SolidBrush(colorSelect.ForeColor), 0, 0, StringFormat.GenericDefault);

            if (chkBox3D.Checked)
            {
                g.DrawString(ch + "", fontDialog1.Font, new SolidBrush(colorSelect2.ForeColor), (float)layerDist.Value, (float)layerDist.Value, StringFormat.GenericDefault);
            }

            g.Dispose();

            return (GetBase64(GetBitmapData(TrimGlyph(image))));
        }

        private string GetBase64(byte[] data)
        {
            return Convert.ToBase64String(data);
        }

        private byte[] GetBitmapData(Bitmap bmp)
        {
            MemoryStream image = new MemoryStream();
            bmp.Save(image, System.Drawing.Imaging.ImageFormat.Png);

            byte[] data = image.ToArray();

            return data;
        }

        private void export_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }
    }
}
