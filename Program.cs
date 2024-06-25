using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

public class ComplexArray
{
    private List<Complex> data;

    // Конструктор за замовчуванням
    public ComplexArray()
    {
        data = new List<Complex>();
    }

    // Конструктор з передачею масиву комплексних чисел
    public ComplexArray(IEnumerable<Complex> initialData)
    {
        data = new List<Complex>(initialData);
    }

    // Конструктор копіювання
    public ComplexArray(ComplexArray other)
    {
        data = new List<Complex>(other.data);
    }

    // Деструктор
    ~ComplexArray()
    {
        Console.WriteLine("ComplexArray object is being destroyed");
    }

    // Метод додавання елементів
    public void Add(Complex complexNumber)
    {
        data.Add(complexNumber);
    }

    // Метод для зміни елементу за індексом
    public void ModifyElement(int index, Complex newValue)
    {
        if (index >= 0 && index < data.Count)
        {
            data[index] = newValue;
        }
        else
        {
            throw new IndexOutOfRangeException("Index out of range");
        }
    }

    // Метод для виведення вмісту масиву
    public void Display()
    {
        foreach (var complex in data)
        {
            Console.WriteLine(complex);
        }
    }

    // Операції над масивами комплексних чисел
    public ComplexArray Add(ComplexArray other)
    {
        return new ComplexArray(data.Zip(other.data, (a, b) => a + b));
    }

    public ComplexArray Subtract(ComplexArray other)
    {
        return new ComplexArray(data.Zip(other.data, (a, b) => a - b));
    }

    public ComplexArray Multiply(ComplexArray other)
    {
        return new ComplexArray(data.Zip(other.data, (a, b) => a * b));
    }

    public ComplexArray Divide(ComplexArray other)
    {
        return new ComplexArray(data.Zip(other.data, (a, b) => a / b));
    }

    // Метод для обчислення модуля всіх елементів масиву
    public List<double> Moduli()
    {
        return data.Select(c => c.Magnitude).ToList();
    }

    // Метод для піднесення всіх елементів масиву до ступеня n
    public ComplexArray Pow(int n)
    {
        return new ComplexArray(data.Select(c => Complex.Pow(c, n)));
    }

    // Метод для обчислення модулів сум сусідніх елементів масиву
    public List<double> ComputeModuliOfSums()
    {
        List<double> result = new List<double>();
        for (int i = 0; i < data.Count - 1; i++)
        {
            var sumComplex = data[i] + data[i + 1];
            result.Add(sumComplex.Magnitude);
        }
        return result;
    }
}

public class Program
{
    public static void Main()
    {
        var complexNumbers = new List<Complex>
        {
            new Complex(1, 2),
            new Complex(2, 3),
            new Complex(3, 4),
            new Complex(4, 5)
        };

        ComplexArray complexArray = new ComplexArray(complexNumbers);

        Console.WriteLine("Original array:");
        complexArray.Display();

        List<double> moduliSums = complexArray.ComputeModuliOfSums();
        Console.WriteLine("Moduli of sums of adjacent elements:");
        foreach (var modulus in moduliSums)
        {
            Console.WriteLine(modulus);
        }

        // Демонстрація інших операцій
        var otherComplexNumbers = new List<Complex>
        {
            new Complex(1, 1),
            new Complex(1, 1),
            new Complex(1, 1),
            new Complex(1, 1)
        };

        ComplexArray otherArray = new ComplexArray(otherComplexNumbers);

        Console.WriteLine("Addition of arrays:");
        ComplexArray resultArray = complexArray.Add(otherArray);
        resultArray.Display();

        Console.WriteLine("Subtraction of arrays:");
        resultArray = complexArray.Subtract(otherArray);
        resultArray.Display();

        Console.WriteLine("Multiplication of arrays:");
        resultArray = complexArray.Multiply(otherArray);
        resultArray.Display();

        Console.WriteLine("Division of arrays:");
        resultArray = complexArray.Divide(otherArray);
        resultArray.Display();

        Console.WriteLine("Moduli of elements:");
        List<double> moduli = complexArray.Moduli();
        foreach (var modulus in moduli)
        {
            Console.WriteLine(modulus);
        }

        Console.WriteLine("Power of elements to 2:");
        ComplexArray poweredArray = complexArray.Pow(2);
        poweredArray.Display();
    }
}
