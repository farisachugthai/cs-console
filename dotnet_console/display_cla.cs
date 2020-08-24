// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/main-and-command-args/how-to-display-command-line-arguments
// let's try to not fuck with this one too hard shall we? i literally destroyed the
// file existence one lol. the original is in ../Windows-task-snippets/tasks/File-exists.md

using System;

class CommandLine
{
    static void Main(string[] args)
    {
        // The Length property provides the number of array elements.
        Console.WriteLine($"parameter count = {args.Length}");

        for (int i = 0; i < args.Length; i++)
        {
            Console.WriteLine($"Arg[{i}] = [{args[i]}]");
        }
    }
}
/* Output (assumes 3 cmd line args):
    parameter count = 3
    Arg[0] = [a]
    Arg[1] = [b]
    Arg[2] = [c]
*/
