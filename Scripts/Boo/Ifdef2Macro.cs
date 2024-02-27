using System;
using Boo.Lang.Compiler.Ast;
using Boo.Lang.Extensions;
using Boo.Lang.Runtime;

[Serializable]
public class Ifdef2Macro : IfdefMacro
{
	public override Statement Expand(MacroStatement node)
	{
		return expandSub(node, eraseSelf: false);
	}

	private Statement expandSub(MacroStatement node, bool eraseSelf)
	{
		object result;
		if (node.ParentNode is Block block)
		{
			int num = block.Statements.IndexOf(node);
			if (num < 0)
			{
				throw new AssertionFailedException("idx >= 0");
			}
			Statement statement = base.Expand(node);
			if (statement != null)
			{
				eraseFollowings(block, num);
				if (eraseSelf)
				{
					block.Replace(node, new Block());
				}
				result = statement;
			}
			else
			{
				if (eraseSelf)
				{
					block.Replace(node, new Block());
				}
				int num2 = checked(num + 1);
				if (num2 >= block.Statements.Count || !(block.Statements[num2] is MacroStatement { Name: var name } macroStatement))
				{
					goto IL_0106;
				}
				if (name == "elif2")
				{
					result = expandSub(macroStatement, eraseSelf: true);
				}
				else
				{
					if (!(name == "else2"))
					{
						goto IL_0106;
					}
					block.Replace(macroStatement, new Block());
					result = macroStatement.Body;
				}
			}
		}
		else
		{
			result = base.Expand(node);
		}
		goto IL_0107;
		IL_0107:
		return (Statement)result;
		IL_0106:
		result = null;
		goto IL_0107;
	}

	private void eraseFollowings(Block blk, int index)
	{
		int num = checked(index + 1);
		int count = blk.Statements.Count;
		int num2 = 1;
		if (count < num)
		{
			num2 = -1;
		}
		while (num != count)
		{
			int index2 = num;
			num += num2;
			if (!(blk.Statements[index2] is MacroStatement macroStatement) || (macroStatement.Name != "elif2" && macroStatement.Name != "else2"))
			{
				break;
			}
			blk.Replace(macroStatement, new Block());
		}
	}
}
