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
        public bool Check { get; private set; }

        public ChessPlay()
        {
            Board = new Board(8, 8);
            Turn = 1;
            ActualPlayer = Color.Branca;
            Finished = false;
            Check = false;
            pieces = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();
            PlacePieces();
        }
        public Piece ExecuteMove(Position origin, Position destination)
        {
            Piece piece = Board.WithdrawPiece(origin);
            piece.IncreaseMovementQty();
            Piece capturedPiece = Board.WithdrawPiece(destination);
            Board.PlacePiece(piece, destination);
            if (capturedPiece != null)
            {
                capturedPieces.Add(capturedPiece);
            }
            return capturedPiece;
        }
        public void UndoMove(Position origin, Position destination, Piece capturedPiece)
        {
            Piece piece = Board.WithdrawPiece(destination);
            piece.DecreaseMovementQty();
            if(capturedPiece != null)
            {
                Board.PlacePiece(capturedPiece, origin);
                capturedPieces.Remove(capturedPiece);
            }
            Board.PlacePiece(piece, origin);
        }
        public void PerformMove(Position origin, Position destination)
        {
            Piece capturedPiece = ExecuteMove(origin, destination);
            if (IsinCheck(ActualPlayer))
            {
                UndoMove(origin,destination,capturedPiece);
                throw new BoardException("Você não pode se colocar em cheque!");
            }
            if (IsinCheck(Opponent(ActualPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }
            if (checkmateTest(Opponent(ActualPlayer)))
            {
                Finished = true;
            }
            else
            {
                Turn++;
                changePlayer();
            }
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
            if (!Board.Piece(origin).PossibleMovement(destination))
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
        private Color Opponent (Color color)
        {
            if (color==Color.Branca)
            {
                return Color.Preta;
            }
            else
            {
                return Color.Branca;
            }
        }
        private Piece King(Color color)
        {
            foreach (Piece piece in PiecesInPlay(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }
            return null;
        }
        public bool IsinCheck(Color color)
        {
            Piece king = King(color);
            if (king==null)
            {
                throw new BoardException($"Não há rei {color} no tabuleiro!");
            }
            foreach (Piece piece in PiecesInPlay(Opponent(color)))
            {
                bool[,] matrix = piece.PossibleMovements();
                if (matrix[king.Position.Line,king.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }
        public bool checkmateTest (Color color)
        {
            if (!IsinCheck(color))
            {
                return false;
            }
            foreach(Piece piece in PiecesInPlay(color))
            {
                bool[,] matrix = piece.PossibleMovements();
                for (int i = 0; i < Board.Lines; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (matrix[i,j])
                        {
                            Position origin = piece.Position;
                            Position destination = new Position(i, j);
                            Piece capturedPiece = ExecuteMove(origin, destination);
                            bool testCheck = IsinCheck(color);
                            UndoMove(origin, destination, capturedPiece);
                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }                
            }
            return true;
        }
        public void PlaceNewPiece(char column, int line, Piece piece)
        {
            Board.PlacePiece(piece, new ChessPosition(column, line).ToPosition());
            pieces.Add(piece);
        }
        private void PlacePieces()
        {
            PlaceNewPiece('a', 1, new Rook(Board, Color.Branca));
            PlaceNewPiece('b', 1, new Knight(Board, Color.Branca));
            PlaceNewPiece('c', 1, new Bishop(Board, Color.Branca));
            PlaceNewPiece('d', 1, new Queen(Board, Color.Branca));
            PlaceNewPiece('e', 1, new King(Board, Color.Branca));
            PlaceNewPiece('f', 1, new Bishop(Board, Color.Branca));
            PlaceNewPiece('g', 1, new Knight(Board, Color.Branca));
            PlaceNewPiece('h', 1, new Rook(Board, Color.Branca));
            PlaceNewPiece('a', 2, new Pawn(Board, Color.Branca));
            PlaceNewPiece('b', 2, new Pawn(Board, Color.Branca));
            PlaceNewPiece('c', 2, new Pawn(Board, Color.Branca));
            PlaceNewPiece('d', 2, new Pawn(Board, Color.Branca));
            PlaceNewPiece('e', 2, new Pawn(Board, Color.Branca));
            PlaceNewPiece('f', 2, new Pawn(Board, Color.Branca));
            PlaceNewPiece('g', 2, new Pawn(Board, Color.Branca));
            PlaceNewPiece('h', 2, new Pawn(Board, Color.Branca));


            PlaceNewPiece('a', 8, new Rook(Board, Color.Preta));
            PlaceNewPiece('b', 8, new Knight(Board, Color.Preta));
            PlaceNewPiece('c', 8, new Bishop(Board, Color.Preta));
            PlaceNewPiece('d', 8, new Queen(Board, Color.Preta));
            PlaceNewPiece('e', 8, new King(Board, Color.Preta));
            PlaceNewPiece('f', 8, new Bishop(Board, Color.Preta));
            PlaceNewPiece('g', 8, new Knight(Board, Color.Preta));
            PlaceNewPiece('h', 8, new Rook(Board, Color.Preta));
            PlaceNewPiece('a', 7, new Pawn(Board, Color.Preta));
            PlaceNewPiece('b', 7, new Pawn(Board, Color.Preta));
            PlaceNewPiece('c', 7, new Pawn(Board, Color.Preta));
            PlaceNewPiece('d', 7, new Pawn(Board, Color.Preta));
            PlaceNewPiece('e', 7, new Pawn(Board, Color.Preta));
            PlaceNewPiece('f', 7, new Pawn(Board, Color.Preta));
            PlaceNewPiece('g', 7, new Pawn(Board, Color.Preta));
            PlaceNewPiece('h', 7, new Pawn(Board, Color.Preta));

        }
    }
}
