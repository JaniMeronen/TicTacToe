namespace TicTacToe
{
    public sealed class Win : Game
    {
        public Player Winner { get; }

        internal Win(Grid grid, Player winner) : base(grid) =>
            Winner = winner;
    }
}