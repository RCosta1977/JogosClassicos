using board;

namespace Chess
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color)
        {

        }
        public override string ToString()
        {
            return "P";
        }
        private bool IsThereAnEnemy(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece != null && piece.Color != Color;
        }
        private bool Free(Position position)
        {
            return Board.Piece(position) == null;
        }
        public override bool[,] PossibleMovements()
        {
            bool[,] matrix = new bool[Board.Lines, Board.Columns];

            Position position = new Position(0, 0);

            if (Color == Color.Branca)
            {

                position.setValues(Position.Line - 1, Position.Column);
                if (Board.ValidPosition(position) && Free(position))
                {
                    matrix[position.Line, position.Column] = true;
                }

                position.setValues(Position.Line - 2, Position.Column);
                if (Board.ValidPosition(position) && MovementQty == 0)
                {
                    matrix[position.Line, position.Column] = true;
                }

                position.setValues(Position.Line - 1, Position.Column - 1);
                if (Board.ValidPosition(position) && IsThereAnEnemy(position))
                {
                    matrix[position.Line, position.Column] = true;
                }

                position.setValues(Position.Line - 1, Position.Column + 1);
                if (Board.ValidPosition(position) && IsThereAnEnemy(position))
                {
                    matrix[position.Line, position.Column] = true;
                }
            }
            else
            {
                position.setValues(Position.Line + 1, Position.Column);
                if (Board.ValidPosition(position) && Free(position))
                {
                    matrix[position.Line, position.Column] = true;
                }

                position.setValues(Position.Line + 2, Position.Column);
                if (Board.ValidPosition(position) && MovementQty == 0)
                {
                    matrix[position.Line, position.Column] = true;
                }

                position.setValues(Position.Line + 1, Position.Column - 1);
                if (Board.ValidPosition(position) && IsThereAnEnemy(position))
                {
                    matrix[position.Line, position.Column] = true;
                }

                position.setValues(Position.Line + 1, Position.Column + 1);
                if (Board.ValidPosition(position) && IsThereAnEnemy(position))
                {
                    matrix[position.Line, position.Column] = true;
                }
            }
            return matrix;
        }
    }
}
