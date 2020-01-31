using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NewYearsResolutions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This a list of your New Year Resolutions.");
            Console.WriteLine("Insert your resolutions separated by a comma and a space (, ).");
            string userinput = Console.ReadLine();
            string[] Resolutions = userinput.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> listOfResolutions = Resolutions.ToList();

            Start:
            string filePath = @"Users\andrisuga\Desktop\FailidVS\NewYearRes.txt";
            File.WriteAllLines(filePath, listOfResolutions);
            List<Resolutions> listOfDescriptions = new List<Resolutions>();

            foreach (string line in listOfResolutions)
            {

                Resolutions newRes = new Resolutions(line);
                listOfDescriptions.Add(newRes);
                File.WriteAllLines(filePath, listOfResolutions);
            }


            int i = 1;

            foreach (Resolutions resolutions in listOfDescriptions)
            {
                Console.WriteLine($"Resolution {i} on your resolutions list is to {resolutions.description}");
                i++;
            }

            Console.WriteLine("ADD/REMOVE/EXIT.");
            string userAnswer = Console.ReadLine();

            if (userAnswer.ToLower() == "add")
            {
                Console.WriteLine("Enter a resolution to add: ");
                string newRes = Console.ReadLine();
                listOfResolutions.Add(newRes);

                Console.Clear();
                Console.WriteLine("A resolution was added.");
                goto Start;
            }
            else if (userAnswer.ToLower() == "remove")
            {
                Console.WriteLine("Enter a resolution to remove: ");
                string removeRes = Console.ReadLine();
                listOfResolutions.Remove(removeRes);

                Console.Clear();
                Console.WriteLine("A resolution was removed.");
                goto Start;
            }
            else
            {
                Console.Clear();
                int j = 1;

                foreach (Resolutions resolutions in listOfDescriptions)
                {
                    Console.WriteLine($"Resolution {j} on your resolutions list is to {resolutions.description}");
                    j++;
                }
            }
        }

        class Resolutions
        {
            public string description;

            public Resolutions(string _description)
            {
                description = _description;

            }
        }
    }

}
