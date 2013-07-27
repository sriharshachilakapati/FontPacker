package com.fontpacker.fontpack;

import java.awt.Graphics2D;
import java.awt.Image;
import java.io.ByteArrayInputStream;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.util.HashMap;

import javax.imageio.ImageIO;
import javax.xml.parsers.ParserConfigurationException;
import javax.xml.parsers.SAXParser;
import javax.xml.parsers.SAXParserFactory;

import org.apache.commons.codec.binary.Base64;
import org.xml.sax.SAXException;
import org.xml.sax.Attributes;
import org.xml.sax.helpers.DefaultHandler;

/**
 * PackedFont - Class to read fonts packed with FontPacker
 * 
 * @author Sri Harsha Chilakapati
 */
public class PackedFont
{
    
    // The map of glyphs
    private HashMap<Character, Image> glyphs = new HashMap<Character, Image>();
    // The map of advance widths
    private HashMap<Character, Integer> advances = new HashMap<Character, Integer>();
    
    /**
     * Constructs a new PackedFont from the name of the file.
     * @param fileName The name of fontpack file
     * @throws FileNotFoundException If the file is not found.
     */
    public PackedFont(String fileName) throws FileNotFoundException
    {
        this (new FileInputStream(fileName));
    }
    
    /**
     * Constructs a new PackedFont from an InputStream.
     * @param stream The InputStream of the fontpack xml data.
     */
    public PackedFont(InputStream stream)
    {
        try
        {
            // Create a new SAX Parser
            SAXParser fontpack = SAXParserFactory.newInstance().newSAXParser();
            DefaultHandler handler = new DefaultHandler()
            {
                @Override
                public void startElement(String uri, String localName, String qName, Attributes attr)
                {
                    // Read every glyph from the font.
                    if (qName.equalsIgnoreCase("Glyph"))
                    {
                        try
                        {
                            // Get the character value
                            char ch = attr.getValue("char").charAt(0);
                            
                            // Get the advance width
                            int xadvance = Integer.parseInt(attr.getValue("xadvance"));
                            
                            // Decode the glyph image
                            String data = attr.getValue("data");
                            byte[] png = Base64.decodeBase64(data);
                            ByteArrayInputStream source = new ByteArrayInputStream(png);
                            Image img = ImageIO.read(source);
                            
                            // Map the Glyph and AdvanceWidth with the character
                            glyphs.put(ch, img);
                            advances.put(ch, xadvance);
                        }
                        catch (IOException e)
                        {
                            e.printStackTrace();
                        }
                    }
                }
            };
            
            // Parse the file.
            fontpack.parse(stream, handler);
            
            // Close the stream.
            stream.close();
        }
        catch (ParserConfigurationException | SAXException | IOException e)
        {
            e.printStackTrace();
        }
    }
    
    /**
     * @return The Map containing all the Glyphs
     */
    public HashMap<Character, Image> getGlyphs()
    {
        return glyphs;
    }
    
    /**
     * @return The Map containing all the AdvanceWidths
     */
    public HashMap<Character, Integer> getAdvanceWidths()
    {
        return advances;
    }
    
    /**
     * @param ch The Character value
     * @return The Glyph for the character
     */
    public Image getGlyph(char ch)
    {
        return glyphs.get(ch);
    }
    
    /**
     * @param ch The Character value
     * @return The amount to advance horizontally after drawing a glyph of this character
     */
    public int getAdvanceWidth(char ch)
    {
        return advances.get(ch);
    }
    
    /**
     * Draws a string of characters at a position on the screen using
     * a graphics context. Skips to newline on entering '\n' new line character.
     * @param text The text to be drawn.
     * @param posX The x-coordinate on the component
     * @param posY The y-coordinate on the component
     * @param g The graphics context.
     */
    public void drawString(String text, float posX, float posY, Graphics2D g)
    {
        float x = posX;
        float y = posY;
        
        for (char ch : text.toCharArray())
        {
            if (ch == '\r')
            {
                continue;
            }
            
            if (ch == '\n')
            {
                y += glyphs.get(' ').getHeight(null);
            }
            
            g.drawImage(glyphs.get(ch), (int)x, (int)y, null);
            x += advances.get(ch);
        }
    }

}
