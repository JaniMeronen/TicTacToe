using System.Collections.Immutable;
using System.Linq;
using static TicTacToe.Position;

namespace TicTacToe
{
    class Grid
    {
        static readonly Position[][] rows =
        {
            new[] { TopLeft, TopCenter, TopRight },
            new[] { MiddleLeft, MiddleCenter, MiddleRight },
            new[] { BottomLeft, BottomCenter, BottomRight },
            new[] { TopLeft, MiddleLeft, BottomLeft },
            new[] { TopCenter, MiddleCenter, BottomCenter },
            new[] { TopRight, MiddleRight, BottomRight },
            new[] { TopLeft, MiddleCenter, BottomRight },
            new[] { TopRight, MiddleCenter, BottomLeft }
        };

        public static Grid Empty { get; } =
            new Grid(ImmutableDictionary<Position, Player>.Empty);

        readonly ImmutableDictionary<Position, Player> cells;

        public bool IsFull =>
            cells.Count is 9;

        Grid(ImmutableDictionary<Position, Player> cells) =>
            this.cells = cells;

        public bool HasThreeInRow(Player player) =>
            rows.Any(row => row.All(position => cells.Contains(position, player)));

        public bool IsSet(Position position) =>
            cells.ContainsKey(position);

        public Grid Set(Player player, Position position) =>
            new Grid(cells.SetItem(position, player));
    }
}