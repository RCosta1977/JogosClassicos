using System;
using board;

namespace Chess
{
    class ChessPlay
    {
        public  Board Board { get; private set; }
        public int Turn { get; private set; }
        public  Color ActualPlayer { get; private set; }
        public bool Finished { get; private set; }

        public ChessPlay()
        {
            Board = new Board(8, 8);
            Turn = 1;
            ActualPlayer = Color.Branca;
            Finished = false;
            PlacePieces();
        }
        public void ExecuteMove(Position origin, Position destination)
        {
            Piece piece = Board.WithdrawPiece(origin);
            piece.IncreaseMovementQty();
            Piece capturedPiece = Board.WithdrawPiece(destination);
            Board.PlacePiece(piece, destination);
        }
        public void PerformMove(Position origin, Position destination)
        {
            ExecuteMove(origin, destination);
            Turn++;
            changePlayer();
        }
        public void ValidateOriginPosition(Position position)
        {
            if (Board.Piece(position) == null)
            {
                throw new BoardException("Não existe peça na posição de origem escolhida!");
            }
            if (ActualPlayer != Board.Piece(position).Color)
            {
                throw new BoardException("A peça de origem escolhida não é sua!");
            }
            if (!Board.Piece(position).AreTherePossibleMovements())

            {
                throw new BoardException("Não há movimentos possíveis para a peça de origem escolhida");
            }

        }
        public void ValidateTargetPosition(Position origin, Position destination)
        {
            if (!Board.Piece(origin).CanMoveFor(destination))
            {
                throw new BoardException("Posição de destino invalida!");
            }
        }
        public void changePlayer()
        {
            if (ActualPlayer==Color.Branca)
            {
                ActualPlayer = Color.Preta;
            }
            else
            {
                ActualPlayer = Color.Branca;
            }
        }
        private void PlacePieces()
        {
            Board.PlacePiece(new Rook(Board, Color.Branca), new ChessPosition('a', 1).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.Branca), new ChessPosition('h', 1).ToPosition());
            Board.PlacePiece(new King(Board, Color.Branca), new ChessPosition('f', 1).ToPosition());

            Board.PlacePiece(new Rook(Board, Color.Preta), new ChessPosition('a', 8).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.Preta), new ChessPosition('h', 8).ToPosition());
            Board.PlacePiece(new King(Board, Color.Preta), new ChessPosition('d', 8).ToPosition());

        }
    }
}
