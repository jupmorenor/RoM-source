using System;
using System.Text;

[Serializable]
public class D540PrettyPrinter : D540DepthFirstTraverser
{
	private int indent;

	private StringBuilder text;

	public D540PrettyPrinter()
	{
		text = new StringBuilder();
	}

	public static void Print(D540OpeCode node)
	{
		D540PrettyPrinter v = new D540PrettyPrinter();
		node?.apply(v);
	}

	public static string ToString(D540OpeCode node)
	{
		D540PrettyPrinter d540PrettyPrinter = new D540PrettyPrinter();
		node?.apply(d540PrettyPrinter);
		return d540PrettyPrinter.text.ToString();
	}

	public override bool defaultIn(D540OpeCode node)
	{
		text.Append("   " * indent + node.ToString() + "\n");
		checked
		{
			indent++;
			return true;
		}
	}

	public override void defaultOut(D540OpeCode node)
	{
		checked
		{
			indent--;
		}
	}
}
