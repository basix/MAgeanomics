using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mageanomics.Collections;
using System.Collections.Generic;

namespace UnitTests.Collections
{
    [TestClass]
    public class ZipListTests
    {
        [TestMethod]
        public void ZipListRemoveFront0Items()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            // Act 
            var removedItem = list.RemoveFront();

            // Assert
            Assert.AreEqual(list.Head, null);
            Assert.AreEqual(list.Tail, null);
            Assert.AreEqual(list.Center, null);
            Assert.AreEqual(removedItem, default(int));

            Assert.AreEqual(list.Head, list.Tail);
            Assert.AreEqual(list.Center, list.Tail);
            Assert.AreEqual(list.Head, list.Center);
        }

        [TestMethod]
        public void ZipListRemoveBack0Items()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            // Act 
            var removedItem = list.RemoveBack();

            // Assert
            Assert.AreEqual(list.Head, null);
            Assert.AreEqual(list.Tail, null);
            Assert.AreEqual(list.Center, null);
            Assert.AreEqual(removedItem, default(int));

            Assert.AreEqual(list.Head, list.Tail);
            Assert.AreEqual(list.Center, list.Tail);
            Assert.AreEqual(list.Head, list.Center);
        }

        [TestMethod]
        public void ZipListAddFront1Item()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            // Act 
            list.AddFront(5);

            // Assert
            Assert.AreEqual(list.Head.Data, 5);
            Assert.AreEqual(list.Tail.Data, 5);
            Assert.AreEqual(list.Center.Data, 5);

            Assert.AreEqual(list.Head, list.Tail);
            Assert.AreEqual(list.Center, list.Tail);
            Assert.AreEqual(list.Head, list.Center);
        }

        [TestMethod]
        public void ZipListAddBack1Item()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            // Act 
            list.AddBack(5);

            // Assert
            Assert.AreEqual(list.Head.Data, 5);
            Assert.AreEqual(list.Tail.Data, 5);
            Assert.AreEqual(list.Center.Data, 5);

            Assert.AreEqual(list.Head, list.Tail);
            Assert.AreEqual(list.Center, list.Tail);
            Assert.AreEqual(list.Head, list.Center);
        }

        [TestMethod]
        public void ZipListAddFrontRemoveFront1Item()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            // Act 
            list.AddFront(5);
            var removedItem = list.RemoveFront();

            // Assert
            Assert.AreEqual(list.Head, null);
            Assert.AreEqual(list.Tail, null);
            Assert.AreEqual(list.Center, null);
            Assert.AreEqual(removedItem, 5);

            Assert.AreEqual(list.Head, list.Tail);
            Assert.AreEqual(list.Center, list.Tail);
            Assert.AreEqual(list.Head, list.Center);
        }

        [TestMethod]
        public void ZipListAddFrontRemoveBack1Item()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            // Act 
            list.AddFront(5);
            var removedItem = list.RemoveBack();

            // Assert
            Assert.AreEqual(list.Head, null);
            Assert.AreEqual(list.Tail, null);
            Assert.AreEqual(list.Center, null);
            Assert.AreEqual(removedItem, 5);

            Assert.AreEqual(list.Head, list.Tail);
            Assert.AreEqual(list.Center, list.Tail);
            Assert.AreEqual(list.Head, list.Center);
        }

        [TestMethod]
        public void ZipListAddBackRemoveBack1Item()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            // Act 
            list.AddBack(5);
            var removedItem = list.RemoveBack();

            // Assert
            Assert.AreEqual(list.Head, null);
            Assert.AreEqual(list.Tail, null);
            Assert.AreEqual(list.Center, null);
            Assert.AreEqual(removedItem, 5);

            Assert.AreEqual(list.Head, list.Tail);
            Assert.AreEqual(list.Center, list.Tail);
            Assert.AreEqual(list.Head, list.Center);
        }

        [TestMethod]
        public void ZipListAddBackRemoveFront1Item()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            // Act 
            list.AddBack(5);
            var removedItem = list.RemoveFront();

            // Assert
            Assert.AreEqual(list.Head, null);
            Assert.AreEqual(list.Tail, null);
            Assert.AreEqual(list.Center, null);
            Assert.AreEqual(removedItem, 5);

            Assert.AreEqual(list.Head, list.Tail);
            Assert.AreEqual(list.Center, list.Tail);
            Assert.AreEqual(list.Head, list.Center);
        }

        [TestMethod]
        public void ZipListAdd2ItemsFront()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            // Act 
            list.AddFront(5);
            list.AddFront(4);

            // Assert
            Assert.AreEqual(list.Head.Data, 4);
            Assert.AreEqual(list.Tail.Data, 5);
            Assert.AreEqual(list.Center.Data, 5);

            Assert.AreEqual(list.Center, list.Tail);
        }

        [TestMethod]
        public void ZipListAdd2ItemsBack()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            // Act 
            list.AddBack(4);
            list.AddBack(5);

            // Assert
            Assert.AreEqual(list.Head.Data, 4);
            Assert.AreEqual(list.Tail.Data, 5);
            Assert.AreEqual(list.Center.Data, 5);

            Assert.AreEqual(list.Center, list.Tail);
        }

        [TestMethod]
        public void ZipListAdd2ItemsFrontBack()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            // Act 
            list.AddFront(4);
            list.AddBack(5);

            // Assert
            Assert.AreEqual(list.Head.Data, 4);
            Assert.AreEqual(list.Tail.Data, 5);
            Assert.AreEqual(list.Center.Data, 5);

            Assert.AreEqual(list.Center, list.Tail);
        }

        [TestMethod]
        public void ZipListAdd2ItemsBackFront()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            // Act 
            list.AddBack(5);
            list.AddFront(4);

            // Assert
            Assert.AreEqual(list.Head.Data, 4);
            Assert.AreEqual(list.Tail.Data, 5);
            Assert.AreEqual(list.Center.Data, 5);

            Assert.AreEqual(list.Center, list.Tail);
        }

        [TestMethod]
        public void ZipListCenterAt3()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            // Act 
            list.AddFront(2);
            list.AddBack(3);
            list.AddFront(1);

            // Assert
            Assert.AreEqual(list.Center.Data, 2);
        }

        [TestMethod]
        public void ZipListCenterAt5()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            // Act 
            list.AddBack(2);
            list.AddFront(1);
            list.AddBack(3);
            list.AddFront(0);
            list.AddBack(4);

            // Assert
            Assert.AreEqual(list.Center.Data, 2);
        }

        [TestMethod]
        public void ZipListRemoveBackKeepsCorrectCenter()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            list.AddFront(3);
            list.AddBack(4);
            list.AddFront(2);
            list.AddBack(5);
            list.AddFront(1);
            list.AddBack(6);
            list.AddFront(0);

            var expectedValues = new int[] { 3, 3, 2, 2, 1, 1, 0};

            // Act
            for (int i = 0; i < 7; i++)
            {
                // Assert
                Assert.AreEqual(list.Center.Data, expectedValues[i]);
                list.RemoveBack();
            }
        }

        [TestMethod]
        public void ZipListRemoveFrontKeepsCorrectCenter()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            list.AddFront(3);
            list.AddBack(4);
            list.AddFront(2);
            list.AddBack(5);
            list.AddFront(1);
            list.AddBack(6);
            list.AddFront(0);

            var expectedValues = new int[] { 3, 4, 4, 5, 5, 6, 6 };

            // Act
            for (int i = 0; i < 7; i++)
            {
                // Assert
                Assert.AreEqual(list.Center.Data, expectedValues[i]);
                list.RemoveFront();
            }
        }

        [TestMethod]
        public void ZipListForwardIterate()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            list.AddBack(2);
            list.AddFront(1);
            list.AddBack(3);
            list.AddFront(0);
            list.AddBack(4);

            // Act
            int value = 0;
            Node<int> iterator = list.Head;

            // make sure the list is in order and that we ave iterated through all members.
            while (iterator != null)
            {
                // Assert
                Assert.AreEqual(value, iterator.Data);
                iterator = iterator.Next;
                value++;
            }

            Assert.AreEqual(value, list.Count, "The count should be 5 before we have a null element.");
        }

        [TestMethod]
        public void ZipListReverseIterate()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            list.AddBack(2);
            list.AddFront(1);
            list.AddBack(3);
            list.AddFront(0);
            list.AddBack(4);

            // Act
            int value = 4;
            Node<int> iterator = list.Tail;

            // make sure the list is in order and that we ave iterated through all members.
            while (iterator != null)
            {
                // Assert
                Assert.AreEqual(value, iterator.Data);
                iterator = iterator.Previous;
                value--;
            }

            Assert.AreEqual(value, -1, "The count should be 5 before we have a null element.");
        }

        [TestMethod]
        public void RedundantRemovesKeepsCountAt0()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            // ACT
            list.RemoveBack();
            list.RemoveFront();
            list.RemoveBack();
            list.RemoveFront();

            Assert.AreEqual(list.Count, 0);
        }

        [TestMethod]
        public void SplitEmptyZipList()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            // Act
            var splitList = list.Split();

            // Assert
            Assert.AreEqual(splitList, null);
        }

        [TestMethod]
        public void SplitSize1ZipList()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            list.AddFront(0);

            // Act
            var splitList = list.Split();

            // Assert
            Assert.AreEqual(splitList, null);
        }

        [TestMethod]
        public void SplitSize2ZipList()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            list.AddFront(0);
            list.AddBack(1);

            // Act
            var splitList = list.Split();

            // Assert
            Assert.AreEqual(splitList.Head, splitList.Tail);
            Assert.AreEqual(splitList.Center, splitList.Tail);
            Assert.AreEqual(splitList.Head, splitList.Center);
            Assert.AreEqual(splitList.Count, 1);
            Assert.AreEqual(splitList.Head.Data, 0);

            Assert.AreEqual(list.Head, list.Tail);
            Assert.AreEqual(list.Center, list.Tail);
            Assert.AreEqual(list.Head, list.Center);
            Assert.AreEqual(list.Count, 1);
            Assert.AreEqual(list.Head.Data, 1);
        }

        [TestMethod]
        public void SplitSize3ZipList()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            list.AddFront(1);
            list.AddBack(2);
            list.AddFront(0);

            // Act
            var splitList = list.Split();

            // Assert
            Assert.AreEqual(splitList.Head, splitList.Tail);
            Assert.AreEqual(splitList.Center, splitList.Tail);
            Assert.AreEqual(splitList.Head, splitList.Center);
            Assert.AreEqual(splitList.Count, 1);
            Assert.AreEqual(splitList.Head.Data, 0);

            Assert.AreNotEqual(list.Head, list.Tail);
            Assert.AreEqual(list.Center, list.Tail);
            Assert.AreNotEqual(list.Head, list.Center);
            Assert.AreEqual(list.Count, 2);
            Assert.AreEqual(list.Head.Data, 1);
            Assert.AreEqual(list.Center.Data, 2);
        }

        [TestMethod]
        public void SplitEvenSizedZipList()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            list.AddFront(1);
            list.AddBack(2);
            list.AddFront(0);
            list.AddBack(3);

            // Act
            var splitList = list.Split();

            // Assert
            Assert.AreNotEqual(splitList.Head, splitList.Tail);
            Assert.AreEqual(splitList.Center, splitList.Tail);
            Assert.AreNotEqual(splitList.Head, splitList.Center);
            Assert.AreEqual(splitList.Count, 2);
            Assert.AreEqual(splitList.Head.Data, 0);
            Assert.AreEqual(splitList.Center.Data, 1);

            Assert.AreNotEqual(list.Head, list.Tail);
            Assert.AreEqual(list.Center, list.Tail);
            Assert.AreNotEqual(list.Head, list.Center);
            Assert.AreEqual(list.Count, 2);
            Assert.AreEqual(list.Head.Data, 2);
            Assert.AreEqual(list.Center.Data, 3);
        }

        [TestMethod]
        public void SplitOddSizedZipList()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            list.AddFront(1);
            list.AddBack(2);
            list.AddFront(0);
            list.AddBack(3);
            list.AddBack(4);

            // Act
            var splitList = list.Split();

            // Assert
            Assert.AreNotEqual(splitList.Head, splitList.Tail);
            Assert.AreEqual(splitList.Center, splitList.Tail);
            Assert.AreNotEqual(splitList.Head, splitList.Center);
            Assert.AreEqual(splitList.Count, 2);
            Assert.AreEqual(splitList.Head.Data, 0);
            Assert.AreEqual(splitList.Center.Data, 1);

            Assert.AreNotEqual(list.Head, list.Tail);
            Assert.AreNotEqual(list.Center, list.Tail);
            Assert.AreNotEqual(list.Head, list.Center);
            Assert.AreEqual(list.Count, 3);
            Assert.AreEqual(list.Head.Data, 2);
            Assert.AreEqual(list.Center.Data, 3);
            Assert.AreEqual(list.Tail.Data, 4);
        }

        [TestMethod]
        public void Split6SizedZipListForwardIterateFirstHalf()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            list.AddFront(3);
            list.AddBack(4);
            list.AddFront(2);
            list.AddBack(5);
            list.AddFront(1);
            list.AddFront(0);

            // Act
            var splitList = list.Split();

            int value = 0;
            Node<int> iterator = splitList.Head;

            // make sure the list is in order and that we ave iterated through all members.
            while (iterator != null)
            {
                // Assert
                Assert.AreEqual(value, iterator.Data);
                iterator = iterator.Next;
                value++;
            }

            // Assert
            Assert.AreEqual(value, splitList.Count);
        }

        [TestMethod]
        public void Split6SizedZipListForwardIterateSecondHalf()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            list.AddFront(3);
            list.AddBack(4);
            list.AddFront(2);
            list.AddBack(5);
            list.AddFront(1);
            list.AddFront(0);

            // Act
            list.Split();

            int value = 3;
            Node<int> iterator = list.Head;

            // make sure the list is in order and that we ave iterated through all members.
            while (iterator != null)
            {
                // Assert
                Assert.AreEqual(value, iterator.Data);
                iterator = iterator.Next;
                value++;
            }

            // Assert
            Assert.AreEqual(value, 6);
        }

        [TestMethod]
        public void Split6SizedZipListBackwardsIterateFirstHalf()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            list.AddFront(3);
            list.AddBack(4);
            list.AddFront(2);
            list.AddBack(5);
            list.AddFront(1);
            list.AddFront(0);

            // Act
            var splitList = list.Split();

            int value = 2;
            Node<int> iterator = splitList.Tail;

            // make sure the list is in order and that we ave iterated through all members.
            while (iterator != null)
            {
                // Assert
                Assert.AreEqual(value, iterator.Data);
                iterator = iterator.Previous;
                value--;
            }

            Assert.AreEqual(value, -1, "The count should be 3 before we have a null element.");
        }

        [TestMethod]
        public void Split6SizedZipListBackwardsIterateSecondHalf()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            list.AddFront(3);
            list.AddBack(4);
            list.AddFront(2);
            list.AddBack(5);
            list.AddFront(1);
            list.AddFront(0);

            // Act
            var splitList = list.Split();

            int value = 5;
            Node<int> iterator = list.Tail;

            // make sure the list is in order and that we ave iterated through all members.
            while (iterator != null)
            {
                // Assert
                Assert.AreEqual(value, iterator.Data);
                iterator = iterator.Previous;
                value--;
            }

            Assert.AreEqual(value, 2, "The count should be 3 before we have a null element.");
        }

        [TestMethod]
        public void Split7SizedZipListForwardIterateFirstHalf()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            list.AddFront(3);
            list.AddBack(4);
            list.AddFront(2);
            list.AddBack(5);
            list.AddFront(1);
            list.AddBack(6);
            list.AddFront(0);

            // Act
            var splitList = list.Split();

            int value = 0;
            Node<int> iterator = splitList.Head;

            // make sure the list is in order and that we ave iterated through all members.
            while (iterator != null)
            {
                // Assert
                Assert.AreEqual(value, iterator.Data);
                iterator = iterator.Next;
                value++;
            }

            // Assert
            Assert.AreEqual(value, splitList.Count);
        }

        [TestMethod]
        public void Split7SizedZipListForwardIterateSecondHalf()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            list.AddFront(3);
            list.AddBack(4);
            list.AddFront(2);
            list.AddBack(5);
            list.AddFront(1);
            list.AddBack(6);
            list.AddFront(0);

            // Act
            var splitList = list.Split();

            // Assert
            int value = 3;
            Node<int> iterator = list.Head;

            // make sure the list is in order and that we ave iterated through all members.
            while (iterator != null)
            {
                // Assert
                Assert.AreEqual(value, iterator.Data);
                iterator = iterator.Next;
                value++;
            }

            // Assert
            Assert.AreEqual(value, 7);
        }

        [TestMethod]
        public void Split7SizedZipListBackwardsIterateFirstHalf()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            list.AddFront(3);
            list.AddBack(4);
            list.AddFront(2);
            list.AddBack(5);
            list.AddFront(1);
            list.AddBack(6);
            list.AddFront(0);

            // Act
            var splitList = list.Split();

            int value = 2;
            Node<int> iterator = splitList.Tail;

            // make sure the list is in order and that we ave iterated through all members.
            while (iterator != null)
            {
                // Assert
                Assert.AreEqual(value, iterator.Data);
                iterator = iterator.Previous;
                value--;
            }

            Assert.AreEqual(value, -1, "The count should be 3 before we have a null element.");
        }

        [TestMethod]
        public void Split7SizedZipListBackwardsIterateSecondHalf()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            list.AddFront(3);
            list.AddBack(4);
            list.AddFront(2);
            list.AddBack(5);
            list.AddFront(1);
            list.AddBack(6);
            list.AddFront(0);

            // Act
            list.Split();

            int value = 6;
            Node<int> iterator = list.Tail;

            // make sure the list is in order and that we ave iterated through all members.
            while (iterator != null)
            {
                // Assert
                Assert.AreEqual(value, iterator.Data);
                iterator = iterator.Previous;
                value--;
            }

            Assert.AreEqual(value, 2, "The count should be 4 before we have a null element.");
        }

        [TestMethod]
        public void SplitAndZipSameList()
        {
            // Setup
            ZipList<int> list = new ZipList<int>();

            list.AddFront(3);
            list.AddBack(4);
            list.AddFront(2);
            list.AddBack(5);
            list.AddFront(1);
            list.AddBack(6);
            list.AddFront(0);

            var expectedValues = new List<int> { 0,1,2,3,4,5,6 };
            var seenValues = new List<int>();

            var splitHalf = list.Split();
            list.Zip(ref splitHalf);

            // Act
            for (Node<int> iterator = list.Head; iterator != null; iterator = iterator.Next)
            {
                // Assert
                // the value seen should be an expected value.
                Assert.IsTrue(expectedValues.Contains(iterator.Data));

                // is should not be one we have seen before.
                Assert.IsTrue(!seenValues.Contains(iterator.Data));

                // update the list of seen values
                seenValues.Add(iterator.Data);
            }

            Assert.AreEqual<int>(7, list.Count, "The final count should be 7");
        }
    }
}
