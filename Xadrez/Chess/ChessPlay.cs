using System;
using board;

namespace Chess
{
    class ChessPlay
    {
        public  Board board { get; private set; }
        private int turn;
        private Color actualPlayer;
        public bool finished { get; private set; }

        public ChessPlay()
        {
            board = new Board(8, 8);
            turn = 1;
            actualPlayer = Color.White;
            finished = false;
            placePieces();
        }
        public void executeMove(Position origin, Position destination)
        {
            Piece piece = board.withdrawPiece(origin);
            piece.increaseMovementQty();
            Piece capturedPiece = board.withdrawPiece(destination);
            board.placePiece(piece, destination);
        }
        private void placePieces()
        {
            board.placePiece(new Rook(board, Color.White), new ChessPosition('a', 1).toPosition());
            board.placePiece(new Rook(board, Color.White), new ChessPosition('h', 1).toPosition());
            board.placePiece(new King(board, Color.White), new ChessPosition('f', 1).toPosition());

            board.placePiece(new Rook(board, Color.Black), new ChessPosition('a', 8).toPosition());
            board.placePiece(new Rook(board, Color.Black), new ChessPosition('h', 8).toPosition());
            board.placePiece(new King(board, Color.Black), new ChessPosition('d', 8).toPosition());

        }
    }
}
