using System;
using System.Text;

[Serializable]
public class Node
{
	public int x;

	public int y;

	public float yCoord;

	public float xCoord;

	public float zCoord;

	public int ID;

	public bool walkable;

	public Node parent;

	public int F;

	public int H;

	public int G;

	public int sortedIndex;

	public Node(int indexX, int indexY, float height, int idValue, float xcoord, float zcoord, bool w, Node p)
	{
		walkable = true;
		sortedIndex = -1;
		x = indexX;
		y = indexY;
		yCoord = height;
		ID = idValue;
		xCoord = xcoord;
		zCoord = zcoord;
		walkable = w;
		parent = p;
		F = 0;
		G = 0;
		H = 0;
	}

	public override string ToString()
	{
		return new StringBuilder("Node(").Append((object)ID).Append(" ").ToString() + x + "," + y + " " + xCoord + "," + yCoord + "," + zCoord + " walk:" + walkable + ")";
	}
}
