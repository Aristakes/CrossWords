using CrossWords;

class Crossword
{
    private static Random random = new Random();



    static bool wordHorizontall(char[,] grid, string word, int row, int colm)
    {
        if (colm + word.Length > grid.GetLength(1))
        {
            return false;
        }

        for (int i = 0; i < word.Length; i++)
        {
            if (grid[row,colm + i] != ' ' && grid[row, colm + i] != word[i])
            {
                return false;
            }
        }

        return true;
    }

    static void placeWordHorizontall(char[,] grid, string word, int row, int colm)
    {
        for (int i = 0; i < word.Length; i++)
        {
            grid[row, colm + i] = word[i];
        }
    }

    static bool wordVertically(char[,] grid, string word, int row, int colm)
    {
        if (row + word.Length > grid.GetLength(0))
        {
            return false;
        }

        for (int i = 0; i < word.Length; i++)
        {
            if (grid[row + i, colm] != ' ' && grid[row + i, colm] != word[i])
            {
                return false;
            }
        }

        return true;
    }

    static void placeWordVertically(char[,] grid, string word, int row, int colm)
    {
        for (int i = 0; i < word.Length; i++)
        {
            grid[row + i, colm] = word[i];
        }
    }

    static void wordInGrid(char[,] grid, List<string> words)
    {
        foreach (var word in words)
        {
            bool placed = false;
            while (!placed)
            {
                string direction = random.Next(2) == 0 ? "horizontal" : "vertical";
                int row = random.Next(grid.GetLength(0));
                int colm = random.Next(grid.GetLength(1));

                if (direction == "horizontal" && wordHorizontall(grid, word, row, colm))
                {
                    placeWordHorizontall(grid,word,row,colm);
                    placed = true;
                }
                else if (direction == "vertical" && wordVertically(grid, word, row, colm))
                {
                    placeWordVertically(grid, word, row, colm);
                    placed = true;
                }
            }
        }
    }

    static void print(char[,] grid)
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                Console.Write(grid[i,j] == ' ' ? ' ' : grid[i,j]);
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        
        int gridSize = 10;
        char[,] grid = new char[gridSize, gridSize];
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                grid[i, j] = ' ';
            }
        }

        List<string> words = new List<string> { "hello", "world", "python", "code" };
        wordInGrid(grid,words);
        print(grid);
        

    }
    
}