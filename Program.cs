using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            while (n != 8)
            {
                /* for issue #1 editing text in comment */
                Console.WriteLine("1. Pobierz plik");
                Console.WriteLine("2. Zlicz liczbę liter w podanym pliku");
                Console.WriteLine("3. Zlicz liczbę wyrazów w pliku");
                Console.WriteLine("4. Zlicz liczbę znaków interpukcyjnych w pliku");
                Console.WriteLine("5. Zlicz liczbę zdań w pliku");
                Console.WriteLine("6. Wygeneruj raport o użyciu liter (A-Z)");
                Console.WriteLine("7. Zapisz statystyki z punktów 2-5 do pliku statystyki.txt");
                Console.WriteLine("8. Wyjście z programu");
                n = Convert.ToInt32(Console.ReadLine());

                if (n == 8)
                {
                    //delete files
                    try
                    {
                        System.IO.File.Delete(@"2.txt");
                    }
                    catch (System.IO.IOException e)
                    {

                        Console.WriteLine("Bład przy usuwaniu pliku");
                        return;
                    }
                    try
                    {
                        System.IO.File.Delete(@"statystyki.txt");

                    }
                    catch (System.IO.IOException e)
                    {
                        Console.WriteLine("Błąd przy usuwaniu pliku");
                        return;
                    }
                    break;
                }
                if (n == 1)
                {

                    //Console.WriteLine("Pobieranie pliku z internetu");

                    //WebClient client = new WebClient()
                    //client.DownloadFile("https://s3.zylowski.net/public/input/2.txt", "2.txt");
                    /*using (var client = new WebClient())
                    {
                        client.DownloadFile("https://s3.zylowski.net/public/input/2.txt", "2.txt");
                        File.OpenRead("2.txt");
                        Console.WriteLine("Plik został pobrany prawidłowo");
                    }
                    */
                    Console.WriteLine("Czy pobrać plik z internetu ? [T/N]");
                    char t = Convert.ToChar(Console.ReadLine());
                    if (t == 't' | t == 'T')
                    {
                        Console.WriteLine("Podaj adres pliku");
                        string address = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Podaj nazwę pliku");
                        string nazwapliku = Convert.ToString(Console.ReadLine());
                        WebClient webClient = new WebClient();
                        try
                        {
                            webClient.DownloadFile(address, "2.txt");
                        }
                        catch (WebException e)
                        {
                            Console.WriteLine("Podaj prawidłowe dane");
                            
                        }
                    }
                    else
                    {


                        string filename;
                        Console.WriteLine("Podaj nazwę pliku");
                        filename = Console.ReadLine();
                        if (File.Exists(filename))
                        {
                            File.OpenRead(filename);
                            Console.WriteLine("Plik został otwarty!");
                        }
                        else
                        {
                            Console.WriteLine($"Podany plik '{filename}' nie istnieje w ścieżce {Directory.GetCurrentDirectory()}");
                        }
                    }

                }

                if (n == 2)
                {

                    Console.Clear();
                    try
                    {
                        /* changing comment for automatic close issue */
                        string text = System.IO.File.ReadAllText(@"2.txt");
                        if (text != null)
                        {
                            if (text == null)
                            {
                                Console.WriteLine("nie pobrano pliku");
                                break;
                            }
                            int vowel = 0;
                            int consonants = 0;
                            int sum=0;
                            foreach (char y in text)
                            {
                                string x = Convert.ToString(y);
                                if (x != "," && x != "." && x != ";" && x != "'" && x != "?" && x != "!" && x != "-" && x != ":" && x != " ")
                                {

                                    if (x == "a" || x == "A" || x == "ą" || x == "Ą" || x == "e" || x == "E" || x == "ę" || x == "Ę" || x == "i" || x == "I" || x == "o" || x == "O" || x == "ó" || x == "Ó" || x == "u" || x == "U" || x == "y" || x == "Y")
                                    {
                                        vowel++;
                                    }
                                    else
                                    {
                                        consonants++;
                                    }

                                }

                            }
                            sum = vowel + consonants;
                            Console.WriteLine("Ilość liter w pliku : " + sum);
                            
                        }

                    }

                    catch (FileNotFoundException e)
                    {
                        Console.WriteLine("Błąd, nie znaleziono pliku, najpierw pobierz plik");
                    }


                }
                if (n == 3)
                {
                    //counting letters
                    Console.Clear();
                    try
                    {
                        string text = System.IO.File.ReadAllText(@"2.txt");

                        if (text != null)
                        {


                            if (text == null)
                            {
                                Console.WriteLine("nie pobrano pliku");
                                break;
                            }
                            string[] source = text.Split(new char[] { '.', '?', '!', ' ', ';', ':',  }, StringSplitOptions.RemoveEmptyEntries);
                            int words = 0;
                            foreach (string word in source)
                            {
                                if (word.Length > 1)
                                {
                                    words++;
                                }

                            }

                            Console.WriteLine("Ilość wyrazów w pliku = " + words);

                        }
                    }
                    catch (FileNotFoundException e);
                    {
                        Console.WriteLine("Błąd, nie znaleziono pliku, najpierw pobierz plik");
                    }


                }





            }



        }
    }
}
            
    



    
