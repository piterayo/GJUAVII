using UnityEngine;
using System.Collections;

public class DataTree<T>{

    private Node<T> root;


    public DataTree()
    {
        initTree();
    }

    public DataTree(T data)
    {
        initTree(data);
    }

    public DataTree(Node<T> node)
    {
        initTree(node);
    }

    private void initTree(){
        initTree(new Node<T>());
    }

    private void initTree(T data)
    {
        initTree(new Node<T>(data));
    }

    private void initTree(Node<T> node){
        root = node;
    }

    public ArrayList getLeaves()
    {
        Stack tempStack = new Stack() ;

        ArrayList leaves = new ArrayList();

        tempStack.Push(root);
        while (tempStack.Count != 0)
        {
            Node<T> currentNode = (Node<T>)tempStack.Pop();
            if (currentNode.ChildCount == 0) leaves.Add(currentNode);
            else
            {
                for (int i = 0; i < currentNode.ChildCount; i++)
                {
                    tempStack.Push(currentNode.getChild(i));
                }
            }
            
        }

        return leaves;

    }

    public Node<T> Root
    {
        get { return root; }
    }

}
