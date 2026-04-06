INCLUDE Globals.ink


はじめまして！今日はいい天気ですね。

+ [こんにちは！]
~dateDScore++
#anim1
-- おお！日本語が話せるんですね！
->Round2

+ [I don’t understand...]
~dateDScore--
#anim1
-- えっ？
->Round2

==Round2
+ [*Gesture politely*]
~dateDScore++
#anim3
-- いいですね！楽しい！
->Round3

+ [Uh, English?]
#anim1
~dateDScore--
-- ...Hello. Coffee good?
->Round3


==Round3
+ [*Smile and nod*]
~dateDScore++
#anim3
--楽しかったです！
->Proceed

+ [*Panic*]
~dateDScore--
#anim2
--大丈夫ですか？！
->Proceed


==Proceed
#anim1
ジャー、また！
#goToHost
->END