using System;
using System.IO;
using System.Collections.Generic;

namespace LearnPractiseXD
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите путь к файлу пожалуйста!");
            string path = Console.ReadLine();
            string originalText = File.ReadAllText(path);
            Console.WriteLine("Текст в найденном файле выглядит следующим образом...");
            Console.WriteLine(originalText);
            string editedtext = originalText;
            SortText(originalText);
        }
        static void SortText(string ORText)
        {
            // Разрезаем его на части по пробелам.
            int begin = 0;
            char space = ' ';
            List<string> words = new List<string>();
            for (int i = 0; i < ORText.Length; i++)
            {
                if (ORText[i] == space)
                {
                    words.Add(ORText.Substring(begin, i - begin) + " ");
                    begin = i;
                }
                if (i == ORText.Length - 1)
                {
                    words.Add(ORText.Substring(begin, i - begin + 1) + " ");
                    begin = i;
                }
            }
            List<string> clearwords = new List<string>();
            // Редактируем получившиеся слова
            for (int i = 0; i < words.Count; i++)
            {
                // Необходимо заменить потом на что-то более адекватное.
                words[i] = words[i].Replace(" ,", "");
                words[i] = words[i].Replace(", ", "");
                words[i] = words[i].Replace(".", "");
                words[i] = words[i].Replace(" ", "");
                words[i] = words[i].Replace("!", "");
                words[i] = words[i].Replace("?", "");
                words[i] = words[i].Replace("+", "");
                if (words[i] != "")
                {
                    clearwords.Add(words[i]);
                }
                Console.WriteLine(words[i]);
            }
            string[] wordsMassive = clearwords.ToArray(); Console.WriteLine("FFFFFFFFFFFF");
            // сортируем
            for (int i = 0; i < wordsMassive.Length; i++)
            {
                for (int j = 0; j < wordsMassive.Length - 1; j++)
                {
                    char j_ch = char.ToLower(wordsMassive[j][0]);
                    char j_1ch = char.ToLower(wordsMassive[j + 1][0]);
                    if (j_ch > j_1ch)
                    {
                        string delta = wordsMassive[j];
                        wordsMassive[j] = wordsMassive[j + 1];
                        wordsMassive[j + 1] = delta;

                    }
                }
            }

            for (int i = 0; i < wordsMassive.Length; i++)
            {

                Console.WriteLine(wordsMassive[i]);

            }
            Console.WriteLine("FFFFFFFFFFFF");
            // Находим конец части с числами
            int g = 0;
            while (true)
            {
                g++;
                if (wordsMassive[g][0] > '9')
                {
                    break;
                }

            }
            // Разрезаем массив на цифры и буквы
            string[] chisla = new string[g];
            for (int k = 0; k < chisla.Length; k++)
            {
                chisla[k] = wordsMassive[k];
                Console.WriteLine(chisla[k]);
            }
            string[] wordsPart = new string[wordsMassive.Length - g];
            for (int k = 0; k < wordsPart.Length; k++)
            {
                wordsPart[k] = wordsMassive[k + g];
                Console.WriteLine(wordsPart[k]);
            }
            words = new List<string>();
            // Сшиваем его по новому
            foreach (string p in wordsPart)
            {
                words.Add(p);
            }
            foreach (string p in chisla)
            {
                words.Add(p);
            }
            wordsMassive = words.ToArray();
            Console.WriteLine("FFFFFFFFFFFF");
            foreach (string p in wordsMassive)
            {
                Console.WriteLine(p);
            }
        }
    }
}
