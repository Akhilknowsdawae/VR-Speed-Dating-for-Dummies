INCLUDE Globals.ink

#sittingTalking
So... just making conversation here... you haven’t happened to see any suspicious individuals?
Maybe tall, dramatic... possibly evil?
+ [Nope.]
~dateBScore++
#sittingTalking
-- Good. That’s good. Because I am definitely not conducting any sort of investigation.
-- Just a regular civilian enjoying beverages.
->Round2

+ [Why are you asking?]
~dateBScore--
#sittingDisbelief
-- Why? I- what? No reason.
#sittingTalking
-- Curiosity is a normal human trait.
->Round2

==Round2
+ [You’re a cop.]
~dateBScore--
#sittingLaughing
-- Haha! No badge, no paperwork, no authority whatsoever.
#sittingTalking
-- Unless... hypothetically. You've seen anyone suspicious here?
-> Round3

+ [I might’ve seen someone...]
~dateBScore++
#sittingTalking
--  Describe them. Slowly. With detail.
-> Round3

==Round3
+ [Dramatic. Evil laugh.]
~dateBScore++
#sittingFistpump
-- That’s EXACTLY who I’m-  I mean... who I’ve heard about.
-> Proceed

+ [Never mind.]
~dateBScore--
#sittingDisbelief
-- You’re withholding information. That’s... suspicious.
-> Proceed

==Proceed
#sittingTalking
-- Thank you, civ- er, friend. Run along now.
-- Debug! Score is {dateBScore}!
#goToDateC
->END