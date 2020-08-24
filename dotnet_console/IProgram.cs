// Believe it or not this is the original Program.cs you get when you
// run dotnet new console on the cmdline....
// Only difference is that this is what happens when you mindlessly hit
// <C-.> to run all quickfixes over and over....
namespace dotnet_console
{
    internal interface IProgram
    {
        bool Equals(object obj);
        int GetHashCode();
        string ToString();
    }
}
