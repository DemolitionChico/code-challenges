using MergeSortedArrays;

namespace Tests;

public class MergeSortedArraysTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ShouldMergeProperly()
    {
        var arr1 = new int[] { 1, 3, 5 };
        var arr2 = new int[] { 2, 4, 6 };

        var mergedArr1 = ArrayMerger.Merge(arr1, arr2);
        var mergedArr2 = ArrayMerger.Merge(arr2, arr1);

        Assert.That(mergedArr1, Is.EquivalentTo(new int[] { 1, 2, 3, 4, 5, 6 }));
        Assert.That(mergedArr2, Is.EquivalentTo(new int[] { 1, 2, 3, 4, 5, 6 }));
    }
    
    [Test]
    public void ShouldMergeDifferentSizes()
    {
        var arr1 = new int[] { 1, 3, 5 };
        var arr2 = new int[] { 2, 4, 6, 8, 10 };

        var mergedArr1 = ArrayMerger.Merge(arr1, arr2);
        var mergedArr2 = ArrayMerger.Merge(arr2, arr1);

        Assert.That(mergedArr1, Is.EquivalentTo(new int[] { 1, 2, 3, 4, 5, 6, 8, 10 }));
        Assert.That(mergedArr2, Is.EquivalentTo(new int[] { 1, 2, 3, 4, 5, 6, 8, 10 }));
    }
}