using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class D540ScriptRunner : MonoBehaviour
{
	public TextAsset dooStart;

	public TextAsset dooUpdate;

	public bool printD540ForDebugAtInitialize;

	private D540Interpreter interpreter;

	private D540OpeCode startCode;

	private D540OpeCode updateCode;

	private bool enabledStart;

	private bool enabledUpdate;

	public bool EnabledStart
	{
		get
		{
			return enabledStart;
		}
		set
		{
			enabledStart = value;
		}
	}

	public bool EnabledUpdate
	{
		get
		{
			return enabledUpdate;
		}
		set
		{
			enabledUpdate = value;
		}
	}

	public void Awake()
	{
		D540RuntimeResolver d540RuntimeResolver = new D540RuntimeResolver(gameObject);
		startCode = resolve(dooStart, d540RuntimeResolver);
		updateCode = resolve(dooUpdate, d540RuntimeResolver);
		interpreter = new D540Interpreter(d540RuntimeResolver.Receivers);
	}

	public void Start()
	{
		if (enabledStart)
		{
			execute(startCode);
		}
	}

	public void OnDestroy()
	{
		if (startCode != null)
		{
			D540OpeCodePool.Instance.dispose(startCode);
		}
		if (updateCode != null)
		{
			D540OpeCodePool.Instance.dispose(updateCode);
		}
		startCode = null;
		updateCode = null;
		object obj = null;
		interpreter = null;
		dooStart = null;
		dooUpdate = null;
	}

	public void Update()
	{
		if (!(Time.deltaTime <= 0f) && enabledUpdate)
		{
			execute(updateCode);
		}
	}

	private D540OpeCode textAssetToD540(TextAsset asset)
	{
		object result;
		if (asset == null)
		{
			result = null;
		}
		else
		{
			D540BinaryToCodeTree d540BinaryToCodeTree = new D540BinaryToCodeTree();
			d540BinaryToCodeTree.traverse(asset.bytes);
			result = d540BinaryToCodeTree.Result;
		}
		return (D540OpeCode)result;
	}

	private D540OpeCode resolve(TextAsset sdata, D540RuntimeResolver resolver)
	{
		if (resolver == null)
		{
			throw new AssertionFailedException("resolver != null");
		}
		D540OpeCode d540OpeCode = textAssetToD540(sdata);
		object result;
		if (d540OpeCode == null)
		{
			result = null;
		}
		else
		{
			if (printD540ForDebugAtInitialize)
			{
				D540PrettyPrinter.Print(d540OpeCode);
			}
			D540OpeCode d540OpeCode2 = d540OpeCode;
			d540OpeCode2.apply(resolver);
			if (printD540ForDebugAtInitialize)
			{
				D540PrettyPrinter.Print(d540OpeCode2);
			}
			result = d540OpeCode2;
		}
		return (D540OpeCode)result;
	}

	private void execute(D540OpeCode code)
	{
		if (interpreter != null && code != null)
		{
			interpreter.clearStack();
			interpreter.execute(code);
		}
	}
}
