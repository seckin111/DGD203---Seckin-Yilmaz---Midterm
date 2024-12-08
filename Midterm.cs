using System;
using System.Collections.Generic;

namespace SimpleGameOOP
{
    // Question class to represent each question
    class Question
    {
        public string Text { get; set; }
        public Dictionary<char, string> Choices { get; set; }
        public Dictionary<char, int> Scores { get; set; }

        public Question(string text, Dictionary<char, string> choices, Dictionary<char, int> scores)
        {
            Text = text;
            Choices = choices;
            Scores = scores;
        }
    }

    // Game class to manage the gameplay
    class Game
    {
        private string PlayerName { get; set; }
        private List<Question> Questions { get; set; }
        private int TotalScore { get; set; }

        public Game()
        {
            Questions = new List<Question>
            {
                new Question(
                    "What's your favorite kind of weather?",
                    new Dictionary<char, string>
                    {
                        {'a', "Sunny"},
                        {'b', "Rainy"},
                        {'c', "Snowy"}
                    },
                    new Dictionary<char, int>
                    {
                        {'a', 1},
                        {'b', 2},
                        {'c', 3}
                    }
                ),
                new Question(
                    "What's your ideal weekend activity?",
                    new Dictionary<char, string>
                    {
                        {'a', "Hiking"},
                        {'b', "Reading a book"},
                        {'c', "Playing video games"}
                    },
                    new Dictionary<char, int>
                    {
                        {'a', 1},
                        {'b', 2},
                        {'c', 3}
                    }
                ),
                new Question(
                    "What's your favorite color?",
                    new Dictionary<char, string>
                    {
                        {'a', "Blue"},
                        {'b', "Green"},
                        {'c', "Red"}
                    },
                    new Dictionary<char, int>
                    {
                        {'a', 1},
                        {'b', 2},
                        {'c', 3}
                    }
                ),
                new Question(
                    "What type of vacation do you prefer?",
                    new Dictionary<char, string>
                    {
                        {'a', "Beach"},
                        {'b', "Mountains"},
                        {'c', "City tour"}
                    },
                    new Dictionary<char, int>
                    {
                        {'a', 1},
                        {'b', 2},
                        {'c', 3}
                    }
                )
            };
        }

        public void Start()
        {
            Console.WriteLine("Welcome to the Game!");
            Console.Write("What's your name? ");
            PlayerName = Console.ReadLine();

            Console.WriteLine($"\nHello, {PlayerName}! Let's start the game.\n");

            foreach (var question in Questions)
            {
                AskQuestion(question);
            }

            DisplayResult();
        }

        private void AskQuestion(Question question)
        {
            Console.WriteLine(question.Text);
            foreach (var choice in question.Choices)
            {
                Console.WriteLine($"{choice.Key}) {choice.Value}");
            }

            char answer;
            do
            {
                Console.Write("Your answer: ");
                answer = Console.ReadKey().KeyChar;
                Console.WriteLine();
            } while (!question.Choices.ContainsKey(answer));

            TotalScore += question.Scores[answer];
        }

        private void DisplayResult()
        {
            Console.WriteLine($"\nThanks for playing, {PlayerName}!");
            if (TotalScore <= 6)
            {
                Console.WriteLine("You seem to love adventure and exploring the outdoors!");
            }
            else if (TotalScore <= 9)
            {
                Console.WriteLine("You're a mix of calm and excitement, finding joy in balance.");
            }
            else
            {
                Console.WriteLine("You enjoy comfort and creativity, thriving in relaxing and imaginative settings.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
