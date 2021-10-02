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
Many, many summers ago (around 2005/06 ?) I was quite a bit into playing poker. One day I 
stumbled upon a great read: [implementation of a poker engine](https://www.codeproject.com/Articles/12279/Fast-Texas-Holdem-Hand-Evaluation-and-Analysis). 
This was written in C#, so I started playing around with it, and before I knew it, 
I was porting it to Java. After a while I totally forgot about 
this project. Several years later I found it on one of my dusty hard drives, and out 
of the pure nostalgia for the memories of that ill period of time, decided to revive 
it. I Mavenized it, cleaned up few issues and uploaded to github. Maybe will get back 
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
