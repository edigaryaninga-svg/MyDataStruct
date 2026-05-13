using System.Collections;

namespace MySet;

public class MySet<T> : IEnumerable<T> 
    where T : IComparable<T>
{
    private readonly List<T> _items = new List<T>();

    public MySet() { }

    public MySet(IEnumerable<T> items)
    {
        AddRange(items);
    }

    public void Add(T item)
    {
        if (Contains(item))
        {
            throw new InvalidOperationException("Item already exists in Set");
        }
        _items.Add(item);
    }

    public void AddRange(IEnumerable<T> items)
    {
        foreach (T item in items)
            Add(item);
    }

    private void AddSkipDuplicates(T item)
    {
        if (!Contains(item))
            _items.Add(item);
    }

    private void AddRangeSkipDuplicates(IEnumerable<T> items)
    {
        foreach (T item in items)
            AddSkipDuplicates(item);
    }

    public bool Remove(T item)
    {
        return _items.Remove(item);
    }

    public bool Contains(T item)
    {
        return _items.Contains(item);
    }

    public int Count => _items.Count;

    public MySet<T> Union(MySet<T> other)
    {
        MySet<T> result = new MySet<T>(_items);
        result.AddRangeSkipDuplicates(other._items);
        return result;
    }

    public MySet<T> Intersection(MySet<T> other)
    {
        MySet<T> result = new MySet<T>();
        foreach (T item in _items)
        {
            if (other.Contains(item))
                result.Add(item);
        }
        return result;
    }

    public MySet<T> Difference(MySet<T> other)
    {
        MySet<T> result = new MySet<T>(_items);
        foreach (T item in other._items)
        {
            result.Remove(item);
        }
        return result;
    }

    public MySet<T> SymmetricDifference(MySet<T> other)
    {
        MySet<T> intersection = Intersection(other);
        MySet<T> union = Union(other);
        return union.Difference(intersection);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _items.GetEnumerator();
    }
}

