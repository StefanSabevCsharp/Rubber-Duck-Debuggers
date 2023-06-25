int[] time = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int[] tasks = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

Queue<int> timeQueue = new Queue<int>(time);
Stack<int> tasksStack = new Stack<int>(tasks);

Dictionary<string, int> values = new Dictionary<string, int>();
values.Add("Darth Vader Ducky", 0);
values.Add("Thor Ducky", 0);
values.Add("Big Blue Rubber Ducky", 0);
values.Add("Small Yellow Rubber Ducky", 0);


while (timeQueue.Count != 0 && tasksStack.Count != 0)
{
    int currentTime = timeQueue.Dequeue();
    int currentTask = tasksStack.Pop();
    int result = currentTime * currentTask;

    if (result >= 0 && result <= 60)
    {
        values["Darth Vader Ducky"] += 1;
    }
    else if (result >= 61 && result <= 120)
    {
        values["Thor Ducky"] += 1;
    }
    else if (result >= 121 && result <= 180)
    {
        values["Big Blue Rubber Ducky"] += 1;
    }
    else if (result >= 181 && result <= 240)
    {
        values["Small Yellow Rubber Ducky"] += 1;
    }
    else if (result > 240)
    {
          tasksStack.Push(currentTask - 2);
        timeQueue.Enqueue(currentTime);
    }
}
Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");

foreach(var item in values)
{
    Console.WriteLine($"{item.Key}: {item.Value}");
}
