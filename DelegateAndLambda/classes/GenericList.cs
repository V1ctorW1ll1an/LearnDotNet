namespace Classes;


public record Employee(string Name, int ID); // you can write methods too

public class GenericList<T> where T : Employee
{

  private class Node
  {
    public Node(T t) => (Next, Data) = (null, t);

    public Node? Next { get; set; }
    public T Data { get; set; }
  }

  private Node? head;

  public void AddHead(T t)
  {
    Node n = new(t) { Next = head };
    head = n;
  }

  public IEnumerator<T> GetEnumerator()
  {
    Node? current = head;

    while (current != null)
    {
      yield return current.Data;
      current = current.Next;
    }
  }

  public T? FindFirstOccurrence(string s)
  {
    Node? current = head;
    T? t = null;

    while (current != null)
    {
      //The constraint enables access to the Name property.
      if (current.Data.Name == s)
      {
        t = current.Data;
        break;
      }
      else
      {
        current = current.Next;
      }
    }
    return t;
  }

}