# karty - a poker rule engine
---------------------
A library capable of analyzing and evaluating poker hand strengts. 
Can be used to build digital poker rooms, bots, and simulated poker 
tournaments.
```
mvn clean test
```

# Origins
---------------------
Many, many summers ago (around 2005/06 ?) I was ill for an extended 
period of time, bound to bed, with not much to do. It was during 
that time that I found a simple implementation of a poker engine 
in C#, which inspired me to play around with the concept of poker AI 
in Java. So I ported some of that C# code, and improved it to make it somewhat 
usable. After recovering, I totally forgot about this project. Several 
years later I found it on one of my dusty hard drives, and out of the pure 
nostalgia for the memories of that sick period decided to revive it. 
I Mavenized it, cleaned up few issues and uploaded to github. Maybe will get back 
to it after all these years and expand it.

# Dislaimer
---------------------
In its current form, the code is not what typical Java project looks like. Mind you, 
most of it had been ported from original C# version and the design fundamentals 
remained the same; that is, hand iterations, rather than being computed on the fly 
are pre-defined in static tables up front (in the form of large arrays) and evaluated 
off those structures which greatly improves performance. If I remember correctly the 
algorithms do generate correct outputs.

In any case, for me this one is full of nostalic memories and an interesting peek 
into my past :-)
