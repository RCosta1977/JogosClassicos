using board;

namespace Chess
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color)
        {

        }
        public override string ToString()
        {
            return "B";
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
            position.setValues(Position.Line - 1, Position.Column -1);
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

            // upper right
            position.setValues(Position.Line -1, Position.Column + 1);
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
            return matrix;
        }
    }
}
