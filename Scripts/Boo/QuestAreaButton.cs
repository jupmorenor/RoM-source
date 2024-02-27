using System;
using System.Collections;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class QuestAreaButton : MonoBehaviour
{
	public GameObject questIconPrefab;

	protected string iconName;

	protected string areaName;

	protected GameObject icon;

	protected UIAutoTweener autoTweener;

	protected int areaId;

	protected GameObject nextPanel;

	protected GameObject newPanel;

	protected GameObject eventPanel;

	protected GameObject bossPanel;

	protected bool nextPanelFlag;

	protected bool newPanelFlag;

	protected bool eventPanelFlag;

	protected bool bossPanelFlag;

	protected int count;

	protected int delay;

	protected bool isNew;

	protected bool showIcon;

	public string AreaName => areaName;

	public bool IsNew => isNew;

	public bool ShowIcon
	{
		get
		{
			return showIcon;
		}
		set
		{
			showIcon = value;
		}
	}

	public int AreaId => areaId;

	public QuestAreaButton()
	{
		delay = 5;
	}

	public void Start()
	{
	}

	public void Update()
	{
		checked
		{
			if ((bool)icon && showIcon)
			{
				icon.SetActive(value: true);
				if ((bool)nextPanel)
				{
					nextPanel.SetActive(nextPanelFlag);
				}
				if ((bool)newPanel)
				{
					newPanel.SetActive(newPanelFlag);
				}
				if ((bool)eventPanel)
				{
					eventPanel.SetActive(eventPanelFlag);
				}
				if ((bool)bossPanel)
				{
					bossPanel.SetActive(bossPanelFlag);
				}
				count++;
				if (count == delay)
				{
					icon.transform.localScale = Vector3.one;
				}
			}
		}
	}

	public void Init(int newAreaId, string newIconName, string newAreaName, bool ignoreNew)
	{
		MAreas mAreas = MAreas.Get(newAreaId);
		bool flag = true;
		areaId = newAreaId;
		iconName = newIconName;
		areaName = newAreaName;
		isNew = false;
		if ((bool)icon || !questIconPrefab)
		{
			return;
		}
		icon = ((GameObject)UnityEngine.Object.Instantiate(questIconPrefab)) as GameObject;
		if (!icon)
		{
			return;
		}
		UIAutoTweener[] componentsInChildren = icon.GetComponentsInChildren<UIAutoTweener>(includeInactive: true);
		int i = 0;
		UIAutoTweener[] array = componentsInChildren;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				if ((bool)array[i])
				{
					array[i].ignoreTimeScale = true;
				}
			}
			icon.transform.parent = gameObject.transform;
			icon.transform.localPosition = Vector3.zero;
			icon.transform.localScale = Vector3.zero;
			UIPanel[] componentsInChildren2 = icon.GetComponentsInChildren<UIPanel>(includeInactive: true);
			int j = 0;
			UIPanel[] array2 = componentsInChildren2;
			for (int length2 = array2.Length; j < length2; j++)
			{
				UnityEngine.Object.DestroyObject(array2[j]);
			}
			nextPanelFlag = false;
			newPanelFlag = false;
			eventPanelFlag = false;
			bossPanelFlag = false;
			Transform transform = icon.transform.Find("Next");
			if ((bool)transform)
			{
				nextPanel = transform.gameObject;
			}
			Transform transform2 = icon.transform.Find("New");
			if ((bool)transform2)
			{
				newPanel = transform2.gameObject;
			}
			Transform transform3 = icon.transform.Find("Event");
			if ((bool)transform3)
			{
				eventPanel = transform3.gameObject;
			}
			Transform transform4 = icon.transform.Find("Boss");
			if ((bool)transform4)
			{
				bossPanel = transform4.gameObject;
			}
			if (mAreas.JumpType == EnumAreaTypes.SpecialQuest || mAreas.JumpType == EnumAreaTypes.Challenge)
			{
				eventPanelFlag = true;
			}
			else if (mAreas.JumpType == EnumAreaTypes.Raid)
			{
				bossPanelFlag = true;
			}
			int num = UserData.Current.userMiscInfo.areaData.getInt(mAreas.AreaGroup.Id.ToString());
			bool nextIconFlag = false;
			bool flag2 = !QuestManager.IsAreaQuestClar(mAreas, 1, ref nextIconFlag);
			if (ignoreNew)
			{
				num = 1;
			}
			if ((num <= 0 || flag2 || nextIconFlag) && !eventPanelFlag && !bossPanelFlag)
			{
				nextPanelFlag = true;
				newPanelFlag = true;
			}
			if (num < 0)
			{
				if (!ignoreNew)
				{
					isNew = true;
				}
				else
				{
					showIcon = true;
					int k = 0;
					UIAutoTweener[] array3 = componentsInChildren;
					for (int length3 = array3.Length; k < length3; k++)
					{
						if ((bool)array3[k])
						{
							array3[k].enabled = false;
						}
					}
				}
				UserData.Current.userMiscInfo.areaData.look(mAreas.AreaGroup.Id.ToString());
			}
			else
			{
				showIcon = true;
				int l = 0;
				UIAutoTweener[] array4 = componentsInChildren;
				for (int length4 = array4.Length; l < length4; l++)
				{
					if ((bool)array4[l])
					{
						array4[l].enabled = false;
					}
				}
			}
			if (mAreas.JumpType == EnumAreaTypes.BoostQuest || mAreas.JumpType == EnumAreaTypes.Colosseum)
			{
				nextPanelFlag = false;
				newPanelFlag = false;
			}
			string empty = string.Empty;
			Transform transform5 = icon.transform.Find("Background");
			UISprite component = default(UISprite);
			if ((bool)transform5)
			{
				component = transform5.gameObject.GetComponent<UISprite>();
			}
			bool flag3 = false;
			if ((bool)component)
			{
				component.spriteName = iconName;
				empty = component.spriteName;
				component.enabled = true;
				bool num2 = empty == iconName;
				if (num2)
				{
					num2 = !string.IsNullOrEmpty(iconName);
				}
				flag3 = num2;
			}
			Transform transform6 = icon.transform.Find("Font");
			if ((bool)transform6)
			{
				IEnumerator enumerator = transform6.transform.GetEnumerator();
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is Transform))
					{
						obj = RuntimeServices.Coerce(obj, typeof(Transform));
					}
					Transform transform7 = (Transform)obj;
					UILabelBase component2 = transform7.gameObject.GetComponent<UILabelBase>();
					if ((bool)component2)
					{
						component2.text = areaName;
						component2.gameObject.SetActive(value: true);
					}
				}
			}
			icon.SetActive(value: false);
			if ((bool)nextPanel)
			{
				nextPanel.SetActive(nextPanelFlag);
			}
			if ((bool)newPanel)
			{
				newPanel.SetActive(newPanelFlag);
			}
			if ((bool)eventPanel)
			{
				eventPanel.SetActive(eventPanelFlag);
			}
			if ((bool)bossPanel)
			{
				bossPanel.SetActive(bossPanelFlag);
			}
		}
	}
}
