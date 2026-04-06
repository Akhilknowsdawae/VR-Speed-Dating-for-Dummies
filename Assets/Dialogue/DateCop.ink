INCLUDE Globals.ink

#anim1
So... just making conversation here... you haven’t happened to see any suspicious individuals?
Maybe tall, dramatic... possibly evil?
+ [Nope.]
~dateBScore++
#anim1
-- Good. That’s good. Because I am definitely not conducting any sort of investigation.
-- Just a regular civilian enjoying beverages.
->Round2

+ [Why are you asking?]
~dateBScore--
#anim2
-- Why? I- what? No reason.
#anim1
-- Curiosity is a normal human trait.
->Round2

==Round2
+ [You’re a cop.]
~dateBScore--
#anim3
-- Haha! No badge, no paperwork, no authority whatsoever.
#anim1
-- Unless... hypothetically. You've seen anyone suspicious here?
-> Round3

+ [I might’ve seen someone...]
~dateBScore++
#anim1
--  Describe them. Slowly. With detail.
-> Round3

==Round3
+ [Dramatic. Evil laugh.]
~dateBScore++
#anim4
-- That’s EXACTLY who I’m-  I mean... who I’ve heard about.
-> Proceed

+ [Never mind.]
~dateBScore--
#anim2
-- You’re withholding information. That’s... suspicious.
-> Proceed

==Proceed
#anim1
-- Thank you, civ- er, friend. Run along now.
#goToDateC
->END