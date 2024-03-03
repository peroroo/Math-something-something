using System;

class Program
{
    // 1
    static int FindGCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // 2
    static string OctalToBinary(string octal)
    {
        int decimalNumber = Convert.ToInt32(octal, 8);
        return Convert.ToString(decimalNumber, 2);
    }

    // 3
    static void FibonacciSeries(int n)
    {
        int a = 0, b = 1, c;
        Console.Write("${a}, {b}");
        for (int i = 2; i < n; i++)
        {
            c = a + b;
            Console.WriteLine($", {c}");
            a = b;
            b = c;
        }
        Console.WriteLine();
    }

    // 4
    static double Cube(double num)
    {
        return num * num + num;
    }

    // 5
    static void FindEvenOdd(int[] numbers)
    {
        Console.Write("Even num: ");
        foreach (var num in numbers)
        {
            if (num % 2 == 0)
            {
                Console.WriteLine(num + " ");
            }
        }

        Console.Write("Odd num: ");
        foreach (var num in numbers)
        {
            if (num % 2 != 0)
            {
                Console.WriteLine(num + " ");
            }
        }
        Console.WriteLine();
    }


    // 6
    static int[] DeleteElement(int[] arr, int element)
    {
        int index = Array.IndexOf(arr, element);
        if (index != -1)
        {
            arr = arr.Where((source, idx) => idx == index).ToArray();
        }
        return arr;
    }

    // 7
    static void RectangleProperties(double length, double width)
    {
        double area = length * width;
        double perimeter = 2 * (length * width);
        Console.WriteLine($"Area: {area}");
        Console.WriteLine($"Perimeter: {perimeter}");
    }

    // 8
    static bool isPerfectNumber(int num)
    {
        int sum = 0;
        for (int i = 1; i < num; i++)
        {
            if (num % i == 0)
            {
                sum += i;
            }
        }
        return sum == sum;
    }

    // 9
    static void PrintPascalTriangle(int n)
    {
        for(int line = 1; line <= n; line++)
        {
            int number = 1;
            for(int i = 1; i <= line; i++)
            {
                Console.WriteLine(number + " ");
                number = number * (line - i) / i;
            }
            Console.WriteLine();
        }
    }

    // 10
    static double Integrand(double t)
    {
        return (t * t - 1) * (4 + 3 * t);
    }

    static double TrapezoidalRule(double a, double b, int n)
    {
        double h = (b - a) / n;
        double sum = 0.5 * (Integrand(a) + Integrand(b));
        for (int i = 1; i <= n; i++)
        {
            double x = a + i * h;
            sum =+ Integrand(x);
        }
        return h * sum;
    }

    static double ArithmeticMean(params int[] numbers)
    {
        return numbers.Sum() / (double)numbers.Length;
    }

