# Question 3

## Architecture

First, The logic is dived in classes following the *Single Responsibility Principle*. The responsibility of get a random card is assume by Deck, and the responsibility of compare is provided by a ICompare<> implementation. 

Second, the class **Game** is created following the *Dependency Inversion Principle*. Game class doesn't depend on the ICompare<> implementation. If a low card game must be implemented, only the implementation of ICompare must be changed.

Finally, A factory class is created to provide the different kind of games that are required. 

Note: the logic of generate a random int number is separated. Generate a random number is a complicate problem in programing, normally the random generator, like *System.Random* class in C#, are pseudo random. Therefore, it is separated to can be improve in the future.

## Advantages

- Classes can be used in other projects.For example, **Deck** could be used in a poker game.
- Classes can be tested separately. For example, **Deck** and **ICompare<>** can be tested alone. In addition, **Game** can be tested using a fake **IDeck** that provide specific cards that allow check all requirements. 




