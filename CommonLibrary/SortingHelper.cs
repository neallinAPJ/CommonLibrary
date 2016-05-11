using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class SortingHelper
    {
        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="array"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public static void QuickSort(int[] array,int left,int right)
        {
            if(left<right)
            {
                int key = array[left];
                int low = left;
                int high = right;
                while(low<high)
                {
                    while(low<high&&key<=array[high])
                    {
                        high--;
                    }
                    array[low]=array[high];
                    while (low < high && array[low] <= key)
                    {
                        low++;
                    }
                    array[high] = array[low];
                }
                QuickSort(array, left, low - 1);
                QuickSort(array, low + 1, right);
            }
        }
        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="array"></param>
        public static void BubbleSort(int[] array)
        {
            for(int i=0;i<array.Length;i++)
            {
                for(int j=i+1;j<array.Length-1;j++)
                {
                    if(array[j]<array[i])
                    {
                        Swap(array, i, j);
                    }
                }
            }
        }
        private static void Swap(int[] num, int v, int u) {
            int temp = num[v];
            num[v] = num[u];
            num[u] = temp;        
        }
        private static void HeapAdjust(int[] array, int i, int size)  //调整堆 
        {
            int lchild = 2 * i;       //i的左孩子节点序号 
            int rchild = 2 * i + 1;     //i的右孩子节点序号 
            int max = i;            //临时变量 
            if (i <= size / 2)          //如果i是叶节点就不用进行调整 
            {
                if (lchild <= size && array[lchild] > array[max])
                {
                    max = lchild;
                }
                if (rchild <= size && array[rchild] > array[max])
                {
                    max = rchild;
                }
                if (max != i)
                {
                    Swap(array, i, max);
                    HeapAdjust(array, max, size);    //避免调整之后以max为父节点的子树不是堆 
                }
            }
        }

        private static void BuildHeap(int[] array, int size)    //建立堆 
        {
            int i;
            for (i = size / 2; i >= 1; i--)    //非叶节点最大序号值为size/2 
            {
                HeapAdjust(array, i, size);
            }
        }
        /// <summary>
        /// 堆排序
        /// </summary>
        /// <param name="array"></param>
        /// <param name="size"></param>
        public static void HeapSort(int[] array, int size)    //堆排序 
        {
            int i;
            BuildHeap(array, size);
            for (i = size; i >= 1; i--)
            {
                //cout<<a[1]<<" ";
                Swap(array,1, i);           //交换堆顶和最后一个元素，即每次将剩余元素中的最大者放到最后面 
                //BuildHeap(a,i-1);        //将余下元素重新建立为大顶堆 
                HeapAdjust(array, 1, i - 1);      //重新调整堆顶节点成为大顶堆
            }
        } 

        public void Test()
        {
            int x = 1;
            x = x & (x - 1);
        }
    }
}
