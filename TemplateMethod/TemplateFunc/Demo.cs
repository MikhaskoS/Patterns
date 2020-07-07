using System;
using static System.Console;


namespace TemplateMethod.TemplateFunc
{
    public class Demo
    {
        public static void Test()
        {
            var numberOfPlayers = 2;
            int currentPlayer = 0;
            int turn = 1, maxTurns = 10;

            void Start()
            {
                WriteLine($"Starting a game of chess with {numberOfPlayers} players.");
            }

            bool HaveWinner()
            {
                return turn == maxTurns;
            }

            void TakeTurn()
            {
                WriteLine($"Turn {turn++} taken by player {currentPlayer}.");
                currentPlayer = (currentPlayer + 1) % numberOfPlayers;
            }

            int WinningPlayer()
            {
                return currentPlayer;
            }

            GameTemplate.Run(Start, TakeTurn, HaveWinner, WinningPlayer);
        }
    }

    // В этом примере не используется ООП. Функции передаются
    // в качестве аргументов (функциональное программирование)
    public static class GameTemplate
    {
        public static void Run(
          Action start,
          Action takeTurn,
          Func<bool> haveWinner,
          Func<int> winningPlayer)
        {
            start();
            while (!haveWinner())
                takeTurn();
            WriteLine($"Player {winningPlayer()} wins.");
        }
    }
}
