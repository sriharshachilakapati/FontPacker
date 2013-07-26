// FontPacker 0.3 Beta Release
//
// Now works with any type of font listed in the font selected dialog
//
// Author: Sri Harsha Chilakapati

using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Drawing;
using System.Collections.Generic;

namespace FontPack
{
    
    /// <summary>
    /// PackedFont - Class to read fonts packed by FontPacker
    /// </summary>
    public class PackedFont
    {
        
        Dictionary<char, Image> glyphs = new Dictionary<char, Image>();
        Dictionary<char, int> advances = new Dictionary<char, int>();

        /// <summary>
        /// Load a PackedFont from a file.
        /// </summary>
        /// <param name="filename">The name of the file</param>
        public PackedFont(string filename) : this(new FileStream(filename, FileMode.Open)) { }

        /// <summary>
        /// Load a PackedFont from a stream.
        /// </summary>
        /// <param name="stream">The stream containing the data.</param>
        public PackedFont(Stream stream)
        {
            XmlReader fontpack = XmlReader.Create(stream);

            // Read from the XML
            while (fontpack.Read())
            {
                switch (fontpack.NodeType)
                {
                    case XmlNodeType.Element:
                        // Read every glyph
                        if (fontpack.LocalName == "Glyph")
                        {
                            char glyph = fontpack.GetAttribute("char")[0];

                            byte[] image = Convert.FromBase64String(fontpack.GetAttribute("data"));

                            int xadvance = int.Parse(fontpack.GetAttribute("xadvance"));
                            advances.Add(glyph, xadvance);
                            
                            MemoryStream imgStream = new MemoryStream();

                            imgStream.Write(image, 0, image.Length);
                            imgStream.Seek(0, SeekOrigin.Begin);

                            Image bmp = Image.FromStream(imgStream);

                            glyphs.Add(glyph, bmp);
                        }
                        break;
                }
            }

            fontpack.Close();
            stream.Close();
        }
        
        /// <summary>
        /// Get the Glyph of the char
        /// </summary>
        /// <param name="c">The character of glyph</param>
        /// <returns>The Glyph as an Image</returns>
        public Image GetGlyph(char c)
        {
            return glyphs[c];
        }
        
        /// <summary>
        /// Get the AdvanceWidth of a glyph
        /// </summary>
        /// <param name="c">The character of glyph</param>
        /// <returns>The amount to move forward after drawing the glyph</returns>
        public int GetAdvanceWidth(char c)
        {
            return advances[c];
        }
        
        /// <summary>
        /// Gets the Dictionary containing the Glyphs
        /// </summary>
        public Dictionary<char, Image> Glyphs
        {
            get
            {
                return glyphs;
            }
        }
        
        /// <summary>
        /// Gets the Dictionary containing the AdvanceWidths
        /// </summary>
        public Dictionary<char, int> AdvanceWidths
        {
            get
            {
                return advances;
            }
        }

        /// <summary>
        /// Draws a string using this font at a position using the given Graphics context.
        /// </summary>
        /// <param name="text">The text to be drawn.</param>
        /// <param name="x">The x-position</param>
        /// <param name="y">The y-position</param>
        /// <param name="g">The graphics context to be used</param>
        public void DrawString(string text, float x, float y, Graphics g)
        {
            float posX = x;
            float posY = y;

            foreach (char ch in text)
            {
                if (ch == '\n')
                {
                    posY += glyphs[' '].Height;
                }
                else
                {
                    Image bmp = glyphs[ch];
                    g.DrawImageUnscaled(bmp, (int)posX, (int)posY);

                    posX += advances[ch];
                }
            }
        }

    }
}
