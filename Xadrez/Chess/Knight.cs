using board;

namespace Chess
{
    class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color)
        {

        }
        public override string ToString()
        {
            return "C";
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

            
            position.setValues(Position.Line - 1, Position.Column - 2);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }

            position.setValues(Position.Line - 1, Position.Column + 2);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }

            position.setValues(Position.Line + 1, Position.Column - 2);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }

            position.setValues(Position.Line + 1, Position.Column + 2);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }

            position.setValues(Position.Line - 2, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }

            position.setValues(Position.Line - 2, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }

            position.setValues(Position.Line + 2, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }

            position.setValues(Position.Line + 2, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }

            return matrix;
        }
    }
}
