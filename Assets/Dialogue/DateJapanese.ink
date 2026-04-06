INCLUDE Globals.ink


はじめまして！今日はいい天気ですね。

+ [こんにちは！]
~dateJapaneseScore++
#anim1
-- おお！日本語が話せるんですね！
->Round2

+ [I don’t understand...]
~dateJapaneseScore--
#anim1
-- えっ？
->Round2

==Round2
+ [*Gesture politely*]
~dateJapaneseScore++
#anim3
-- いいですね！楽しい！
->Round3

+ [Uh, English?]
#anim1
~dateJapaneseScore--
-- ...Hello. Coffee good?
->Round3


==Round3
+ [*Smile and nod*]
~dateJapaneseScore++
#anim3
--楽しかったです！
->Proceed

+ [*Panic*]
~dateJapaneseScore--
#anim2
--大丈夫ですか？！
->Proceed


==Proceed
#anim1
ジャー、また！
#goToHost
->END