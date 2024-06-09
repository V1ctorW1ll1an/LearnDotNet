namespace Adder.Tests;


public class NumberAdderConsoleTests
{
  [Fact]
  public void AddingValidNumbers_ShouldPrintSums()
  {
    // Arrange
    var nacm = new NumberAdderConsoleMock(["5", "6", "q"]);

    // Act 
    var result = nacm.AggregateEnteredNumbers();

    // Assert
    Assert.Equal(11, result);
    Assert.Equal([
      "Enter numbers, q to quit",
      "The current sum is 5",
      "The current sum is 11",
    ], nacm.Outputs);
  }



}