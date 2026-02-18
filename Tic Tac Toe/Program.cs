using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    internal class Program
    {

        static void Main(string[] args)
        {
            char?[] field = new char?[9];

            int[][] winCombination = new int[][]
            {
                [0,3,6],
                [1,4,7],
                [2,5,8], //Vertical

                [0,1,2],
                [3,4,5],
                [6,7,8], //Horizontal

                [0,4,8],
                [2,4,6] //Diagonal
            };

            string input = "";
            bool success;

            bool move = true; // if is true - user1, if false - user2

            string user1; // Player1
            string user2; // Player2

            bool game = true;

            int win1 = 0;
            int win2 = 0;
            int draws = 0;

            
            PlayerChoice();
           
            void Game()
            {
                while (game)
                {

                    if (move == true)
                    {
                        Console.WriteLine("User1: Select the field number.");
                        input = Console.ReadLine();
                        success = int.TryParse(input, out int putnumber);
                        putnumber -= 1;

                        if (putnumber < 0 || putnumber > 9)
                        {
                            Console.WriteLine("Error!\n");
                            success = false;
                        }
                        if (success)
                        {

                            if (field[putnumber] == null)
                            {
                                field[putnumber] = char.Parse(user1);
                                WinCheck1();
                                DrawCheck();
                                if (game == false)
                                {
                                    Menu();
                                }
                                move = false;
                                Showfield();
                            }
                            else
                            {
                                Console.WriteLine("This field is full");
                            }
                        }
                    }

                    if (move == false)
                    {
                        Console.WriteLine("User2: Select the field number.");
                        input = Console.ReadLine();
                        success = int.TryParse(input, out int putnumber);
                        putnumber -= 1;

                        if (putnumber < 0 || putnumber > 9)
                        {
                            Console.WriteLine("Error!\n");
                            success = false;

                        }
                        if (success)
                        {

                            if (field[putnumber] == null)
                            {
                                field[putnumber] = char.Parse(user2);
                                WinCheck2();
                                DrawCheck();
                                if (game == false)
                                {
                                    Menu();
                                }
                                move = true;
                                Showfield();
                            }
                            else
                            {
                                Console.WriteLine("This field is full");
                            }

                        }
                    }
                }
            }


            void Showfield()
            {
                for (int i = 0; i < field.Length; i++)
                {
                    Console.Write(field[i] + "\t|");
                    if (i == 2)
                    {
                        Console.Write("\n");
                    }
                    if (i == 5)
                    {
                        Console.Write("\n");
                    }
                    if (i == 8)
                    {
                        Console.Write("\n");
                    }
                }
            }

            void WinCheck1()
            {
                for (int i = 0; i < winCombination.Length; i++)
                {
                    if (field[winCombination[i][0]] == field[winCombination[i][1]] &&
                        field[winCombination[i][1]] == field[winCombination[i][2]] &&
                        field[winCombination[i][0]].HasValue)
                    {
                        game = false;
                        Showfield();
                        Console.WriteLine("\nWin! Player1 can celebrate!\n");
                        win1++;                    
                    }

                }
            }
            void WinCheck2()
            {
                for (int i = 0; i < winCombination.Length; i++)
                {
                    if (field[winCombination[i][0]] == field[winCombination[i][1]] &&
                        field[winCombination[i][1]] == field[winCombination[i][2]] &&
                        field[winCombination[i][0]].HasValue)
                    {
                        game = false;
                        Showfield();
                        Console.WriteLine("\nWin! Player2 can celebrate!\n");
                        win2++;
                    }

                }
            }
            void DrawCheck()
            {
                if (!field.Contains(null) && game == true)

                {
                    Showfield();
                    Console.WriteLine("draw\n");
                    draws++;
                    game = false;
                }
            }

            void Menu()
            {
                Console.WriteLine("Do you want to play again? 1 - Yes. 2 - No");
                string Choice = Console.ReadLine();
                if( Choice == "1")
                {
                    game = true;
                    Array.Clear(field, 0, field.Length);
                    PlayerChoice();
                }
                else if(Choice == "2") 
                {
                    Environment.Exit(0);
                }
                else {
                    Console.WriteLine("You need to choose 1 or 2");
                }

            }

            void PlayerChoice()
            {
                while (true)
                {
                    Console.WriteLine("User1: Which team do you want to play for?");
                    user1 = Console.ReadLine();
                    if (user1 == "x" || user1 == "o")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You have to choose between X and O\n");
                    }
                }

                while (true)
                {
                    Console.WriteLine("User2: Which team do you want to play for?");
                    user2 = Console.ReadLine();
                    if ((user2 == "x" || user2 == "o") && user2 != user1)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You have to choose between X and O, and distinguishing it from User1\n");
                    }
                }
                Console.WriteLine("\nWelcome to Tic Tac Toe!\n");
                Console.WriteLine($"\nPlayer1 wins: {win1}. Player2 wins: {win2}. Draws {draws}\n");
                move = true;
                Showfield();
                Game();
            }
        }
    }
}