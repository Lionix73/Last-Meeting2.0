using UnityEngine;

public class GridNodes
{
    private int width;
    private int heigth;

    private Node[,] gridNode;

    public GridNodes(int width, int heigth)
    {
        this.width = width;
        this.heigth = heigth;

        gridNode = new Node[width, heigth];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < heigth; y++)
            {
                gridNode[x, y] = new Node(new Vector2Int(x, y));
            }
        }
    }

    public Node GetGridNode(int xPosition, int yPosition)
    {
        if(xPosition < width && yPosition < heigth)
        {
            return gridNode[xPosition, yPosition];
        }
        else
        {
            Debug.Log("Requested grid node is out of range");
            return null;
        }
    }
}
