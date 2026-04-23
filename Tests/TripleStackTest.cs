using Challenges;
using Challenges.ThreeStacksOneArray;

namespace Tests;

public class TripleStackTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ShouldPushToStartUntilFull()
    {
        int size = 10;
        var stack = new TripleStack(size);

        for (int i = 0; i < size; i++)
        {
            stack.PushToStart(i);
        }

        Assert.Throws<InvalidOperationException>(() => stack.PushToStart(size));
    }
    
    [Test]
    public void ShouldPushToEndUntilFull()
    {
        int size = 10;
        var stack = new TripleStack(size);

        for (int i = 0; i < size; i++)
        {
            stack.PushToEnd(i);
        }

        Assert.Throws<InvalidOperationException>(() => stack.PushToEnd(size));
    }

    [Test]
    public void ShouldPopFromStartUntilEmpty()
    {
        int size = 10;
        var stack = new TripleStack(size);
        
        for (int i = 0; i < size; i++)
        {
            stack.PushToStart(i);
        }
        
        for (int i = size - 1; i >= 0; i--)
        {
            Assert.AreEqual(i, stack.PopFromStart());
        }
        Assert.Throws<InvalidOperationException>(() => stack.PopFromStart());
    }
    
    [Test]
    public void ShouldPopFromEndUntilEmpty()
    {
        int size = 10;
        var stack = new TripleStack(size);
        
        for (int i = 0; i < size; i++)
        {
            stack.PushToEnd(i);
        }
        
        for (int i = size - 1; i >= 0; i--)
        {
            Assert.AreEqual(i, stack.PopFromEnd());
        }
        Assert.Throws<InvalidOperationException>(() => stack.PopFromEnd());
    }
}