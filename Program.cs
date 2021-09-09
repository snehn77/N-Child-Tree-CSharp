using System;

namespace NChildTree
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declaring a new tree with a parameter of max child a node can hold. In this case it is 3 i.e. each node can hold a max of 3 childs
            Tree<int> tree = new Tree<int>(3);
            int flag = 0;
        redo:
            Console.Clear();
            ShowOptions();
            int choice = Choice();
            while (flag == 0)
            {
                switch (choice)
                {
                    case 1:
                        tree.Insert();
                        PressToContinue();
                        goto redo;

                    case 2:
                        tree.Delete();
                        PressToContinue();
                        goto redo;

                    case 3:
                        int value = tree.GetValue();
                        Console.WriteLine("\n" + tree.Contains(value));
                        PressToContinue();
                        goto redo;

                    case 4:
                        tree.GetElementByValue();
                        PressToContinue();
                        goto redo;

                    case 5:
                        tree.GetElementByLevel();
                        PressToContinue();
                        goto redo;

                    case 6:
                        tree.IteratorDFS();
                        PressToContinue();
                        goto redo;

                    case 7:
                        tree.IteratorBFS();
                        PressToContinue();
                        goto redo;
                    case 8:
                        tree.PrintDFS();
                        PressToContinue();
                        goto redo;

                    case 9:
                        tree.PrintBFS();
                        PressToContinue();
                        goto redo;

                    case 0:
                        flag = 1;
                        break;

                    default:
                        goto redo;
                }
            }
        }

        public static void ShowOptions()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press 0 ---> Exit");
            Console.WriteLine("Press 1 ---> Insert");
            Console.WriteLine("Press 2 ---> Delete");
            Console.WriteLine("Press 3 ---> Contains");
            Console.WriteLine("Press 4 ---> Get Element by Value");
            Console.WriteLine("Press 5 ---> Get Element by Level");
            Console.WriteLine("Press 6 ---> Iterator Depth First");
            Console.WriteLine("Press 7 ---> Iteratot Breadth First");
            Console.WriteLine("Press 8 ---> Print Depth First");
            Console.WriteLine("Press 9 ---> Print Breadth First");
        }
        public static int Choice()
        {
        redo:
            Console.Write("\nEnter Choice of Operation: ");
            int choice;
            try
            {
                choice = int.Parse(Console.ReadLine());
                while (choice < 0 || choice > 9)
                {
                    Console.Write("\nPlease enter valid choice: ");
                    choice = int.Parse(Console.ReadLine());
                }
                return choice;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Invalid Type! Please enter a integer from the given choices");
                Console.ForegroundColor = ConsoleColor.White;
                goto redo;
            }
        }

        public static void PressToContinue()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\nPress Any Key to continue: ");
            Console.ReadKey();
        }
    }
}
