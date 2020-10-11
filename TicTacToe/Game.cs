using static TicTacToe.Grid;
using static TicTacToe.Player;

namespace TicTacToe
{
    public abstract class Game
    {
        public static Game New { get; } =
            new On(Empty, X);

        internal Grid Grid { get; }

        internal Game(Grid grid) =>
            Grid = grid;

        public virtual Game Play(Position position) =>
            this;
    }
}