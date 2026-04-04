INCLUDE Globals.ink

{hostIntroComplete: ->Ending | ->Intro}

==Intro
Welcome to our cafe's new Speed-Dating Event!
Today you will get to meet four lovely eligible dates.
Aren't you excited?

+ [Yeah!!]
-- Happy to hear it!
-> Proceed

+ [Totally...]
-- I'm sure you'll find someone who appreciates that dour temperament!
-> Proceed

== Proceed
Now, grab a coffee, be charming, and have fun!
~hostIntroComplete = true
#goToDateA
->DONE

==Ending
So, how do you feel? Giddy? Smitten, even?

+ [None of them were particularly interesting.]
-- Well, that sucks! Too bad you're contractually obligated to pick someone!
-> Rose

+ [I think I've found "The One"...]
-- Aww geez, I'm blushing at the thought! I'm happy to hear that!
-> Rose

==Rose
#rose
-- Now, take this rose, and go tell your beloved your feelings!
-- I'm rooting for ya, champ!
#closeHostDialogue
->DONE