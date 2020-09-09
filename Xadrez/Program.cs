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

                while (!play.finished)
                {
                    Console.Clear();
                    Screen.printBoard(play.board);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Position origin = Screen.readChessPosition().toPosition();
                    Console.Write("Destino: ");
                    Position destination = Screen.readChessPosition().toPosition();
                    play.executeMove(origin, destination);
                }
            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
