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
                ChessPlay play = new ChessPlay();

                while (!play.Finished)
                {
                    Console.Clear();
                    Screen.PrintBoard(play.Board);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();

                    bool[,] possiblePositions = play.Board.Piece(origin).PossibleMovements();

                    Console.Clear();
                    Screen.PrintBoard(play.Board, possiblePositions);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Position destination = Screen.ReadChessPosition().ToPosition();
                    play.ExecuteMovement(origin, destination);
                }
            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
