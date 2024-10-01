var game = new Game();

await game.Run();

Console.WriteLine("Game Over!");

public class Game
{
    //Create a 3 by 3 board with 0 as empty, 1 as X and 2 as O
    public int[,] Board = new int[3, 3];
    private bool _isPlayerOneTurn = true;
    public bool IsGameOver { get; private set; }
    private Player _playerOne;
    private Player _playerTwo;

    public Game()
    {
        _playerOne = new Player();
        _playerTwo = new Player();
    }
    
    public async Task Run()
    {
        while (!IsGameOver)
        {
            Update();
            Render();
            await Task.Delay(1000);
        }
    }
    
    public void Update()
    {
        var availableMoves = GetAllAvailableMoves();
        
        if (_isPlayerOneTurn)
        {
            var move = _playerOne.MakeMove(availableMoves);
            Board[move.Item1, move.Item2] = 1;
        }
        else
        {
            var move = _playerTwo.MakeMove(availableMoves);
            Board[move.Item1, move.Item2] = 2;
        }
        if (availableMoves.Count == 1)
        {
            IsGameOver = true;
        }
        
        // check if there is a winner
        if (CheckWinner())
        {
            IsGameOver = true;
        }
        
        _isPlayerOneTurn = !_isPlayerOneTurn;
    }

    private bool CheckWinner()
    {
        var hasWon = false;
        // checks rows
        for (int i = 0; i < 3; i++)
        {
            if(Board[i, 0] == Board[i, 1] && Board[i, 1] == Board[i, 2] && Board[i, 0] != 0)
            {
                hasWon = true;
            }
        }
        // checks columns
        for (int i = 0; i < 3; i++)
        {
            if(Board[0, i] == Board[1, i] && Board[1, i] == Board[2, i] && Board[0, i] != 0)
            {
                hasWon = true;
            }
        }
        // checks diagonals
        if(Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2] && Board[0, 0] != 0)
        {
            hasWon = true;
        }
        if(Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0] && Board[0, 2] != 0)
        {
            hasWon = true;
        }

        return hasWon;
    }

    private List<(int,int)> GetAllAvailableMoves()
    {
        var availableMoves = new List<(int, int)>();
        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 3; j++)
            {
                if (Board[i, j] == 0)
                {
                    availableMoves.Add((i, j));
                }
            }
        }

        return availableMoves;
    }

    public void Render()
    {
        Console.Clear();
        for (var i = 0; i < 3; i++)
        {
            Console.WriteLine($"{Board[i, 0]} {Board[i, 1]} {Board[i, 2]}");
        }
    }
}


public class Player
{
    public (int,int) MakeMove(List<(int, int)> availableMoves)
    {
        if(availableMoves.Count == 0)
        {
            throw new InvalidOperationException("No available moves");
        }
        
        // Use a random number generator to select a move
        var random = new Random();
        var index = random.Next(0, availableMoves.Count);
        return availableMoves[index];
    }
}