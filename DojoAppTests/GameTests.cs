namespace DojoAppTests;

public class GameTests
{
    [Fact]
    public void Render_ShouldRenderOutAEmptyBoard_When_Initialized()
    {
        using var sw = new StringWriter();
        Console.SetOut(sw);

        var game = new Game();
        game.Render();

        // expecting a 3x3 board with 0 as empty
        var expected = "0 0 0\r\n0 0 0\r\n0 0 0\r\n";
        Assert.Equal(expected, sw.ToString());
    }

    [Fact]
    public void Update_Player_ShouldChoseARandomMoveFromAListOfAvailableMoves()
    {
        var player = new Player();
        var moves = new List<(int,int)>()
        {
            (0, 0),
            (0, 1),
            (0, 2),
            (1, 0),
            (1, 1),
            (1, 2),
            (2, 0),
            (2, 1),
            (2, 2)
        };
        
        var move = player.MakeMove(moves);
        
        Assert.Contains(move, moves);
    }
    
    [Fact]
    public void Player_IfThereIsNoAvailableMoves_ShouldThrowInvalidOperationException()
    {
        var player = new Player();
        var moves = new List<(int,int)>();
        
        Assert.Throws<InvalidOperationException>(() => player.MakeMove(moves));
    }
    [Fact]
    public void Game_WhenBoardIsFull_ShouldEndGame()
    {
        var game = new Game();
        game.Update();
        game.Update();
        game.Update();
        game.Update();
        game.Update();
        game.Update();
        game.Update();
        game.Update();
        game.Update();
        
        Assert.True(game.IsGameOver);
    }
    
    [Fact]
    public void Game_WhenPlayerOneWins_HorizontalLines_ShouldEndGame()
    {
        var game = new Game();
        game.Board[0, 0] = 1;
        game.Board[0, 1] = 1;
        game.Board[0, 2] = 1;
        
        game.Update();
        
        Assert.True(game.IsGameOver);
    }
    [Fact]
    public void Game_WhenPlayerOneWins_VerticalLines_ShouldEndGame()
    {
        var game = new Game();
        game.Board[0, 0] = 1;
        game.Board[1, 0] = 1;
        game.Board[2, 0] = 1;
        
        game.Update();
        
        Assert.True(game.IsGameOver);
    }
    [Fact]
    public void Game_WhenPlayerOneWins_DiagonalLines_ShouldEndGame()
    {
        var game = new Game();
        game.Board[0, 0] = 1;
        game.Board[1, 1] = 1;
        game.Board[2, 2] = 1;
        
        game.Update();
        
        Assert.True(game.IsGameOver);
    }
}