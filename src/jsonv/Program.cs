﻿using System;
using System.IO;
using System.Text.Json;

namespace JsonValidate
{
    public class Program
    {
        /// <param name="filePath">The absolute path to the JSON file</param>
        /// <param name="allowComments">Option to allow comments in the file</param>
        static void Main(string filePath, bool allowComments = false)
        {
            var (valid, error) = ValidateJson(filePath, allowComments);

            if (valid)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("File is valid JSON!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File is not valid JSON!");
                Console.WriteLine($"Error: {error}");
            }

            Console.ResetColor();
        }

        /// <param name="filePath">The absolute path to the JSON file</param>
        /// <param name="allowComments">Option to allow comments in the file</param>
        public static (bool Valid, string Error) ValidateJson(string filePath, bool allowComments)
        {
            if (!File.Exists(filePath))
            {
                return (false, "File does not exist!");
            }

            try
            {
                var serializerOptions = new JsonSerializerOptions
                {
                    ReadCommentHandling = allowComments ? JsonCommentHandling.Skip : JsonCommentHandling.Disallow
                };
                JsonSerializer.Deserialize<object>(File.ReadAllBytes(filePath), serializerOptions);
                return (true, string.Empty);

            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }
    }
}
