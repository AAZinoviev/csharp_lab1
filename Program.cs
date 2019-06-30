using System;
using System.Collections.Generic;
using System.Reflection;

namespace lab1
{
    class Program
    {
        static IVector3f EnterVector(Type Realization)
        {
            float x, y, z;
            string[] words;
            string str = string.Empty;

            do
            {
                Console.WriteLine("Enter vector coordinates in format <x> <y> <z>, ex.: 1.23 4.56 7.89");
                str = Console.ReadLine();
                words = str.Split();
                Console.WriteLine(words.Length);
            } while (words.Length != 3 || !float.TryParse(words[0], out x) || !float.TryParse(words[1], out y) || !float.TryParse(words[2], out z));

            return (IVector3f)Activator.CreateInstance(Realization, x, y, z);

        }

        static int Ask(string question, List<string> variants)
        {
            Console.WriteLine(question);

            for(int i = 0; i < variants.Count; i++)
            {
                Console.WriteLine($"{i}: {variants[i]}");
            }
            
            int answer = 0;
            string str = string.Empty;

            while(true)
            {
                try
                {
                    str = Console.ReadLine();
                    answer = int.Parse(str);
                    if (answer > variants.Count - 1 || answer < 0)
                    {
                        throw new IndexOutOfRangeException($"Must be within 0 and {variants.Count - 1}");
                    }
                    break;
                } catch (Exception)
                {
                    Console.WriteLine("Wrong answer!");
                }
            }

            return answer;
        }

        static Type EnterRealization()
        {
            int answer;
            var realizations = new List<string> { typeof(Vector3f).Name, typeof(VerboseVector3f).Name };
            answer = Ask(
                "What realization must be used?",
                realizations
                );

            return Type.GetType(MethodBase.GetCurrentMethod().DeclaringType.Namespace +"." + realizations[answer]);
        }

        static void Main(string[] args)
        {
            Type Realization = EnterRealization();

            IVector3f current = EnterVector(Realization);

            int answer;
            do
            {
                answer = Ask(
                    "What you want to do?",
                    new List<string> {
                        "Exit",
                        "Change realization",
                        "Enter new vector",
                        "Print current vector",
                        "Print lenth of current vector",
                        "Calculate sum with another vector",
                        "Calculate difference with another vector",
                        "Calculate dot product with another vector",
                        "Calculate cos between this and another vector",
                    });

                IVector3f another = null;
                switch (answer)
                {
                    case 0: return;
                    case 1:
                        Realization = EnterRealization();
                        current = (IVector3f)Activator.CreateInstance(Realization, current.X, current.Y, current.Z);
                        break;
                    case 2: current = EnterVector(Realization); break;
                    case 3: Console.WriteLine($"Current vector is {current.ToString()}"); break;
                    case 4: Console.WriteLine($"Current vector's lenght is {current.Lenght()}"); break;
                    case 5:
                        another = EnterVector(Realization);
                        Console.WriteLine($"Sum of vectors {current} and {another} is {current.Sum(another)} ");
                        break;
                    case 6:
                        another = EnterVector(Realization);
                        Console.WriteLine($"Difference of vectors {current} and {another} is {current.Diff(another)} ");
                        break;
                    case 7:
                        another = EnterVector(Realization);
                        Console.WriteLine($"Dot product of vectors {current} and {another} is {current.Dot(another)} ");
                        break;
                    case 8:
                        another = EnterVector(Realization);
                        Console.WriteLine($"Cosine between vectors {current} and {another} is {current.Cos(another)} ");
                        break;
                    default: Console.WriteLine("Wrong answer!"); break;
                }
            } while (answer != 0);
        }
    }
}
