using System;

public class Converter
{
    public static int Do(float x)
    {
        // Проверяем, что число имеет ровно 1 знак после запятой
        float fractionalPart = Math.Abs(x - Math.Truncate(x));
        bool hasOneDecimal = Math.Abs(fractionalPart * 10 - Math.Round(fractionalPart * 10, 2)) < 0.0001f;

        if (!hasOneDecimal)
        {
            throw new ArgumentException("Число должно иметь точность 1 знак после запятой");
        }

        // Получаем последнюю цифру дробной части
        int lastDigit = (int)(Math.Abs(x - Math.Truncate(x)) * 10);

        switch (lastDigit)
        {
            case 0:
                return 1000;

            case 1:
            case 2:
            case 3:
            case 4:
                return (int)Math.Truncate(x);

            case 5:
                throw new ArgumentException();

            case 6:
            case 7:
            case 8:
                return (int)Math.Truncate(x) - 5;

            case 9:
                return -2000;

            default:
                throw new ArgumentException("Некорректное значение дробной части");
        }
    }
}