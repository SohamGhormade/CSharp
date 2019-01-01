using System;
using System.Collections.Generic;
using System.Collections;

public class Program
{
	public static void Main()
	{
		Console.WriteLine("Hello World");

		var rS = new ResizingStack<int>();
		rS.push(1);
		rS.push(2);
		rS.push(12);
		rS.push(223);
		Console.WriteLine("=======");
		int i = rS.pop();
		Console.WriteLine("pop"+i);//223
		i = rS.pop();
		Console.WriteLine("Pop"+i);//12
		i = rS.pop();
		Console.WriteLine("Pop "+i);//2
		i = rS.pop();
		Console.WriteLine("Pop "+i);//1

	}
}

public class ResizingStack<T>:IEnumerable<T>
{
private T[] a = new T[1];
private int n = 0;//size

public void push(T t)
{
 a[n++] = t;
 if(n == a.Length)
 {
   resize(2 * a.Length);
 }
}

public T pop()
{
 T t = a[n--];
 if(n >0 && n < a.Length/4)
    resize(a.Length/2);
 return t;

}
public bool isEmpty()
{
   return n==0;
}
public int size()
{
    return n;
}
private void resize(int max)
{
 var temp = new T[max];
 for(int i = 0;i < n;i++)
    temp[i] = a[i];

 a = temp;
}

public IEnumerator<T> GetEnumerator()
{
  return new ReverseEnumerator<T>(n,a);
}
    // Must also implement IEnumerable.GetEnumerator, but implement as a private method.
    private IEnumerator GetEnumerator1()
    {
        return this.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator1();
    }
private class ReverseEnumerator<T>:IEnumerator<T>
{
private int i;
private T[] a;
public ReverseEnumerator(int n,T[] a )
{
i = n -1;
this.a = a;
}

public T Current{
  get{
       return a[i--];
     }
  }

   private object Current1
    {

        get { return this.Current; }
    }

    object IEnumerator.Current
    {
        get { return Current1; }
    }

    // Implement MoveNext and Reset, which are required by IEnumerator.
    public bool MoveNext()
    {
        if (i>=0)
            return true;
        return false;
    }

    public void Reset()
    {

    }

    // Implement IDisposable, which is also implemented by IEnumerator(T).
    private bool disposedValue = false;
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposedValue)
        {
            if (disposing)
            {
                // Dispose of managed resources.
            }

            }
        }

    }
}


