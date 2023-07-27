using System;
using System.Collections.Generic;

// The Model for my Application(this can also be the business logic of my C# app)

namespace RockPaperScissors.Models
{

    public class RPSGenerator
    {

        public int GetPlayerMove()
        {
            // Running the while loop here helps me ensure that my user is inputting what I want
            // THe int.TryParse() method takes in a string as an argument and then it outputs an integer for us
            // Before, the way I would naturally do that would have been to first store Console.ReadLine(
            // a string method) and then later, I will now have to write another variable again that will convert the string to integer using(int.Parse()) but with the int.TryParse() I am able to dry my code by one line


            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int move) && (move >= 0 && move <= 3))
                {
                    return move;
                }
                Console.WriteLine("Invalid input. Please choose a valid move.");
            }
        }


        // Moving the GetComputerMove() & DetermineWInner() method here... I no longer want everything on a single file; thats why I am putting it in this class


        // Making use of just the static access modifier; this method would be inaccessible in other files(i.e only in this file will access be granted to this method)
        // But thanks to the public access modifier, I can ensure my method is accessible accross everywhere in my application

        public int GetComputerMove()
        {
            Random random = new Random();
            return random.Next(1, 4);
        }

        public int DetermineWinner(int playerMove, int computerMove)
        {
            // all what this integer method does is that it determines the move of a player,
            // First, it takes in 2 integer variables which are both the player and computer move; dont forget we have been able to 
            // determine both player an dcomputer moves in our GetComputerMove() and GetPlayerMove() methods respectively... The computers own we used Random object and .Next() and the players own we used a while loop


            // the else if is to handle all of the different results we can get which is 1-3
            if (playerMove == computerMove)
            {
                return 0; // Tie
            }
            else if ((playerMove == 1 && computerMove == 3) ||
                     (playerMove == 2 && computerMove == 1) ||
                     (playerMove == 3 && computerMove == 2))
            {
                return 1; // Player wins
            }

            // With the else statement we return -1 to tell C# that the user lost and computer won
            else
            {
                return -1; // Computer wins
            }
        }


        // For getting the move name --> a string method
        // don't forget here; I also need to make use of the public access modifier.. there are other access modifiers like the protected internal, internal, private, private protected, protected
        // An access modifier controls how a class or a member of a class(int this case mathod) can be accessed


        public string GetMoveName(int move)
        {
            switch (move)
            {
                case 1:
                    return "Rock";
                case 2:
                    return "Paper";
                case 3:
                    return "Scissors";
                default:
                    return "Unknown";
            }
        }

    }

}




// The below can be regarded as a function but since I want to carry out a separation of concern(logic)
// I would now be writing it as a public method on the class RPSGenerator, and access it via my Entry Point file(Program.cs ---> the one housing my Main() function)


// static int GetPlayerMove()
// {
//     // Running the while loop here helps me ensure that my user is inputting what I want
//     // THe int.TryParse() method takes in a string as an argument and then it outputs an integer for us
//     // Before, the way I would naturally do that would have been to first store Console.ReadLine(
//     // a string method) and then later, I will now have to write another variable again that will convert the string to integer using(int.Parse()) but with the int.TryParse() I am able to dry my code by one line


//     while (true)
//     {
//         if (int.TryParse(Console.ReadLine(), out int move) && (move >= 0 && move <= 3))
//         {
//             return move;
//         }
//         Console.WriteLine("Invalid input. Please choose a valid move.");
//     }
// }


// C# doesn;t really have functions because there is no return statement here; 
// But C# has methods with which we can write for our classes and call those method 