# Motorsport Manager DLL Tweaks (v1.53.16967)
___
## Better Forecast
* Shows current water/rubber percentage on track, giving you more control over the race
* Water/rubber level forecast is now also shown in percentages, allowing you to plan pitstop strategies with much bigger precision

## Perfect Practice Setup
* Automatically finds "purple" spots during practice sessions
* For those ~~lazy bastards~~, who find it tedious and repetetive to spam "Bring In" button and abuse this whole system

## Complete Challenges
* Automatically completes all challenges (career challenges are untouched) and unlocks all rewards
* Run the game once, and all progress will be saved in Steam Cloud (you can then swap back to original DLL)
___
## How to install
__!! Do not forget to BACKUP your `Assembly-CSharp.dll` in `Motorsport Manager\MM_Data\Managed` folder !!__
* For __Complete Challenges__: 
  1. Copy `Assembly-CSharp-challenges.dll` to `Motorsport Manager\MM_Data\Managed` folder
  2. Rename it to `Assembly-CSharp.dll`
  3. Launch the game once
  4. Go to Challenges tab and check if all challenges are completed
  5. Close the game
  6. Swap back `Assembly-CSharp.dll` with original file (I hope you made a backup :) If not, just validate your game in Steam)
* For __any other DLL__:
  1. Copy `Assembly-CSharp-{whatever_you_chose}.dll` to `Motorsport Manager\MM_Data\Managed` folder
  2. Rename it to `Assembly-CSharp.dll`
  3. Launch the game and have fun!
___
## Source Code
Source code is included in respective folders. I have commented original methods in case you want to see what exactly was changed

All DLLs are based off the latest version of Motorsport Manager (1.53.16967)

DLLs were decompiled, edited and recompiled with `dnSpy`
___
## Misc
If you want to upload these tweaks to somewhere else, please give me some credit :)

~~shameless plug~~ I also extracted and uploaded the soundtrack from Motorsport Manager, it's absolutely gorgeous! https://www.youtube.com/user/MattGroyning
___
## TODO:
* Make an additional version of Better Forecast, where percentages are only shown if player had built a Forecasting Centre