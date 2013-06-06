namespace RotatingWalkInMatrix.Common
{
    using System;
    using System.Text;

    public class Matrix
    {
        public const int MaxSize = 100;
        private const int DirectionsCount = 8;

        private readonly int[,] body;
        private static readonly MatrixCoordinates[] directions;

        static Matrix()
        {
            directions = GetDirections();
        }

        public Matrix(int size)
        {
            if (size < 1 || size > MaxSize)
            {
                throw new ArgumentOutOfRangeException(
                    "size", string.Format("Matrix size must be in the range [1..{0}]", MaxSize));
            }

            this.body = new int[size, size];
        }

        public void Walk()
        {
            int currentCellValue = 1;
            MatrixCoordinates currentCoordinates = new MatrixCoordinates(0, 0);
            MatrixCoordinates currentDirection = Directions.Southeast;

            while (true)
            {
                this.body[currentCoordinates.Row, currentCoordinates.Column] = currentCellValue;

                if (!this.CanContinue(currentCoordinates))
                {
                    bool newCoordinatesFound = this.TryFindNewCoordinates(out currentCoordinates);
                    if (newCoordinatesFound)
                    {
                        currentCellValue++;
                        this.body[currentCoordinates.Row, currentCoordinates.Column] = currentCellValue;
                        currentDirection = Directions.Southeast;
                    }
                    else
                    {
                        break;
                    }
                }

                while (!this.CanGoToCoordinates(currentCoordinates + currentDirection))
                {
                    this.UpdateDirectionClockwise(ref currentDirection);
                }

                currentCoordinates += currentDirection;
                currentCellValue++;
            }
        }

        private void UpdateDirectionClockwise(ref MatrixCoordinates direction)
        {
            int currentDirectionIndex = 0;

            for (int i = 0; i < DirectionsCount; i++)
            {
                if (direction == directions[i])
                {
                    currentDirectionIndex = i;
                    break;
                }
            }

            int newDirectionIndex = 0;
            if (currentDirectionIndex == DirectionsCount - 1)
            {
                newDirectionIndex = 0;
            }
            else
            {
                newDirectionIndex = currentDirectionIndex + 1;
            }

            direction = directions[newDirectionIndex];
        }

        private bool CanContinue(MatrixCoordinates newCoordinates)
        {
            for (int i = 0; i < directions.Length; i++)
            {
                if (this.CanGoToCoordinates(newCoordinates + directions[i]))
                {
                    return true;
                }
            }

            return false;
        }

        private bool TryFindNewCoordinates(out MatrixCoordinates newCoordinates)
        {
            newCoordinates = new MatrixCoordinates(0, 0);

            for (int row = 0; row < this.body.GetLength(0); row++)
            {
                for (int col = 0; col < this.body.GetLength(1); col++)
                {
                    if (this.body[row, col] == 0)
                    {
                        newCoordinates.Row = row;
                        newCoordinates.Column = col;
                        return true;
                    }
                }
            }

            return false;
        }

        private bool CanGoToCoordinates(MatrixCoordinates coordinates)
        {
            bool validRow = (0 <= coordinates.Row && coordinates.Row < this.body.GetLength(0));
            bool validCol = (0 <= coordinates.Column && coordinates.Column < this.body.GetLength(1));

            return validRow && validCol && this.body[coordinates.Row, coordinates.Column] == 0;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            for (int row = 0; row < this.body.GetLength(0); row++)
            {
                for (int col = 0; col < this.body.GetLength(1); col++)
                {
                    output.AppendFormat("{0, 5}", this.body[row, col]);
                }

                output.AppendLine();
            }

            output.Length -= 2;
            return output.ToString();
        }

        private static MatrixCoordinates[] GetDirections()
        { 
            MatrixCoordinates[] directions = new MatrixCoordinates[DirectionsCount];
            directions[0] = Directions.Southeast;
            directions[1] = Directions.South;
            directions[2] = Directions.Southwest;
            directions[3] = Directions.West;
            directions[4] = Directions.Northwest;
            directions[5] = Directions.North;
            directions[6] = Directions.Northeast;
            directions[7] = Directions.East;
            
            return directions;
        }
    }
}
