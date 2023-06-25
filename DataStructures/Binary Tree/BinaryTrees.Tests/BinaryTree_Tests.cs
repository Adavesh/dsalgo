using FluentAssertions;
using Xunit;

namespace BinaryTrees._Tests;

public class BinaryTree_Tests
{
    private readonly int[] input = { 56, 65, 32, 40, 48, 25, 20, 54, 18, 23, 12, 36 };

    [Fact]
    public void Build_Test()
    {
        //Redirect the Console to StringWriter to capture the displayed output
        var console = new StringWriter();
        Console.SetOut(console);

        //Build the tree with array of items
        var bTree = new BinaryTree<int>();
        bTree.Build(input);

        //Display the output
        bTree.Display(TraverseMode.BreadFirst);

        int[] expected = { 56, 65, 32, 40, 48, 25, 20, 54, 18, 23, 12, 36 };
        var output = console.ToString()
            .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        //Assert
        for (int i = 0; i < input.Length; i++)
        {
            Assert.Equal(expected[i], output[i]);
        }
    }

    [Fact]
    public void Add_Test()
    {
        //Redirect the Console to StringWriter to capture the displayed output
        var console = new StringWriter();
        Console.SetOut(console);

        //Build the tree with array of items
        var bTree = new BinaryTree<int>();
        bTree.Build(input);

        //Method to _Test. 
        bTree.Add(15);

        //Display the output
        bTree.Display(TraverseMode.BreadFirst);

        int[] expected = { 56, 65, 32, 40, 48, 25, 20, 54, 18, 23, 12, 36, 15 };
        int[] actual = console.ToString().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        //Assert - Lengths
        Assert.Equal(expected.Length, actual.Length);

        //Assert - elements
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }

    [Fact]
    public void Remove_Test()
    {
        //Redirect the Console to StringWriter to capture the displayed output
        var console = new StringWriter();
        Console.SetOut(console);

        //Build the tree with array of items
        var bTree = new BinaryTree<int>();
        bTree.Build(input);

        //Method to _Test. 
        bTree.Remove(65);

        //Display the output
        bTree.Display(TraverseMode.BreadFirst);

        int[] expected = { 56, 40, 32, 54, 48, 25, 20, 18, 23, 12, 36 };
        int[] actual = console.ToString().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        //Assert - Lengths
        Assert.Equal(expected.Length, actual.Length);

        //Assert - elements
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }

    [Fact]
    public void PreOrderTraverse_Test()
    {
        //Redirect the Console to StringWriter to capture the displayed output
        var console = new StringWriter();
        Console.SetOut(console);

        //Build the tree with array of items
        var bTree = new BinaryTree<int>();
        bTree.Build(input);

        //Display the output
        bTree.Display(TraverseMode.PreOrder);

        int[] expected = { 54, 40, 18, 65, 23, 48, 12, 56, 36, 25, 32, 20 };
        int[] actual = console.ToString().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        //Assert - Lengths
        Assert.Equal(expected.Length, actual.Length);

        //Assert - elements
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }

    [Fact]
    public void PostOrderTraverse_Test()
    {
        //Redirect the Console to StringWriter to capture the displayed output
        var console = new StringWriter();
        Console.SetOut(console);

        //Build the tree with array of items
        var bTree = new BinaryTree<int>();
        bTree.Build(input);

        //Display the output
        bTree.Display(TraverseMode.PostOrder);

        int[] expected = { 20, 32, 25, 36, 56, 12, 48, 23, 65, 18, 40, 54 };
        int[] actual = console.ToString().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        //Assert - Lengths
        Assert.Equal(expected.Length, actual.Length);

        //Assert - elements
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }

    [Fact]
    public void InOrderTraverse_Test()
    {
        //Redirect the Console to StringWriter to capture the displayed output
        var console = new StringWriter();
        Console.SetOut(console);

        //Build the tree with array of items
        var bTree = new BinaryTree<int>();
        bTree.Build(input);

        //Display the output
        bTree.Display(TraverseMode.InOrder);

        int[] expected = { 56, 65, 40, 54, 18, 48, 23, 12, 32, 25, 36, 20 };
        int[] actual = console.ToString().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        //Assert - Lengths
        Assert.Equal(expected.Length, actual.Length);

        //Assert - elements
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }

    [Fact]
    public void DisplayLeaves_Test()
    {
        //Redirect the Console to StringWriter to capture the displayed output
        var console = new StringWriter();
        Console.SetOut(console);

        //Build the tree with array of items
        var bTree = new BinaryTree<int>();
        bTree.Build(input);

        //Display the output
        bTree.DisplayLeaves();

        int[] expected = { 54, 18, 23, 12, 36, 20 };
        int[] actual = console.ToString().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        //Assert - Lengths
        Assert.Equal(expected.Length, actual.Length);

        //Assert - elements
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }

    [Fact]
    public void DisplayOuterLeaves_Test()
    {
        //Redirect the Console to StringWriter to capture the displayed output
        var console = new StringWriter();
        Console.SetOut(console);

        //Build the tree with array of items
        var bTree = new BinaryTree<int>();
        bTree.Build(input);

        //Display the output
        bTree.DisplayOuterLeaves();

        int[] expected = { 56, 65, 40, 54, 18, 23, 12, 36, 20, 32 };
        int[] actual = console.ToString().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        //Assert - Lengths
        Assert.Equal(expected.Length, actual.Length);

        //Assert - elements
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }

    [Fact]
    public void DisplayHeight_Test()
    {
        //Redirect the Console to StringWriter to capture the displayed output
        var console = new StringWriter();
        Console.SetOut(console);

        //Build the tree with array of items
        var bTree = new BinaryTree<int>();
        bTree.Build(input);

        //Display the output
        bTree.DisplayHeight();

        var expected = "3";
        var actual = console.ToString();

        //Assert - Lengths
        Assert.Equal(expected, actual);
    }
}