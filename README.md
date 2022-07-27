# OpenGloves-Unity
A **C#** library made to interact with the force feedback of the [OpenGloves driver](https://github.com/LucidVR/opengloves-driver).

## Disclaimer
A large amount of this code is not mine. (Most) credit goes to [Hydr4](https://github.com/Hydr4Bytes) from his [Boneworks FFB mod](https://github.com/LucidVR/opengloves-boneworks-mod).

### What is this?
A library I am planning on using for my mods. At the time of creation, I was not yet aware Hydr4 had made a library himself ([Hydr4](https://github.com/Hydr4Bytes/OpenGlovesLib)). This just has a different naming convention and (some) documentation. I am planning to add a sample with this.

I made this specifically for the ChilloutVR FFB mod I'm making. Feel free to use as a dependency.

### How do I use this?
You must be a developer to use this. If not, you probably came here from a mod. Look what the mod instructs you to do with this.

**If you are a developer:**

This project does not only work with **Unity**. It will work with **Godot** games and such, if you know how to mod them, as it doesn't interact with Unity but only with the driver.

This contains a **Log** class you can use to log stuff for your mod. Just create an instance of the `OpenGloves_Unity::Logging::Log` class (and remember to read the documentation).

**Shared Link Instances**

The library contains the possibility to use already created for you instances of `Link`s, which are what connects to the Drivers through things named "named pipes". You can find more about them online. To access said "shared links", use `OpenGloves_Unity::Shared::SharedLinks`. They contain a link for each hand. You can send information about Force Feedbacks using "finger curls". Use `Link::Write(Input input)`. The input struct is in `OpenGloves_Unity::Data::Input` (that is passed as an argument).

**If you want to create your own Link instances**

If you want to create your own instances instead of using the Shared links, you can create an instance of `OpenGloves_Unity::Link` for both hands (using the Handedness argument).

### If you still need help
If you don't understand how to use this, or need examples, feel free to contact me on Discord: The Ulti One#1998.

## Thanks for using :)