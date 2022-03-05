using System;

namespace Quest
{
    public class Prize
    {
        private string _text = "";

        public void ShowPrize(Adventurer givenAdventurer)
        {
            if (givenAdventurer.Awesomeness > 0)
            {
                Console.WriteLine(_text);
            }
            else
            {
                Console.WriteLine("I pity you.");
            }
        }

        public Prize(string inputText)
        {
            _text = inputText;
        }
    }
}