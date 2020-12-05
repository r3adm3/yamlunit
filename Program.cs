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

                    //Console.WriteLine("content:" + content);

                    string val = "customer";

                    var deserializer = new Deserializer();
                    var yamlObject = deserializer.Deserialize<dynamic>(content);

                    Console.WriteLine(yamlObject["items"][0]["part_no"]);
                    Console.WriteLine(yamlObject["items"][1]["part_no"]);
                    Console.WriteLine(yamlObject["date"]);

                }


                /*/ Open the text file using a stream reader.
                using (var sr = new StreamReader(yamlFileName))
                {
                    // Read the stream as a string, and write the string to the console.
                    //Console.WriteLine(sr.ReadToEnd()) ;
                    //var yaml = new YamlStream();
                    //yaml.Load(sr);

                    Console.WriteLine();

                    var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;

                    var deserializer = new Deserializer();
                    var yamlObject = deserializer.Deserialize<dynamic>(sr)["receipt"]["customer"].Values;

                    string doodad = JsonSerializer.Serialize(yamlObject);

                    Console.WriteLine(doodad);
                    

                    //var serializer = new JsonSerializer();
                    //serializer.Serialize(Console.Out, yamlObject);


                    foreach (var entry in mapping.Children)
                    {
                        Console.WriteLine(((YamlScalarNode)entry.Key).Value);
                    }
                    */
                
 
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
