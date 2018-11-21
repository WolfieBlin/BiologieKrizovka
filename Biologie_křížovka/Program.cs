using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace pokusTextFile
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var pokracovat = true;
            var moznaSlova = new List<string>();
            var moznaSlovaPisemno = new List<string>();

            var logFile = File.ReadAllText(@"C:\Users\ufon2\Desktop\Biologie Křížovka\biologie.txt", Encoding.Default);

            var punctuation = logFile.Where(Char.IsPunctuation).Distinct().ToArray();
            var words = logFile.Split().Select(x => x.Trim(punctuation));
            words = words.Distinct().ToList();

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine("Zadejte kolik písmen má slovo obsahovat");
            var delkaSlova = Convert.ToInt32(Console.ReadLine());

            foreach (var slovo in words)
            {
                if (slovo.Length == delkaSlova && !slovo.Contains("ch"))
                {
                    moznaSlova.Add(slovo);
                }

                if (slovo.Contains("ch"))
                {
                    if (slovo.Length - 1 == delkaSlova)
                    {
                        moznaSlova.Add(slovo);
                    }
                }
            }

            foreach (var slovo in moznaSlova)
            {
                moznaSlovaPisemno.Add(slovo);
            }

            foreach (var slovo in moznaSlova)
            {
                Console.WriteLine(slovo);
            }

            while (pokracovat)
            {
                Console.WriteLine("Zadejte písmeno které má slovo obsahovat");


                var pismeno = Console.ReadLine().ToLower();


                if (pismeno.Length != 1 && pismeno != "ch")
                    pismeno = pismeno.Substring(0, 1);
                bool obsahujePismeno;

                foreach (var slovo in moznaSlova)
                {
                    obsahujePismeno = false;

                    if (slovo.ToLower().Contains(pismeno))
                    {
                        obsahujePismeno = true;
                    }

                    if (!obsahujePismeno)
                    {
                        moznaSlovaPisemno.Remove(slovo);
                    }
                }

                if (moznaSlovaPisemno.Count == 0)
                {
                    Console.WriteLine("Žádné slovo nesplňujě podmínky");
                    pokracovat = false;
                }
                else
                {
                    Console.WriteLine("Slova po vyfiltrovaní");
                    foreach (var slovo in moznaSlovaPisemno)
                    {
                        Console.WriteLine(slovo);
                    }

                    Console.WriteLine("Chcete zadat další písmeno ? A/N");
                    if (Console.ReadLine() != "a")
                    {
                        pokracovat = false;
                    }
                }
            }
        }
    }
}
