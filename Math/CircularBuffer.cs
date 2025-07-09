using System.Diagnostics;
using UnityEngine;

public class CircularBuffer<T> where T : class
{
    private T[] buffer;
    private int head;
    private int tail;
    private int size;
    private int count;

    public CircularBuffer(int capacity)
    {
        buffer = new T[capacity];
        size = capacity;
        head = 0;
        tail = 0;
        count = 0;
    }

    public bool Add(T item)
    {
        if (count == size)
        {
            //BUFFER IS FULL
            
            return false;
        }
        buffer[tail] = item;
        tail = (tail + 1) % size;
        count++;
        return true;
    }

    public T Remove()
    {
        if (count == 0)
        {
            //BUFFER IS EMPTY
            return null;
        }

        T item = buffer[head];
        buffer[head] = null;
        head = (head + 1) % size;
        count--;
        return item;
    }

    public bool IsEmpty => count == 0;
    public bool IsFull => count == size;
    public int Count => count;
}