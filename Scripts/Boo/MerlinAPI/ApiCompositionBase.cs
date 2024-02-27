using System;
using System.Collections;
using Boo.Lang;

namespace MerlinAPI;

[Serializable]
public class ApiCompositionBase : RequestBase
{
	[Serializable]
	public class Set : JsonBase
	{
		public BoxId BaseId;

		public string MaterialId;

		public int EvolutionInformationId;

		public Set(BoxId baseId, BoxId[] materialId, int evoinfoId)
		{
			BaseId = baseId;
			MaterialId = Builtins.join(materialId, ",");
			EvolutionInformationId = evoinfoId;
		}
	}

	public ArrayList __REQUEST__;

	public ApiCompositionBase()
	{
		__REQUEST__ = new ArrayList();
	}

	public void add(BoxId baseId, BoxId[] materialId)
	{
		__REQUEST__.Add(new Set(baseId, materialId, 0));
	}

	public void add(BoxId baseId, BoxId[] materialId, int evoinfosId)
	{
		__REQUEST__.Add(new Set(baseId, materialId, evoinfosId));
	}
}
