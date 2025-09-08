using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace projet_morse_114
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choix = 0;
            Console.WriteLine("=== Couteau Suisse – Utilitaires ===");
            Console.WriteLine("1. Convertir du texte en code Morse");
            Console.WriteLine("2. Convertir des nombres entre différentes bases (Décimal <> Binaire <> Octal)");
            Console.WriteLine("3. (à venir)");
            Console.WriteLine("4. Quitter le programme");
            Console.Write("Entrer votre choix :");

            choix = Convert.ToInt32(Console.ReadLine());

            if (choix == 1)
            {
                Morse();
            }

            if (choix == 2)
            {
                Convertisseur();
            }

            if (choix == 3)
            {
                Console.WriteLine("en cours de dévellopement");
            }

            if(choix == 4)
            {
                Environment.Exit(0);
            }

            




            Console.ReadLine(); //affiche tout dans la console
        }

        static void Morse()
        {
            Dictionary<char, string> monDictionnaire = new Dictionary<char, string>()
            {
                {'a', ".-"}, {'b', "-..."}, {'c', "-.-."}, {'d', "-.."}, {'e', "."},
                {'f', "..-."}, {'g', "--."}, {'h', "...."}, {'i', ".."}, {'j', ".---"},
                {'k', "-.-"}, {'l', ".-.."}, {'m', "--"}, {'n', "-."}, {'o', "---"},
                {'p', ".--."}, {'q', "--.-"}, {'r', ".-."}, {'s', "..."}, {'t', "-"},
                {'u', "..-"}, {'v', "...-"}, {'w', ".--"}, {'x', "-..-"}, {'y', "-.--"},
                {'z', "--.."}, {' ', "/"}, {'0', "-----"}, {'1', ".----"}, {'2', "..---"},
                {'3', "...--"}, {'4', "....-"}, {'5', "....."}, {'6', "-...."},
                {'7', "--..."}, {'8', "---.."}, {'9', "----."}, {'.', ".-.-.-"}, {',',"--..--"}, {'?', "..--.."},
                {'!', "-.-.--"}, {'/', "-..-."}, {'(', "-.--."}, {')', "-.--.-"}, {'&', ".-..."}, {':', "---..."},
                {';', "-.-.-."}, {'=', "-...-"}, {'-', "-....-"}, {'_', "..--.-"}, {'"', ".-..-."}, {'+', ".-.-."}
            };
            Console.Clear();
            Console.Write("Entrez votre phrase à convertir : ");
            string phrase = Console.ReadLine();

            string morsePhrase = "";

            Console.WriteLine("Veuillez entrer la phrase a convertir");
            foreach (char lettre in phrase.ToLower()) // déclare une variable qui va chercher les lettres similaires a celle dans la bibliothèque
            {
                if (monDictionnaire.ContainsKey(lettre)) // vérifie si il y a des lettres similiaire a celle dans la bibliothèque 
                {
                    string morse = monDictionnaire[lettre]; //déclare une variable pour dire que morse est égal au vrai morse dans le dictionnaire
                    morsePhrase += morse + " ";
                    Console.Write(morse + " "); // écrit le morse dans la console
                }
                else
                {
                    Console.Write(" inconnu"); // affiche sa pour un caractère inconnue
                }
            }

            foreach (char symbole in morsePhrase) // lance un foreach pour détecter les symbole dans la variable morsePhrase
            {
                if (symbole == '.') //si il y a un . dans symbole alors sa lance un beep
                {
                    Console.Beep(500, 200); // point = beep court
                }
                else if (symbole == '-')
                {
                    Console.Beep(500, 500); // tiret = beep long
                }
                else if (symbole == '/')
                {
                    Thread.Sleep(500); // séparation des mots
                }
                else if (symbole == ' ')
                {
                    Thread.Sleep(100); // pause entre lettres
                }
            }
            string FilePath = "C:\\Users\\po66sxd\\Desktop\\file.txt";
            File.WriteAllText(FilePath, morsePhrase);
        }

        static void Convertisseur()
        {
            Console.Clear();
            int choixconvert = 0;
            Console.WriteLine("=== Convertisseur de bases ===");
            Console.WriteLine("1. Décimal > Binaire");
            Console.WriteLine("2. Binaire > Décimal");
            Console.WriteLine("3. Binaire > Octal");
            Console.WriteLine("4. Octal > Binaire");
            Console.WriteLine();

            Console.Write("Entrer votre choix :");


            choixconvert = Convert.ToInt32(Console.ReadLine()); // récupère le chiffre taper par l'utilisateur 


            // Convertion Décimal en Binaire
            if (choixconvert == 1) 
            {
                int decimalbinaire = 0; // création d'une variable
                Console.Write("Entrez un nombre décimal : "); 
                decimalbinaire = Convert.ToInt32(Console.ReadLine());//récupère ce que l'utilisateur à écrit
                string resutatbinairedecimal = "";// création de la variable réponse
                do
                {
                    if (decimalbinaire % 2 == 0) // verifie si c'est pas divisible par 2
                    {
                        resutatbinairedecimal = "0" + resutatbinairedecimal;//rajoute un 1 à la variable si c'est divisible par 2
                    }
                    else
                    {
                        resutatbinairedecimal = "1" + resutatbinairedecimal;//rajoute un 0 à la variable si c'est pas divisible par 2
                    }

                    decimalbinaire /= 2;

                } while (decimalbinaire != 0);




                Console.WriteLine("");
                Console.Write("Résultat : ");
                Console.Write(resutatbinairedecimal);

            }

            // Convertion Binaire en Décimal
            if (choixconvert == 2)
            {
                int binairedecimal = 0;
                int binairedecimalresultat = 0;
                Console.Write("Entrez un nombre décimal : ");
                binairedecimal = Convert.ToInt32(Console.ReadLine());//récupère ce que l'utilisateur à écrit




                Console.WriteLine("");
                Console.Write("Résultat : ");
                Console.Write(binairedecimal);
            }

            // convertir Binaire en Octal
            if (choixconvert == 3)
            {
                int binaireoctal = 0;
                Console.Write("Entrez un nombre décimal : ");
                binaireoctal = Convert.ToInt32(Console.ReadLine());//récupère ce que l'utilisateur à écrit



                Console.WriteLine("");
                Console.Write("Résultat : ");
                Console.Write(binaireoctal);

            }

            //convertir Octal en Binaire
            if (choixconvert == 4)
            {
                int octalbinaire = 0;
                Console.Write("Entrez un nombre décimal : ");
                octalbinaire = Convert.ToInt32(Console.ReadLine());//récupère ce que l'utilisateur à écrit



                Console.WriteLine("");
                Console.Write("Résultat : ");
                Console.Write(octalbinaire);

            }



        }
    }
}
