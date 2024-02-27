using System;
using System.Linq;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class LevelColorController : MonoBehaviour
{
	public bool showLog;

	public UIListBase[] list;

	public Color normal;

	public Color limit_break;

	public Color limit_break_max;

	private bool update;

	private int frame;

	private int lastFrame;

	public void Start()
	{
		frame = 0;
		lastFrame = 0;
		normal = StaticLevelColor.NORMAL;
		limit_break = StaticLevelColor.LIMIT_BREAK;
		limit_break_max = StaticLevelColor.LIMIT_BREAK_MAX;
	}

	public void LateUpdate()
	{
		checked
		{
			frame++;
			if (frame - lastFrame < 100)
			{
				return;
			}
			if (normal != StaticLevelColor.NORMAL)
			{
				ShowLog("change normal");
				StaticLevelColor.set_normal(normal);
				update = true;
			}
			if (limit_break != StaticLevelColor.LIMIT_BREAK)
			{
				ShowLog("change limit_break");
				StaticLevelColor.set_limit_break(limit_break);
				update = true;
			}
			if (limit_break_max != StaticLevelColor.LIMIT_BREAK_MAX)
			{
				ShowLog("change limit_break_max");
				StaticLevelColor.set_limit_break_max(limit_break_max);
				update = true;
			}
			if (!Application.isPlaying || !update || list == null || list.Count() <= 0)
			{
				return;
			}
			lastFrame = frame;
			int i = 0;
			UIListBase[] array = list;
			for (int length = array.Length; i < length; i++)
			{
				if (!array[i])
				{
					continue;
				}
				int j = 0;
				GameObject[] itemObjectList = array[i].GetItemObjectList();
				for (int length2 = itemObjectList.Length; j < length2; j++)
				{
					if (!itemObjectList[j])
					{
						continue;
					}
					UIListItem component = itemObjectList[j].GetComponent<UIListItem>();
					Color nORMAL = StaticLevelColor.NORMAL;
					JsonBase jsonBase = null;
					JsonBase data = component.GetData<JsonBase>();
					if (data is RespPlayerBox)
					{
						RespPlayerBox respPlayerBox = (RespPlayerBox)data;
						if (respPlayerBox.IsWeapon)
						{
							jsonBase = respPlayerBox.toRespWeapon();
						}
						else if (respPlayerBox.IsPoppet)
						{
							jsonBase = respPlayerBox.toRespPoppet();
						}
					}
					if (jsonBase == null)
					{
						continue;
					}
					if (jsonBase is RespWeapon)
					{
						nORMAL = (jsonBase as RespWeapon).LevelColor;
					}
					else if (jsonBase is RespPoppet)
					{
						nORMAL = (jsonBase as RespPoppet).LevelColor;
					}
					if (component is WeaponListItem)
					{
						(component as WeaponListItem).SetLevelLabelColor((RespWeapon)jsonBase);
					}
					else if (component is MapetListItem)
					{
						(component as MapetListItem).SetLevelLabelColor((RespPoppet)jsonBase);
					}
					else if (component is BoxListItem)
					{
						component = (component as BoxListItem).Instance.GetComponent<UIListItem>();
						if (component is WeaponInfo)
						{
							(component as WeaponInfo).SetLevelLabelColor((RespWeapon)jsonBase);
						}
						else if (component is MuppetInfo)
						{
							(component as MuppetInfo).SetLevelLabelColor((RespPoppet)jsonBase);
						}
					}
				}
			}
			update = false;
		}
	}

	private void ShowLog(string s)
	{
		if (!showLog)
		{
		}
	}
}
