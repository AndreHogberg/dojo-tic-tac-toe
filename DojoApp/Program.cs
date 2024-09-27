// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



public class Game
{
    //Create a 3 by 3 board with 0 as empty, 1 as X and 2 as O
    private int[,] _board = new int[3, 3];
    private bool _isPlayerXTurn = true;
    private bool _isGameOver = false;
    public void Run()
    {
        
    }
    
    
    public void Update()
    {
        
    }
    
    public void Render()
    {
        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 3; j++)
            {
                if(j == 2)
                    Console.Write(_board[i, j]);
                else
                {
                    Console.Write(_board[i, j] + " ");
                }
            }
            Console.WriteLine();
        }
    }
    
    
}