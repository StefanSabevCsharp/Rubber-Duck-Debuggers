int n = int.Parse(Console.ReadLine());

string[] moves = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
Queue<string> queue = new Queue<string>(moves);
char[,] matrix = new char[n, n];
int playerRow = 0;
int playerCol = 0;
int hazelnuts = 0;
for (int row = 0; row < n; row++)
{
    string input = Console.ReadLine();

    for (int col = 0; col < n; col++)
    {
        matrix[row, col] = input[col];

        if (matrix[row, col] == 's')
        {
            playerRow = row;
            playerCol = col;
        }

    }
}

while (queue.Count != 0)
{
    string currentMove = queue.Dequeue();

    if (currentMove == "left")
    {
        if (isValidPosition(matrix, playerRow, playerCol - 1))
        {
            if (matrix[playerRow, playerCol - 1] == 't')
            {
                Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                Console.WriteLine($"Hazelnuts collected: {hazelnuts}");
                Environment.Exit(0);
            }
            else if (matrix[playerRow, playerCol - 1] == 'h')
            {
                hazelnuts++;
                matrix[playerRow, playerCol] = '*';
                matrix[playerRow, playerCol - 1] = 's';
            }
            else if (matrix[playerRow, playerCol - 1] == '*')
            {
                matrix[playerRow, playerCol] = '*';
                matrix[playerRow, playerCol - 1] = 's';
            }
            playerCol--;


        }
        else
        {
            Console.WriteLine("The squirrel is out of the field.");
            Console.WriteLine($"Hazelnuts collected: {hazelnuts}");
            Environment.Exit(0);

        }
    }
    else if (currentMove == "right")
    {
        if (isValidPosition(matrix, playerRow, playerCol + 1))
        {
            if (matrix[playerRow, playerCol + 1] == 't')
            {
                Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                Console.WriteLine($"Hazelnuts collected: {hazelnuts}");
                Environment.Exit(0);
            }
            else if (matrix[playerRow, playerCol + 1] == 'h')
            {
                hazelnuts++;
                matrix[playerRow, playerCol] = '*';
                matrix[playerRow, playerCol + 1] = 's';
            }
            else if (matrix[playerRow, playerCol - 1] == '*')
            {
                matrix[playerRow, playerCol] = '*';
                matrix[playerRow, playerCol + 1] = 's';
            }
            playerCol++;

        }
        else
        {
            Console.WriteLine("The squirrel is out of the field.");
            Console.WriteLine($"Hazelnuts collected: {hazelnuts}");
            Environment.Exit(0);

        }
    }
    else if (currentMove == "up")
    {
        if (isValidPosition(matrix, playerRow - 1, playerCol))
        {
            if (matrix[playerRow - 1, playerCol] == 't')
            {
                Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                Console.WriteLine($"Hazelnuts collected: {hazelnuts}");
                Environment.Exit(0);
            }
            else if (matrix[playerRow - 1, playerCol] == 'h')
            {
                hazelnuts++;
                matrix[playerRow, playerCol] = '*';
                matrix[playerRow - 1, playerCol] = 's';
            }
            else if (matrix[playerRow, playerCol - 1] == '*')
            {
                matrix[playerRow, playerCol] = '*';
                matrix[playerRow - 1, playerCol] = 's';
            }
           
            playerRow--;
        }
        else
        {
            Console.WriteLine("The squirrel is out of the field.");
            Console.WriteLine($"Hazelnuts collected: {hazelnuts}");
            Environment.Exit(0);

        }
    }
    else if (currentMove == "down")
    {
        if (isValidPosition(matrix, playerRow + 1, playerCol))
        {
            if (matrix[playerRow + 1, playerCol] == 't')
            {
                Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                Console.WriteLine($"Hazelnuts collected: {hazelnuts}");
                Environment.Exit(0);
            }
            else if (matrix[playerRow + 1, playerCol] == 'h')
            {
                hazelnuts++;
                matrix[playerRow, playerCol] = '*';
                matrix[playerRow + 1, playerCol] = 's';
            }
            else if (matrix[playerRow, playerCol - 1] == '*')
            {
                matrix[playerRow, playerCol] = '*';
                matrix[playerRow + 1, playerCol] = 's';
            }
           
            playerRow++;
        }
        else
        {
            Console.WriteLine("The squirrel is out of the field.");
            Console.WriteLine($"Hazelnuts collected: {hazelnuts}");
            Environment.Exit(0);

        }
    }

    if (hazelnuts == 3)
    {
        Console.WriteLine("Good job! You have collected all hazelnuts!");
        Console.WriteLine($"Hazelnuts collected: {hazelnuts}");
        Environment.Exit(0);
    }
}

Console.WriteLine("There are more hazelnuts to collect.");
Console.WriteLine($"Hazelnuts collected: {hazelnuts}");

bool isValidPosition(char[,] matrix, int playerRow, int playerCol)

{
    return playerRow >= 0 && playerRow < matrix.GetLength(0) && playerCol >= 0 && playerCol < matrix.GetLength(1);


}