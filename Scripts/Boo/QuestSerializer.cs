using System;
using System.Text;
using UnityEngine;

[Serializable]
public abstract class QuestSerializer
{
	public virtual void serialize(object val)
	{
	}

	public virtual object deserialize()
	{
		return null;
	}

	public virtual object typedDeserialize(Type type)
	{
		return deserialize();
	}

	public T typedDeserialize<T>()
	{
		object obj = typedDeserialize(typeof(T));
		if (obj is T)
		{
			return (T)obj;
		}
		throw new Exception(new StringBuilder("deserialize ERROR: ").Append(obj).Append(" is not ").ToString() + typeof(T));
	}

	public void serializeVector3(Vector3 v)
	{
		serialize(v.x);
		serialize(v.y);
		serialize(v.z);
	}

	public Vector3 deserializeVector3()
	{
		float x = typedDeserialize<float>();
		float y = typedDeserialize<float>();
		float z = typedDeserialize<float>();
		return new Vector3(x, y, z);
	}
}
