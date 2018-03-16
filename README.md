# VoluMIDI
Program to use a soundcard's volume controller as a MIDI controller

# But... why...?
If you're looking at the Windows volume bar with confusion, consider this: many keyboards now have a physical volume knob you can use to manipulate sound levels.

VoluMIDI is a really quick and easy way to turn those into MIDI controllers. This allows you to control a variety of music production software with them.

You have two options: you can either "pin" the volume to 50% and have it snap back whenever you move the knob, or have the volume go up and down as normal along with your MIDI signals.

VoluMIDI outputs to a standard MIDI port; if you don't have the hardware you may want to try LoopBE to give you a virtual loopback: http://www.nerds.de/en/loopbe1.html
