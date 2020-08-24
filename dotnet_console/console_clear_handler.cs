// Well I fucked up at some point because this no longer matches the output of the online sample...
using System;

internal class moving_a_console
{
    public moving_a_console()
    {
    }

    public static void Main()
    {
        ConsoleKeyInfo cki;

        Console.Clear();

        // Establish an event handler to process key press events.
        Console.CancelKeyPress += new ConsoleCancelEventHandler(MyHandler);
        while (true)
        {
            Console.Write("Press any key, or 'X' to quit, or ");
            Console.WriteLine("CTRL+C to interrupt the read operation:");

            // Start a console read operation. Do not display the input.
            cki = Console.ReadKey(true);

            // Announce the name of the key that was pressed .
            Console.WriteLine(value: "  Key pressed: {cki.Key}\n");

            // Exit if the user pressed the 'X' key.
            if (cki.Key == ConsoleKey.X)
            {
                break;
            }
        }
    }

    protected static void MyHandler(object sender,
                                    ConsoleCancelEventArgs args)
    {
        if (sender is null)
        {
            throw new ArgumentNullException(nameof(sender));
        }

        if (args is null)
        {
            throw new ArgumentNullException(nameof(args));
        }

        Console.WriteLine("\nThe read operation has been interrupted.");

        Console.WriteLine(value: "  Key pressed: {args.SpecialKey}");

        Console.WriteLine(value: "  Cancel property: {args.Cancel}");

        // Set the Cancel property to true to prevent the process from terminating.
        Console.WriteLine("Setting the Cancel property to true...");
        args.Cancel = true;

        // Announce the new value of the Cancel property.
        Console.WriteLine(value: "  Cancel property: {args.Cancel}");
        Console.WriteLine("The read operation will resume...\n");
    }
}
// The example displays output similar to the following:
//    Press any key, or 'X' to quit, or CTRL+C to interrupt the read operation:
//      Key pressed: J
//
//    Press any key, or 'X' to quit, or CTRL+C to interrupt the read operation:
//      Key pressed: Enter
//
//    Press any key, or 'X' to quit, or CTRL+C to interrupt the read operation:
//
//    The read operation has been interrupted.
//      Key pressed: ControlC
//      Cancel property: False
//    Setting the Cancel property to true...
//      Cancel property: True
//    The read operation will resume...
//
//      Key pressed: Q
//
//    Press any key, or 'X' to quit, or CTRL+C to interrupt the read operation:
//      Key pressed: X