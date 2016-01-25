This is Max! A bot for fetching bus schedules and mess menu of IIT Jodhpur!

Requirements:

Microsoft Visual Studio 2015

Windows 10(tested it on windows enterprise)

Setup:

Download two folders. One MaxBot and the other named SharedContent(available on my bitbucket account https://bitbucket.org/gargrishabh/sharedcontent/)
1-Go to Visual Studio Diectory (C:\Users\rishabh\Documents\Visual Studio 2015)

2-Copy the folder MaxBot to the Projects folder

3-Replace the SharedContent folder with the downloaded folder

4-Open SpeechToText solution file(C:\Users\rishabh\Documents\Visual Studio 2015\Projects\MaxBot\cs\SpeechToText)

5-Build teh project

Congrats!Your bot Max is ready. The fun begins now! 

After buiding,open Cortana. You can give the following commands! (Available in VoiceCommands.xaml)

[please] show [me] [the] bus time table 

[please] show [me] bus schedule

[please] show [me] [the] {time} bus 

[please] show [me] [the] {time} bus from {source}

[please] show [me] bus 

[please] fetch [me] [the] timetable 

[please] fetch [me] timetable 

[please] get [me] [the] next bus

{time} bus [please] 

bus time table [for] {relativeDay}

show [me] bus time table from 

show [me] [the] bus [time] [table] from {source}   

[please] show [me] [the] bus time table to {destination}

[please] show [me] [the] bus from {source}

[please] show [me] [the] bus [time] [table] from {destination} to {source} 

    
For checking out what's in the menu!

what's [in] [the] menu

what's in [the] menu {relativeDay}

what's in [the] menu in {interval} on {day}

what's in [the] {interval}

what's in [the] menu on {day}

[please] show [me] [the] mess menu

[please] show [me] [the] {interval}

[please] fetch [me] mess menu

[please] fetch [me] mess menu for {day}

* the words in [] are optional to say.

*the definition for words in {} is mentioned in PhraseLists in VoiceCommand.xaml file

Awesome! Isn't it!

And yes dont forget to wake Max before each command! Max is too lazy so do call out Max before each command!

If you face any problems do reach out to Anmol Priyanka Ankita or me! 
