// File Banners apparently copy paste throughout files in VSCode
// https://docs.microsoft.com/en-us/dotnet/api/system.consolecolor?view=netframework-4.8

using NuGet.Configuration;
using System;
using System.Threading.Tasks;
using System.Xml;

namespace cs
{
#pragma warning disable CS0116 // A namespace cannot directly contain members such as fields or methods
    private async Task TestReader(System.IO.Stream stream)
#pragma warning restore CS0116 // A namespace cannot directly contain members such as fields or methods
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        using var reader = XmlReader.Create(stream, Settings);
        while (await reader.ReadAsync())
        {
            switch (reader.NodeType)
            {
                case XmlNodeType.Element:
                    Console.WriteLine("Start Element {0}", reader.Name);
                    break;
                case XmlNodeType.Text:
                    Console.WriteLine("Text Node: {0}",
                             await reader.GetValueAsync());
                    break;
                case XmlNodeType.EndElement:
                    Console.WriteLine("End Element {0}", reader.Name);
                    break;
                default:
                    Console.WriteLine("Other node {0} with value {1}",
                                    reader.NodeType, reader.Value);
                    break;
            }
        }

        static XmlReaderSettings GetSettings()
        {
            return new XmlReaderSettings
            {
                Async = true
            };
        }
    }

}