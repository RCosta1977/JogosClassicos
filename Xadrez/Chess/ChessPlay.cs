using System;
using board;

namespace Chess
{
    class ChessPlay
    {
        public  Board Board { get; private set; }
        private int turn;
        private Color actualPlayer;
        public bool Finished { get; private set; }

        public ChessPlay()
        {
            Board = new Board(8, 8);
            turn = 1;
            actualPlayer = Color.White;
            Finished = false;
            PlacePieces();
        }
        public void ExecuteMovement(Position origin, Position destination)
        {
            Piece piece = Board.WithdrawPiece(origin);
            piece.IncreaseMovementQty();
            Piece capturedPiece = Board.WithdrawPiece(destination);
            Board.PlacePiece(piece, destination);
        }
        private void PlacePieces()
        {
            Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('a', 1).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('h', 1).ToPosition());
            Board.PlacePiece(new King(Board, Color.White), new ChessPosition('f', 1).ToPosition());

            Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('a', 8).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('h', 8).ToPosition());
            Board.PlacePiece(new King(Board, Color.Black), new ChessPosition('d', 8).ToPosition());

        }
    }
}
