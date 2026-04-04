INCLUDE Globals.ink


はじめまして！今日はいい天気ですね。

+ [こんにちは！]
~dateDScore++
#sittingTalking
-- おお！日本語が話せるんですね！
->Round2

+ [I don’t understand...]
~dateDScore--
#sittingTalking
-- えっ？
->Round2

==Round2
+ [*Gesture politely*]
~dateDScore++
#sittingLaugh
-- いいですね！楽しい！
->Round3

+ [Uh, English?]
#sittingTalking
~dateDScore--
-- ...Hello. Coffee good?
->Round3


==Round3
+ [*Smile and nod*]
~dateDScore++
#sittingLaugh
--楽しかったです！
->Proceed

+ [*Panic*]
~dateDScore--
#sittingDisbelief
--大丈夫ですか？！
->Proceed


==Proceed
#sittingTalking
-- Debug! Score is {dateDScore}!
#goToHost
->END