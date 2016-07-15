using System.Collections;
using System.Collections.Generic;

public class Node<T> {
    private Node<T> parent;
    private ArrayList children;

    private T data;

    public Node()
    {
        parent = null;
        children = new ArrayList();
    }

    public Node(Node<T> parent)
    {
        this.parent = parent;
        children = new ArrayList();
    }

    public Node<T> Parent
    {
        get { return parent; }
    }

    public Node<T> getChild(int n)
    {
        if (n < children.Count)
        {
            return (Node<T>)children[n];
        }
        return null;
    }

    public void addChild(Node<T> n)
    {
        n.parent = this;
        children.Add(n);
    }

    public void removeChild(Node<T> n)
    {
        children.Remove(n);
    }

    public T Data
    {
        get { return data; }
        set { data = value; }
    }

}
