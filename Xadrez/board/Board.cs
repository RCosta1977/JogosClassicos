namespace board
{
    class Board
    {
        public int lines { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public Board(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            pieces = new Piece[lines, columns];
        }
        public Piece piece(int line, int column)
        {
            return pieces[line, column];
        }
        public Piece piece(Position position)
        {
            return pieces[position.line, position.column];
        }
        public bool pieceExist(Position position)
        {
            validatePosition(position);
            return piece(position) != null;
        }
        public void placePiece(Piece piece, Position position)
        {
            if (pieceExist(position))
            {
                throw new BoardException("Já existe uma peça nessa posição!");
            }
            pieces[position.line, position.column] = piece;
            piece.position = position;
        }
        public bool validPosition(Position position)
        {
            if (position.line < 0 || position.line >= lines || position.column <0 || position.column >= columns)
            {
                return false;
            }
            return true;
        }
        public void validatePosition(Position position)
        {
            if (!validPosition(position))
            {
                throw new BoardException("Posição inválida!");
            }
        }
    }
}
