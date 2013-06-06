namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class MinesweeperGame
    {
        private const int FieldRows = 5;
        private const int FieldColumns = 10;
        private const int MaxPoints = 35;

        private static readonly Random RandomGenerator = new Random();

        public class Score
        {
            private string name;
            private int points;

            public Score()
            {
            }

            public Score(string name, int points)
            {
                this.Name = name;
                this.Points = points;
            }

            public string Name
            {
                get { return this.name; }
                set { this.name = value; }
            }

            public int Points
            {
                get { return this.points; }
                set { this.points = value; }
            }
        }

        public static void Main()
        {
            char[,] gameField = InitializeGameField();
            char[,] minesField = InitializeMinesField();

            List<Score> topScores = new List<Score>(6);

            int points = 0;
            int row = 0;
            int col = 0;

            bool isStarting = true;
            bool hasHitMine = false;
            bool hasMaxPoints = false;

            string command = string.Empty;

            do
            {
                if (isStarting)
                {
                    Console.WriteLine("***Let's play \"Minesweeper\"! Try your luck finding all cells without mines***");
                    Console.WriteLine("---Enter 'top' to view the top scores board---");
                    Console.WriteLine("---Enter 'restart' to start a new game---");
                    Console.WriteLine("---Enter 'exit' to exit the game---");

                    PrintGameField(gameField);
                    isStarting = false;
                }

                Console.Write("Enter a row and a column separated by a space: ");
                command = Console.ReadLine().Trim();
                string[] coordinates = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (coordinates.Length == 2)
                {
                    if (int.TryParse(coordinates[0], out row) &&
                        int.TryParse(coordinates[1], out col) &&
                        row >= 0 && col >= 0 &&
                        row < gameField.GetLength(0) && col < gameField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintTopScoresBoard(topScores);
                        break;
                    case "restart":
                        gameField = InitializeGameField();
                        minesField = InitializeMinesField();
                        PrintGameField(gameField);
                        hasHitMine = false;
                        isStarting = false;
                        break;
                    case "exit":
                        Console.WriteLine("Goodbye! :)");
                        break;
                    case "turn":
                        if (minesField[row, col] != '*')
                        {
                            if (minesField[row, col] == '-')
                            {
                                UpdateFields(gameField, minesField, row, col);
                                points++;
                            }

                            if (points == MaxPoints)
                            {
                                hasMaxPoints = true;
                            }
                            else
                            {
                                PrintGameField(gameField);
                            }
                        }
                        else
                        {
                            hasHitMine = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nInvalid command! Try again...\n");
                        break;
                }

                if (hasHitMine)
                {
                    PrintGameField(minesField);
                    Console.Write("\nGame over! Your score is {0} points. Enter your name: ", points);
                    string playerName = Console.ReadLine();
                    Score score = new Score(playerName, points);

                    if (topScores.Count < 5)
                    {
                        topScores.Add(score);
                    }
                    else
                    {
                        for (int index = 0; index < topScores.Count; index++)
                        {
                            if (topScores[index].Points < score.Points)
                            {
                                topScores.Insert(index, score);
                                topScores.RemoveAt(topScores.Count - 1);
                                break;
                            }
                        }
                    }

                    topScores.Sort((Score r1, Score r2) => r2.Name.CompareTo(r1.Name));
                    topScores.Sort((Score r1, Score r2) => r2.Points.CompareTo(r1.Points));
                    PrintTopScoresBoard(topScores);

                    gameField = InitializeGameField();
                    minesField = InitializeMinesField();
                    points = 0;
                    hasHitMine = false;
                    isStarting = true;
                }

                if (hasMaxPoints)
                {
                    Console.WriteLine("\nCongratulations! You opened all 35 cells without mines!");
                    PrintGameField(minesField);

                    Console.WriteLine("Enter your name: ");
                    string playerName = Console.ReadLine();
                    Score score = new Score(playerName, points);
                    topScores.Add(score);
                    PrintTopScoresBoard(topScores);

                    gameField = InitializeGameField();
                    minesField = InitializeMinesField();
                    points = 0;
                    hasMaxPoints = false;
                    isStarting = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Minesweeper v1.0");
            Console.WriteLine("Copyright (c) 2013 Telerik Academy. All rights reserved.");
            
            Console.Read();
        }

        private static void PrintTopScoresBoard(List<Score> scores)
        {
            Console.WriteLine("\nTop scores board: ");
            if (scores.Count > 0)
            {
                for (int i = 0; i < scores.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points", i + 1, scores[i].Name, scores[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The score board is empty!\n");
            }
        }

        private static void UpdateFields(char[,] gameField, char[,] minesField, int currentRow, int currentCol)
        {
            char adjacentMinesCount = CountAdjacentMines(minesField, currentRow, currentCol);
            minesField[currentRow, currentCol] = adjacentMinesCount;
            gameField[currentRow, currentCol] = adjacentMinesCount;
        }

        private static void PrintGameField(char[,] gameField)
        {
            int rows = gameField.GetLength(0);
            int cols = gameField.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int row = 0; row < rows; row++)
            {
                Console.Write("{0} | ", row);

                for (int col = 0; col < cols; col++)
                {
                    Console.Write("{0} ", gameField[row, col]);
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] InitializeGameField()
        {
            char[,] gameField = new char[FieldRows, FieldColumns];

            for (int row = 0; row < FieldRows; row++)
            {
                for (int col = 0; col < FieldColumns; col++)
                {
                    gameField[row, col] = '?';
                }
            }

            return gameField;
        }

        private static char[,] InitializeMinesField()
        {
            char[,] minesField = new char[FieldRows, FieldColumns];

            for (int row = 0; row < FieldRows; row++)
            {
                for (int col = 0; col < FieldColumns; col++)
                {
                    minesField[row, col] = '-';
                }
            }

            List<int> randomNumbers = new List<int>(15);
            while (randomNumbers.Count < 15)
            {
                int randomNumber = RandomGenerator.Next(0, 50);
                if (!randomNumbers.Contains(randomNumber))
                {
                    randomNumbers.Add(randomNumber);
                }
            }

            foreach (int number in randomNumbers)
            {
                int row = number / FieldColumns;
                int col = number % FieldColumns;
                minesField[row, col] = '*';
            }

            return minesField;
        }

        private static char CountAdjacentMines(char[,] minesField, int currentRow, int currentCol)
        {
            int rows = minesField.GetLength(0);
            int cols = minesField.GetLength(1);
            int adjacentMinesCount = 0;

            if (currentRow - 1 >= 0)
            {
                if (minesField[currentRow - 1, currentCol] == '*')
                {
                    adjacentMinesCount++;
                }
            }

            if (currentRow + 1 < rows)
            {
                if (minesField[currentRow + 1, currentCol] == '*')
                {
                    adjacentMinesCount++;
                }
            }

            if (currentCol - 1 >= 0)
            {
                if (minesField[currentRow, currentCol - 1] == '*')
                {
                    adjacentMinesCount++;
                }
            }

            if (currentCol + 1 < cols)
            {
                if (minesField[currentRow, currentCol + 1] == '*')
                {
                    adjacentMinesCount++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCol - 1 >= 0))
            {
                if (minesField[currentRow - 1, currentCol - 1] == '*')
                {
                    adjacentMinesCount++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCol + 1 < cols))
            {
                if (minesField[currentRow - 1, currentCol + 1] == '*')
                {
                    adjacentMinesCount++;
                }
            }

            if ((currentRow + 1 < rows) && (currentCol - 1 >= 0))
            {
                if (minesField[currentRow + 1, currentCol - 1] == '*')
                {
                    adjacentMinesCount++;
                }
            }

            if ((currentRow + 1 < rows) && (currentCol + 1 < cols))
            {
                if (minesField[currentRow + 1, currentCol + 1] == '*')
                {
                    adjacentMinesCount++;
                }
            }

            return char.Parse(adjacentMinesCount.ToString());
        }
    }
}
