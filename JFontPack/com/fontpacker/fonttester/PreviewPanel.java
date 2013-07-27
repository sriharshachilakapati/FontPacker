package com.fontpacker.fonttester;

import java.awt.Graphics;
import java.awt.Graphics2D;

import javax.swing.JComponent;

import com.fontpacker.fontpack.PackedFont;

public class PreviewPanel extends JComponent
{

    /**
     * 
     */
    private static final long serialVersionUID = -5049499029940291308L;
    
    public PackedFont font = null;
    public String text = "Sample Text";
    
    public PreviewPanel()
    {
        setDoubleBuffered(true);
    }
    
    @Override
    public void paintComponent(Graphics g)
    {
        g.clearRect(0, 0, getWidth(), getHeight());
        if (font != null)
        {
            font.drawString(text, 0, 0, (Graphics2D)g);
        }
    }

}
