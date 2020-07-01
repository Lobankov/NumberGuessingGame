using System;

namespace NumberGuessingGame
{
    class Program
    {
        #region Fields

        private static int _lowerRange;

        private static int _upperRange;

        private static int _guessNumber;

        private static int _userGuessNumber;

        private static int _numberOfAttempts;

        #endregion

        static void Main(string[] args)
        {
            Introduce();
            
            while (true)
            {
                GetLowerAndUpperRangeFromUser();

                GenerateGuessNumber();

                StartGuessing();

                if (!UserWantToPlayAgain())
                    break;
            }

            SayGoodBye(); 
        }

        #region Methods

        static void Introduce()
        {
            Console.WriteLine("Welcome, contesntant!");
        }

        static void GetLowerAndUpperRangeFromUser()
        {
            Console.WriteLine("Please specify the lowest number I can think about");
            var lowerRangeIsGiven = false;
            do
            {                
                var lowerValue = Console.ReadLine();
                if (int.TryParse(lowerValue, out _lowerRange))
                    lowerRangeIsGiven = true;
                else
                    Console.WriteLine("This is not a valid number. Please try again");
            }
            while (!lowerRangeIsGiven);

            Console.WriteLine("Now specify the highest number I can think about");
            var upperRangeIsGiven = false;
            do
            {                
                var upperValue = Console.ReadLine();
                if (int.TryParse(upperValue, out _upperRange))
                {
                    if(_upperRange > _lowerRange)
                        upperRangeIsGiven = true;
                    else
                        Console.WriteLine($"The highest number must be greater than the lowest ({_lowerRange})");
                }
                else
                {
                    Console.WriteLine("This is not a valid number. Please try again");
                }
            }
            while (!upperRangeIsGiven);
        }

        static void GenerateGuessNumber()
        {
            _guessNumber = new Random().Next(_lowerRange, _upperRange);
            Console.WriteLine($"Take a guess what I'm thinking... Any number between {_lowerRange} and {_upperRange}");
        }

        static void GetProperGuessNumber()
        {            
            var numberIsValid = false;
            do
            {
                var guessValue = Console.ReadLine();
                if (int.TryParse(guessValue, out _userGuessNumber))
                {
                    if(_userGuessNumber >= _lowerRange && _userGuessNumber <= _upperRange)
                        numberIsValid = true;
                    else
                        Console.WriteLine($"Do you remember our range? The lowest possible is {_lowerRange}, the highest possible is {_upperRange}. Try again");
                }
                else
                    Console.WriteLine("Well, not quite what I've expected. Please try again");
            }
            while (!numberIsValid); 
        }

        static void StartGuessing()
        {
            while (true)
            {
                GetProperGuessNumber();
                _numberOfAttempts++;

                if (_userGuessNumber > _guessNumber)
                    Console.WriteLine("Not exactly. I am thinking of a nubmer that is lower");   
                else if(_userGuessNumber < _guessNumber)                
                    Console.WriteLine("Not exactly. I am thinking of a nubmer that is higher");                
                else
                {
                    Console.WriteLine("Good job! You get it!");
                    Console.WriteLine($"It took you {_numberOfAttempts} attempt{(_numberOfAttempts > 1 ? "s" : string.Empty)}");
                    break;
                }
            }
        }

        static bool UserWantToPlayAgain()
        {
            Console.WriteLine("Wanna try again?");
            var answer = Console.ReadLine();

            return answer == string.Empty || answer.ToLower().Contains("y") || answer.ToLower().Contains("+");                
        }

        static void SayGoodBye()
        {
            Console.WriteLine("Well, good luck sir. See you next time");
        }

        #endregion
    }
}
