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

            Console.WriteLine("Bonjour, ce programme convertit une phrase en Morse. Appuyez sur Entrée pour continuer.");
            Console.ReadLine();
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


            Console.ReadLine(); //affiche tout dans la console
        }
    }
}
