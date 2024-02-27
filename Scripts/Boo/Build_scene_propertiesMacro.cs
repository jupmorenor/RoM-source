using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler.Ast;

[Serializable]
public class Build_scene_propertiesMacro : SceneIDBaseMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002415473 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal Field _0024_00244124_002415474;

			internal Field _0024_00244125_002415475;

			internal Field _0024_00244126_002415476;

			internal Field _0024_00244127_002415477;

			internal Field _0024_00244128_002415478;

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					Field field5 = (_0024_00244124_002415474 = new Field(LexicalInfo.Empty));
					TypeMemberModifiers typeMemberModifiers10 = (_0024_00244124_002415474.Modifiers = TypeMemberModifiers.Protected | TypeMemberModifiers.Static | TypeMemberModifiers.Final);
					string text10 = (_0024_00244124_002415474.Name = "BOOT_SCENE_NAME");
					Expression expression10 = (_0024_00244124_002415474.Initializer = Expression.Lift("BOOT"));
					bool flag10 = (_0024_00244124_002415474.IsVolatile = false);
					result = (Yield(2, _0024_00244124_002415474) ? 1 : 0);
					break;
				}
				case 2:
				{
					Field field4 = (_0024_00244125_002415475 = new Field(LexicalInfo.Empty));
					TypeMemberModifiers typeMemberModifiers8 = (_0024_00244125_002415475.Modifiers = TypeMemberModifiers.Protected | TypeMemberModifiers.Static | TypeMemberModifiers.Final);
					string text8 = (_0024_00244125_002415475.Name = "BASE_PATH");
					Expression expression8 = (_0024_00244125_002415475.Initializer = Expression.Lift("Assets/Scenes/"));
					bool flag8 = (_0024_00244125_002415475.IsVolatile = false);
					result = (Yield(3, _0024_00244125_002415475) ? 1 : 0);
					break;
				}
				case 3:
				{
					Field field3 = (_0024_00244126_002415476 = new Field(LexicalInfo.Empty));
					TypeMemberModifiers typeMemberModifiers6 = (_0024_00244126_002415476.Modifiers = TypeMemberModifiers.Protected | TypeMemberModifiers.Static | TypeMemberModifiers.Final);
					string text6 = (_0024_00244126_002415476.Name = "IGNORE_PATH");
					Expression expression6 = (_0024_00244126_002415476.Initializer = Expression.Lift("/Sandboxes/"));
					bool flag6 = (_0024_00244126_002415476.IsVolatile = false);
					result = (Yield(4, _0024_00244126_002415476) ? 1 : 0);
					break;
				}
				case 4:
				{
					Field field2 = (_0024_00244127_002415477 = new Field(LexicalInfo.Empty));
					TypeMemberModifiers typeMemberModifiers4 = (_0024_00244127_002415477.Modifiers = TypeMemberModifiers.Protected | TypeMemberModifiers.Static | TypeMemberModifiers.Final);
					string text4 = (_0024_00244127_002415477.Name = "SCENE_LIST_FILE");
					Expression expression4 = (_0024_00244127_002415477.Initializer = Expression.Lift("DontDeleteSceneList.lst"));
					bool flag4 = (_0024_00244127_002415477.IsVolatile = false);
					result = (Yield(5, _0024_00244127_002415477) ? 1 : 0);
					break;
				}
				case 5:
				{
					Field field = (_0024_00244128_002415478 = new Field(LexicalInfo.Empty));
					TypeMemberModifiers typeMemberModifiers2 = (_0024_00244128_002415478.Modifiers = TypeMemberModifiers.Protected | TypeMemberModifiers.Static | TypeMemberModifiers.Final);
					string text2 = (_0024_00244128_002415478.Name = "DUMMY_BOO_SRC");
					Expression expression2 = (_0024_00244128_002415478.Initializer = Expression.Lift("Assets/Scripts/dummy.boo"));
					bool flag2 = (_0024_00244128_002415478.IsVolatile = false);
					result = (Yield(6, _0024_00244128_002415478) ? 1 : 0);
					break;
				}
				case 6:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			//yield-return decompiler failed: Method not found
			return new _0024();
		}
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement mc)
	{
		return new _0024ExpandGeneratorImpl_002415473();
	}
}
