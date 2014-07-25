Optional
========

An implementation of the Optional pattern (also called Maybe, May, Option or a bunch of other things) in C#

Patterned mostly after the [Java 8 Optional](http://docs.oracle.com/javase/8/docs/api/java/util/Optional.html)

Use
===

```csharp

var a = Optional.Of(10);
var b = Optional.Absent;

a.IsPresent;                        // true
b.IsPresent;                        // false

var c = a.Map( i => i * 2 );        // c == Optional.Of(20)
var d = b.Map( (int i) => i * 2) ;  // d == Optional.Absent (Optional.AbsentOf<int>)

var e = c.FlatMap( i => Optional.Of( String.Format("It is {0}", i) );
                                    // e = Optional.Of("It is 20")

var f = a.Match(
    i => "Woot!",
    () => "Aww"
);                                  // f == "Woot!"

var g = b.Match(
    i => "Woot!",
    () => "Aww"
);                                  // g == "Aww"

```

And have a look at the tests for more examples of what you can do, including
mapping over collections.

Notes
=====

There's some distinction between typed and untyped Optionals and, particularly,
`Absent`s. I tried to make `Absent`s as type-agnostic as possible, but
there are cases where an `Absent` does need a type (particularly around mapping
and flat mapping, as they require source and destination types). All `Absent`s,
whether typed or untyped, are considered the same for `Equals`, and there is an
implicit conversion from `Absent` to `Absent<T>`, normally triggered by
specifying a type in a lambda (again, see the mapping tests for an example).
