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
}