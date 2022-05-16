using System;
using System.IO;

namespace LearnPractiseXD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к файлу пожалуйста!");
            string path = Console.ReadLine();
            string originalText = File.ReadAllText(path);
            Console.WriteLine(originalText);
        }
    }
}
