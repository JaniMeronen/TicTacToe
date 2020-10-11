namespace TicTacToe
{
    public sealed class On : Game
    {
        public Player Player { get; }

        internal On(Grid grid, Player player) : base(grid) =>
            Player = player;

        public override Game Play(Position position)
        {
            if (Grid.IsSet(position))
                return this;

            Grid grid = Grid.Set(Player, position);

            if (grid.HasThreeInRow(Player))
                return new Win(grid, Player);

            if (grid.IsFull)
                return new Draw(grid);

            return new On(grid, (Player)((int)Player ^ 1));
        }
    }
}