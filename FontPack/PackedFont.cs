// <summary>
// Copyright 2013 Sri Harsha Chilakapati.
//
// This file is for loading fonts produced by FontPacker
// </summary>

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

                    posX += bmp.Width;
                }
            }
        }

    }
}
