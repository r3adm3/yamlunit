using System;
using System.IO;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.RepresentationModel;
using System.Text.Json;
using System.Collections.Generic;

namespace yaml
{
    class Program
    {
        static void Main(string[] args)
        {

            string yamlFileName = "";
            Console.WriteLine("\r\n == yaml Check == (c) MMXX");


            yamlFileName = "sample.yaml";

            try
            {
                string content;
                using (StreamReader reader = new StreamReader(yamlFileName))
                {
                    content = reader.ReadToEnd();

                    var deserializer = new Deserializer();
                    var yamlObject = deserializer.Deserialize<dynamic>(content);

                    Console.WriteLine(yamlObject["items"][0]["part_no"]);
                    Console.WriteLine(yamlObject["items"][1]["part_no"]);
                    Console.WriteLine(yamlObject["date"]);

                }
 
            }
            catch (IOException e)
            {
                Console.WriteLine(" Error: The file could not be read:");
                Console.WriteLine(e.Message);
            }

            Console.WriteLine ("\r\n"); 

        }

        static void displayHelp (){
            Console.WriteLine ("\r\n Usage:");
            Console.WriteLine ("  --filename=[filename.yaml]  name of file to process");
            Console.WriteLine ("  -h --help -?                displays help");
        }

    }
}
