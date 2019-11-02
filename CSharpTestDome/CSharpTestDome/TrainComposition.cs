/*
    A TrainComposition is built by attaching and detaching wagons from the left and the right sides, efficiently with respect to time used.

    For example, if we start by attaching wagon 7 from the left followed by attaching wagon 13, 
    3 again from the left, 
    we get a composition of two wagons (13 and 7 from left to right). 
    Now the first wagon that can be detached from the right is 7 and the first that can be detached from the left is 13.

    Implement a TrainComposition that models this problem. 

    Tip: practice Linked List and Doubly Linked List
*/

using System;

public class TrainComposition
{
    public LinkedList<int> WagonList = new LinkedList<int>();
    public void AttachWagonFromLeft(int wagonId)
    {
        WagonList.AddLast(wagonId);
    }

    public void AttachWagonFromRight(int wagonId)
    {
        WagonList.AddFirst(wagonId);
    }

    public int DetachWagonFromLeft()
    {
        int result = WagonList.Last.Value;
        WagonList.RemoveLast();
        return result;
    }

    public int DetachWagonFromRight()
    {
        int result = WagonList.First.Value;
        WagonList.RemoveFirst();
        return result;
    }

    public static void Main(string[] args)
    {
        var tree = new TrainComposition();
        tree.AttachWagonFromLeft(7);
        tree.AttachWagonFromLeft(13);
        Console.WriteLine(tree.DetachWagonFromRight()); // 7 
        Console.WriteLine(tree.DetachWagonFromLeft()); // 13
    }
}
