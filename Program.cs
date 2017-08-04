using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace chat_bot_vkAPI
{
    class Program
    {
        // удаление букв
        static string Trim(string str, char[] chars)
        {
            string strA = str; // копирование строки (не правильное)

            // удаление символов
            for (int i = 0; i < chars.Length; i++)
            {
                strA = strA.Replace(char.ToString(chars[i]), "");
            }

            return strA;
        }

        // генерация ответа
        static string Ans(string q)
        {
            string tr = "():^=!?", // символы, которые надо удалять
            ans = ""; // ответ бота

            q = q.ToLower(); // перевод в нижний регистр
            q = Trim(q, tr.ToCharArray()); // удаление букв
            string[] BaseAnswer = File.ReadAllLines("BaseAnswer.txt"); // загрузка файла

            for (int i = 0; i < BaseAnswer.Length; i += 2)
            {
                if (q == BaseAnswer[i])
                {
                    ans = BaseAnswer[i + 1]; // выдает ответ
                    break; // завершает цикл
                }
            }

            return ans; // ответ
        }

        public static void Main(string[] args)
        {
            // бесконечный цикл
            while (true)
            {
                Console.Write("Your answer: ");
                string q = Console.ReadLine(); // ввод вопроса
                Console.WriteLine("Bot say: " + Ans(q) + "\n"); // вывод ответа
            }
        }

    }
}
