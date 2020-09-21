using board;

namespace Chess
{
    class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color)
        {

        }
        public override string ToString()
        {
            return "D";
        }
        private bool CanMove(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Color != Color;
        }
        public override bool[,] PossibleMovements()
        {
            bool[,] matrix = new bool[Board.Lines, Board.Columns];

            Position position = new Position(0, 0);

            // upper left
            position.setValues(Position.Line - 1, Position.Column - 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Line--;
                position.Column--;
            }

            // up
            position.setValues(Position.Line - 1, Position.Column);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Line--;
            }

            // upper right
            position.setValues(Position.Line - 1, Position.Column + 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Line--;
                position.Column++;
            }

            // right
            position.setValues(Position.Line, Position.Column + 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Column++;
            }

            // down right
            position.setValues(Position.Line + 1, Position.Column + 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Line++;
                position.Column++;
            }

            // down
            position.setValues(Position.Line + 1, Position.Column);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Line++;
            }

            // down left
            position.setValues(Position.Line + 1, Position.Column - 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Line++;
                position.Column--;
            }

            // left
            position.setValues(Position.Line, Position.Column - 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Column--;
            }
            return matrix;
        }
    }
}
