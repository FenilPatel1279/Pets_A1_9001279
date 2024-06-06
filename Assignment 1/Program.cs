using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
    public static class PetTypes
{
    //Constant values for pet types
    public const string Cat = "Cat";
    public const string Dog = "Dog";
    public const string Rabbit = "Rabbit";
}

public class Pet
{
    // Attributes of the Pet class.
    public string Name { get; set; }
    public string Type { get; set; }
    public int Hunger { get; set; }
    public int Happiness { get; set; }
    public int Health { get; set; }

    // Construct for launching pet attributes.
    public Pet(string name, string type)
    {
        Name = name;
        Type = type;
        Hunger = 5;
        Happiness = 5;
        Health = 5;
    }


    public void Feed()  // Ways to feed the pet
    {
        Hunger = Math.Max(Hunger - 2, 0);
        Health = Math.Min(Health + 1, 10);
        Console.WriteLine($"You fed {Name}. His Hunger decreases and Health improves slightly");
    }


    public void Play()      // ways to play with the pet
    {
        Happiness = Math.Min(Happiness + 2, 10);
        Hunger = Math.Min(Hunger + 1, 10);
        Console.WriteLine($"You played with {Name}. His happiness increases, but he's a bit hungry");
    }

    public void Rest()      // ways to let the pet rest

    {
        Health = Math.Min(Health + 2, 10);
        Happiness = Math.Max(Happiness - 1, 0);
        Console.WriteLine($"{Name} rested for a while, his health increased but his happiness decreased");
    }

    public void DisplayStatus() // Ways to display the pet status
    {
        Console.WriteLine($"Status of {Name}:");
        Console.WriteLine($"Hunger: {Hunger}");
        Console.WriteLine($"Happiness: {Happiness}");
        Console.WriteLine($"Health: {Health}");
    }
}

class Program
{
    static void Main(string[] args)
    {

        string petType = SelectPetType();    // Pet type selection
        Console.WriteLine($"You have chosen a {petType}.");


        Console.Write("Enter the name of your pet: ");   // Naming pat 
        string name = Console.ReadLine();


        Pet pet = new Pet(name, petType);    // Create a new pet instance
        Console.WriteLine($"You have created a {petType} named {name}.");


        while (true)  // Main contact loop.
        {
            Console.WriteLine($"\nWhat would you like to do with {name}?");
            Console.WriteLine("1. Feed the pet");
            Console.WriteLine("2. Play with the pet");
            Console.WriteLine("3. Let the pet rest");
            Console.WriteLine("4. Check pet status");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            // Read user input
            string choice = Console.ReadLine();

            // Handle user input
            switch (choice)
            {
                case "1":
                    pet.Feed();
                    break;
                case "2":
                    pet.Play();
                    break;
                case "3":
                    pet.Rest();
                    break;
                case "4":
                    pet.DisplayStatus();
                    break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }


            pet.Hunger = Math.Min(pet.Hunger + 1, 10);
            pet.Happiness = Math.Max(pet.Happiness - 1, 0);

            // Status check
            if (pet.Hunger == 10)
            {
                Console.WriteLine($"{pet.Name} is starving!");
            }
            if (pet.Happiness == 0)
            {
                Console.WriteLine($"{pet.Name} is very unhappy!");
            }
        }
    }

    static string SelectPetType()
    {
        while (true)
        {
            Console.WriteLine("Select the type of pet:");
            Console.WriteLine("1. Cat");
            Console.WriteLine("2. Dog");
            Console.WriteLine("3. Rabbit");
            Console.Write("User Input: ");


            string choice = Console.ReadLine();


            switch (choice)
            {
                case "1":
                    return PetTypes.Cat;
                case "2":
                    return PetTypes.Dog;
                case "3":
                    return PetTypes.Rabbit;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}