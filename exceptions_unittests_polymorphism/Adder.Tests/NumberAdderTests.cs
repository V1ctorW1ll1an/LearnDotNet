namespace Adder.Tests;

public class NumberAdderTests
{
    [Fact]
    public void Add_WhenCalledWithValidInput_ShouldAddToSum()
    {
        // arrange
        var numberAdder = new NumberAdder();

        // act
        var result = numberAdder.Add(5);

        // assert
        Assert.Equal(5, result);
    }

    [Fact]
    public void Add_SumIsInitiallyZero()
    {
        // arrange, act
        var numberAdder = new NumberAdder();

        // assert
        Assert.Equal(0, numberAdder.Sum);
    }

    [Fact]
    public void Add_ThrowsOverflowException_WhenSumExceedsMaxValue()
    {
        // arrange 
        var numberAdder = new NumberAdder();

        // act
        numberAdder.Add(int.MaxValue);

        // assert
        Assert.Throws<OverflowException>(() => numberAdder.Add(1));
    }
}