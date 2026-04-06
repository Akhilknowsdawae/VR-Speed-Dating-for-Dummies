INCLUDE Globals.ink


Thank you for taking the time to meet with me today. I believe I’d be an excellent fit for this... position.

+ [This isn’t a job interview...]
#anim2
-- ...I’m sorry, this isn’t an interview?
#anim1
-- Then why is there a table, structured seating, and emotional stakes?
~dateJobScore -=1

-> Round2

+ [Go on.]
#anim4
-- Fantastic. I appreciate the opportunity.
#anim1
-- I would describe myself as highly motivated and results-driven in interpersonal environments.
~dateJobScore +=1
-> Round2

== Round2

+ [What are your strengths?]
#anim1
--  I maintain strong eye contact, I listen actively, and I can sustain conversations for extended periods without noticeable discomfort.
~dateJobScore +=1
->Round3

+ [What are your weaknesses?]
#anim2
-- I... occasionally overanalyze emotional responses.
#anim1
-- Also, I prepared a spreadsheet for this interaction.
~dateJobScore-=1
->Round3

==Round3
+ [Why should I pick you?]
#anim4
-- Because I will exceed expectations and deliver consistent emotional performance.
~dateJobScore +=1
->Proceed

+ [Do you even like me?]
#anim2
-- ...I had not factored personal affection into the evaluation criteria.
-- But I am open to adjusting my approach.

-> Proceed


==Proceed
#anim1
-- Thank you for taking the time to meet with me today.
-- I hope your other meetings are as informative as this one.
#goToDateVillain
->END