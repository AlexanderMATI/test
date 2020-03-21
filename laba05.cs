using System;
using System.Collections.Generic;
using System.IO;

namespace laba05
{
    class laba05
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Launch the console? Y/N");
            ConsoleKeyInfo change = Console.ReadKey() ;
            string tempString = string.Empty; 

            if (change.Key == ConsoleKey.N)
            {

                string filename = string.Empty;
                while (true)
                {
                    Console.WriteLine("Enter name of your file after his path: ");
                filename = Console.ReadLine();

                    if (!File.Exists(filename))
                    {
                        Console.WriteLine("File does not exists. Repeat enter? Y/N");

                        change = Console.ReadKey();
                        if (change.Key == ConsoleKey.Y)
                            continue;
                        else return;
                        
                         }
                    break;
                    }//end while
                

                try
                {
                    using (StreamReader readerFile = new StreamReader(filename))
                    {
                        tempString = readerFile.ReadLine();

                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error until reading file: " + e.Message);
                    Console.ReadKey();
                    return;
                }
            }



            else if (change.Key == ConsoleKey.Y)
            {

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Enter the number and number system");
                    tempString = Console.ReadLine();
                    if (tempString.Length == 0)
                    {
                        Console.WriteLine("Enter is empty, finish? Y/*AnySymbol");
                        change = Console.ReadKey();
                        if (change.Key == ConsoleKey.Y)
                            return;
                        else continue;
                    }
                    break;
                }//end while
            }
            else return;
            var Array = tempString.Split(' ', ',');
            Array[1] = "0," + Array[1];
            Boolean okey = true;

            var numList = new List<decimal>();
            if (Array.Length == 3)
            {
                for (int i = 0; i < Array.Length; i++)
                {
                    decimal num;
                    okey = decimal.TryParse(Array[i], out num);
                    if (okey)
                    {
                        numList.Add(num);
                    }
                    else
                    {
                        Console.WriteLine("Wrong symbols");
                        Console.ReadKey();
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("Error empty");
                Console.ReadKey();
                return;
            }
            if (numList[2] >= 2)
            {
                Console.WriteLine(Functions.NumtoSystem((int)numList[0], numList[1], (int)numList[2]));
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Error empty");
                Console.ReadKey();
                return;
            }
        }
    }
}
