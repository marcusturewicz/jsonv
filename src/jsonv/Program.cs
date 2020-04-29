using System;
using System.IO;
using System.Text.Json;

namespace JsonValidate
{
    class Program
    {
        /// <param name="filePath">The absolute path to the JSON file</param>
        /// <param name="allowComments">Option to allow comments in the file</param>
        static void Main(string filePath, bool allowComments = false)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Error: file does not exist!");
                return;
            }

            Console.WriteLine($"File path is: {filePath}, allowing comments: {allowComments}");                

            try
            {
                var serializerOptions = new JsonSerializerOptions
                {
                    ReadCommentHandling = allowComments ? JsonCommentHandling.Skip : JsonCommentHandling.Disallow
                };
                JsonSerializer.Deserialize<object>(File.ReadAllBytes(filePath), serializerOptions);
                Console.WriteLine("File is valid JSON!");

            }
            catch (Exception e)
            {
                Console.WriteLine("File is NOT valid JSON!");
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}
