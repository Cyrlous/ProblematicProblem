using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    public class Program
    {
        static Random rng = new Random();
        static bool cont = true;

        private static List<string> activities = new List<string>()
            { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };


        static void Main(string[] args)
        {
            var userInput = "";
            var validInput = false;
            
            var userName = "";
            int userAge = 0;
            
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            do
            {
                userInput = Console.ReadLine().ToLower();
                
                switch (userInput)
                {
                    case "yes":
                    {
                        Console.WriteLine("Ok great.  Let's get started!");
                        validInput = true;
                        break;
                    }
                    case "no":
                    {
                        Console.WriteLine("All right, maybe next time.  Have a great day!");
                        return;
                    }
                    default:
                    {
                        Console.WriteLine("Please respond with yes or no.");
                        validInput = false;
                        break;
                    }
                }
            } while(!validInput);

            Console.WriteLine();
            Console.WriteLine("We are going to need your information first! What is your name? ");
            
            userName = Console.ReadLine();
            
            Console.WriteLine($"\nHello {userName}, nice to mee you!\n");
            Console.WriteLine("What is your age? ");
            while (!int.TryParse(Console.ReadLine(), out userAge) || userAge < 0)
            {
                Console.WriteLine("Please enter a valid age.");
            }
            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? yes/no: ");
            
            do
            {
                userInput = Console.ReadLine().ToLower();
                
                switch (userInput)
                {
                    case "yes":
                    {
                        Console.WriteLine("Here is a list of activities currently available:\n");
                        foreach (string activity in activities)
                        {
                            Console.WriteLine($"{activity} ");
                            Thread.Sleep(250);
                        }
                        validInput = true;
                        break;
                    }
                    case "no":
                    {
                        Console.WriteLine("Ok then, let's continue.");
                        validInput = true;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Please respond with yes or no.");
                        validInput = false;
                        break;
                    }
                }
            } while(!validInput);
            
            Console.WriteLine();
            
            do
            {
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                userInput = Console.ReadLine().ToLower();
                
                switch (userInput)
                {
                    case "yes":
                    {
                        Console.WriteLine("Please type the name of the activity you would like to add:\n");
                        userInput = Console.ReadLine();
                        activities.Add(userInput);
                        
                        Console.WriteLine("Here is the new list of activities:");
                        
                        foreach (string activity in activities)
                        {
                            Console.WriteLine($"{activity} ");
                            Thread.Sleep(250);
                        }
                        
                        Console.WriteLine();
                        Console.WriteLine("Would you like to add another? yes/no: ");
                        
                        userInput = Console.ReadLine();
                        while (userInput != "yes" && userInput != "no")
                        {
                            Console.WriteLine("Please answer yes or no.");
                            userInput = Console.ReadLine();
                        }

                        if (userInput == "yes")
                        {
                            validInput = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Ok then, let's continue.");
                            validInput = true;
                            break;
                        }
                    }
                    case "no":
                    {
                        Console.WriteLine("Ok then, let's continue.");
                        validInput = true;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Please respond with yes or no.");
                        validInput = false;
                        break;
                    }
                }
            } while(!validInput);
            
            Console.WriteLine();
            
            do
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();
                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();
                
                var randomNumber = rng.Next(activities.Count);
                var randomActivity = activities[randomNumber - 1];
                
                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                }

                Console.WriteLine($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();
                
                userInput = Console.ReadLine().ToLower();

                while (userInput != "keep" && userInput != "redo")
                {
                    Console.WriteLine("Please answer keep or redo.");
                }

                if (userInput == "keep")
                {
                    Console.WriteLine($"Ok, enjoy your time with {randomActivity} and have a great day!");
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Ok, let's generate a different activity for you.");
                    validInput = false;
                }
            }while(!validInput);
        }
    }
}