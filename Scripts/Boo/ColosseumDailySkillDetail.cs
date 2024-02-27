using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class ColosseumDailySkillDetail : MonoBehaviour
{
	[Serializable]
	public class SkillSet
	{
		public UILabelBase nameLabel;

		public UILabelBase explainLabel;
	}

	public SkillSet[] skillSets;

	public void SetDailySkills(int[] skills)
	{
		if (null == skills || null == skillSets)
		{
			return;
		}
		int num = 0;
		int length = skillSets.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int num2 = num;
			num++;
			SkillSet[] array = skillSets;
			if (array[RuntimeServices.NormalizeArrayIndex(array, num2)] == null)
			{
				continue;
			}
			MCoverSkills mCoverSkills = null;
			if (num2 < skills.Length)
			{
				mCoverSkills = MCoverSkills.Get(skills[RuntimeServices.NormalizeArrayIndex(skills, num2)]);
			}
			if (mCoverSkills != null && !mCoverSkills.DisableColosseum)
			{
				SkillSet[] array2 = skillSets;
				if (null != array2[RuntimeServices.NormalizeArrayIndex(array2, num2)].nameLabel)
				{
					SkillSet[] array3 = skillSets;
					array3[RuntimeServices.NormalizeArrayIndex(array3, num2)].nameLabel.text = mCoverSkills.Name.msg;
				}
				SkillSet[] array4 = skillSets;
				if (null != array4[RuntimeServices.NormalizeArrayIndex(array4, num2)].explainLabel)
				{
					SkillSet[] array5 = skillSets;
					array5[RuntimeServices.NormalizeArrayIndex(array5, num2)].explainLabel.text = MasterExtensionsModule.MultiDetail(mCoverSkills, mCoverSkills.LevelMax);
				}
			}
			else
			{
				SkillSet[] array6 = skillSets;
				if (null != array6[RuntimeServices.NormalizeArrayIndex(array6, num2)].nameLabel)
				{
					SkillSet[] array7 = skillSets;
					array7[RuntimeServices.NormalizeArrayIndex(array7, num2)].nameLabel.text = MTexts.Msg("exp_none");
				}
				SkillSet[] array8 = skillSets;
				if (null != array8[RuntimeServices.NormalizeArrayIndex(array8, num2)].explainLabel)
				{
					SkillSet[] array9 = skillSets;
					array9[RuntimeServices.NormalizeArrayIndex(array9, num2)].explainLabel.text = string.Empty;
				}
			}
		}
	}
}
