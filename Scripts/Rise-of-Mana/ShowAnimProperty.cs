using UnityEngine;

public class ShowAnimProperty : MonoBehaviour
{
	public Color fontColor = Color.white;

	public Animation[] targetAnims;

	public bool deleteModalCollider = true;

	private string text;

	private AnimationState[] states;

	private int numAnim = 20;

	private float[,] oldTimes;

	private int[] oldNums;

	private float waitFind = 2f;

	private void Start()
	{
		states = new AnimationState[256];
		oldTimes = new float[numAnim, 256];
		targetAnims = new Animation[numAnim];
		oldNums = new int[numAnim];
	}

	private void Update()
	{
		if (!Application.isEditor)
		{
			return;
		}
		waitFind -= Time.deltaTime;
		if (waitFind <= 0f)
		{
			for (int i = 0; i < numAnim; i++)
			{
				Animation[] array = Object.FindObjectsOfType(typeof(Animation)) as Animation[];
				int num = 0;
				Animation[] array2 = array;
				foreach (Animation animation in array2)
				{
					for (int k = 0; k < numAnim; k++)
					{
						if (!(targetAnims[num] != null))
						{
							break;
						}
						num++;
					}
					if (animation == null || (animation.name.Length >= 5 && animation.name.Substring(0, 5) == "plane"))
					{
						continue;
					}
					string text = animation.name.Substring(0, 1);
					if (!(text == "c"))
					{
						switch (text)
						{
						case "p":
						case "e":
						case "c":
						case "M":
							break;
						default:
							continue;
						}
					}
					bool flag = false;
					for (int k = 0; k < numAnim; k++)
					{
						if (targetAnims[k] == animation)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						targetAnims[num] = animation;
						num++;
					}
				}
				oldNums[i] = 0;
			}
			waitFind = 2f;
			if (deleteModalCollider)
			{
				GameObject gameObject = GameObject.Find("__ModalCollider__");
				if ((bool)gameObject)
				{
					Object.Destroy(gameObject);
				}
			}
		}
		this.text = string.Empty;
		for (int i = 0; i < numAnim; i++)
		{
			Animation animation2 = targetAnims[i];
			if (animation2 == null || !animation2.enabled)
			{
				continue;
			}
			int num = 0;
			foreach (AnimationState item in animation2)
			{
				states[num] = item;
				num++;
			}
			if (num != oldNums[i])
			{
				for (int k = 0; k < num; k++)
				{
					oldTimes[i, k] = 0f;
				}
				oldNums[i] = num;
			}
			this.text = this.text + animation2.name + "\n";
			for (int k = 0; k < num; k++)
			{
				float num2 = states[k].time % states[k].length;
				float num3 = Mathf.Floor(num2 * 100f) / 100f;
				float num4 = Mathf.Floor(states[k].length * 100f) / 100f;
				if (oldTimes[i, k] != num2)
				{
					string text2 = this.text;
					this.text = text2 + "  " + states[k].name + " : " + num3 + " / " + num4;
					this.text += "\n";
					oldTimes[i, k] = num2;
				}
			}
			this.text += "\n";
		}
	}

	private void OnGUI()
	{
		GUI.color = Color.white;
		GUI.Label(new Rect(79f, 79f, 400f, 400f), text);
		GUI.color = Color.black;
		GUI.Label(new Rect(81f, 81f, 400f, 400f), text);
		GUI.color = fontColor;
		GUI.Label(new Rect(80f, 80f, 400f, 400f), text);
	}
}
