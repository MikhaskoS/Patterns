using System;

namespace Mediator.MediatorWithEvents
{
    public class Demo
    {
        public static void Test()
        {
            var game = new Game();
            var player = new Player("Sam", game);
            var coach = new Coach(game);

            player.Score(); // coach says: well done, Sam
            player.Score(); // coach says: well done, Sam
            player.Score(); // ignored by coach
        }
    }

    #region Game Events

    abstract class GameEventArgs : EventArgs
    {
        public abstract void Print();
    }

    class PlayerScoredEventArgs : GameEventArgs
    {
        public string PlayerName;
        public int GoalsScoredSoFar;

        public PlayerScoredEventArgs
          (string playerName, int goalsScoredSoFar)
        {
            PlayerName = playerName;
            GoalsScoredSoFar = goalsScoredSoFar;
        }

        public override void Print()
        {
            Console.WriteLine($"{PlayerName} has scored! " +
                      $"(their {GoalsScoredSoFar} goal)");
        }
    }

    #endregion

    class Game
    {
        public event EventHandler<GameEventArgs> Events;

        public void Fire(GameEventArgs args)
        {
            Events?.Invoke(this, args);
        }
    }

    class Player
    {
        private string name;
        private int goalsScored = 0;
        private Game game;

        public Player(string name, Game game)
        {
            this.name = name;
            this.game = game;
        }

        public void Score()
        {
            goalsScored++;
            var args = new PlayerScoredEventArgs(name, goalsScored);
            game.Fire(args);
        }
    }

    class Coach
    {
        private Game _game;

        public Coach(Game game)
        {
            _game = game;

            // celebrate if player has scored <3 goals
            _game.Events += (sender, args) =>
            {
                if (args is PlayerScoredEventArgs scored
                    && scored.GoalsScoredSoFar < 3)
                {
                    Console.WriteLine($"coach says: well done, {scored.PlayerName}");
                }
            };
        }
    }

}
