using System;
using System.Collections.Generic;
using UnityEngine;

class PriorityQueue<T> where T : IComparable<T>
{

    List<T> _heap = new List<T>();

    //0logN
    public void Push(T data)
    {
        //���� �� ���� ���ο� ������ ����
        _heap.Add(data);

        int now = _heap.Count - 1;

        //�������...
        while (now > 0)
        {

            int next = (now - 1) / 2;
            //now�� �� ���� ��� ����
            if (_heap[now].CompareTo(_heap[next]) < 0)
                break;

            //�� ��ü (now�� �� Ŭ ���
            T temp = _heap[now];
            _heap[now] = _heap[next];
            _heap[next] = temp;

            //���� �������� �̵�
            now = next;
        }
    }

    //0logN
    public T Pop()
    {
        //��ȯ�� �����͸� ���� ����
        T ret = _heap[0];

        //������ �����͸� ��Ʈ�� �̵�
        int lastindex = _heap.Count - 1;
        _heap[0] = _heap[lastindex];
        _heap.RemoveAt(lastindex);
        lastindex--;

        int now = 0;
        while (true)
        {
            int left = 2 * now + 1;
            int right = 2 * now + 2;

            int next = now;
            //���ʰ��� ���簪���� ũ��, �������� �̵�
            if (left <= lastindex && _heap[next].CompareTo(_heap[left]) < 0)
                next = left;

            //�����ʰ��� ���簪���� ũ��, ���������� �̵�
            if (right <= lastindex && _heap[next].CompareTo(_heap[right]) < 0)
                next = right;

            //�� �� ��� ���簪���� ������ ����
            if (next == now)
                break;

            T temp = _heap[now];
            _heap[now] = _heap[next];
            _heap[next] = temp;

            now = next;

        }

        return ret;
    }

    public int Count { get { return _heap.Count; } }
}