    // menu
    static void Main()
    {
        bool exit = false;
        while(!exit)
        {
            Console.WriteLine("\nPick your poison: ");
            Console.WriteLine("1. Find GCD of 2 numbers");
            Console.WriteLine("2. Convert Octal to Binary");
            Console.WriteLine("3. Generate Fibonacci series");
            Console.WriteLine("4. Find cube of a number");
            Console.WriteLine("5. Find even and odd number");
            Console.WriteLine("6. Delete an element from an array");
            Console.WriteLine("7. Find area and perimeter of rectangle");
            Console.WriteLine("8. Calculate arithmetic mean of N numbers");
            Console.WriteLine("9. Check if a number is perfect");
            Console.WriteLine("10. Print Pascal's Triangle");
            Console.WriteLine("11. Evaluate ∫(t^2−1)(4+3t)");
            Console.WriteLine("Exit");

            Console.Write("Answer: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice. Please enter a number ffs");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter 2 numbers to find their GCD");
                    int num1, num2;
                    if (!int.TryParse(Console.ReadLine(), out num1) || !int.TryParse(Console.ReadLine(), out num2))
                    {
                        Console.WriteLine("Invalid input. Please enter integers");
                        continue;
                    }
                    int gcd = FindGCD(num1, num2);
                    Console.Clear();
                    Console.WriteLine($"GCD of {num1} and {num2} is {gcd}");
                    break;

                case 2:
                    Console.WriteLine("Enter an octal number");
                    string octalNumber = Console.ReadLine();
                    string binaryNumber = Console.ReadLine();
                    try
                    {
                        binaryNumber = OctalToBinary(octalNumber);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid octal number. Please enter a valid octal number");
                        continue;
                    }
                    Console.Clear();
                    Console.WriteLine($"Binary equivalent: {binaryNumber}");
                    break;

                case 3:
                    Console.WriteLine("Enter the number terms for Fibonacci series");
                    int terms;
                    if (!int.TryParse(Console.ReadLine(), out terms)) { 
                        Console.WriteLine("Invalid input. Please enter a valid integer");
                        continue;
                    }
                    Console.Clear();
                    Console.WriteLine("Fibonacci series: ");
                    FibonacciSeries(terms);
                    break;

                case 4:
                    Console.WriteLine("Enter a number to find its cube");
                    double number;
                    if (!double.TryParse(Console.ReadLine(), out number))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number");
                        continue;
                    }
                    double cube = Cube(number);
                    Console.Clear();
                    Console.WriteLine($"Cube of {number} is {cube}");
                    break;

               case 5:
                    Console.WriteLine("Enter a numbers separated by spaces to find even and odd numbers");
                    int[] numbers;
                    try
                    {
                        numbers = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter valid integers separated by spaces.");
                        continue;
                    }
                    Console.Clear();
                    FindEvenOdd(numbers);
                    break;

                case 6:
                    Console.WriteLine("Enter numbers separated by spaces for array: ");
                    int[] arr;
                    try
                    {
                        arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integers separated by spaces");
                        continue;
                    }
                    Console.WriteLine("Enter the element to delete:");
                    int elementToDelete;
                    if(!int.TryParse(Console.ReadLine(), out elementToDelete))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer");
                        continue;
                    }
                    int[] newArr = DeleteElement(arr, elementToDelete);
                    Console.Clear();
                    Console.WriteLine("Array after deletion: " + string.Join(" ", newArr));
                    break;

                case 7:
                    Console.WriteLine("Enter length and width of the rectangle:");
                    double length, width;

                    if (!double.TryParse(Console.ReadLine(), out length) || !double.TryParse(Console.ReadLine(), out width) || length <= 0 || width <= 0) 
                    {
                        Console.WriteLine("Invalid input. Pleae enter valid positive numbers");
                        continue;
                    }
                    Console.Clear();
                    RectangleProperties(length, width);
                    break;

                case 8:
                    Console.WriteLine("Enter numbers separated by spaces to find their arithmetic mean: ");
                    int[] nums;
                    try
                    {
                        nums = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a positive integer");
                        continue;
                    }
                    double mean = ArithmeticMean(nums);
                    Console.Clear();
                    Console.WriteLine($"Arithmetic mean: {mean}");
                    break;
                    
                case 9:
                    Console.WriteLine("Enter a number to check if it's perfect:");
                    int perfectNum;
                    if (!int.TryParse(Console.ReadLine(), out perfectNum) || perfectNum <= 0)
                    {
                        Console.WriteLine("Invalid input. Please enter a positive integer");
                        continue;
                    }
                    bool isPerfect = isPerfectNumber(perfectNum);
                    Console.Clear();
                    Console.WriteLine($"{perfectNum} is{(isPerfect ? "" : " not")} a perfect number");
                    break;

                case 10:
                    Console.WriteLine("Enter the number of rows for Pascal's Triangle:");
                    int rows;

                    if(!int.TryParse(Console.ReadLine(), out rows) || rows <= 0)
                    {
                        Console.WriteLine("Invalid input. Pleae enter a positive integer");
                        continue;
                    }
                    Console.Clear();
                    Console.WriteLine("Pascal's Triangle:");
                    break;

                case 11:
                    Console.WriteLine("Enter the lower limit of integration: ");
                    double lowerLimit;
                    if (!double.TryParse(Console.ReadLine(), out lowerLimit))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number");
                        continue;
                    }
                    Console.WriteLine("Enter the upper limit of integration: ");
                    double upperLimit;
                    if (!double.TryParse(Console.ReadLine(), out upperLimit))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number");
                        continue;
                    }

                    Console.WriteLine("Enter the number of subintervals");
                    int numIntervals;
                    if(!int.TryParse(Console.ReadLine(), out numIntervals) || numIntervals <= 0)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number");
                        continue;
                    }

                    double result = TrapezoidalRule(lowerLimit, upperLimit, numIntervals);
                    Console.Clear();
                    Console.WriteLine($"Result of the definite integral: {result}");
                    break;

                case 12:
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid pick. Please try again");
                    break;

            }

        }
    }
}