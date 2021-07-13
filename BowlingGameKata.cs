using System;

namespace BowlingGameKataCSharp
{
    class BowlingGameKata
    {
        static void Main(string[] args)
        {
            Game game1 = new GameImpl();
            game1.Roll(new int[] {10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10});
            // Score : 300
            Console.WriteLine("Score : " + game1.Score());

            Game game2 = new GameImpl();
            game2.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 0});
            // Score : 131
            Console.WriteLine("Score : " + game2.Score());

            Game game3 = new GameImpl();
            game3.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 1, 10});
            // Score : 143
            Console.WriteLine("Score : " + game3.Score());

            Game game4 = new GameImpl();
            game4.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 10, 10, 10});
            // Score : 163
            Console.WriteLine("Score : " + game4.Score());
        }
    }

    interface Game {
        void Roll(int pins);
        void Roll(int[] pins);
        int Score();
    }


    class GameImpl : Game
    {
        private int[] rolls = new int[21];
        private int[] frame = new int[10];
        int currentRoll = 0;
        private bool isSpare(int frameIndex) {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
        }

        private bool isStrike(int frameIndex)
        {
            return rolls[frameIndex] == 10;
        }

        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public void Roll(int[] pins)
        {
            for(int i = 0; i < pins.Length; i++)
            {
                rolls[currentRoll++] = pins[i];
            }
        }

        public int Score()
        {
            int score = 0;
            int frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (isSpare(frameIndex))
                {
                    score += 10 + rolls[frameIndex + 2];
                    frameIndex += 2;
                }
                else if (isStrike(frameIndex))
                {
                    score += 10 + rolls[frameIndex + 1] + rolls[frameIndex + 2];
                    frameIndex++;
                }
                else
                {
                    score += rolls[frameIndex] + rolls[frameIndex + 1];
                    frameIndex += 2;
                }
            }
            return score;
        }
    }
}
