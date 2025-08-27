using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_morse_114
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, string> monDictionnaire = new Dictionary<char, string>();

            // Ajout d'éléments
            monDictionnaire.Add('a', ".-");
            monDictionnaire.Add('b', "-...");
            monDictionnaire.Add('c', "-.-.");
            monDictionnaire.Add('d', "-..");
            monDictionnaire.Add('e', ".");
            monDictionnaire.Add('f', "..-.");
            monDictionnaire.Add('g', "--.");
            monDictionnaire.Add('h', "....");
            monDictionnaire.Add('i', "..");
            monDictionnaire.Add('j', ".---");
            monDictionnaire.Add('k', "-.-");
            monDictionnaire.Add('l', ".-..");
            monDictionnaire.Add('m', "--");
            monDictionnaire.Add('n', "-.");
            monDictionnaire.Add('o', "---");
            monDictionnaire.Add('p', ".--.");
            monDictionnaire.Add('q', "--.-");
            monDictionnaire.Add('r', ".-.");
            monDictionnaire.Add('s', "...");
            monDictionnaire.Add('t', "-");
            monDictionnaire.Add('u', "..-");
            monDictionnaire.Add('v', "...-");
            monDictionnaire.Add('w', ".--");
            monDictionnaire.Add('x', "-..-");
            monDictionnaire.Add('y', "-.--");
            monDictionnaire.Add('z', "--..");
            monDictionnaire.Add(' ', "/");
            monDictionnaire.Add('0', "-----");
            monDictionnaire.Add('1', ".----");
            monDictionnaire.Add('2', "..---");
            monDictionnaire.Add('3', "...--");
            monDictionnaire.Add('4', "....-");
            monDictionnaire.Add('5', ".....");
            monDictionnaire.Add('6', "-....");
            monDictionnaire.Add('7', "--...");
            monDictionnaire.Add('8', "---..");
            monDictionnaire.Add('9', "----.");


            Console.WriteLine("Bonjour ce petit programme sert à convertir n'importe qu'elle phrase en Morse, pour y acceder appuyer sur Enter");
            int touches = Console.Read();
            if (touches == (int)ConsoleKey.Enter)
            {
                Console.Clear();
            }


            Console.Write("Veuillez entrer votre votre phrase à convertir en morse :");
            string phrase = Console.ReadLine();









            Console.ReadLine();
        }
    }
}
