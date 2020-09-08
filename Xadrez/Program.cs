using System;
using board;
using Chess;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = new Board(8, 8);

                board.placePiece(new Rook(board, Color.Black), new Position(0, 0));
                board.placePiece(new Rook(board, Color.Black), new Position(1, 3));
                board.placePiece(new King(board, Color.Black), new Position(0, 2));

                board.placePiece(new King(board, Color.White), new Position(0, 5));

                Screen.printBoard(board);
            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
