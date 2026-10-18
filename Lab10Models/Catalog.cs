namespace Lab10Models;
using System.Collections.Generic;


public class Catalog<T> where T : IEntry 
{
    private readonly List<T> _items = new List<T>();
    
    
    public int Count => _items.Count;


    public void Add(T item)
    {
        _items.Add(item);
    }
    
    
    public T GetAt(int index)
    {
        return _items[index];
    }
    
    
    public bool ContainsCode(string code)
    {
        foreach (T item in _items)
        {
            // Обмеження IEntry гарантує наявність властивості Code.
            if (item.Code == code)
            {
                return true;
            }
        }
        return false;
    }

    public bool RemoveByCode(string code)
    {
        for (var i = 0; i < _items.Count; i++)
        {
            if (_items[i].Code != code) continue;
            _items.RemoveAt(i);
            return true;
        }

        return false;
    }
    
    
    public void PrintAll()
    {
        foreach (T item in _items)
        {
            // Обмеження IEntry гарантує наявність GetInfo().
            Console.WriteLine(item.GetInfo());
        }
    }
    
}