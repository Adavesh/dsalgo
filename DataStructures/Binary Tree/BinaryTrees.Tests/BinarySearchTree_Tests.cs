using System;
using BinaryTrees;
using FluentAssertions;
using Xunit;

namespace BinarySearchTrees.Tests;

public class BinarySearchTree_Tests
{
    private readonly int[] input = { 56, 65, 32, 40, 48, 25, 20, 54, 18, 23, 12, 36 };

    [Fact]
    public void Build_Test()
    {
        //Redirect the Console to StringWriter to capture the displayed output
        var console = new StringWriter();
        Console.SetOut(console);

        //Build the tree with array of items
        var bTree = new BinarySearchTree<int>();
        bTree.Build(input);

        //Display the output
        bTree.Display(TraverseMode.BreadFirst);

        int[] expected = { 56, 32, 65, 25, 40, 20, 36, 48, 18, 23, 54, 12 };
        ValidateExpectedAndActual(expected, console.ToString());
    }

    [Fact]
    public void Add_Test()
    {
        //Redirect the Console to StringWriter to capture the displayed output
        var console = new StringWriter();
        Console.SetOut(console);

        //Build the tree with array of items
        var bTree = new BinarySearchTree<int>();
        bTree.Build(input);

        //Method to _Test. 
        bTree.Add(15);

        //Display the output
        bTree.Display(TraverseMode.BreadFirst);

        int[] expected = { 56, 32, 65, 25, 40, 20, 36, 48, 18, 23, 54, 12, 15 };
        ValidateExpectedAndActual(expected, console.ToString());
    }

    [Fact]
    public void Remove_Test()
    {
        //Redirect the Console to StringWriter to capture the displayed output
        var console = new StringWriter();
        Console.SetOut(console);

        //Build the tree with array of items
        var bTree = new BinarySearchTree<int>();
        bTree.Build(input);

        //Method to _Test. 
        bTree.Remove(32);

        //Display the output
        bTree.Display(TraverseMode.BreadFirst);

        int[] expected = { 56, 25, 65, 20, 40, 18, 23, 36, 48, 12, 54 };
        ValidateExpectedAndActual(expected, console.ToString());
    }

    [Fact]
    public void PreOrderTraverse_Test()
    {
        //Redirect the Console to StringWriter to capture the displayed output
        var console = new StringWriter();
        Console.SetOut(console);

        //Build the tree with array of items
        var bTree = new BinarySearchTree<int>();
        bTree.Build(input);

        //Display the output
        bTree.Display(TraverseMode.PreOrder);

        int[] expected = { 12, 18, 20, 23, 25, 32, 36, 40, 48, 54, 56, 65 };
        ValidateExpectedAndActual(expected, console.ToString());
    }

    [Fact]
    public void PostOrderTraverse_Test()
    {
        //Redirect the Console to StringWriter to capture the displayed output
        var console = new StringWriter();
        Console.SetOut(console);

        //Build the tree with array of items
        var bTree = new BinarySearchTree<int>();
        bTree.Build(input);

        //Display the output
        bTree.Display(TraverseMode.PostOrder);

        int[] expected = { 65, 56, 54, 48, 40, 36, 32, 25, 23, 20, 18, 12 };
        ValidateExpectedAndActual(expected, console.ToString());
    }

    [Fact]
    public void InOrderTraverse_Test()
    {
        //Redirect the Console to StringWriter to capture the displayed output
        var console = new StringWriter();
        Console.SetOut(console);

        //Build the tree with array of items
        var bTree = new BinarySearchTree<int>();
        bTree.Build(input);

        //Display the output
        bTree.Display(TraverseMode.InOrder);

        int[] expected = { 56, 32, 25, 20, 18, 12, 23, 40, 36, 48, 54, 65 };
        ValidateExpectedAndActual(expected, console.ToString());
    }

    [Fact]
    public void DisplayLeaves_Test()
    {
        //Redirect the Console to StringWriter to capture the displayed output
        var console = new StringWriter();
        Console.SetOut(console);

        //Build the tree with array of items
        var bTree = new BinarySearchTree<int>();
        bTree.Build(input);

        //Display the output
        bTree.DisplayLeaves();

        int[] expected = { 12, 23, 36, 54, 65 };
        ValidateExpectedAndActual(expected, console.ToString());
    }

    [Fact]
    public void DisplayOuterRing_Test()
    {
        //Redirect the Console to StringWriter to capture the displayed output
        var console = new StringWriter();
        Console.SetOut(console);

        //Build the tree with array of items
        var bTree = new BinarySearchTree<int>();
        bTree.Build(input);

        //Display the output
        bTree.DisplayOuterRing();

        int[] expected = { 56, 32, 25, 20, 18, 12, 23, 36, 54, 65 };
        ValidateExpectedAndActual(expected, console.ToString());
    }

    [Fact]
    public void DisplayHeight_Test()
    {
        //Redirect the Console to StringWriter to capture the displayed output
        var console = new StringWriter();
        Console.SetOut(console);

        //Build the tree with array of items
        var bTree = new BinarySearchTree<int>();
        bTree.Build(input);

        //Display the output
        bTree.DisplayHeight();

        var expected = "5";
        var actual = console.ToString();

        //Assert - Lengths
        Assert.Equal(expected, actual);
    }

    private void ValidateExpectedAndActual(int[] expected, string consoleOutput)
    {
        int[] actual = consoleOutput
            .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        //Assert - Lengths
        Assert.Equal(expected.Length, actual.Length);

        //Assert - elements
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }
}