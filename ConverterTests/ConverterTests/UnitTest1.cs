using NUnit.Framework;
using System;

[TestFixture]
public class ConverterTests
{
    [Test]
    public void Do_WhenFractionalPartIs0_Returns1000()
    {
        // Arrange
        float input = 42.0f;

        // Act
        int result = Converter.Do(input);

        // Assert
        Assert.AreEqual(1000, result);
    }

    [Test]
    public void Do_WhenFractionalPartIs0_WithNegativeNumber_Returns1000()
    {
        // Arrange
        float input = -94.0f;

        // Act
        int result = Converter.Do(input);

        // Assert
        Assert.AreEqual(1000, result);
    }

    [TestCase(1.1f, 1)]
    [TestCase(2.2f, 2)]
    [TestCase(3.3f, 3)]
    [TestCase(4.4f, 4)]
    [TestCase(-5.1f, -5)]
    [TestCase(-6.2f, -6)]
    [TestCase(-7.3f, -7)]
    [TestCase(-8.4f, -8)]
    public void Do_WhenFractionalPartIs1To4_ReturnsIntegerPart(float input, int expected)
    {
        // Act
        int result = Converter.Do(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Do_WhenFractionalPartIs5_ThrowsArgumentException()
    {
        // Arrange
        float input = 10.5f;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Converter.Do(input));
    }

    [Test]
    public void Do_WhenFractionalPartIs5_WithNegativeNumber_ThrowsArgumentException()
    {
        // Arrange
        float input = -20.5f;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Converter.Do(input));
    }

    [TestCase(6.6f, 1)]      // 6 - 5 = 1
    [TestCase(7.7f, 2)]      // 7 - 5 = 2
    [TestCase(8.8f, 3)]      // 8 - 5 = 3
    [TestCase(15.6f, 10)]    // 15 - 5 = 10
    [TestCase(-3.6f, -8)]    // -3 - 5 = -8
    [TestCase(-4.7f, -9)]    // -4 - 5 = -9
    [TestCase(-5.8f, -10)]   // -5 - 5 = -10
    public void Do_WhenFractionalPartIs6To8_ReturnsIntegerPartMinus5(float input, int expected)
    {
        // Act
        int result = Converter.Do(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestCase(9.9f, -2000)]
    [TestCase(3.9f, -2000)]
    [TestCase(-7.9f, -2000)]
    [TestCase(100.9f, -2000)]
    public void Do_WhenFractionalPartIs9_ReturnsMinus2000(float input, int expected)
    {
        // Act
        int result = Converter.Do(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Do_WhenInputHasWrongPrecision_ThrowsArgumentException()
    {
        // Arrange
        float input = 10.55f; // 2 знака после зап€той

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Converter.Do(input));
    }

    [Test]
    public void Do_WhenInputIsIntegerButRepresentedAsFloat_Returns1000()
    {
        // Arrange
        float input = 42.0f;

        // Act
        int result = Converter.Do(input);

        // Assert
        Assert.AreEqual(1000, result);
    }

    [Test]
    public void Do_WithBoundaryValues_WorksCorrectly()
    {
        // ѕроверка граничных значений
        Assert.AreEqual(1000, Converter.Do(0.0f));
        Assert.AreEqual(0, Converter.Do(0.1f));
        Assert.Throws<ArgumentException>(() => Converter.Do(0.5f));
        Assert.AreEqual(-5, Converter.Do(0.6f));
        Assert.AreEqual(-2000, Converter.Do(0.9f));

        Assert.AreEqual(1000, Converter.Do(-0.0f));
        Assert.AreEqual(0, Converter.Do(-0.1f));
        Assert.Throws<ArgumentException>(() => Converter.Do(-0.5f));
        Assert.AreEqual(-5, Converter.Do(-0.6f));
        Assert.AreEqual(-2000, Converter.Do(-0.9f));
    }
}