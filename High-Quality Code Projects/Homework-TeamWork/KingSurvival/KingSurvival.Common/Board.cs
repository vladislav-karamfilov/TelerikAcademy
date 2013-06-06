namespace KingSurvival.Common
{
    using System.Text;

    internal class Board
    {
        private const char HorizontalBorderSymbol = '-';
        private const char VerticalBorderSymbol = '|';
        private const char BlackCellSymbol = '-';
        private const char WhiteCellSymbol = '+';
        private const char WhiteSpaceSymbol = ' ';

        private readonly StringBuilder image;
        private readonly int rows;
        private readonly int columns;

        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            this.image = new StringBuilder();
        }

        public int Rows
        {
            get { return this.rows; }
        }

        public int Columns
        {
            get { return this.columns; }
        }

        public string GetImage(params Pawn[] pawns)
        {
            this.image.Clear();

            this.AppendRowIndicatorsLine();

            this.AppendBorder();

            this.AppendBody(pawns);

            this.AppendBorder();

            return this.image.ToString();
        }

        private void AppendRowIndicatorsLine()
        {
            // Append white space in the beginning
            this.image.Append(new string(WhiteSpaceSymbol, 4));

            for (int row = 0; row < this.Rows; row++)
            {
                this.image.AppendFormat("{0} ", row);
            }

            this.image.AppendLine();
        }

        private void AppendBody(params Pawn[] pawns)
        {
            for (int row = 0; row < this.Rows; row++)
            {
                this.image.AppendFormat("{0} {1} ", row, VerticalBorderSymbol);

                for (int col = 0; col < this.Columns; col++)
                {
                    char symbol = this.GetSymbol(row, col, pawns);
                    this.image.AppendFormat("{0} ", symbol);
                }

                this.image.AppendLine(VerticalBorderSymbol.ToString());
            }
        }

        private char GetSymbol(int row, int column, params Pawn[] pawns)
        {
            char symbol = new char();
            bool isPawnSymbol = false;

            for (int i = 0; i < pawns.Length; i++)
            {
                if (pawns[i].Coordinates.Row == row && pawns[i].Coordinates.Column == column)
                {
                    isPawnSymbol = true;
                    symbol = pawns[i].Symbol;
                    break;
                }
            }

            if (!isPawnSymbol)
            {
                if ((row + column) % 2 == 0)
                {
                    symbol = WhiteCellSymbol;
                }
                else
                {
                    symbol = BlackCellSymbol;
                }
            }

            return symbol;
        }

        private void AppendBorder()
        {
            // Append white space in the beginning
            this.image.Append(new string(WhiteSpaceSymbol, 3));

            // Append border of '-' symbols
            this.image.AppendLine(new string(HorizontalBorderSymbol, (2 * this.Rows) + 1));
        }
    }
}
