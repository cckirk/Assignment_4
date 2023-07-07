using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Numerics;
using System.Security.Cryptography;

interface ISpeak
{
    string greeting();
    string getInformation();
    string sayGoodbye();
}

abstract class Character : ISpeak
{
    private string description = null;
    private string whoami = null;
    public Character(string d, string w)
    {
        description = d;
        whoami = w;
    }
    public string getDescription()
    {
        return description;
    }
    public bool guessWho(string guess)
    {
        string lowerGuess = guess.ToLower();
        string rightAns = whoami.ToLower();
        return (lowerGuess.Equals(rightAns));
    }
    public string getCharacterName()
    {
        return whoami;
    }
    public abstract string greeting();
    public abstract string getInformation();
    public abstract string sayGoodbye();
}

class Room
{
    static int nextRoomNum = 1;
    int roomNum;
    Character personInRoom;
    public Room()
    {
        roomNum = nextRoomNum++;
        if (roomNum == 1)
        {
            personInRoom = new CharacterOne();
        }
        else if (roomNum == 2)
        {
            personInRoom = new CharacterTwo();
        }
        else
        {
            personInRoom = new CharacterThree();
        }
        Console.WriteLine("Welcome to roomnumber "+roomNum);
        Console.WriteLine("In here we have a fascinating character from popular movies...");
        Console.WriteLine("Movie character, please tell us a little about yourself...");
        Console.WriteLine();
        Console.WriteLine(""+personInRoom.getDescription());
        Console.WriteLine(""+personInRoom.greeting());
        Console.WriteLine();
    }
    public void askForSecret()
    {
        Console.WriteLine("Okay, movie character,tell me a secret");
        Console.WriteLine();
        Console.WriteLine("" + personInRoom.getInformation());
        Console.WriteLine();
    }
    public void sayGoodbye()
    {
        Console.WriteLine("Thank you" + personInRoom.getCharacterName());
        Console.WriteLine();
        Console.WriteLine("" + personInRoom.sayGoodbye());
        Console.WriteLine();
    }
    public void guessWho(string nameGuess)
    {
        if (personInRoom.guessWho(nameGuess))
        {
            Console.WriteLine("Congratulations you guessed " + nameGuess + " correctly.");
            Console.WriteLine("" + personInRoom.getCharacterName() + " says " + personInRoom.sayGoodbye());
        }
        else
        {
            Console.WriteLine("I'm sorry it's not" + nameGuess + " it was" + personInRoom.getCharacterName());
            Console.WriteLine("" + personInRoom.getCharacterName() + " says" + personInRoom.sayGoodbye());
        }
    }
}

class CharacterOne : Character
{
    public CharacterOne() : base ("Jedi", "Yoda")
    {
    }

    public override string greeting()
    {
        return "Yoda I am";
    }
    public override string getInformation()
    {
        return "Jedi";
    }
    public override string sayGoodbye()
    {
        return "Goodbye";
    }
}


class CharacterTwo : Character
{
    public CharacterTwo() : base ("Jedi","Luke")
    {
        
    }
    public override string greeting()
    {
        return "Hello Im luke";
    }
    public override string getInformation()
    {
        return "Jedi";
    }
    public override string sayGoodbye()
    {
        return "Goodbye";
    }
}

class CharacterThree : Character    
{
    public CharacterThree() : base ("robot" ,"r2")
    {
        
    }
    public override string greeting()
    {
        return "Beep boop";
    }
    public override string getInformation()
    {
        return "Droid";
    }
    public override string sayGoodbye()
    {
        return "Beep";
    }
}
class Program
{
    public static void Main(string[] args)
    {
        for (int i = 0; i < 3; i++)
        {
            Room newRoom = new Room();
            Console.WriteLine("If you know who it is guess, if you don't type hint");
        String theGuess = Console.ReadLine();
            if (theGuess.Equals("hint"))
            {
                newRoom.askForSecret();
                Console.WriteLine("OK, so who is it?");
                String finalGuess = Console.ReadLine();
                newRoom.guessWho(finalGuess);
            }
            else
            {
                newRoom.guessWho(theGuess);
            }
        }
    }
}