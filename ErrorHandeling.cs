using System;
using System.Collections.Generic;
using System.Text;

namespace NChildTree
{
    public class ErrorHandeling
    {
        public int GetRootValue()
        {
        redo:
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nEnter Value of Root Node: ");
                int value = int.Parse(Console.ReadLine());
                return value;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid Type. Please enter a integer");
                Console.ForegroundColor = ConsoleColor.White;
                goto redo;
            }
        }
        public int GetValue()
        {
        redo:
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nEnter Value : ");
                int value = int.Parse(Console.ReadLine());
                return value;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid Type. Please enter a integer");
                Console.ForegroundColor = ConsoleColor.White;
                goto redo;
            }
        }
        public int GetValueLevel()
        {
        redo:
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nEnter Level : ");
                int value = int.Parse(Console.ReadLine());
                return value;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid Type. Please enter a integer");
                Console.ForegroundColor = ConsoleColor.White;
                goto redo;
            }
        }
        public int GetParent()
        {
        redo:
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nEnter Value of Parent: ");
                int value = int.Parse(Console.ReadLine());
                return value;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid Type. Please enter a integer");
                Console.ForegroundColor = ConsoleColor.White;
                goto redo;
            }
        }
        public void DFSQueue(List<int> queue, int value)
        {
            if (!(queue.Contains(value)))
            {
                queue.Add(value);
                Console.Write(value + " ");
            }
        }
        public int DFSQueueIterator(List<int> queue, int value)
        {
            if (!(queue.Contains(value)))
            {
                queue.Add(value);
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
