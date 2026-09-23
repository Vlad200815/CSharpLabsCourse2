

int variant = 7;
int n = 19;
int minValue = -35;
int maxValue = 15;
int p = -10;


string divider = "-------------------------------------------";

int[] numbers = new int[n];
var random = new Random(variant);
int sum = 0;


Console.WriteLine(divider);
for (int i = 0; i < numbers.Length; i++)
{ 
    // Нижня межа включається, верхня межа методу Next — ні.
    // Тому додаємо 1, щоб значення maxValue також могло з’явитися.
    numbers[i] = random.Next(minValue, maxValue + 1);
    Console.WriteLine($"index: {i}.\t number: {numbers[i]}");
    
    
}
Console.WriteLine(divider);



int min = numbers[0];
int max = numbers[0];
int minIndex = 0;
int maxIndex = 0;

Console.WriteLine($"Numbers: {string.Join(", ", numbers)}");


for (int i = 1; i < numbers.Length; i++)
{   
    sum += numbers[i];
    if (numbers[i] < min)
    {   
        min = numbers[i];
        minIndex = i;
    }
    if (numbers[i] > max)
    {
        max = numbers[i];
        maxIndex = i;
    }
}

var avrage = sum / n;
Console.WriteLine($"average: {avrage}");
Console.WriteLine($"Min index: {minIndex}, Min value: {min}");
Console.WriteLine($"Min index: {maxIndex}, Min value: {max}");

Console.WriteLine(divider);

// numbers = [0, 0, 0];

int selectedCount = 0;
int selectedSum = 0;
foreach (int number in numbers)
{
    if (number < p)
    {
        selectedCount++;
        selectedSum += number;

    }
}


if (selectedCount == 0)
{
    Console.WriteLine("Nothing was selected!");
}
else
{
    int selectedAvrage = selectedSum / selectedCount;
    Console.WriteLine($"selectedCount: {selectedCount}, selectedSum: {selectedSum}");
    Console.WriteLine($"Selected average: {selectedAvrage}");
}
Console.WriteLine(divider);

numbers.Sort();
Console.WriteLine($"Sorted list: [{string.Join(", ", numbers)}]");



Console.WriteLine(divider);



var matrix = new int[3, 4]; // 3 рядки та 4 стовпці
List<int> rowSums = [];

for (var row = 0; row < matrix.GetLength(0); row++)
{
    var rowSum = 0;
    Console.Write("| ");
    for (var column = 0; column < matrix.GetLength(1); column++)
    {  
        
        var randomNum = random.Next(minValue, maxValue + 1);
        rowSum = rowSum + randomNum;
        
        matrix[row, column] = randomNum;
        Console.Write($"{matrix[row, column],5} |");
        
    }
    rowSums.Add(rowSum);
    Console.Write($" | Sum: {rowSum}");
    Console.WriteLine(); // наступний рядок матриці
}

Console.WriteLine(divider);

int maxRowSum = rowSums[0];
int maxRowIndex = 0;


Console.WriteLine(string.Join(", ", rowSums));

for (int i = 1; i < rowSums.Count; i++)
{
    if (rowSums[i] > maxRowSum)
    {
        maxRowSum = rowSums[i];
        maxRowIndex = i;
    }
}

Console.WriteLine($"Max row sum: {maxRowSum}, Max row: {maxRowIndex + 1}");
Console.WriteLine(divider);


// Editional exercise
Console.WriteLine(string.Join(", ", numbers));

Console.WriteLine(divider);

int half = numbers.Length / 2;
for (int i = 0; i < half; i++)
{  
    Console.WriteLine($"{numbers[i]} | {numbers[numbers.Length - 1 - i]}");
    (numbers[i], numbers[numbers.Length - 1 - i]) = (numbers[numbers.Length - 1 - i], numbers[i]);
    
}
Console.WriteLine(string.Join(", ", numbers));







