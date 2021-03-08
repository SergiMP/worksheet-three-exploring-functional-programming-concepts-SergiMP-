using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
//using System.Threading.Channels;
//using System.Xml.Serialization;


namespace Functional
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var message = "Please types at least one name separated by spaces. Like so \"Keith Steve\"";
             

             // 1. Action print. Reads a collection of names and prints them
             
             static void ProcessNames(List<String>names)
             {
                 names.ForEach(n=> Console.WriteLine(n));
             }
             
            Console.WriteLine(message);
            var names = Console.ReadLine()?.Split(" ").ToList();
            Action<List<String>> PrintNames = ProcessNames;
            PrintNames(names);

            Console.WriteLine("*****************************************");

            // 2. Knights of Honour. Reads a collection of String and adds Sir.

            static void AddSir(List<String> names)
            {
                names.ForEach(n => Console.WriteLine("Sir " + n));
            }

            Console.WriteLine($"{message}.Type q on a separated line to quit.\n");
            List<String> input = new List<string>();
            // we found the .IsNullOrWhiteSpace code on stack overflow since we didn't found a .hasNext()equivalent
            string line = line = Console.ReadLine();
            while (line != null && line.ToLower() != "q" & !(input.Contains("q")))
            {
                ;
                String[] inputNames = line.Split(" ");
                foreach (var name in inputNames)
                {
                    if (name == "q")
                    {
                        break;
                        
                    }else if (name == "")
                    {
                        continue;
                    }
                    else
                    {
                        input.Add(name);
                    }
                }

                line = Console.ReadLine();
            };
            
            Action<List<String>> PrintSir = AddSir;
            PrintSir(names);

            Console.WriteLine("*****************************************");


            // 3. Custom Min Function.

            static int Smallest(String[] numbers)
            {
                return numbers.Select(Int32.Parse).OrderBy(n=>n ).FirstOrDefault();;
        
            }

            Console.WriteLine("Please enter a series of numbers. Like so \"1 3 4 5 77 5\"\n");
            var numbers = Console.ReadLine()?.Split(" ");
            Func< String[], int> Min = Smallest;
            Console.WriteLine(Min(numbers));
            
            
            // 4. Find evens or Odds in a given range. Use Predicate<T>
            Console.WriteLine("Please enter two numbers representing the beginning and the end of a range (both inclusive).\n");
            var userNumbers = Console.ReadLine().Split(" ").ToList().Select(int.Parse).ToList();
            Console.WriteLine("Type even or odd to quit and see the desired output.\n");
            var evenOrodd = Console.ReadLine()?.ToLower();
            Predicate<int> EvenOdd = evenOrodd switch
            {
                "odd" => (x => x % 2 != 0),
                "even" => (x => x % 2 == 0)                
                // assuming the input is always correct we only added even/odd conditions.
            };
            Enumerable.Range(userNumbers[0],userNumbers[1]).Where(x=> EvenOdd(x)).ToList().ForEach(n => Console.WriteLine(n));

            Console.WriteLine("*****************************************");
            
            // 5.Applied arithmetic
            //Write a program that executes some mathematical operations on a given collection. On the first line you are 
            //given a list of numbers. On the next lines you are passed different commands that you need to apply to
            //all numbers in the list:


            // We create a dictionary of functions
            Dictionary<string,Func<int,int>> methodsToApply = new Dictionary<string,Func<int,int>>();
            methodsToApply.Add("add", (x) => x + 1);
            methodsToApply.Add("subtract", x => x - 1);
            methodsToApply.Add("multiply", x => x * 2);

            Console.WriteLine("Please enter a series of numbers on which you would like to perform the operations i.e 1 2 3 4.\n");
            var numberList = Console.ReadLine()?.Split(" ").ToList().Select(x => x.Trim()).Select(s => Convert.ToInt32(s)).ToList();
            
            Console.WriteLine("Please enter a series of operations from this list [add, multiply, subtract or print].\n+" +
                              "Type 'end' to exit.\n");
            List<string> methodList = new List<string>();
            while (!(methodList.Contains("end")))
            {
             methodList.Add(Console.ReadLine().ToLower().TrimEnd());   
            }
            // remove end from the list
            methodList.RemoveAt(methodList.Count -1);


            // We create a method that takes a function and an integer that will be used in the foreach loop below

            static int ActionsOnNumber(Func<int,int> func,int number)
            {
                return func(number);
            }
  

            var resultFinal = new List<int>();


            for(var i =0; i <= methodList.Count-1; i++)
                {
                 

                    if (methodList[i] == "print")
                    {
                        numberList.ForEach(x => Console.Write($"{x} "));
                        Console.WriteLine("");

                    }
                    else
                    {

                        var tempresult = numberList.Select(x => ActionsOnNumber(methodsToApply[methodList[i]], x)).ToList();
                        numberList.Clear();
                        tempresult.ForEach(x => numberList.Add(x));
                    }

                        
                    
                }

            resultFinal.ForEach(x => Console.Write(x + " "));

            Console.WriteLine("*****************************************");


            //6.Reverse and exclude
            //Write a program that reverses a collection and removes elements that are divisible by a given integer n.
            //Use predicates/ functions.

            Console.WriteLine("Please enter a list of numbers, like so 1 2 3 4 5, press enter and type the divisor.\n");
            var numbersToReverse = Console.ReadLine()?.Split(" ").ToList().Select(x => x.Trim()).Select(s => Convert.ToInt32(s)).ToList().OrderByDescending(i => i).ToList();
            var divisor =Int32.Parse(Console.ReadLine());

            static bool Divisible(int number, int divisor)
            {
                return number % divisor != 0;
            }
             
            Func<int,int,bool> isDivisible = Divisible;

            numbersToReverse.Where(x => isDivisible(x, divisor)).ToList().ForEach(x => Console.Write($"{x} "));
            Console.WriteLine("");
            Console.WriteLine("*****************************************");


            // 7.Predicate for names
            // Write a program that filters a list of names according to their length.On the first line you will be given integer n representing name length.On the second line 
            // you will be given some names as strings separated by space.Write a function that prints only the names whose length is less than or equal to n.

            Console.WriteLine("Please enter a number representing the length of the name, press enter and then the list of names separated by a space. \n");
            var lengthFilter = Int32.Parse(Console.ReadLine());
            var userNames = Console.ReadLine().Split(" ").ToList();

            static void FilterNames(int lengthname, List<string> names)
            {
                names.Where(x => x.Length <= lengthname).ToList().ForEach(x=> Console.WriteLine(x));
                
            }

            FilterNames(lengthFilter, userNames);

            Console.WriteLine("*****************************************");


            // 8.Custom Comparator
            // Write a custom comparator that sorts all even numbers before all odd ones in ascending order. Pass it to an Array.sort() function and print the result.

            static void Comparator(List<int> numbersToSort)
            {
                var evenNumbers = numbersToSort.Where(x => x % 2 == 0);
                Array.Sort(evenNumbers.ToArray());
                var oddNumbers = numbersToSort.Where(x => x % 2 != 0);
                Array.Sort(oddNumbers.ToArray());
                evenNumbers.Concat(oddNumbers).ToList().ForEach(x => Console.Write($"{x} "));
            }

            Console.WriteLine("Please enter a list of numbers, like so 1 2 3 4 5 \n");
            var userNumber = Console.ReadLine()?.Split(" ").ToList().Select(x => x.Trim()).Select(s => Convert.ToInt32(s)).ToList();
            Comparator(userNumber);
            Console.WriteLine();

            Console.WriteLine("*****************************************");



            // 9.List of Predicates
            // Find all numbers in the range 1..N that are divisible by the numbers of a given sequence.
            // Use predicates/ functions.

            static bool DivisibleByNumbers(int number, List<int> divisor)
            {
                return divisor.All( x=> number % x == 0);
            }

            Console.WriteLine("Please enter the final number of the range: \n");
            var rangeNumber = Enumerable.Range(1,Int32.Parse(Console.ReadLine())).ToList();

            Console.WriteLine("Please enter the list of  numbers of the range: \n");
            var divisorNumbers = Console.ReadLine()?.Split(" ").ToList().Select(x => x.Trim()).Select(s => Convert.ToInt32(s)).ToList();

            Func<int, List<int>, bool> DivisorOrgy = DivisibleByNumbers;
            rangeNumber.Where(x => DivisorOrgy(x, divisorNumbers)).ToList().ForEach(x => Console.Write($"{x} "));
            Console.WriteLine("");
            Console.WriteLine("*****************************************");
            
            //10.Predicates Galore!
            //Fred's parents are on a vacation for the holidays and he is planning an epic party at home. Unfortunately, his organisational skills are next to non-existent 
            //so you are given the task to help him with the reservations.

            //On the first line you get a list with all the people that are coming.On the next lines, until you get the "Party!" command, you may be asked to double or remove 
            //all the people that apply to given criteria.There are three different criteria are:
            //Everyone that has a name starting with a given string;
            //Everyone that has a name ending with a given string;
            //Everyone that has a name with a given length.
            
            Console.WriteLine("Please enter the names and the instructions on separated lines \n");
            var namess = Console.ReadLine().Split().ToList();
            List<List<string>> instructions = new List<List<string>>();
            do
            {
                instructions.Add(Console.ReadLine().Split().ToList());

            } while (!(instructions[instructions.Count-1].Contains("Party!")));

            //We added .ToLower() to ensure that different cases won't case any issues

            foreach (var command in instructions)
            {
                if (command[0].ToLower() == "double")
                {
                    if (command[1].ToLower() == "startswith")
                    {

                        var adjustAdd = namess.Where(x => x.ToLower().StartsWith(command[2].ToLower())).ToList();
                        adjustAdd.ForEach(x => namess.Add(x));

                    }
                    else if (command[1] == "EndsWith")
                    {
                        var adjustAdd = namess.Where(x => x.ToLower().EndsWith(command[2].ToLower())).ToList();
                        adjustAdd.ForEach(x => namess.Add(x));

                    }
                    else // lenght of string condition
                    {

                        var adjustAdd = namess.Where(x => x.Length.ToString() == (command[2])).ToList();
                        adjustAdd.ForEach(x => namess.Add(x));

                    }
                } else if (command[0].ToLower() == "remove")
                {
                    if (command[1].ToLower() == "startswith")
                    {

                        var adjustRemove = namess.Where(x => !(x.ToLower().StartsWith(command[2].ToLower()))).ToList();
                        namess.Clear();
                        adjustRemove.ForEach(x => namess.Add(x));

                    }
                    else if (command[1].ToLower() == "endswith")
                    {
                        var adjustRemove = namess.Where(x => !(x.ToLower().EndsWith(command[2].ToLower()))).ToList();
                        namess.Clear();
                        adjustRemove.ForEach(x => namess.Add(x));

                    }
                    else // lenght of string condition
                    {
                        var adjustRemove = namess.Where(x => !(x.Length.ToString() == (command[2]))).ToList();
                        namess.Clear();
                        adjustRemove.ForEach(x => namess.Add(x));
                    }
                }
                else
                {
                    List<string> partyGuest = new List<string>();
                    namess.ForEach(x => partyGuest.Add(x));
                    partyGuest.Sort();
                    var guestPartyList = string.Join(", ", partyGuest.ToArray());
                    if (partyGuest.Count == 0)
                    {
                        Console.WriteLine("Everybody is self-isolating, no party!");
                    } else if (partyGuest.Count == 1)
                    {
                        Console.WriteLine($"{guestPartyList} is the only one partying!");
                    }
                    else {
                        Console.WriteLine($"{guestPartyList} are going to the party!");
                    }
                }

          
            }

            Console.WriteLine("*****************************************");
        }
    }
}