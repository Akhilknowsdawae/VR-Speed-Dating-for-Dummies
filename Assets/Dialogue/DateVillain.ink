INCLUDE Globals.ink


 At last... someone who might understand the magnitude of my ambitions.
 
+ [Are you a villain?]
~dateCScore++
#sittingLaugh
-- HAHAHA - no. Of course not.
#sittingTalking
-- But if I were, you would already be too late to stop me.
->Round2

+ [Hey.]
~dateCScore--
#sittingDisbelief
-- ..."Hey"?
-- You respond to destiny with "hey"?
->Round2

==Round2
+ [What are you planning?]
~dateCScore++
#sittingTalking
-- Phase one is already complete. Phase two begins soon.
-- You’re sitting at the center of it.
->Round3

+ [Nice weather.]
~dateCScore--
#sittingDisbelief
-- Weather is irrelevant to power!
->Round3

==Round3
+ [Should I be worried?]
~dateCScore--
#sittingLaugh
-- Worried? No. Honored.
->Proceed

+ [Can I join?]
~dateCScore++
#sittingFistPump
-- YES! A recruit who understands greatness!
->Proceed

==Proceed
#sittingTalking
-- Soon. Soon you will learn of my machinations.
-- Until then... Anticipate me!
-- Debug! Score is {dateCScore}!
#goToDateD
->END