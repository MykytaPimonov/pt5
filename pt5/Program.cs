int[] numbers = new int[10];
Random random = new Random();

for (int i = 0; i < numbers.Length; i++)
{
    numbers[i] = random.Next(1, 25);
}

foreach (var number in numbers)
{
    Console.Write(number + " ");
}
Console.WriteLine();

Task<int> task0 = Task.Run(() =>
{
    double average = numbers.Average();
    int product = 1;
    foreach (int num in numbers)
    {
        if (num < average)
        {
            product *= num;
        }
    }
    return product;
});

Task<int> task1 = Task.Run(() =>
{
    int sum = 0;
    foreach (int num in numbers)
    {
        if (num % 2 == 0)
        {
            sum += num;
        }
    }
    return sum;
});

Task.WhenAll(task0, task1).ContinueWith(_ =>
{
    Console.WriteLine($"Добуток чисел менших за середнє арифметичне: {task0.Result}");
    Console.WriteLine($"Сума парних елементів: {task1.Result}");
}).Wait();