package com.fontpacker.fonttester;

import java.awt.BorderLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.File;
import java.io.FileNotFoundException;

import javax.swing.JButton;
import javax.swing.JFileChooser;
import javax.swing.JFrame;
import javax.swing.JTextField;
import javax.swing.event.DocumentEvent;
import javax.swing.event.DocumentListener;
import javax.swing.filechooser.FileFilter;

import com.fontpacker.fontpack.PackedFont;

public class FontTester extends JFrame implements ActionListener, DocumentListener
{

    /**
     * 
     */
    private static final long serialVersionUID = -5817264070021782962L;
    
    PreviewPanel previewPanel = null;
    JButton fontSelect = null;
    JTextField previewText = null;
    
    public FontTester()
    {
        super("FontTester");
        setLayout(new BorderLayout());
        fontSelect = new JButton("Select Font");
        fontSelect.addActionListener(this);
        add(fontSelect, BorderLayout.NORTH);
        previewPanel = new PreviewPanel();
        add(previewPanel, BorderLayout.CENTER);
        previewText = new JTextField("Sample Text");
        previewText.getDocument().addDocumentListener(this);
        previewPanel.text = previewText.getText();
        add(previewText, BorderLayout.SOUTH);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setSize(400, 300);
        setLocationRelativeTo(null);
        setVisible(true);
    }

    @Override
    public void actionPerformed(ActionEvent e)
    {
        if (e.getSource() == fontSelect)
        {
            JFileChooser fc = new JFileChooser();
            fc.setFileFilter(new FontFilter());
        
            if (fc.showOpenDialog(this) == JFileChooser.APPROVE_OPTION)
            {
                try
                {
                    previewPanel.font = new PackedFont(fc.getSelectedFile().getAbsolutePath());
                    previewPanel.repaint();
                }
                catch (FileNotFoundException e1)
                {
                    e1.printStackTrace();
                }
            }
        }
    }

    @Override
    public void insertUpdate(DocumentEvent e)
    {
        updatePreview();
    }

    @Override
    public void removeUpdate(DocumentEvent e)
    {
        updatePreview();
    }

    @Override
    public void changedUpdate(DocumentEvent e)
    {
        updatePreview();
    }
    
    private void updatePreview()
    {
        previewPanel.text = previewText.getText();
        previewPanel.repaint();
    }
    
    public static void main(String[] args)
    {
        new FontTester();
    }
    
    class FontFilter extends FileFilter
    {

        @Override
        public boolean accept(File pathname)
        {
            if (pathname.isDirectory() || pathname.getName().endsWith(".fntpack"))
            {
                return true;
            }
            return false;
        }
        
        @Override
        public String getDescription()
        {
            return "FontPacker fonts";
        }
        
    }

}
