namespace MatrixOperations;

public class Matrix
{
    public static int[,] Transpose(int[,] matrix)
    {
        var rows = matrix.GetLength(0);
        var cols = matrix.GetLength(1);

        if (rows != cols)
        {
            var transpose = new int[cols, rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    transpose[j, i] = matrix[i, j];
                }
            }

            return transpose;
        }
        else
        {
            // This else is not required even for NxN matrix
            // It just to demonstrate NxN matrix transpose without creating another matrix.
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i == j) break;

                    (matrix[j, i], matrix[i, j]) = (matrix[i, j], matrix[j, i]);
                }
            }

            return matrix;
        }
    }

    public static int[,] RotateRight90Degrees(int[,] matrix)
    {
        var rows = matrix.GetLength(0);
        var cols = matrix.GetLength(1);

        if (rows != cols)
        {
            // If rows count and column count are different,
            // we need another matrix to hold the result of rotation

            var result = new int[cols, rows];

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    result[i, j] = matrix[rows - j - 1, i];
                }
            }

            return result;
        }
        else
        {
            // It is a square matrix, so we can rotate the actual matrix
            // No need of intermediate matrix.

            var length = matrix.GetLength(0);
            var limit = matrix.GetLength(1) / 2;

            for (int i = 0; i < limit; i++)
            {
                for (int j = 0; j < limit + length % 2; j++)
                {
                    var temp = matrix[i, j];
                    matrix[i, j] = matrix[length - j - 1, i];
                    matrix[length - j - 1, i] = matrix[length - i - 1, length - j - 1];
                    matrix[length - i - 1, length - j - 1] = matrix[j, length - i - 1];
                    matrix[j, length - i - 1] = temp;
                }
            }

            return matrix;
        }
    }

    public static int[,] RotateLeft90Degrees(int[,] matrix)
    {
        var rows = matrix.GetLength(0);
        var cols = matrix.GetLength(1);

        if (rows != cols)
        {
            // If rows count and column count are different,
            // we need another matrix to hold the result of rotation

            var result = new int[cols, rows];

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    result[i, j] = matrix[j, cols - i - 1];
                }
            }

            return result;
        }
        else
        {
            // It is a square matrix, so we can rotate the actual matrix
            // No need of intermediate matrix.

            var length = matrix.GetLength(0);
            var limit = matrix.GetLength(1) / 2;

            for (int i = 0; i < limit; i++)
            {
                for (int j = 0; j < limit + length % 2; j++)
                {
                    var temp = matrix[i,j];
                    matrix[i, j] = matrix[j, length - i - 1];
                    matrix[j, length - i - 1] = matrix[length-i-1, length - j - 1];
                    matrix[length - i - 1, length - j - 1] = matrix[length - j - 1, i];
                    matrix[length - j - 1, i] = temp;
                }
            }

            return matrix;
        }
    }

    public static int[,] Rotate180Degrees(int[,] matrix)
    {
        var cols = matrix.GetLength(1);
        var rows = matrix.GetLength(0);
        var rowsLimit = rows / 2 + rows % 2;

        for (int i = 0; i < rowsLimit; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                (matrix[i, j], matrix[rows - i - 1, cols - j - 1]) = (matrix[rows - i - 1, cols - j - 1], matrix[i, j]);

                if(i == rowsLimit - 1)
                {
                    break;
                }
            }
        }

        return matrix;
    }
}

