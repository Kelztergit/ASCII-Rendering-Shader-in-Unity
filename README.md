# A modified Ascii rendering shader in unity
original credit goes to [StefanJo3107/ASCII-Rendering-Shader-in-Unity: Unity Image Effect that replicates retro ASCII rendering seen in games such as Rogue and Dwarf Fortress (github.com)](https://github.com/StefanJo3107/ASCII-Rendering-Shader-in-Unity)

what i did was mainly : 
- Change monochromatic from being green only to instead monogreen and added monored, monoblue and mono gray as options. 
- Change parts that were bound to expect 1920x1080 to instead use screen size as it is (found some _ScreenParams in docs that  seems to work)
- Change it so you don't need to specify character size manually, it now sets it based on your current screensize and your tilesizes you picked, thus simplifying it down to 3 fields you need to modify, i.e. Tiles X, Tiles Y and Char Count

The goal being to simplify the process of setting up the characters and tiles in such a way that it felt more intuitive to me, whether these can be considered an improvement or not is up to you.

Note, the charmap you add in needs to be in point/nearest neighbour, i got some good results also putting it in as a "sprite", sometimes i've gotten vertical black lines especially if i pick tiles X, tiles Y that's in a different ratio to the screen size, i believe i might be able to tweak this somewhat later but as long as your charmap is set up right you should be able to set things up decently as it is.

images via original repo + some of mine 
![Example 01](https://i.imgur.com/c0I6ilo.png)
![Example 02](https://i.imgur.com/iGROj0O.png)
![Example 03](https://i.imgur.com/23NWYVU.png)
![Example 04](https://imgur.com/ZMZheJL.png)
![Example 05](https://imgur.com/q0SwQSt.png)
![Example 06](https://imgur.com/Cq2qiQG.gif)

