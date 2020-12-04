using System;
using System.IO;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.RepresentationModel;

namespace yaml
{
    class Program
    {
        static void Main(string[] args)
        {

            string yamlFileName = "";
            Console.WriteLine("\r\n == yaml Check == (c) MMXX");
            //read command line arguments for file type and output test results
            if ( args.Length < 1 ){
                Console.WriteLine (" Err: No Args \r\n");
                displayHelp();
                Environment.Exit(0);
            } else {
                Console.WriteLine(" Getting filename");
                yamlFileName = args[0].Replace("--filename=", "");
            }
            
            Console.WriteLine ( "\r\n arg: " + yamlFileName);

            try
            {
                // Open the text file using a stream reader.
                using (var sr = new StreamReader(yamlFileName))
                {
                    // Read the stream as a string, and write the string to the console.
                    //Console.WriteLine(sr.ReadToEnd()) ;
                    var yaml = new YamlStream();
                    yaml.Load(sr);

                    var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;

                    foreach (var entry in mapping.Children)
                    {
                        Console.WriteLine(((YamlScalarNode)entry.Key).Value);
                    }

                }
 
            }
            catch (IOException e)
            {
                Console.WriteLine(" Error: The file could not be read:");
                Console.WriteLine(e.Message);
            }

            //Console.WriteLine (" \r\n File Contents:- \r\n" +  yamlStream);


            Console.WriteLine ("\r\n"); 

        }

        static void displayHelp (){
            Console.WriteLine ("\r\n Usage:");
            Console.WriteLine ("  --filename=[filename.yaml]  name of file to process");
            Console.WriteLine ("  -h --help -?                displays help");
        }

    }
}
