tokipona.parser
===============

A Toki Pona Parser
This is a library for parsing toki pona, an artificial language where most lexical categories are closed. 
There are about 125 unbound morphemes (words). The syntax is also limited to a single sentence template, 
which formally can be represented in about a dozen rules. It small, toy-like size makes it suitable for 
linguistic experiments.

Using
=====
Here is the working app:

http://tokipona.net/parser/

Currently illustrates:
    
* Normalizing. (Removing some irregularities from the text)
* Parsing to C# datastructures (See Serializations)
* Diagramming/Bracketing
* Colorizing
* Glossing, with & without POS

###Contributing

###If you don't write code
- [ ] Write toki pona and create issues for text that should parse but fails to parse
- [ ] Write issues for breaks in the various features of the demo site.

Here is the issue tracker:
https://github.com/matthewdeanmartin/tokipona.parser/issues

###Suggestions on getting started:
You can contribute with VS2010, VS2013, VS2013 Community (free and allows plugins) or SharpDev.

- [ ] Read unit tests *inside* BasicTypes. They are all well behaved (ie. safe to run over and over)
- [ ] The DemoSite is the entry point for the UI.

###To Write Your Own Apps
- [ ] To use in your own application, use the BasicTypes dll.
- [ ] SOON. If you don't write C#, soon I will support a REST+XML+JSON API. Any day now.


