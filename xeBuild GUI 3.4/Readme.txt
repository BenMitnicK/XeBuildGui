Swizzy's xeBuild GUI Version 2.097
----------------------------------

****** If you find a bug, let me know! you can reach me on: swizzy@xeupd.com ******

NOTE: I did NOT create xeBuild! i merely made a frontend/GUI for it!
NOTE: This is the official frontend/GUI for xeBuild, i have contacts with the team, but i cannot give you details about future features or how everything works.
NOTE: I take NO responsibility for damage to your console/files caused by your use of my program!
NOTE: If the program say something about "Unkown" when you check the nand this ussually means it is NOT supported! If you encounter a problem with a NAND that the GUI can't identify that's probably NOT a bug in the program, but rather unsupported versions...

======================================================================
   Requirements - What you need to do have in order for this to work!
======================================================================
- Microsoft .NET Framework 2.0 or later
- Your CPUKey or network connection with your console ;) (when creating images other then ECC)
- A dump of your nand OR donor files OR a motherboard and a device that can dump the nand using nandpro

======================================================================
   Overview - What it does
======================================================================

- This is a frontend/GUI for xeBuild, what it does is make it easy for you to select most options that you might need, such as Motherboard, SMC hack for freeboot, image type etc. etc.

- It is able to check what SMC hack you have previously used for JTAG it's also able to tell you what SMC version you have, and if it's a JTAG, Clean/Retail, Glitch or Cygnos patched SMC :)

- If you put any of these files next to the executable it'll use them automaticly:
SMC.bin - Custom SMC of your choice; ONLY USE THIS IF YOU KNOW WHAT YOU ARE DOING!!!!
kv.bin - donor keyvault; ONLY USE THIS IF YOU KNOW WHAT YOU ARE DOING!!!!
smc_config.bin - donor smc_config; ONLY USE THIS IF YOU KNOW WHAT YOU ARE DOING!!!!
Xell.bin - Custom Xell of your choice; ONLY USE THIS IF YOU KNOW WHAT YOU ARE DOING!!!!
cpukey.txt - It'll read first line of this file, if it starts with "cpukey" it'll read the last 32 characters from that line (removing any extra spaces) otherwise it'll read the first 32 characters of that line (removing any extra spaces)
FUSE.txt - It'll parse it as if it was saved from Xell using network...
flashdmp.bin - It'll load this as source nand ;)
Default.xml - It'll load any preset settings from this file ;)
nandpro.xml - It'll load any nandpro settings from this file ;)
options.ini - It'll load any custom settings from this (for xeBuild)
launch.ini - Settings for Dashlaunch, if you choose to use this setting it'll include this file in the generated image ;)

======================================================================
    Notes about build types/image types
======================================================================

First of all, there are 3 types of hacks, first one is called "JTAG"
or "SMC-JTAG" it's the first version of the JTAG hack for Xbox 360
the requirements to use this type of hack is:
- Dashboard may NOT be higher then 2.0.7371.0
- The console may NOT be manufactured or have been to a repaircenter
after 2009-06-xx~ there are some exceptions to this, but most of the
consoles after this has new CB versions which have "fixed" the hack

Valid CB versions for JTAG includes:
 * Xenon: 1888, 1902, 1903, 1920, 1921
 * Zephyr: 4558, 4571, 4580
 * Falcon: 5761, 5766, 5770
 * Jasper: 6712, 6723

Second hack is called "RGH" or "Reset Glitch Hack" it was made by GliGli
and Tiros, This hack works for almost all versions of consoles, however
phat consoles have had this "fixed" by getting split CB versions, the
requirements here are quite simple:
- If you have a "phatt" console (non-slim) it may NOT have a dashboard above
2.0.14699.0 because after this it'll have the new CB versions and require the
new RGH 2.0 hack

Valid CB versions for RGH includes:
 * Xenon: 1923, 1940, 7375
 * Zephyr: 4578, 4579
 * Falcon: 5771
 * Jasper: 6750, 6751
 * Trinity: 9188, 9230, 9231

