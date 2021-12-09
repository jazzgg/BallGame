using System;
using System.Collections.Generic;

public class Pool<T> where T : IPoolable
{
    public List<T> PoolList { get; private set; }

    public Pool(List<T> pool)
    {
        PoolList = pool;

        foreach (var elem in PoolList)
        {
            elem.Disable();
        }
    }
    public T GetElement()
    {
        var elem = GetFreeElement();
        elem.Enable();

        return elem;
    }
    public void DisableElement(T element)
    {
        element.Disable();
    }
    private T GetFreeElement()
    {
        foreach (var elem in PoolList)
        {
            if (elem.IsActive == false)
            {
                return elem;
            }
        }

        throw new Exception("there is no free elements");
    }

}
