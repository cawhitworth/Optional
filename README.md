Optional
========

An implementation of the Optional pattern (also called Maybe, May, Option or a bunch of other things) in C#

Patterned mostly after the [Java 8 Optional](http://docs.oracle.com/javase/8/docs/api/java/util/Optional.html)

Use
===

```csharp

var a = Optional.Of(10);
var b = Optional.Absent;

Console.WriteLine(a.IsPresent); // true
Console.WriteLine(b.IsPresent); // false

var c = a.Map( i => i * 2 );        // c = Optional.Of(20)
var d = b.Map( (int i) => i * 2) ;  // d = Optional.Absent

var e = c.FlatMap( i => Optional.Of( String.Format("It is {0}", i) );
                                    // e = Optional.Of("It is 20")

```
