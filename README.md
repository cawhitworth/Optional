Optional
========

An implementation of the Optional pattern (also called Maybe, May, Option or a bunch of other things) in C#

Patterned mostly after the [Java 8 Optional](http://docs.oracle.com/javase/8/docs/api/java/util/Optional.html)

Use
===

```csharp

var concrete = Optional.Of(10);
var absent = Optional.Absent;

concrete.IsPresent;                      // true
absent.IsPresent;                        // false

var c = concrete.Map( i => i * 2 );      // c == Optional.Of(20)
var d = absent.Map( (int i) => i * 2) ;  // d == Optional.Absent (Optional.AbsentOf<int>)

var e = concrete.FlatMap( i => Optional.Of( String.Format("It is {0}", i) );
                                         // e = Optional.Of("It is 20")

var f = concrete.Match(
    i => "Woot!",
    () => "Aww"
);                                       // f == "Woot!"

var g = absent.Match(
    i => "Woot!",
    () => "Aww"
);                                       // g == "Aww"

```

And have a look at the tests for more examples of what you can do, including
mapping over collections.

Notes
=====

The base interface is IOptional, which simply requires an implementer to
indicate if it `IsPresent`. The basic `Absent` type implements this interface.

The more useful interface is `IOptional<T>`, which extends `IOptional` and adds
a `Value` property, and `Map`, `FlatMap`, and `Match` methods. `Absent<T>` and
`Concrete<T>` implement this.

The `Optional` class provides convience methods - `Of<T>` and `AbsentOf<T>` -
and a property `Absent`.

There is a distinction between a typed and untyped `Absent` - I would have
preferred for them to be completely untyped, but C#'s type system requires them
to have types in order for `Map` and `FlatMap` to work. There is an
implicit conversion available from `Absent` to `Absent<T>` - you can see how
this plays out in the Mapping tests. All `Absent`s, typed or untyped, are
considered equal.
