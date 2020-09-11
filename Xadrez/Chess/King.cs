using board;

namespace Chess
{
    class King : Piece
    {
        public King(Board board, Color color) : base(board, color)
        {

        }
        public override string ToString()
        {
            return "R";
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

            // up
            position.setValues(Position.Line - 1, Position.Column);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }

            //upper right
            position.setValues(Position.Line - 1, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }

            //right
            position.setValues(Position.Line, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }

            //down right
            position.setValues(Position.Line + 1, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }

            //down
            position.setValues(Position.Line + 1, Position.Column);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }

            //down left
            position.setValues(Position.Line + 1, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }

            //left
            position.setValues(Position.Line, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }

            //upper left
            position.setValues(Position.Line - 1, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }
            return matrix;
        }
    }
}
