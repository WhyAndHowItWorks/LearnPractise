using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace LearnPractiseXD
{
    class Program
    {

        static void Main(string[] args)
        {


            string path = @"c:\Users\PB\Desktop\Учебная практика 2022\Мое\Исходный файл.txt";
            string originalText = File.ReadAllText(path);

            string path1 = @"c:\Users\PB\Desktop\Учебная практика 2022\Мое\Результат фильтрации.txt";
            string path2 = @"c:\Users\PB\Desktop\Учебная практика 2022\Мое\Анализ текста.txt";
            float time = 0f;





            string editedtext = originalText;
            Stopwatch s = new Stopwatch();
            s.Start();
            string[] wordsmassive = SortText(editedtext, path1);
            s.Stop();
            time = s.ElapsedMilliseconds;
            Analize(originalText, wordsmassive, time, path2);
        }
        static string[] SortText(string ORText, string Filepath)
        {
            FileInfo filt_file = new FileInfo(Filepath);
            StreamWriter ff = filt_file.CreateText();
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

            }
            string[] wordsMassive = clearwords.ToArray();



            // сортируем
            Stopwatch s = new Stopwatch();

            Console.WriteLine(wordsMassive.Length);
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

            }
            string[] wordsPart = new string[wordsMassive.Length - g];
            for (int k = 0; k < wordsPart.Length; k++)
            {
                wordsPart[k] = wordsMassive[k + g];

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

            foreach (string p in wordsMassive)
            {
                ff.WriteLine(p);
            }
            ff.Close();
            return wordsMassive;
        }
        static void Analize(string Original_text, string[] Edited_text, float time_spent, string PathToFile)
        {

            FileInfo filt_file = new FileInfo(PathToFile);
            StreamWriter ff = filt_file.CreateText();
            string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя1234567890";
            // Выводим исходный текст
            ff.WriteLine(Original_text);
            ff.WriteLine();
            // Описание Варианта
            ff.WriteLine("Вариант 1. Необходимо разрезать текст на части, затем отсортировать получившиеся слова по алфавиту. " +
                "Числа также входят в сортировку. Порядок слов: от а до я, затем цифры.");
            // Количество слов 
            ff.WriteLine("Количество слов в тексте: " + Edited_text.Length);
            // Время сортировки
            ff.WriteLine("Время получившийся сортировки в миллисекундах: " + time_spent);
            // Статистика 
            ff.WriteLine("Количество слов, начинающихся с конкретной буквы");
            int kolvo = 0;
            for (int i = 0; i < alphabet.Length; i++)
            {
                kolvo = 0;
                for (int g = 0; g < Edited_text.Length; g++)
                {
                    char g_small = char.ToLower(Edited_text[g][0]);
                    if (g_small == alphabet[i])
                    {
                        kolvo++;
                    }
                }
                ff.WriteLine(alphabet[i] + " : " + kolvo);
            }
            ff.Close();
        }
    }
}
