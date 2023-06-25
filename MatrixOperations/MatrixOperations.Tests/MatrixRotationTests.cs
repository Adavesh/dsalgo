namespace MatrixOperations.Tests;

public class MatrixRotationTests
{
    [Fact]
    public void RotateRight90Degrees_SquareMatrix_Test()
    {
        var matrix = new int[,]
        {
            { 10, 11, 12, 13 },
            { 14, 15, 16, 17 },
            { 18, 19, 20, 21 },
            { 22, 23, 24, 25 }
        };

        var expected = new int[,]
        {
            { 22, 18, 14, 10 },
            { 23, 19, 15, 11 },
            { 24, 20, 16, 12 },
            { 25, 21, 17, 13 }
        };

        var actual = Matrix.RotateRight90Degrees(matrix);    

        Assert.True(AreEqual(expected, actual));
    }

    [Fact]
    public void RotateLeft90Degrees_SquareMatrix_Test()
    {
        var matrix = new int[,]
        {
            { 10, 11, 12, 13 },
            { 14, 15, 16, 17 },
            { 18, 19, 20, 21 },
            { 22, 23, 24, 25 }
        };

        var expected = new int[,]
        {
            { 13, 17, 21, 25 },
            { 12, 16, 20, 24 },
            { 11, 15, 19, 23 },
            { 10, 14, 18, 22 }
        };

        var actual = Matrix.RotateLeft90Degrees(matrix);

        Assert.True(AreEqual(expected, actual));
    }

    [Fact]
    public void RotateRight90Degrees_NonSquareMatrix_Test()
    {
        var matrix = new int[,]
        {
            { 10, 11, 12, 13 },
            { 14, 15, 16, 17 },
            { 18, 19, 20, 21 }
        };

        var expected = new int[,]
        {
            { 18, 14, 10 },
            { 19, 15, 11 },
            { 20, 16, 12 },
            { 21, 17, 13 }
        };

        var actual = Matrix.RotateRight90Degrees(matrix);

        Assert.True(AreEqual(expected, actual));
    }

    [Fact]
    public void RotateLeft90Degrees_NonSquareMatrix_Test()
    {
        var matrix = new int[,]
        {
            { 10, 11, 12, 13 },
            { 14, 15, 16, 17 },
            { 18, 19, 20, 21 }
        };

        var expected = new int[,]
        {
            { 13, 17, 21 },
            { 12, 16, 20 },
            { 11, 15, 19 },
            { 10, 14, 18 }
        };

        var actual = Matrix.RotateLeft90Degrees(matrix);

        Assert.True(AreEqual(expected, actual));
    }

    [Fact]
    public void RotateLeft180Degrees_SquareMatrix_Test()
    {
        var matrix = new int[,]
        {
            { 10, 11, 12, 13, 14 },
            { 15, 16, 17, 18, 19 },
            { 20, 21, 22, 23, 24 },
            { 25, 26, 27, 28, 29 }
        };

        var expected = new int[,]
        {
            { 29, 28, 27, 26, 25 },
            { 24, 23, 22, 21, 20 },
            { 19, 18, 17, 16, 15 },
            { 14, 13, 12, 11, 10 }
        };

        var actual = Matrix.Rotate180Degrees(matrix);

        Assert.True(AreEqual(expected, actual));
    }

    [Fact]
    public void RotateLeft180Degrees_NonSquareMatrix_Test()
    {
        var matrix = new int[,]
        {
            { 10, 11 },
            { 12, 13 },
            { 14, 15 },
            { 16, 17 },
            { 18, 19 },
        };

        var expected = new int[,]
        {
            { 19, 18 },
            { 17, 16 },
            { 15, 14 },
            { 13, 12 },
            { 11, 10 }
        };

        var actual = Matrix.Rotate180Degrees(matrix);

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
                if (source[i, j] != target[i, j])
                {
                    return false;
                }
            }
        }

        return true;
    }
}
