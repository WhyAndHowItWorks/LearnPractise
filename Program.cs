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
            // Пути к нужным файлам
            Console.WriteLine("Введите путь к файлу с текстом");
            string pathToOriginal = Console.ReadLine();
            string pathToResult = @"c:\Users\PB\Desktop\Учебная практика 2022\Мое\Результат фильтрации.txt";
            string pathToAnalize = @"c:\Users\PB\Desktop\Учебная практика 2022\Мое\Анализ текста.txt";

            // Получение текстов
            string originalText = File.ReadAllText(pathToOriginal);
            string editedtext = originalText;
            // Заведение таймера и непосредственно работа алгоритма разрезки и сортировки
            Stopwatch timer = new Stopwatch();
            float time = 0f;
            timer.Start();
            string[] wordsmassive = SortText(editedtext, pathToResult);
            timer.Stop();
            time = timer.ElapsedMilliseconds;

            // Выведение статистики 
            Analize(originalText, wordsmassive, time, pathToAnalize);
        }

        //Функция, разрезающая на части текст и сортирующая получившиеся слова. 
        static string[] SortText(string ORText, string Filepath)
        {

            FileInfo filt_file = new FileInfo(Filepath);
            StreamWriter ff = filt_file.CreateText();
            // Удаляем ненужные символы
            for (int t = 0; t < ORText.Length; t++)
            {
                short h = ((short)ORText[t]);
                if (!(h == 44 || h == 46 || h == 1105 || (h > 1039 && h < 1104) || (h > 47 && h < 58)))
                {
                    ORText = ORText.Replace(ORText[t], ' ');
                }

            }

            // Удаляем ненужные комбинации символов
            ORText = ORText.Replace(" ,", " ");
            ORText = ORText.Replace(", ", " ");
            ORText = ORText.Replace(" .", " ");
            ORText = ORText.Replace(". ", " ");


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
            // Редактируем получившиеся слова, удаляя пустые позиции
            for (int i = 0; i < words.Count; i++)
            {


                words[i] = words[i].Replace(" ", "");

                if (words[i] != "")
                {
                    clearwords.Add(words[i]);
                }

            }
            string[] wordsMassive = clearwords.ToArray();



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




            // Записываем их все в файлик          
            foreach (string p in wordsMassive)
            {
                ff.WriteLine(p);
            }
            ff.Close();
            // возвращаем получившийся массив
            return wordsMassive;
        }
        // Анализируем работу функции сортировки
        static void Analize(string Original_text, string[] Edited_text, float time_spent, string PathToFile)
        {

            // Открытие файла
            FileInfo filt_file = new FileInfo(PathToFile);
            StreamWriter ff = filt_file.CreateText();
            string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя1234567890";
            // Выводим исходный текст
            ff.WriteLine("Исходный текст выглядит следующим образом:");
            Console.WriteLine("Исходный текст выглядит следующим образом:");
            Console.WriteLine(Original_text);
            ff.WriteLine(Original_text);
            ff.WriteLine();
            Console.WriteLine();
            // Описание Варианта
            ff.WriteLine("Вариант 1. Необходимо разрезать текст на части, затем отсортировать получившиеся слова по алфавиту. " +
                "Числа также входят в сортировку. Порядок слов: от а до я, затем цифры.");
            Console.WriteLine("Вариант 1. Необходимо разрезать текст на части, затем отсортировать получившиеся слова по алфавиту. " +
                "Числа также входят в сортировку. Порядок слов: от а до я, затем цифры.");
            // Количество слов 
            ff.WriteLine("Количество слов в тексте: " + Edited_text.Length);
            Console.WriteLine("Количество слов в тексте: " + Edited_text.Length);
            // Время сортировки
            ff.WriteLine("Время получившийся сортировки в миллисекундах: " + time_spent);
            Console.WriteLine("Время получившийся сортировки в миллисекундах: " + time_spent);
            // Статистика 
            ff.WriteLine("Количество слов, начинающихся с конкретной буквы");
            Console.WriteLine("Количество слов, начинающихся с конкретной буквы");
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
                Console.WriteLine(alphabet[i] + " : " + kolvo);
            }
            ff.Close();
        }
    }
}
