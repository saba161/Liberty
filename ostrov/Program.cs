using System;

namespace ostrov
{
    class Program
    {
        public static int[,] matrix;
        public static int columns;
        public static int rows;

        static void Main(string[] args)
        {
            columns = 3;//int.Parse(Console.ReadLine());
            rows = 3;//int.Parse(Console.ReadLine());

            int count = 0;
            //matrix = new int[rows, columns];

            matrix = new int[3,3]
            {
                { 1, 0, 0 },
                { 0, 0, 1 },
                { 0, 1, 0 },
            };

           // FillTheMatrix(rows, columns);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        count++;
                        Check(i, j);
                    }
                }
            }

            Console.WriteLine(count);
        }

        public static bool Check(int row, int col)
        {
            if (row < 0 || col < 0 || col >= columns || row >= rows)
            {
                return false;
            }

            if (matrix[row, col] != 1)
            {
                return false;
            }

            matrix[row, col] = 2;

            //Horizontal and Vertical
            Check(row + 1, col);
            Check(row - 1, col);
            Check(row, col + 1);
            Check(row, col - 1); 
            
            //Diagonal
            Check(row - 1, col - 1);
            Check(row + 1, col - 1);
            Check(row - 1, col + 1);
            Check(row + 1, col + 1);

            return true;
        }

        public static void FillTheMatrix(int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix[i,j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
    }
}