using Mageanomics.DataTypes;
using Mageanomics.enums;
using System;

namespace Mageanomics.Collections
{
    public class ZipList<T>
    {
        #region Constructors

        public ZipList()
        {
            this.Head = this.Tail = this.Center;
            this.Count = 0;
        }

        #endregion Constructors

        #region Properties

        public int Count
        {
            get;
            set;
        }

        public Node<T> Head
        {
            get;
            private set;
        }

        public Node<T> Tail
        {
            get;
            private set;
        }

        public Node<T> Center
        {
            get;
            private set;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Add an item to the fron of the list.
        /// O(1)
        /// </summary>
        /// <param name="data">The item to add to the front of the list.</param>
        public void AddFront(T data)
        {
            var newNode = new Node<T>(data, this.Head, null);

            this.AddFront(newNode);
        }

        private void AddFront(Node<T> newNode)
        {
            this.Count++;

            if (this.Head != null)
            {
                newNode.Next = this.Head;
                this.Head.Previous = newNode;
            }

            this.Head = newNode;

            // if there is one item in the list all pointers are equal.
            if (this.Count == 1)
            {
                this.Tail = this.Center = this.Head;
            }
            else if (this.Count % 2 == 1)
            {
                // if the count is odd move the center back one
                this.Center = this.Center.Previous;
            }
        }

        /// <summary>
        /// Add an item to the back of the list.
        /// O(1)
        /// </summary>
        /// <param name="data">The Item to add to the back of the list.</param>
        public void AddBack(T data)
        {
            var newNode = new Node<T>(data, null, this.Tail);

            this.AddBack(newNode);
        }

        private void AddBack(Node<T> newNode)
        {
            this.Count++;

            if (this.Tail != null)
            {
                newNode.Previous = this.Tail;
                this.Tail.Next = newNode;
            }

            this.Tail = newNode;

            // if there is one item in the list all pointers are equal.
            if (this.Count == 1)
            {
                this.Head = this.Center = this.Tail;
            }
            else if (this.Count % 2 == 0)
            {
                // when there are 2 items or the count is even, move the center forward one
                this.Center = this.Center.Next;
            }
        }

        /// <summary>
        /// Remove an item from the fron of the list.
        /// O(1)
        /// </summary>
        /// <returns>The item that was removed.</returns>
        public T RemoveFront()
        {
            T retVal = default(T);

            Node<T> node = this.RemoveFrontInternal();

            if (node != null)
            {
                retVal = node.Data;
            }

            return retVal;
        }

        private Node<T> RemoveFrontInternal()
        {
            Node<T> retVal = null;

            if (this.Count == 0)
            {
                return retVal;
            }

            if (this.Head != null)
            {
                this.Head.Previous = null;

                retVal = this.Head;

                this.Head = this.Head.Next;
            }

            this.Count--;

            if (this.Count == 0 || this.Count == 1)
            {
                // if there is one or less items in the list all pointers are equal.
                this.Tail = this.Center = this.Head;
            }
            else if (this.Count % 2 == 0)
            {
                // otherwise if the count is even, move the center pointer forward one item.
                this.Center = this.Center.Next;
            }

            return retVal;
        }

        /// <summary>
        /// Call this method to remove an item from the back of the list.
        /// O(1)
        /// </summary>
        /// <returns>The item that was removed.</returns>
        public T RemoveBack()
        {
            T retVal = default(T);

            if (this.Count == 0)
            {
                return retVal;
            }

            if (this.Tail != null)
            {
                retVal = this.Tail.Data;

                this.Tail = this.Tail.Previous;

                this.Tail.Next = null;
            }

            this.Count--;

            if (this.Count == 0 || this.Count == 1)
            {
                // if there is one or less items in the list all pointers are equal.
                this.Head = this.Center = this.Tail;
            }
            else if (this.Count % 2 == 1)
            {
                // otherwise if there are at least three items in the list and the count is even,
                // move the center pointer back one item.
                // When the cound is odd the center is already in the right place
                this.Center = this.Center.Previous;
            }

            return retVal;
        }

        /// <summary>
        /// This method splits the current list into two separate lists.
        /// The top half is returned, the other half is left in the ZipList.
        /// This operation modifies the current ZipList. O(Log(n))
        /// </summary>
        /// <returns>The top/front half of the ZipList.</returns>
        public ZipList<T> Split()
        {
            if (this.Count == 0 || this.Count == 1)
            {
                // you can not split an empty list or a list with one item.
                return null;
            }

            // make the new list
            ZipList<T> returnList = new ZipList<T>();

            // update the new count
            returnList.Count = this.Count / 2;

            // set its head to this lists head.
            returnList.Head = this.Head;

            // make the returnList tail the element before the center.
            returnList.Tail = this.Center.Previous;

            // cut the list's tail.
            returnList.Tail.Next = null;

            // find the center of new half of the list
            returnList.Center = FindCenter(returnList);

            // update this list's count.
            this.Count = (int)Math.Floor(this.Count / 2.0 + .5);

            // move this head to the center
            this.Head = this.Center;

            // prevent backwards navation into the top half
            this.Head.Previous = null;

            this.Center = FindCenter(this);

            return returnList;
        }

        /// <summary>
        /// This method does an interleaved merge of this ZipList and the specifiedZipList.
        /// This operation consumes the input list, leaving it empty, and grows this ZipList.
        /// O(n)
        /// </summary>
        /// <param name="list">The ZipList that should be consumed and merged into this ZipList.</param>
        public void Zip(ref ZipList<T> list)
        {
            if (list == null || list.Count == 0)
            {
                // nothing to do here.
                return;
            }
            else if (this.Count == 0)
            {
                this.Concat(ref list, Direction.Top);
                return;
            }
            else if (this.Count == 1)
            {
                this.Concat(ref list, Direction.Bottom);
                return;
            }

            // there is at least one element in each list.

            // make a new list that we will add to.  Adds are O(1) and the center is updated for us
            var newList = new ZipList<T>();

            var thisIterator = this.Head;
            var listIterator = list.Head;

            // skip the loop if this is an empty list.
            while (thisIterator != null || listIterator != null)
            {
                // otherwise add the heads of both lists.  We add the listIterator first so the first element of this list is always changing.

                if (listIterator != null)
                {
                    newList.AddBack(listIterator);
                    listIterator = listIterator.Next;
                }

                if (thisIterator != null)
                {
                    newList.AddBack(thisIterator);
                    thisIterator = thisIterator.Next;
                }
            }

            // update this list to have the values of newList
            this.Head = newList.Head;
            this.Center = newList.Center;
            this.Tail = newList.Tail;
            this.Count = newList.Count;

            // delete newList and list
            this.DeleteList(ref list);
            this.DeleteList(ref newList);
        }

        /// <summary>
        /// This method takes the input ZipList and merges it by placing the entire list either on top or on the bottom of this ZipList.
        /// O(Log(n))
        /// </summary>
        /// <param name="list">The ZipList to add to this ZipList.</param>
        /// <param name="direction">Specifies if the input list should be placed directly on the top or on the bottom of this ZipList.</param>
        public void Concat(ref ZipList<T> list, Direction direction)
        {
            if (list.Count == 0)
            {
                // nothing to do here.
                return;
            }

            this.Count += list.Count;

            if (direction == Direction.Top)
            {
                // make the next element of list point to this head.
                if (list.Tail != null) /*should not happen if the list is non empty*/
                {
                    list.Tail.Next = this.Head;
                }

                // make the current head point backwards to the lits's tail
                if (this.Head != null)
                {
                    this.Head.Previous = list.Tail;
                }

                // move this head to the list's head
                this.Head = list.Head;
            }
            else
            {
                if (this.Tail != null)
                {
                    // make the end of this list point to the head of the list.
                    this.Tail.Next = list.Head;
                }

                // keep the back reference
                list.Head.Previous = this.Tail;

                // move this tail to the tail of the list.
                this.Tail = list.Tail;
            }

            // always update the center.
            this.Center = FindCenter(this);

            // release all the previous references and release the list.
            this.DeleteList(ref list);
        }

        private void DeleteList(ref ZipList<T> list)
        {
            list.Head = null;
            list.Count = 0;
            list.Tail = null;
            list.Center = null;
            list = null;
        }

        private static Node<T> FindCenter(ZipList<T> list)
        {
            Node<T> iterator = list.Head;

            if (list.Count < 2)
            {
                return iterator;
            }

            int elementCount = list.Count / 2;

            for (int i = 0; i < elementCount; i++)
            {
                iterator = iterator.Next;
            }

            return iterator;
        }

        #endregion Methods
    }
}
