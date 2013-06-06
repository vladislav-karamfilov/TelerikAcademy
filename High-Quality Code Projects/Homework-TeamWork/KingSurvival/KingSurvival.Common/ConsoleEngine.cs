namespace KingSurvival.Common
{
    using System;

    public class ConsoleEngine : IEngine
    {
        private const int KingInitialRow = 7;
        private const int KingInitialColumn = 3;
        private const int PawnAInitialRow = 0;
        private const int PawnAInitialColumn = 0;
        private const int PawnBInitialRow = 0;
        private const int PawnBInitialColumn = 2;
        private const int PawnCInitialRow = 0;
        private const int PawnCInitialColumn = 4;
        private const int PawnDInitialRow = 0;
        private const int PawnDInitialColumn = 6;
        private const int BoardRows = 8;
        private const int BoardColumns = 8;

        private static readonly int BoardMaxRow = BoardRows - 1;
        private static readonly int BoardMaxColumn = BoardColumns - 1;
        private static readonly MatrixCoordinates UpLeftDirection = new MatrixCoordinates(-1, -1);
        private static readonly MatrixCoordinates UpRightDirection = new MatrixCoordinates(-1, 1);
        private static readonly MatrixCoordinates DownLeftDirection = new MatrixCoordinates(1, -1);
        private static readonly MatrixCoordinates DownRightDirection = new MatrixCoordinates(1, 1);

        private readonly Board board;
        private bool isKingWinner;

        public ConsoleEngine()
        {
            this.board = new Board(BoardRows, BoardColumns);
            this.isKingWinner = false;
        }

        public void Run()
        {
            MatrixCoordinates kingCoordinates = new MatrixCoordinates(KingInitialRow, KingInitialColumn);
            King king = new King(kingCoordinates);

            MatrixCoordinates pawnACoordinates = new MatrixCoordinates(PawnAInitialRow, PawnAInitialColumn);
            Pawn pawnA = new Pawn('A', pawnACoordinates);

            MatrixCoordinates pawnBCoordinates = new MatrixCoordinates(PawnBInitialRow, PawnBInitialColumn);
            Pawn pawnB = new Pawn('B', pawnBCoordinates);

            MatrixCoordinates pawnCCoordinates = new MatrixCoordinates(PawnCInitialRow, PawnCInitialColumn);
            Pawn pawnC = new Pawn('C', pawnCCoordinates);

            MatrixCoordinates pawnDCoordinates = new MatrixCoordinates(PawnDInitialRow, PawnDInitialColumn);
            Pawn pawnD = new Pawn('D', pawnDCoordinates);

            bool endOfGame = false;
            int currentMove = 1;
            do
            {
                bool isValidMove = false;
                do
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine(this.board.GetImage(king, pawnA, pawnB, pawnC, pawnD));
                        isValidMove = this.IsValidMove(currentMove, king, pawnA, pawnB, pawnC, pawnD);
                    }
                    catch (KingSurvivalException kse)
                    {
                        Console.WriteLine(kse.Message);
                        Console.ReadLine();
                    }
                }
                while (!isValidMove);

                endOfGame = this.HasGameEnded(currentMove, king, pawnA, pawnB, pawnC, pawnD);
                this.isKingWinner = this.HasKingWon(currentMove, endOfGame, king, pawnA, pawnB, pawnC, pawnD);
                currentMove++;
            }
            while (!endOfGame);

            if (endOfGame)
            {
                this.DisplayCurrentEndOnConsole(currentMove, king, pawnA, pawnB, pawnC, pawnD);
            }
        }

        private bool HasGameEnded(int gameTurn, King king, Pawn pawnA, Pawn pawnB, Pawn pawnC, Pawn pawnD)
        {
            bool isKingOnTurn = false;

            isKingOnTurn = (gameTurn % 2 == 1);

            if (isKingOnTurn && king.Coordinates.Row == 0)
            {
                return true;
            }
            else
            {
                if (!this.CanKingMove(king, pawnA, pawnB, pawnC, pawnD) ||
                    !this.CanAtLeastOnePawnMove(king, pawnA, pawnB, pawnC, pawnD))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private bool HasKingWon(int gameTurn, bool gameCondition, King king, Pawn pawnA, Pawn pawnB, Pawn pawnC, Pawn pawnD)
        {
            bool isGameEnded = gameCondition;
            bool isKingOnTurn = (gameTurn % 2 == 1);

            if (isGameEnded)
            {
                if (isKingOnTurn && king.Coordinates.Row == 0)
                {
                    return true;
                }
                else
                {
                    if (!this.CanKingMove(king, pawnA, pawnB, pawnC, pawnD))
                    {
                        return false;
                    }
                    else if (!this.CanAtLeastOnePawnMove(king, pawnA, pawnB, pawnC, pawnD))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        private bool CanKingMove(King king, Pawn pawnA, Pawn pawnB, Pawn pawnC, Pawn pawnD)
        {
            bool canKingGoUpLeft = this.IsKingUpLeftMovementAvailable(king, pawnA, pawnB, pawnC, pawnD);
            bool canKingGoDownLeft = this.IsKingDownLeftMovementAvailable(king, pawnA, pawnB, pawnC, pawnD);
            bool canKingGoUpRight = this.IsKingUpRightMovementAvailable(king, pawnA, pawnB, pawnC, pawnD);
            bool canKingGoDownRight = this.IsKingDownRightMovementAvailable(king, pawnA, pawnB, pawnC, pawnD);

            bool isAnyOfKingMovesAvaiable = canKingGoDownRight || canKingGoDownLeft || canKingGoUpLeft || canKingGoUpRight;

            return isAnyOfKingMovesAvaiable;
        }

        private bool IsKingUpLeftMovementAvailable(King king, Pawn pawnA, Pawn pawnB, Pawn pawnC, Pawn pawnD)
        {
            if (king.Coordinates.Row == 0 || king.Coordinates.Column == 0)
            {
                return false;
            }

            MatrixCoordinates newKingCoordinates = king.Coordinates + UpLeftDirection;
            bool canKingGoUpLeft =
                this.IsAvailableNextPosition(
                newKingCoordinates,
                pawnA.Coordinates,
                pawnB.Coordinates,
                pawnC.Coordinates,
                pawnD.Coordinates);

            return canKingGoUpLeft;
        }

        private bool IsKingDownLeftMovementAvailable(King king, Pawn pawnA, Pawn pawnB, Pawn pawnC, Pawn pawnD)
        {
            if (king.Coordinates.Row == BoardMaxRow || king.Coordinates.Column == 0)
            {
                return false;
            }

            MatrixCoordinates newKingCoordinates = king.Coordinates + DownLeftDirection;
            bool canKingGoDownLeft =
                this.IsAvailableNextPosition(
                newKingCoordinates,
                pawnA.Coordinates,
                pawnB.Coordinates,
                pawnC.Coordinates,
                pawnD.Coordinates);

            return canKingGoDownLeft;
        }

        private bool IsKingUpRightMovementAvailable(King king, Pawn pawnA, Pawn pawnB, Pawn pawnC, Pawn pawnD)
        {
            if (king.Coordinates.Row == 0 || king.Coordinates.Column == BoardMaxColumn)
            {
                return false;
            }

            MatrixCoordinates newKingCoordinates = king.Coordinates + UpRightDirection;
            bool canKingGoUpRight =
                this.IsAvailableNextPosition(
                newKingCoordinates,
                pawnA.Coordinates,
                pawnB.Coordinates,
                pawnC.Coordinates,
                pawnD.Coordinates);

            return canKingGoUpRight;
        }

        private bool IsKingDownRightMovementAvailable(King king, Pawn pawnA, Pawn pawnB, Pawn pawnC, Pawn pawnD)
        {
            if (king.Coordinates.Row == BoardMaxRow || king.Coordinates.Column == BoardMaxColumn)
            {
                return false;
            }

            MatrixCoordinates newKingCoordinates = king.Coordinates + DownRightDirection;
            bool canKingGoDownRight =
                this.IsAvailableNextPosition(
                newKingCoordinates,
                pawnA.Coordinates,
                pawnB.Coordinates,
                pawnC.Coordinates,
                pawnD.Coordinates);

            return canKingGoDownRight;
        }

        private bool CanAtLeastOnePawnMove(King king, Pawn pawnA, Pawn pawnB, Pawn pawnC, Pawn pawnD)
        {
            bool canPawnAMove =
                this.CanCurrentPawnMove(
                pawnA.Coordinates,
                pawnB.Coordinates,
                pawnC.Coordinates,
                pawnD.Coordinates,
                king.Coordinates);
            bool canPawnBMove =
                this.CanCurrentPawnMove(
                pawnB.Coordinates,
                pawnA.Coordinates,
                pawnC.Coordinates,
                pawnD.Coordinates,
                king.Coordinates);
            bool canPawnCMove =
                this.CanCurrentPawnMove(
                pawnC.Coordinates,
                pawnA.Coordinates,
                pawnB.Coordinates,
                pawnD.Coordinates,
                king.Coordinates);
            bool canPawnDMove =
                this.CanCurrentPawnMove(
                pawnD.Coordinates,
                pawnA.Coordinates,
                pawnB.Coordinates,
                pawnC.Coordinates,
                king.Coordinates);

            bool canAtLeastOnePawnMove = canPawnAMove || canPawnBMove || canPawnCMove || canPawnDMove;

            return canAtLeastOnePawnMove;
        }

        private bool CanCurrentPawnMove(MatrixCoordinates currentPawnCoordinates, params MatrixCoordinates[] obstaclesCoordinates)
        {
            if (currentPawnCoordinates.Row == BoardMaxRow)
            {
                return false;
            }
            else if (currentPawnCoordinates.Column > 0 && currentPawnCoordinates.Column < BoardMaxColumn)
            {
                MatrixCoordinates newCoordinatesDownRight = currentPawnCoordinates + DownRightDirection;
                MatrixCoordinates newCoordinatesDownLeft = currentPawnCoordinates + DownLeftDirection;

                if (!this.IsAvailableNextPosition(newCoordinatesDownRight, obstaclesCoordinates) &&
                    !this.IsAvailableNextPosition(newCoordinatesDownLeft, obstaclesCoordinates))
                {
                    return false;
                }
            }
            else if (currentPawnCoordinates.Row == 0)
            {
                MatrixCoordinates newCoordinates = currentPawnCoordinates + DownRightDirection;

                if (!this.IsAvailableNextPosition(newCoordinates, obstaclesCoordinates))
                {
                    return false;
                }
            }
            else if (currentPawnCoordinates.Column == BoardMaxColumn)
            {
                MatrixCoordinates newCoordinates = currentPawnCoordinates + DownLeftDirection;

                if (!this.IsAvailableNextPosition(newCoordinates, obstaclesCoordinates))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsValidMove(int turn, King king, Pawn pawnA, Pawn pawnB, Pawn pawnC, Pawn pawnD)
        {
            bool isValid;
            string command;
            if (turn % 2 == 1)
            {
                Console.Write("King's turn: ");
                command = Console.ReadLine().ToLower();
                isValid = this.IsValidKingMove(command, king, pawnA, pawnB, pawnC, pawnD);
            }
            else
            {
                Console.Write("Pawn's turn: ");
                command = Console.ReadLine().ToLower();
                isValid = this.IsValidPawnMove(command, king, pawnA, pawnB, pawnC, pawnD);
            }

            return isValid;
        }

        private bool HandleDownLeftPawnMove(Pawn pawn, params MatrixCoordinates[] otherPawnsCoordinates)
        {
            MatrixCoordinates newCoordinates = pawn.Coordinates + DownLeftDirection;

            if (pawn.Coordinates.Row < BoardMaxRow && pawn.Coordinates.Column > 0 &&
                this.IsAvailableNextPosition(newCoordinates, otherPawnsCoordinates))
            {
                pawn.Coordinates = newCoordinates;
                return true;
            }
            else
            {
                throw new KingSurvivalException("Invalid move!");
            }
        }

        private bool HandleDownRightPawnMove(Pawn pawn, params MatrixCoordinates[] otherPawnsCoordinates)
        {
            MatrixCoordinates newCoordinates = pawn.Coordinates + DownRightDirection;

            if (pawn.Coordinates.Row < BoardMaxRow && pawn.Coordinates.Column < BoardMaxColumn &&
                this.IsAvailableNextPosition(newCoordinates, otherPawnsCoordinates))
            {
                pawn.Coordinates = newCoordinates;
                return true;
            }
            else
            {
                throw new KingSurvivalException("Invalid move!");
            }
        }

        private bool IsValidPawnMove(string command, King king, Pawn pawnA, Pawn pawnB, Pawn pawnC, Pawn pawnD)
        {
            switch (command)
            {
                case "adl":
                    return this.HandleDownLeftPawnMove(
                        pawnA,
                        king.Coordinates,
                        pawnB.Coordinates,
                        pawnC.Coordinates,
                        pawnD.Coordinates);
                case "adr":
                    return this.HandleDownRightPawnMove(
                        pawnA,
                        king.Coordinates,
                        pawnB.Coordinates,
                        pawnC.Coordinates,
                        pawnD.Coordinates);
                case "bdl":
                    return this.HandleDownLeftPawnMove(
                        pawnB,
                        king.Coordinates,
                        pawnA.Coordinates,
                        pawnC.Coordinates,
                        pawnD.Coordinates);
                case "bdr":
                    return this.HandleDownRightPawnMove(
                        pawnB,
                        king.Coordinates,
                        pawnA.Coordinates,
                        pawnC.Coordinates,
                        pawnD.Coordinates);
                case "cdl":
                    return this.HandleDownLeftPawnMove(
                        pawnC,
                        king.Coordinates,
                        pawnA.Coordinates,
                        pawnB.Coordinates,
                        pawnD.Coordinates);
                case "cdr":
                    return this.HandleDownRightPawnMove(
                        pawnC,
                        king.Coordinates,
                        pawnA.Coordinates,
                        pawnB.Coordinates,
                        pawnD.Coordinates);
                case "ddl":
                    return this.HandleDownLeftPawnMove(
                        pawnD,
                        king.Coordinates,
                        pawnA.Coordinates,
                        pawnB.Coordinates,
                        pawnC.Coordinates);
                case "ddr":
                    return this.HandleDownRightPawnMove(
                        pawnD,
                        king.Coordinates,
                        pawnA.Coordinates,
                        pawnB.Coordinates,
                        pawnC.Coordinates);
                default:
                    throw new KingSurvivalException("Invalid move!");
            }
        }

        private bool HandleUpLeftKingMove(King king, params MatrixCoordinates[] otherPawnsCoordinates)
        {
            MatrixCoordinates newCoordinates = king.Coordinates + UpLeftDirection;

            if (king.Coordinates.Row > 0 && king.Coordinates.Column > 0 &&
                this.IsAvailableNextPosition(newCoordinates, otherPawnsCoordinates))
            {
                king.Coordinates = newCoordinates;
                return true;
            }
            else
            {
                throw new KingSurvivalException("Invalid move!");
            }
        }

        private bool HandleUpRightKingMove(King king, params MatrixCoordinates[] otherPawnsCoordinates)
        {
            MatrixCoordinates newCoordinates = king.Coordinates + UpRightDirection;

            if (king.Coordinates.Row > 0 && king.Coordinates.Column < BoardMaxColumn &&
                this.IsAvailableNextPosition(newCoordinates, otherPawnsCoordinates))
            {
                king.Coordinates = newCoordinates;
                return true;
            }
            else
            {
                throw new KingSurvivalException("Invalid move!");
            }
        }

        private bool IsValidKingMove(string command, King king, Pawn pawnA, Pawn pawnB, Pawn pawnC, Pawn pawnD)
        {
            switch (command)
            {
                case "kul":
                    return this.HandleUpLeftKingMove(
                        king,
                        pawnA.Coordinates,
                        pawnB.Coordinates,
                        pawnC.Coordinates,
                        pawnD.Coordinates);
                case "kur":
                    return this.HandleUpRightKingMove(
                        king,
                        pawnA.Coordinates,
                        pawnB.Coordinates,
                        pawnC.Coordinates,
                        pawnD.Coordinates);
                case "kdl":
                    return this.HandleDownLeftPawnMove(
                        king,
                        pawnA.Coordinates,
                        pawnB.Coordinates,
                        pawnC.Coordinates,
                        pawnD.Coordinates);
                case "kdr":
                    return this.HandleDownRightPawnMove(
                        king,
                        pawnA.Coordinates,
                        pawnB.Coordinates,
                        pawnC.Coordinates,
                        pawnD.Coordinates);
                default:
                    {
                        throw new KingSurvivalException("Invalid move!");
                    }
            }
        }

        private bool IsAvailableNextPosition(MatrixCoordinates newCoordinates, params MatrixCoordinates[] pawnsCoordinates)
        {
            foreach (MatrixCoordinates coordinates in pawnsCoordinates)
            {
                if (newCoordinates == coordinates)
                {
                    return false;
                }
            }

            return true;
        }

        private void DisplayCurrentEndOnConsole(int turn, King king, Pawn pawnA, Pawn pawnB, Pawn pawnC, Pawn pawnD)
        {
            if (this.isKingWinner)
            {
                Console.Clear();
                Console.WriteLine(this.board.GetImage(king, pawnA, pawnB, pawnC, pawnD));
                Console.WriteLine("King wins in {0} turns!", turn / 2);
            }
            else
            {
                Console.Clear();
                Console.WriteLine(this.board.GetImage(king, pawnA, pawnB, pawnC, pawnD));
                Console.WriteLine("King loses in {0} turns...", turn / 2);
            }
        }
    }
}
