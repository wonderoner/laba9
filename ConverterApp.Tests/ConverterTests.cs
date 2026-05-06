using NUnit.Framework;
using System;

[TestFixture]
public class ConverterTests
{
    [Test]
    public void Do_FractionalPart0_Returns1000()
    {
        Assert.AreEqual(1000, Converter.Do(42.0f));
        Assert.AreEqual(1000, Converter.Do(-94.0f));
    }

    [TestCase(1.1f, 1)]
    [TestCase(2.2f, 2)]
    [TestCase(3.3f, 3)]
    [TestCase(4.4f, 4)]
    [TestCase(-5.1f, -5)]
    [TestCase(-6.2f, -6)]
    public void Do_FractionalPart1To4_ReturnsIntegerPart(float input, int expected)
    {
        Assert.AreEqual(expected, Converter.Do(input));
    }

    [Test]
    public void Do_FractionalPart5_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Converter.Do(10.5f));
        Assert.Throws<ArgumentException>(() => Converter.Do(-20.5f));
    }

    [TestCase(6.6f, 1)]
    [TestCase(7.7f, 2)]
    [TestCase(8.8f, 3)]
    [TestCase(-3.6f, -8)]
    [TestCase(-4.7f, -9)]
    public void Do_FractionalPart6To8_ReturnsIntegerPartMinus5(float input, int expected)
    {
        Assert.AreEqual(expected, Converter.Do(input));
    }

    [TestCase(9.9f, -2000)]
    [TestCase(3.9f, -2000)]
    [TestCase(-7.9f, -2000)]
    public void Do_FractionalPart9_ReturnsMinus2000(float input, int expected)
    {
        Assert.AreEqual(expected, Converter.Do(input));
    }
}