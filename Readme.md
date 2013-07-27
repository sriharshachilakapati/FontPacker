## FontPacker Beta Version 0.3 ##

![](http://transfer2pc.weebly.com/uploads/2/7/9/6/2796142/9905488_orig.png)

## Features ##

- Fully Cross-Platform. Can be run in mono.
- Selection of Glyphs to export.
- Easy to read XML format.
- Accurate advance widths.
- Nice Easy To Use User Interface.
- Included Font Tester to test exported fonts.
- Supports all the fonts supported in the host OS.

## Licence ##

This project is licenced with GNU Lesser Public Licence (LGPL) and the terms [here](http://opensource.org/licenses/LGPL-3.0).

You can use the the `FontPack` library for free in C# projects and you can even sell the projects using this library.

## Using the Fonts ##

After you create a `.fntpack` file, you need to use it as XML. Here's the structure of the file.

The xml file starts normally with the xml declaration. Then comes the root tag `<FontPacker>` which contains the `<Font>` tag with an attribute `name`.

```xml
<Font name="Microsoft Sans Serif"> ... </Font>
```

Then comes the `Glyph` tags in the font tag with the following attributes.

- `char       ` - The character value
- `data       ` - The Base64 encoded PNG image of that glyph
- `xadvance   ` - The pixels to move forward after drawing that glyph

Here's an example overview.

```xml
<?xml version="1.0" encoding="utf-8"?>
<FontPacker>
    <Font name="Microsoft Sans Serif">
        <Glyph char="A"
               data="....Base64 encoded PNG image here..."
               xadvance="33" />
        <Glyph char="B"
               data="....Base64 encoded PNG image here..."
               xadvance="30" />
    </Font>
</FontPacker>
```

## Downloads ##

The downloads are available on my site [here](http://transfer2pc.weebly.com/fontpacker.html)

## Changes ##

- Added progress bar and font tester
- Fixed the packer to give correct values for xadvance
- Fixed the glyph width measuring algorithm
- Supports Italic Fonts and Script fonts
