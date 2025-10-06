using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

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
            Console.WriteLine("3. Stéganographie");
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
                stéganographie();
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
                string binairedecimal = "";
                int binairedecimalresultat = 0;
                Console.Write("Entrez un nombre binaire : ");
                binairedecimal = Convert.ToString(Console.ReadLine());//récupère ce que l'utilisateur à écrit
                int j = 0;
                foreach (char i in binairedecimal.Reverse())
                {
                    if (i == '1')
                    {
                       
                        binairedecimalresultat += (int)Math.Pow(2, j);
                    }
                         
                    j++;
                    
                }
                Console.WriteLine("");
                Console.Write("Résultat : ");
                Console.Write(binairedecimalresultat);
            }

            // convertir Binaire en Octal
            if (choixconvert == 3)
            {
                string binaireoctal = "";
                int binaireoctalresultat = 0;
                int reste = 0;
                string binaireoctalresultat2 = "";
                Console.Write("Entrez un nombre binaire : ");
                binaireoctal = Convert.ToString(Console.ReadLine());//récupère ce que l'utilisateur à écrit
                int j = 0;
                foreach (char i in binaireoctal.Reverse())
                {
                    if (i == '1')
                    {

                        binaireoctalresultat += (int)Math.Pow(2, j);
                    }

                    j++;

                }
                while(binaireoctalresultat != 0)
                {
                    reste = binaireoctalresultat % 8;
                    binaireoctalresultat = binaireoctalresultat / 8;
                    binaireoctalresultat2 = reste + binaireoctalresultat2;

                }


                Console.WriteLine("");
                Console.Write("Résultat : ");
                Console.Write(binaireoctalresultat2);

            }

            //convertir Octal en Binaire
            //convertir Octal en Binaire
            if (choixconvert == 4)
            {
                string octalbinaire = "";
                Console.Write("Entrez un nombre octal : ");
                octalbinaire = Convert.ToString(Console.ReadLine());//récupère ce que l'utilisateur à écrit
                string resulatatbinaireoctal = "";// création de la variable réponse

                foreach (char i in octalbinaire)
                {
                    // conversion du caractère octal en entier
                    int chiffreOctal = int.Parse(i.ToString());

                    // variable temporaire pour le calcul
                    int temp = chiffreOctal;
                    string binaire = "";

                    // calcul manuel décimal → binaire
                    do
                    {
                        int reste = temp % 2;
                        binaire = reste.ToString() + binaire;
                        temp = temp / 2;
                    } while (temp != 0);

                    // chaque chiffre octal correspond à 3 bits, donc on complète si besoin
                    binaire = binaire.PadLeft(3, '0');

                    resulatatbinaireoctal += binaire;
                }

                Console.WriteLine("");
                Console.Write("Résultat : ");
                Console.Write(resulatatbinaireoctal);
            }




        }

        static void stéganographie()
        {
            int choix = 0;
            Console.Clear();
            Console.WriteLine("1. Encoder (Cacher un message)");
            Console.WriteLine("2. Décoder (Extraire un message caché)");
            Console.Write("Veuillez entrer votre choix : ");
            choix = Convert.ToInt16(Console.ReadLine());




            if (choix == 1)
            {
                string fileName = "C:\\Users\\po66sxd\\Desktop\\test\\exported_file.txt";
                string texte = "";
                string textecachee = "";
                string textecacheecache = "";
                Console.Clear ();
                Console.Write("Texte porteur (ce que l'on verra) : ");
                texte = Convert.ToString(Console.ReadLine());//récupère ce que l'utilisateur à écrit
                Console.WriteLine(" ");
                Console.Write("Message secret à cacher (A-Z et espace) :");
                textecachee = Convert.ToString(Console.ReadLine());//récupère ce que l'utilisateur à écrit
                Console.WriteLine(" "); //pour faire un saut de page sans devoir cliquer





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


                foreach (char lettre in textecachee.ToLower()) // déclare une variable qui va chercher les lettres similaires a celle dans la bibliothèque
                {
                    if (monDictionnaire.ContainsKey(lettre)) // vérifie si il y a des lettres similiaire a celle dans la bibliothèque 
                    {
                        string morse = monDictionnaire[lettre]; //déclare une variable pour dire que morse est égal au vrai morse dans le dictionnaire
                        textecachee += morse + " ";
                    }
                    else
                    {
                        Console.Write(" inconnu"); // affiche sa pour un caractère inconnue
                    }
                }





                foreach (char character in textecachee)
                {
                    if (character == '.') textecacheecache += "\u200B";
                    else if (character == '-') textecacheecache += "\u200C";
                    else if (character == ' ') textecacheecache += "\u200D";
                    else if (character == '/') textecacheecache += "\u2060";
                }



                File.AppendAllText(fileName, texte + textecacheecache);


                Console.WriteLine("Le texte avec stéganographie a été sauvegardé dans le fichier stegano.txt");
            }

            if (choix == 2)
            {
                string FilePath = "";
                Console.Clear();
                Console.WriteLine("Veuillez entrer le chemin d'un txt que vous voulez décoder :");
                FilePath = Convert.ToString(Console.ReadLine());//récupère ce que l'utilisateur à écrit
                string contenuComplet = File.ReadAllText(FilePath);


                foreach (char character in File.ReadAllText(FilePath))
                {
                    if (character == '\u200B') contenuComplet += ".";
                    else if (character == '\u200C') contenuComplet += "-";
                    else if (character == '\u200D') contenuComplet += " ";
                    else if (character == '\u2060') contenuComplet += "/";
                }

                Console.WriteLine(contenuComplet);

            }

        }
    }
}
