using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge

            Prize bigTrophy = new Prize("A very large trophy");

            Robe newRobe = new Robe
            {
                Color = new List<string> { "red", "blue", "green" },
                Length = 42
            };
            Hat newHat = new Hat
            {
                ShininessLevel = 5
            };
            Console.Write("Please Enter Your Name: ");
            // Make a new "Adventurer" object using the "Adventurer" class
            Adventurer theAdventurer = new Adventurer(Console.ReadLine(), newRobe, newHat);
            Console.WriteLine(theAdventurer.GetDescription());
            bool userContinue = true;

            int correctAnswers = 0;

            while (userContinue)
            {
                Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
                Challenge theAnswer = new Challenge(
                    "What's the answer to life, the universe and everything?", 42, 25);
                Challenge whatSecond = new Challenge(
                    "What is the current second?", DateTime.Now.Second, 50);

                int randomNumber = new Random().Next() % 10;
                Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

                Challenge favoriteBeatle = new Challenge(
                    @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                    4, 20
                );
                Challenge chiTrip = new Challenge("How many miles is it from Chicago to New York?", 796, 30);
                Challenge abbaAlbums = new Challenge("How many studio albums has the swedish pop group ABBA released?", 9, 25);
                Challenge midwestStates = new Challenge("How many states make up the Midwestern United States?", 12, 20);

                // "Awesomeness" is like our Adventurer's current "score"
                // A higher Awesomeness is better

                // Here we set some reasonable min and max values.
                //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
                //  If an Adventurer has an Awesomeness less than the min, they are terrible
                int minAwesomeness = 0;
                int maxAwesomeness = 100;

                theAdventurer.Awesomeness += (correctAnswers * 10);

                // A list of challenges for the Adventurer to complete
                // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
                List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                chiTrip,
                abbaAlbums,
                midwestStates
            };

                List<int> challengeSelections = new List<int>();

                while (challengeSelections.Count < 5)
                {
                    int randomIndexSelection = new Random().Next(0, challenges.Count);
                    if (!challengeSelections.Contains(randomIndexSelection))
                    {
                        challengeSelections.Add(randomIndexSelection);
                    }
                }

                foreach (int index in challengeSelections)
                {
                    int preChallengeAwesomeness = theAdventurer.Awesomeness;
                    challenges[index].RunChallenge(theAdventurer);
                    if (preChallengeAwesomeness > theAdventurer.Awesomeness)
                    {
                        correctAnswers--;
                    }
                    else
                    {
                        correctAnswers++;
                    }
                }

                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
                }
                bigTrophy.ShowPrize(theAdventurer);
                Console.WriteLine("Continue? (y/n): ");
                string userChosenContinue = Console.ReadLine().ToLower();
                if (userChosenContinue == "n")
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}