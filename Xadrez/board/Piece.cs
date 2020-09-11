namespace board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovementQty { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Board board, Color color)
        {
            Position = null;
            Board = board;
            Color = color;
            MovementQty = 0;
        }
        public void IncreaseMovementQty()
        {
            MovementQty++;
        }
        public bool AreTherePossibleMovements()
        {
            bool[,] matrix = PossibleMovements();
            for (int i = 0; i < Board.Lines; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (matrix[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool CanMoveFor(Position position)
        {
            return PossibleMovements()[position.Line, position.Column];
        }
        public abstract bool[,] PossibleMovements();
    }
}
