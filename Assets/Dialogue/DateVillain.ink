INCLUDE Globals.ink


 At last... someone who might understand the magnitude of my ambitions.
 
+ [Are you a villain?]
~dateCScore++
#anim3
-- HAHAHA - no. Of course not.
#anim1
-- But if I were, you would already be too late to stop me.
->Round2

+ [Hey.]
~dateCScore--
#anim2
-- ..."Hey"?
-- You respond to destiny with "hey"?
->Round2

==Round2
+ [What are you planning?]
~dateCScore++
#anim1
-- Phase one is already complete. Phase two begins soon.
-- You’re sitting at the center of it.
->Round3

+ [Nice weather.]
~dateCScore--
#anim2
-- Weather is irrelevant to power!
->Round3

==Round3
+ [Should I be worried?]
~dateCScore--
#anim3
-- Worried? No. Honored.
->Proceed

+ [Can I join?]
~dateCScore++
#anim34
-- YES! A recruit who understands greatness!
->Proceed

==Proceed
#anim1
-- Soon. Soon you will learn of my machinations.
-- Until then... Anticipate me!
-- Debug! Score is {dateCScore}!
#goToDateD
->END