// FontPacker 0.3 Beta Release
//
// Now works with any type of font listed in the font selected dialog
//
// Author: Sri Harsha Chilakapati

using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace FontPacker
{
    /// <summary>
    /// The form of the FontPacker.
    /// </summary>
    public partial class PackerForm : Form
    {

        /// <summary>
        /// All the small alphabets available
        /// </summary>
        private char[] alphabetsSmall = {
                                          'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                                          'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ' '
                                        };

        /// <summary>
        /// All the capital alphabets avaiable
        /// </summary>
        private char[] alphabetsCapital = {
                                          'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
                                          'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', ' '
                                          };

        /// <summary>
        /// All the numbers available
        /// </summary>
        private char[] numbers = {
                                     '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ' '
                                 };

        /// <summary>
        /// All the arithmetic operators
        /// </summary>
        private char[] arithmeticOperators = {
                                                 '+', '-', '*', '/', '%', '^', ' '
                                             };

        /// <summary>
        /// All the punctuation symbols
        /// </summary>
        private char[] puntuations = {
                                         ',', '.', '?', '!', '_', ' '
                                     };

        /// <summary>
        /// All the other symbols which are found on a standard QWERTY keyboard
        /// </summary>
        private char[] otherSymbols = {
                                          '`', '~', '!', '@', '#', '$',  '%', '^', '&', '*',  '(', ')', '-', '_', '=',
                                          '+', '[', '{', ']', '}', '\\', '|', ';', ':', '\'', '"', ',', '<', '>', '.',
                                          '/', '?', ' '
                                      };

        /// <summary>
        /// The default constructor. Initializes the window.
        /// </summary>
        public PackerForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The fontSelect button has been clicked.
        /// </summary>
        private void fontSelect_Click(object sender, EventArgs e)
        {
            // Show the font selector and refresh the preview panel
            
            if (fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fontSelect.Text = fontDialog1.Font.Name + "    " + fontDialog1.Font.Size + " pt";
                
                // Default value based on the font
                layerDist.Value = (decimal)fontSelect.Font.GetHeight() / 12;
            }

            previewPanel.Refresh();
        }

        /// <summary>
        /// Sets the default values for fields in this form
        /// </summary>
        private void PackerForm_Load(object sender, EventArgs e)
        {
            // Default font name on the fontSelect button
            fontSelect.Text = fontSelect.Text = fontDialog1.Font.Name + "    " + fontDialog1.Font.Size + " pt";

            // Color selector 1
            colorDialog1.Color = Color.Black;
            colorSelect.Text = colorDialog1.Color.Name;
            colorSelect.ForeColor = colorDialog1.Color;

            // Color selector 2
            colorSelect2.Text = colorDialog1.Color.Name;
            colorSelect2.ForeColor = colorDialog1.Color;

            // The "3D Layer Distance" default value
            layerDist.Value = (decimal)fontSelect.Font.GetHeight() / 12;

            // Refresh the preview panel
            previewPanel.Refresh();
        }

        /// <summary>
        /// Paint the preview on to the panel.
        /// </summary>
        private void previewPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString(previewText.Text, fontDialog1.Font, new SolidBrush(colorSelect.ForeColor), 0, 0, StringFormat.GenericDefault);

            if (chkBox3D.Checked)
            {
                e.Graphics.DrawString(previewText.Text, fontDialog1.Font, new SolidBrush(colorSelect2.ForeColor), (float)layerDist.Value, (float)layerDist.Value, StringFormat.GenericDefault);
            }
        }

        /// <summary>
        /// Shows the Color Selector for the first color button
        /// </summary>
        private void colorSelect_Click(object sender, EventArgs e)
        {
            // Show the color selector
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                colorSelect.Text = colorDialog1.Color.Name;
                colorSelect.ForeColor = colorDialog1.Color;
            }

            // Refresh the preview panel
            previewPanel.Refresh();
        }

        /// <summary>
        /// The text to use for the preview has been changed
        /// </summary>
        private void previewText_TextChanged(object sender, EventArgs e)
        {
            previewPanel.Refresh();
        }

        /// <summary>
        /// The check box "Enable 3D" has changed
        /// </summary>
        private void chkBox3D_CheckedChanged(object sender, EventArgs e)
        {
            colorSelect2.Enabled = chkBox3D.Checked;
            layerDist.Enabled = chkBox3D.Checked;

            layerDist.Value = (decimal) fontSelect.Font.GetHeight() / 12;

            previewPanel.Refresh();
        }

        /// <summary>
        /// The second Color button has been clicked
        /// </summary>
        private void colorSelect2_Click(object sender, EventArgs e)
        {
            // Show the color dialog
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                colorSelect2.Text = colorDialog1.Color.Name;
                colorSelect2.ForeColor = colorDialog1.Color;
            }

            // Refresh the preview panel
            previewPanel.Refresh();
        }

        /// <summary>
        /// The value in the Layer Distance has been changed
        /// </summary>
        private void layerDist_ValueChanged(object sender, EventArgs e)
        {
            previewPanel.Refresh();
        }
        
        /// <summary>
        /// Creates a list of glyphs to export
        /// </summary>
        private List<char> GetGlyphsToExport()
        {
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
            
            return glyphs;
        }

        /// <summary>
        /// Export runs on another thread to avoid hanging of GUI
        /// </summary>
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // Open the file in create mode. The file selector will be displayed without calling this.
            FileStream stream = new FileStream(saveFileDialog1.FileName, FileMode.Create);
            
            // Create an XML writer
            XmlWriter fontpack = XmlWriter.Create(stream);
            
            // Get selected glyphs
            List<char> glyphs = GetGlyphsToExport();
            
            // The progress of this work
            int numGlyphs = glyphs.Count;
            int exportedGlyphs = 0;

            // The root element is "FontPacker"
            fontpack.WriteStartElement("FontPacker");
            {
                // The first element is "Font"
                fontpack.WriteStartElement("Font");
                {
                    // Write the name of the font
                    fontpack.WriteStartAttribute("name");
                    {
                        fontpack.WriteString(fontDialog1.Font.Name);
                    }
                    fontpack.WriteEndAttribute();

                    // Start writing the glyphs
                    foreach (char glyph in glyphs)
                    {
                        // Create a new element Glyph
                        fontpack.WriteStartElement("Glyph");
                        {
                            // Write the "char" attribute
                            fontpack.WriteStartAttribute("char");
                            {
                                fontpack.WriteString("" + glyph);
                            }
                            fontpack.WriteEndAttribute();
                            
                            // The accurate width of each character
                            int xadvance = 0;

                            // Write the Base64 encoded image data and retrieve calculated advance width
                            fontpack.WriteStartAttribute("data");
                            {
                                fontpack.WriteString(GetGlyph(glyph, out xadvance));
                            }
                            fontpack.WriteEndAttribute();
                            
                            // Write the advanced width attribute
                            fontpack.WriteStartAttribute("xadvance");
                            {
                                fontpack.WriteValue(xadvance);
                            }
                            
                            exportedGlyphs++;
                            
                            // Report percentage
                            backgroundWorker1.ReportProgress((int) (exportedGlyphs/numGlyphs * 100));
                        }
                        fontpack.WriteEndElement();
                    }
                }
                fontpack.WriteEndElement();
            }
            fontpack.WriteEndElement();

            // Close the XML Writer
            fontpack.Close();
            // Close the FileStream
            stream.Close();
        }

        /// <summary>
        /// This method creates the glyph for a character 'ch' in the selected font.
        /// The width to advance after drawing this font is written to the 'xadvance' variable.
        /// </summary>
        private string GetGlyph(char ch, out int xadvance)
        {
            // Measure the width of character
            Size size = TextRenderer.MeasureText("" + ch, fontDialog1.Font);
            
            // Work-around to measure the width of space character
            if (ch == ' ')
            {
                size = TextRenderer.MeasureText("i ", fontDialog1.Font);
                size.Width -= TextRenderer.MeasureText("i", fontDialog1.Font).Width;
            }

            // The width and height of the glyph image
            int width = size.Width;
            int height = size.Height;

            // If 3D is enabled, add the layer distance to the size
            if (chkBox3D.Checked)
            {
                width += (int) layerDist.Value;
                height += (int)layerDist.Value;
            }

            // Create an empty Bitmap to render the glyph on
            Bitmap image = new Bitmap(width, height);

            // Render the char onto the bitmap
            Graphics g = Graphics.FromImage(image);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            g.DrawString(ch + "", fontDialog1.Font, new SolidBrush(colorSelect.ForeColor), 0, 0, StringFormat.GenericTypographic);

            if (chkBox3D.Checked)
            {
                g.DrawString(ch + "", fontDialog1.Font, new SolidBrush(colorSelect2.ForeColor), (float)layerDist.Value, (float)layerDist.Value, StringFormat.GenericTypographic);
            }

            // Dispose the graphics object
            g.Dispose();
            
            // Calculate the advance width of this character
            xadvance = GetAdvanceWidth(ch);
            
            // Return the Base64 encoded image of the Glyph in PNG format
            return (GetBase64(GetBitmapData(image)));
        }

        /// <summary>
        /// Utility method to convert the byte array into Base64 string.
        /// </summary>
        private string GetBase64(byte[] data)
        {
            return Convert.ToBase64String(data);
        }
        
        /// <summary>
        /// Calculates the advance width of a char in the given font.
        /// </summary>
        private int GetAdvanceWidth(char ch)
        {
            int underScoresWidth = MeasureCharsWidth('_', '_');
            return MeasureCharsWidth('_', ch, '_') - underScoresWidth;
        }
        
        /// <summary>
        /// Utility method to measure the width of the characters instead of passing strings.
        /// </summary>
        private int MeasureCharsWidth(params char[] ch)
        {
            string str = "";
            foreach (char c in ch)
            {
                str += c;
            }
            return TextRenderer.MeasureText(str, fontDialog1.Font).Width;
        }

        /// <summary>
        /// Returns the byte data of the bitmap saved as a PNG
        /// </summary>
        private byte[] GetBitmapData(Bitmap bmp)
        {
            // Create a memory stream
            MemoryStream image = new MemoryStream();
            // Save in memory
            bmp.Save(image, System.Drawing.Imaging.ImageFormat.Png);

            // Return the byte data
            return image.ToArray();
        }

        /// <summary>
        /// The export button is clicked.
        /// </summary>
        private void export_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }
        
        /// <summary>
        /// The "Open Font Tester" button is clicked.
        /// </summary>
        void FontTesterClick(object sender, EventArgs e)
        {
            new FontTester();
        }
        
        /// <summary>
        /// Some progress in exporting is done
        /// </summary>
        void BackgroundWorker1ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            
            // Show completed message box if percentage is 100
            if (e.ProgressPercentage == 100)
            {
                MessageBox.Show("Exporting completed successfully", "FontPacker");
            }
        }
    }
}
