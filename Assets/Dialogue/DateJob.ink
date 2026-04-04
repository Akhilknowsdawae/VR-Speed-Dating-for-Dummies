INCLUDE Globals.ink


Thank you for taking the time to meet with me today. I believe I’d be an excellent fit for this... position.

+ [This isn’t a job interview...]
#sittingDisbelief
-- ...I’m sorry, this isn’t an interview?
#sittingTalking
-- Then why is there a table, structured seating, and emotional stakes?
~dateAScore -=1

-> Round2

+ [Go on.]
#sittingFistpump
-- Fantastic. I appreciate the opportunity.
#SittingTalking
-- I would describe myself as highly motivated and results-driven in interpersonal environments.
~dateAScore +=1
-> Round2

== Round2

+ [What are your strengths?]
#sittingTalking
--  I maintain strong eye contact, I listen actively, and I can sustain conversations for extended periods without noticeable discomfort.
~dateAScore +=1
->Round3

+ [What are your weaknesses?]
#sittingDisbelief
-- I... occasionally overanalyze emotional responses.
#sittingTalking
-- Also, I prepared a spreadsheet for this interaction.
~dateAScore-=1
->Round3

==Round3
+ [Why should I pick you?]
#sittingFistpump
-- Because I will exceed expectations and deliver consistent emotional performance.
~dateAScore +=1
->Proceed

+ [Do you even like me?]
#sittingDisbelief
-- ...I had not factored personal affection into the evaluation criteria.
#sittingTalking
-- But I am open to adjusting my approach.

-> Proceed


==Proceed
#sittingTalking
-- Thank you for taking the time to meet with me today.
-- I hope your other meetings are as informative as this one.
-- Debug! Score is {dateAScore}!
#goToDateB
->END