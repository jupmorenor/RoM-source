using System;
using System.IO;
using System.Runtime.CompilerServices;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;
using Boo.Lang.Compiler.TypeSystem.Reflection;
using CompilerGenerated;

[Serializable]
public sealed class IMPORT_CS_JS_DLLSMacro : LexicalInfoPreservingMacro
{
	[CompilerGenerated]
	private MacroStatement __macro;

	public IMPORT_CS_JS_DLLSMacro()
	{
	}

	public IMPORT_CS_JS_DLLSMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override Statement ExpandImpl(MacroStatement IMPORT_CS_JS_DLLS)
	{
		if (IMPORT_CS_JS_DLLS == null)
		{
			throw new ArgumentNullException("IMPORT_CS_JS_DLLS");
		}
		__macro = IMPORT_CS_JS_DLLS;
		__Req_FailHandler_0024callable6_0024440_32__ _Req_FailHandler_0024callable6_0024440_32__ = delegate(string name)
		{
			string currentDirectory = Directory.GetCurrentDirectory();
			string lhs = currentDirectory + "/Library/ScriptAssemblies/";
			string text = lhs + name;
			string text2 = currentDirectory + "/boo-tmp";
			CompilerReferenceCollection references = Context.References;
			CompilerParameters parameters = Context.Parameters;
			if (references.Find(name) == null)
			{
				string text3 = text2 + "/" + name;
				IAssemblyReference assemblyReference = parameters.LoadAssembly(text, throwOnError: false);
				if (assemblyReference != null)
				{
					references.Add(assemblyReference);
					Directory.CreateDirectory(text2);
					File.Copy(text + ".dll", text3 + ".dll", overwrite: true);
				}
				else
				{
					assemblyReference = parameters.LoadAssembly(text3, throwOnError: false);
					if (assemblyReference == null)
					{
						throw new Exception("PLEASE save some script file and re-compile project. (if you are unsure, CALL NISHIMORI!)");
					}
					references.Add(assemblyReference);
				}
			}
		};
		_Req_FailHandler_0024callable6_0024440_32__("Assembly-UnityScript");
		_Req_FailHandler_0024callable6_0024440_32__("Assembly-UnityScript-firstpass");
		return null;
	}

	internal void _0024ExpandImpl_0024importDLL_00245503(string name)
	{
		string currentDirectory = Directory.GetCurrentDirectory();
		string lhs = currentDirectory + "/Library/ScriptAssemblies/";
		string text = lhs + name;
		string text2 = currentDirectory + "/boo-tmp";
		CompilerReferenceCollection references = Context.References;
		CompilerParameters parameters = Context.Parameters;
		if (references.Find(name) != null)
		{
			return;
		}
		string text3 = text2 + "/" + name;
		IAssemblyReference assemblyReference = parameters.LoadAssembly(text, throwOnError: false);
		if (assemblyReference != null)
		{
			references.Add(assemblyReference);
			Directory.CreateDirectory(text2);
			File.Copy(text + ".dll", text3 + ".dll", overwrite: true);
			return;
		}
		assemblyReference = parameters.LoadAssembly(text3, throwOnError: false);
		if (assemblyReference != null)
		{
			references.Add(assemblyReference);
			return;
		}
		throw new Exception("PLEASE save some script file and re-compile project. (if you are unsure, CALL NISHIMORI!)");
	}
}
