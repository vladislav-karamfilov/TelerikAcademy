using System;

class TicTacToe
{
    static readonly char[][] board = new char[3][];
    static int playerXWinsCount = 0;
    static int evenGamesCount = 0;
    static int playerOWinsCount = 0;

    static void Main()
    {
        for (int line = 0; line < 3; line++)
        {
            board[line] = Console.ReadLine().ToCharArray();
        }

        FindWinners(1);

        Console.WriteLine(playerXWinsCount);
        Console.WriteLine(evenGamesCount);
        Console.WriteLine(playerOWinsCount);
    }

    static void FindWinners(int currentTurn)
    {
        if (HasWinner())
        {
            return;
        }

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board.Length; j++)
            {
                if (board[i][j] == '-')
                {
                    board[i][j] = (currentTurn % 2 == 1) ? 'X' : 'O';
                    FindWinners(currentTurn + 1);
                    board[i][j] = '-';
                }
            }
        }
    }

    static bool HasWinner()
    {
        if ((board[0][0] == 'X' && board[0][1] == 'X' && board[0][2] == 'X') ||
            (board[1][0] == 'X' && board[1][1] == 'X' && board[1][2] == 'X') ||
            (board[2][0] == 'X' && board[2][1] == 'X' && board[2][2] == 'X') ||
            (board[0][0] == 'X' && board[1][0] == 'X' && board[2][0] == 'X') ||
            (board[0][1] == 'X' && board[1][1] == 'X' && board[2][1] == 'X') ||
            (board[0][2] == 'X' && board[1][2] == 'X' && board[2][2] == 'X') ||
            (board[0][0] == 'X' && board[1][1] == 'X' && board[2][2] == 'X') ||
            (board[0][2] == 'X' && board[1][1] == 'X' && board[2][0] == 'X'))
        {
            playerXWinsCount++;
            return true;
        }

        if ((board[0][0] == 'O' && board[0][1] == 'O' && board[0][2] == 'O') ||
            (board[1][0] == 'O' && board[1][1] == 'O' && board[1][2] == 'O') ||
            (board[2][0] == 'O' && board[2][1] == 'O' && board[2][2] == 'O') ||
            (board[0][0] == 'O' && board[1][0] == 'O' && board[2][0] == 'O') ||
            (board[0][1] == 'O' && board[1][1] == 'O' && board[2][1] == 'O') ||
            (board[0][2] == 'O' && board[1][2] == 'O' && board[2][2] == 'O') ||
            (board[0][0] == 'O' && board[1][1] == 'O' && board[2][2] == 'O') ||
            (board[0][2] == 'O' && board[1][1] == 'O' && board[2][0] == 'O'))
        {
            playerOWinsCount++;
            return true;
        }

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board.Length; j++)
            {
                if (board[i][j] == '-')
                {
                    return false;
                }
            }
        }

        evenGamesCount++;
        return true;
    }
}
