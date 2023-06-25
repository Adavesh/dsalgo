namespace MatrixOperations.Tests;

public class MatrixTransposeTest
{
    [Fact]
    public void Transpose_NxN_Test()
    {
        // Initialize
        var matrix = new int[,]
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        var expected = new int[,]
        {
            { 1, 4, 7 },
            { 2, 5, 8 },
            { 3, 6, 9 }
        };

        // Test
        int[,] actual = Matrix.Transpose(matrix);

        //Assert
        Assert.True(AreEqual(expected, actual));
    }

    [Fact]
    public void Transpose_MxN_Test()
    {
        // Initialize
        var matrix = new int[,]
        {
            { 1, 2, 3 },
            { 4, 5, 6 }
        };

        var expected = new int[,]
        {
            { 1, 4 },
            { 2, 5 },
            { 3, 6 }
        };

        // Test
        int[,] actual = Matrix.Transpose(matrix);

        //Assert
        Assert.True(AreEqual(expected, actual));
    }

    private bool AreEqual(int[,] source, int[,] target)
    {
        var sourceRows = source.GetLength(0);
        var sourceColumns = source.GetLength(1);

        var targetRows = target.GetLength(0);
        var targetColumns = target.GetLength(1);

        if (sourceRows != targetRows || sourceColumns != targetColumns)
        {
            return false;
        }

        for (int i = 0; i < sourceRows; i++)
        {
            for (int j = 0; j < sourceColumns; j++)
            {
                if (source[i,j] != target[i, j])
                {
                    return false;
                }
            }
        }

        return true;
    }
}