using System;
using System.IO;
using YamlDotNet.Serialization;

namespace yaml
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup strings for file name
            string yamlFileName = "";

            //bit of UI
            Console.WriteLine("\r\n == yaml Check == (c) MMXX");

            //hardcoded filename, TODO: will replace with args collector. 
            yamlFileName = "sample.yaml";

            try
            {
                //setup string for content to work on
                string content;

                //read the contents of the specified file into variable 'content'
                using (StreamReader reader = new StreamReader(yamlFileName))
                {
                    //read the file to the end
                    content = reader.ReadToEnd();

                    //setup the yaml deserializer
                    var deserializer = new Deserializer();
                    
                    //get the yaml into an object we can start reading programmatically. 
                    var yamlObject = deserializer.Deserialize<dynamic>(content);

                    //some display entries
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
