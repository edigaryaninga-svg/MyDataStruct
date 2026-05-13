class MyChessProj
{
    static void Main()
    {
        int n = 8;

        PrintMainDiagonal(n);
        Console.WriteLine("---------------------------");
        Console.WriteLine();
        PrintSecondDiagonal(n);
        Console.WriteLine("---------------------------");
        Console.WriteLine(PrintCanRookMove(2, 3, 5, 3));
        Console.WriteLine("---------------------------");
        Console.WriteLine(PrintCanKnightMove(2, 3, 4, 4));
        Console.WriteLine("------------------------------");
        int steps = GetKnightMinSteps(1, 1, 8, 8); 
        Console.WriteLine("Dziu nvazaguyn qayleri qanaky: " + steps);




        Console.ReadKey();
    }

    static void PrintMainDiagonal(int MatrixSize)
    {
        for (int i = 0; i < MatrixSize; i++)
        {
            for (int j = 0; j < MatrixSize; j++)
            {
                if (i == j)
                {
                    Console.Write("# ");
                }
                else
                {
                    Console.Write("* ");
                }
            }
            Console.WriteLine();
        }
    }

    static void PrintSecondDiagonal(int MatrixSize)
    {
        for (int i = 0; i < MatrixSize; i++)
        {
            for (int j = 0; j < MatrixSize; j++)
            {
                if (i + j == MatrixSize - 1)
                {
                    Console.Write("# ");
                }
                else
                {
                    Console.Write("* ");
                }
            }
            Console.WriteLine();
        }
    }

    static bool PrintCanRookMove(int startRow, int startCol, int targetRow, int targetCol)
    {

        if (startRow == targetRow && startCol == targetCol)
        {
            return false;
        }

        if (startRow == targetRow || startCol == targetCol)
        {
            return true;
        }

        return false;
    }

    static bool PrintCanKnightMove(int startRow, int startCol, int targetRow, int targetCol)
    {
        int deltaRow = Math.Abs(startRow - targetRow);
        int deltaCol = Math.Abs(startCol - targetCol);

        if ((deltaRow == 2 && deltaCol == 1) || (deltaRow == 1 && deltaCol == 2))
        {
            return true;
        }

        return false;
    }

    static int GetKnightMinSteps(int startRow, int startCol, int targetRow, int targetCol)
    {
        int[] dx = { 2, 2, -2, -2, 1, 1, -1, -1 };
        int[] dy = { 1, -1, 1, -1, 2, -2, 2, -2 };

        Queue<(int, int, int)> queue = new Queue<(int, int, int)>();
        queue.Enqueue((startRow, startCol, 0));

        bool[,] visited = new bool[9, 9]; 
        visited[startRow, startCol] = true;

        while (queue.Count > 0)
        {
            var (r, c, dist) = queue.Dequeue();

            if (r == targetRow && c == targetCol)
                return dist;

            for (int i = 0; i < 8; i++)
            {
                int nextR = r + dx[i];
                int nextC = c + dy[i];

                if (nextR >= 1 && nextR <= 8 && nextC >= 1 && nextC <= 8 && !visited[nextR, nextC])
                {
                    visited[nextR, nextC] = true;
                    queue.Enqueue((nextR, nextC, dist + 1));
                }
            }
        }
        return -1;
    }

}
