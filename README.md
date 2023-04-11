# A modified Ascii rendering shader in unity
original credit goes to [StefanJo3107/ASCII-Rendering-Shader-in-Unity: Unity Image Effect that replicates retro ASCII rendering seen in games such as Rogue and Dwarf Fortress (github.com)](https://github.com/StefanJo3107/ASCII-Rendering-Shader-in-Unity)

what i did was mainly : 
- Change monochromatic from being green only to instead monogreen and added monored, monoblue and mono gray as options. 
-  Change parts there were bound to expect 1920x1080 to instead use screen size as it is
- Change it so you don't need to specify character size manually, it now sets it based on your current screensize and your tilesizes you picked, thus simplifying it down to 3 fields you need to modify, i.e. Tiles X, Tiles Y and Char Count

The goal being to simplify the process of setting up the characters and tiles in such a way that it felt more intuitive to me, whether these can be considered an improvement or not is up to you.

images via original repo + some of mine 
![Example 01](https://i.imgur.com/c0I6ilo.png)
![Example 02](https://i.imgur.com/iGROj0O.png)
![Example 03](https://i.imgur.com/23NWYVU.png)
![Example 04](https://imgur.com/ZMZheJL.png)
![Example 05](https://imgur.com/q0SwQSt.png)

