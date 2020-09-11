using System;
using System.Collections.Generic;
using board;

namespace Chess
{
    class ChessPlay
    {
        public  Board Board { get; private set; }
        public int Turn { get; private set; }
        public  Color ActualPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> capturedPieces;

        public ChessPlay()
        {
            Board = new Board(8, 8);
            Turn = 1;
            ActualPlayer = Color.Branca;
            Finished = false;
            pieces = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();
            PlacePieces();
        }
        public void ExecuteMove(Position origin, Position destination)
        {
            Piece piece = Board.WithdrawPiece(origin);
            piece.IncreaseMovementQty();
            Piece capturedPiece = Board.WithdrawPiece(destination);
            Board.PlacePiece(piece, destination);
            if (capturedPiece != null)
            {
                capturedPieces.Add(capturedPiece);
            }
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

        public HashSet<Piece> CapturedPieces (Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in capturedPieces)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            return aux;
        }
        public HashSet<Piece> PiecesInPlay(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in pieces)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }
        public void PlaceNewPiece(char column, int line, Piece piece)
        {
            Board.PlacePiece(piece, new ChessPosition(column, line).ToPosition());
            pieces.Add(piece);
        }
        private void PlacePieces()
        {
            PlaceNewPiece('a', 1, new Rook(Board, Color.Branca));
            PlaceNewPiece('h', 1, new Rook(Board, Color.Branca));
            PlaceNewPiece('f', 1, new King(Board, Color.Branca));

            PlaceNewPiece('a', 8, new Rook(Board, Color.Preta));
            PlaceNewPiece('h', 8, new Rook(Board, Color.Preta));
            PlaceNewPiece('d', 8, new King(Board, Color.Preta));

        }
    }
}
