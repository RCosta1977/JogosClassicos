namespace board
{
    class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] pieces;

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            pieces = new Piece[lines, columns];
        }
        public Piece Piece(int line, int column)
        {
            return pieces[line, column];
        }
        public Piece Piece(Position position)
        {
            return pieces[position.Line, position.Column];
        }
        public bool PieceExist(Position position)
        {
            ValidatePosition(position);
            return Piece(position) != null;
        }
        public void PlacePiece(Piece piece, Position position)
        {
            if (PieceExist(position))
            {
                throw new BoardException("Já existe uma peça nessa posição!");
            }
            pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }
        public Piece WithdrawPiece(Position position)
        {
            if (Piece(position) == null)
            {
                return null;
            }
            Piece aux = Piece(position);
            aux.Position = null;
            pieces[position.Line, position.Column] = null;
            return aux;
        }
        public bool ValidPosition(Position position)
        {
            if (position.Line < 0 || position.Line >= Lines || position.Column <0 || position.Column >= Columns)
            {
                return false;
            }
            return true;
        }
        public void ValidatePosition(Position position)
        {
            if (!ValidPosition(position))
            {
                throw new BoardException("Posição inválida!");
            }
        }
    }
}