Third and last hack is called "RGH 2.0", it was made by Team-Xecuter and
stolen/leaked to Team Squirt360 and released, it works something similar
to RGH but still a little different, this supports updated phatt consoles
and will probably support any newer dashboard, this type will NOT work with
a console updated to 15572 or above :(

since v 2.08 of xeBuild GUI files for Corona are also included and the info
below has been updated...

Valid CB versions for RGH 2.0 includes:
 * Zephyr: 4559, 4560, 4575, 4577, 4561, 4562, 4569, 4574
 * Falcon: 5772, 5773, 5774
 * Jasper: 6752, 6753, 6754
 * Corona: 13121, 13180, 13181, 13182

======================================================================
    Notes about building retail/devkit images
======================================================================

Retail images can be built using this gui, it includes common retail
SMC's i've extracted myself, i make no form of garantuee that these
are safe to use for your console, some machines might not like the
bootloaders etc. which are used by default...

If you want to create devkit images you will need to find the files for
it on your own, and you will also need to select custom version because
they're different from the normal dashboard. i've limited this type
of images to advanced due to normal users not having a devkit in the
first place, only devs should have one and devs should be advanced ;)

Please read the xeBuild readme for more details about devkit building...

======================================================================
     Notes about LDV
======================================================================

There are 3 ways you can get your LDV value:

1. Use Xell and manually count the ammount of "f" on fusesets
07 and 08, the total here is your LDV value.
2. Use Xell and a network connection, doing this the app can
read fusesets for you and read cpukey aswell as check what ldv your
Xbox 360 should have automaticly for you (this option also sets both)
3. Use 360 Flash Dump Tool and check which value is the highest, this
is the one you will want to be using

Normally (if you have a good dump that does NOT include data from
.ECC file created using RGH python script) xeBuild should be able
to extract this value on it's own, if it can't just follow the
instructions above... if you don't understand these instructions,
ask google!

======================================================================
     Notes about FCRT patches
======================================================================

This patch removes the need for FCRT.bin in nand, however, it will
NOT work for everyone, it's been disabled in the default configuration,
and should stay disabled if you are using a machine with a Liteon DG16-D5S
FW: 1175, it's been confirmed by me that it doesn't work on these drives
all others i've tested has worked just fine, however it can still be a 
problem for you to have this activated, disable it if games don't work
from discs (if you use this feature!)

======================================================================
 Other things you need to know about that don't fit in the changelog
======================================================================

**************
* KNOWN BUGS *
**************
- If you have a badblock @ block 1 the app will NOT be able to extract/check your KV
if you want it to do this for you, you'll have to manually remap it to fix your nand
i'll be adding support for doing this automatically when needed later on ;)

- Sometimes when you start a download for the first time the app may stand still for a while
doing nothing... i have no idea why this is happening atm, only had it happen to a friend of
mine but haven't been able to reproduce it myself and therefor i cannot find the reason for 
this to happen, i'm looking for what is causing it, if you experience this, let me know and tell
me about your computer, what connection you have, what OS you have etc. all this will help me
if it's because of connections i can't do anything about it ;)

*******************************
* Features beeing worked upon *
*******************************
- A Full Updater, i will be making a update program for xeBuild GUI which will be capable of checking for
and downloading new files/versions for you, i had one in previous code base but decided not to include it
here because it needs more work, and i've also considerd the possiblity of replacing current xebuild GUI version
which would require the prog to NOT be running, thus an external updater would be required, i'll be working
around that idea and hopefully release an updater soon :)

- Badblock management, i'll be working on detecting and dealing with badblocks which could cause a problem with
some features, such as dumping/decrypting KV to check various values in it

======================================================================
     Credits - Thanks to:
======================================================================

- A HUGE thanks to: cOz and Razkar - Thanks for everything, without you guys i wouldn't have been able to make this app into what it is! i owe you bigtime! ;)
- Team Xecuter - Thanks for figuring out and releasing info about glitching Xenons and RGH 2.0!
- GliGli & Tiros - Thanks for figuring out and releasing RGH in the first place! :D
- BestPig - Thanks for releasing the source for your FCRT.bin extractor, it helped me out alot! ;)
- Blackaddr - Thanks for your SMC_Utility it's awesome! :D
- Tiros - Thanks for nandpro! :D
- nitram - Thanks for the updated build.py
- RF1911 - Thanks for your help with extracting smc_config :)
- LegendaryFire - NandApi : http://www.team-hq.com/index.php?title=NandApi Thanks for making this! it really helped me out with the keyvault stuff :)
- Jack Nepacha - Making my new icons and other graphical stuff thanks mate ;)
- Aioros - Making the latest Icon/Logo
- Anyone else that has helped me with anything such as tests, bug finding and such that is not mentioned above, THANK YOU! without testers this app would be pretty much useless compared to the other GUI versions out there ;)