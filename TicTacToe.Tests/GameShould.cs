using System.Linq;
using Xunit;
using static TicTacToe.Player;
using static TicTacToe.Position;
using static Xunit.Assert;

namespace TicTacToe.Tests
{
    public class GameShould
    {
        [Fact]
        public void Alternate_The_Players()
        {
            Game game = Play(TopLeft);
            On on = IsType<On>(game);
            Equal(O, on.Player);
        }

        [Fact]
        public void Not_Allow_A_Position_To_Be_Played_Twice()
        {
            Game game = Play(TopLeft, TopLeft);
            On on = IsType<On>(game);
            Equal(O, on.Player);
        }

        [Fact]
        public void Not_Permit_Play_After_Game_Is_Won()
        {
            Game game = Play(TopLeft, MiddleLeft, TopCenter, MiddleCenter, TopRight, MiddleRight);
            Win win = IsType<Win>(game);
            Equal(X, win.Winner);
        }

        [Fact]
        public void Recognize_A_Draw()
        {
            Game game = Play(TopLeft, TopCenter, TopRight, MiddleLeft, MiddleCenter, BottomRight, MiddleRight, BottomLeft, BottomCenter);
            _ = IsType<Draw>(game);
        }

        [Fact]
        public void Recognize_When_O_Has_Won()
        {
            Game game = Play(MiddleLeft, TopLeft, MiddleCenter, TopCenter, BottomLeft, TopRight);
            Win win = IsType<Win>(game);
            Equal(O, win.Winner);
        }

        [InlineData(TopLeft, MiddleLeft, TopCenter, MiddleCenter, TopRight)]
        [InlineData(MiddleLeft, TopLeft, MiddleCenter, TopCenter, MiddleRight)]
        [InlineData(BottomLeft, TopLeft, BottomCenter, TopCenter, BottomRight)]
        [InlineData(TopLeft, TopCenter, MiddleLeft, MiddleCenter, BottomLeft)]
        [InlineData(TopCenter, TopLeft, MiddleCenter, MiddleLeft, BottomCenter)]
        [InlineData(TopRight, TopLeft, MiddleRight, MiddleLeft, BottomRight)]
        [InlineData(TopLeft, TopRight, MiddleCenter, MiddleRight, BottomRight)]
        [InlineData(TopRight, TopLeft, MiddleCenter, BottomRight, BottomLeft)]
        [Theory]
        public void Recognize_When_X_Has_Won(Position a, Position b, Position c, Position d, Position e)
        {
            Game game = Play(a, b, c, d, e);
            Win win = IsType<Win>(game);
            Equal(X, win.Winner);
        }

        [Fact]
        public void Recognize_Win_When_Won_On_Final_Position()
        {
            Game game = Play(TopLeft, TopCenter, TopRight, MiddleLeft, MiddleCenter, BottomLeft, MiddleRight, BottomCenter, BottomRight);
            Win win = IsType<Win>(game);
            Equal(X, win.Winner);
        }

        [Fact]
        public void Wait_For_X_To_Play_First()
        {
            Game game = Play();
            On on = IsType<On>(game);
            Equal(X, on.Player);
        }

        Game Play(params Position[] positions) =>
            positions.Aggregate(Game.New, (game, position) => game.Play(position));
    }
}