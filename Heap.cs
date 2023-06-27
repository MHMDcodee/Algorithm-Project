using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoProj
{
    class Heap
    {
        int z = 0;
        public int[] HeapArray;
        int capacity;
        int currentSize;
        public Heap(int n)
        {
            capacity = n;
            HeapArray = new int[capacity];
            currentSize = 0;
        }
        public int Parent(int i)
        {
            if (i == 0)
                throw new ArgumentOutOfRangeException("This Node is Root");
            else
                return (i - 1) / 2;
        }
        public int LeftChild(int i)
        {
            return (2 * i + 1);
        }
        public int RightChild(int i)
        {
            return (2 * i + 2);
        }
        public void Swap(int i, int j)
        {
            int temp = 0;
            temp = HeapArray[i];
            HeapArray[i] = HeapArray[j];
            HeapArray[j] = temp;
        }
        public void MaxHeapify(int i)
        {
            int largest = -1;
            if (LeftChild(i) >= currentSize)
            {
                return;
            }
            if (HeapArray[i] < HeapArray[LeftChild(i)])
                largest = LeftChild(i);
            else
                largest = i;
            if (RightChild(i) >= currentSize)
            {
                return;
            }
            if (HeapArray[largest] < HeapArray[RightChild(i)])
                largest = RightChild(i);
            if (largest != i)
            {
                Swap(largest, i);
                MaxHeapify(largest);
            }
        }
        public void BuildHeap()
        {
            for (int i = (currentSize) / 2; i > 0; i--)
                MaxHeapify(i-1);
        }
        public void HeapIncrease(int i, int key)
        {
            if (key < HeapArray[i])
                throw new ArgumentOutOfRangeException("New Key is smaller than current Key");
            else
            {
                HeapArray[i] = key;
                while (i > 0 && HeapArray[Parent(i)] < HeapArray[i])
                {
                    Swap(i, Parent(i));
                    i = Parent(i);
                }
            }

        }
        public void InsertHeap(int key)
        {
            if (currentSize == capacity)
            {
                throw new ArgumentOutOfRangeException("The Heap is Full");
            }
            HeapArray[currentSize] = -100000;
            HeapIncrease(currentSize, key);
            currentSize++;
        }
        public bool IsHeap(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (LeftChild(i) > array.Length)
                {
                    return true;
                }
                else if (array[i] < array[LeftChild(i)])
                {
                    return false;
                }
                if (RightChild(i) > array.Length)
                {
                    return true;
                }
                else if (array[i] < array[RightChild(i)])
                {
                    return false;
                }
            }
            return true;
        }
        public void FindAndDelete(int key)
        {
            int temp = -1;
            for (int i = 0; i < currentSize; i++)
            {
                if (HeapArray[i] == key)
                {
                    temp = i;
                    break;
                }
            }
            if (temp == -1)
                throw new ArgumentOutOfRangeException("This Key isn't in the Heap");
            HeapArray[temp] = HeapArray[currentSize-1];
            currentSize--;
            MaxHeapify(temp);
        }
        public Heap HeapSort(int[] array)
        {
            Heap heap = new Heap(100);
            heap.HeapArray = array;
            heap.currentSize = currentSize;
            heap.BuildHeap();
            while (heap.currentSize>2)
            {
                heap.Swap(0, heap.currentSize-1);
                heap.currentSize--;
                heap.MaxHeapify(0);
            }
            return heap;
        }
        public int kthBiggestNum(int k)
        {
            return HeapSort(HeapArray).HeapArray[currentSize - k];
        }
        public Heap MergeHeap(Heap heap)
        {
            int j = 0;
            int temp = heap.currentSize;
            for (int i = heap.currentSize; i < currentSize + heap.currentSize; i++)
            {
                heap.HeapArray[i] = HeapArray[j];
                temp++;
                j++;
            }
            heap.currentSize = temp;
            heap.BuildHeap();
            return heap;
        }
        public void PrintkthBiggestNum(int k)
        {
            Console.WriteLine(kthBiggestNum(k));
        }
        public void PrintSortedHeap()
        {
            int temp = currentSize;
            Heap heap = HeapSort(HeapArray);
            heap.currentSize = temp;
            for (int i = 0; i < heap.currentSize; i++)
            {
                Console.Write(heap.HeapArray[i] + "\t");
            }
        }
        public void PrintHeap()
        {
            for (int i = 0; i < currentSize; i++)
            {
                Console.WriteLine(HeapArray[i]);
            }
        }

        public void MaxHeapToBST(int root, int[] arr)//LVR
        {
            if (arr == null)
                return;

            MaxHeapToBST(arr[LeftChild(z)], arr);
            root = arr[z++];
            MaxHeapToBST(arr[RightChild(z)], arr);

        }
        public void ConvertToBst(int[] arr)
        {
            Heap heap = HeapSort(arr);
            MaxHeapToBST(heap.HeapArray[0], heap.HeapArray);
        }
    }
}
