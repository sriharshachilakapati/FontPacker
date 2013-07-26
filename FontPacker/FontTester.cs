// FontPacker 0.3 Beta Release
//
// Now works with any type of font listed in the font selected dialog
//
// Author: Sri Harsha Chilakapati

using System;
using System.Drawing;
using System.Windows.Forms;

using FontPack;

namespace FontPacker
{
    /// <summary>
    /// A form to test the rendering of PackedFont
    /// </summary>
    public partial class FontTester : Form
    {
        
        /// <summary>
        /// The PackedFont to use in preview
        /// </summary>
        PackedFont font = null;
        
        /// <summary>
        /// Constructs a new FontTester form
        /// </summary>
        public FontTester()
        {
            InitializeComponent();
            Show();
        }
        
        /// <summary>
        /// Repaints the preview panel
        /// </summary>
        void Panel1Paint(object sender, PaintEventArgs e)
        {
            if (font != null)
            {
                font.DrawString(textBox1.Text, 0, 0, e.Graphics);
            }
        }
        
        /// <summary>
        /// The Select Font button has clicked
        /// </summary>
        void Button1Click(object sender, EventArgs e)
        {
            // Show the fontselector and repaint the preview panel
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                font = new PackedFont(openFileDialog1.FileName);
                panel1.Refresh();
            }
        }
        
        /// <summary>
        /// The text in the preview has changed
        /// </summary>
        void TextBox1TextChanged(object sender, EventArgs e)
        {
            panel1.Refresh();
        }
    }
}
