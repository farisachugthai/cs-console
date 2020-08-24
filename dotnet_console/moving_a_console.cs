// This example demonstrates the Console.WindowLeft and
//                               Console.WindowTop properties.
using System;
using System.Text;
using System.IO;

interface Iconsole_clear_handler
{
    bool Equals(object obj);
    int GetHashCode();
    string ToString();
}

#pragma warning disable CS0101 // The namespace '<global namespace>' already contains a definition for 'moving_a_console'
class moving_a_console : Iconsole_clear_handler
#pragma warning restore CS0101 // The namespace '<global namespace>' already contains a definition for 'moving_a_console'
{
    private static int saveBufferWidth;
    private static int saveBufferHeight;
    public static int saveWindowWidth;
    public static bool saveCursorVisible;

    public static int SaveBufferWidth { get => saveBufferWidth; set => saveBufferWidth = value; }
    public static int SaveBufferHeight { get => saveBufferHeight; set => saveBufferHeight = value; }
    public static int SaveWindowHeight { get; set; }

    //
#pragma warning disable CS0111 // Type 'moving_a_console' already defines a member called 'Main' with the same parameter types
    public static void Main()
#pragma warning restore CS0111 // Type 'moving_a_console' already defines a member called 'Main' with the same parameter types
    {
        string m1 = "1) Press the cursor keys to move the console window.\n" +
                    "2) Press any key to begin. When you're finished...\n" +
                    "3) Press the Escape key to quit.";
        string g1 = "+----";
        string g2 = "|    ";
        string grid1;
        string grid2;
        StringBuilder sbG1 = new StringBuilder();
        StringBuilder sbG2 = new StringBuilder();
        ConsoleKeyInfo cki;
        int y;
        //
        try
        {
            SaveBufferWidth = Console.BufferWidth;
            saveBufferHeight = Console.BufferHeight;
            SaveWindowHeight = Console.WindowHeight;
            saveWindowWidth = Console.WindowWidth;
            saveCursorVisible = Console.CursorVisible;
            //
            Console.Clear();
            Console.WriteLine(m1);
            Console.ReadKey(true);

            // Set the smallest possible window size before setting the buffer size.
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(80, 80);
            Console.SetWindowSize(40, 20);

            // Create grid lines to fit the buffer. (The buffer width is 80, but
            // this same technique could be used with an arbitrary buffer width.)
            for (y = 0; y < Console.BufferWidth / g1.Length; y++)
            {
                sbG1.Append(g1);
                sbG2.Append(g2);
            }
            sbG1.Append(g1, 0, Console.BufferWidth % g1.Length);
            sbG2.Append(g2, 0, Console.BufferWidth % g2.Length);
            grid1 = sbG1.ToString();
            grid2 = sbG2.ToString();

            Console.CursorVisible = false;
            Console.Clear();
            for (y = 0; y < Console.BufferHeight - 1; y++)
            {
                if (y % 3 == 0)
                    Console.Write(grid1);
                else
                    Console.Write(grid2);
            }

            Console.SetWindowPosition(0, 0);
            do
            {
                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (Console.WindowLeft > 0)
                            Console.SetWindowPosition(
                                    Console.WindowLeft - 1, Console.WindowTop);
                        break;
                    case ConsoleKey.UpArrow:
                        if (Console.WindowTop > 0)
                            Console.SetWindowPosition(
                                    Console.WindowLeft, Console.WindowTop - 1);
                        break;
                    case ConsoleKey.RightArrow:
                        if (Console.WindowLeft < (Console.BufferWidth - Console.WindowWidth))
                            Console.SetWindowPosition(
                                    Console.WindowLeft + 1, Console.WindowTop);
                        break;
                    case ConsoleKey.DownArrow:
                        if (Console.WindowTop < (Console.BufferHeight - Console.WindowHeight))
                            Console.SetWindowPosition(
                                    Console.WindowLeft, Console.WindowTop + 1);
                        break;
                }
            }
            while (cki.Key != ConsoleKey.Escape);  // end do-while
        } // end try
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.Clear();
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(SaveBufferWidth, saveBufferHeight);
            Console.SetWindowSize(saveWindowWidth, SaveWindowHeight);
            Console.CursorVisible = saveCursorVisible;
        }
    } // end Main

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return base.ToString();
    }
} // end Sample
/*
This example produces results similar to the following:

1) Press the cursor keys to move the console window.
2) Press any key to begin. When you're finished...
3) Press the Escape key to quit.

...

+----+----+----+-
|    |    |    |
|    |    |    |
+----+----+----+-
|    |    |    |
|    |    |    |
+----+----+----+-

*/
