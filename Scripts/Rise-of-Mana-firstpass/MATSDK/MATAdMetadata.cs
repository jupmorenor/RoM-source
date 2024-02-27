using System;
using System.Collections.Generic;

namespace MATSDK;

public class MATAdMetadata
{
	private MATAdGender gender;

	private DateTime? birthDate;

	private bool debugMode;

	private HashSet<string> keywords;

	private float latitude;

	private float longitude;

	private float altitude;

	private Dictionary<string, string> customTargets;

	public MATAdMetadata()
	{
		gender = MATAdGender.UNKNOWN;
		debugMode = false;
		keywords = new HashSet<string>();
		customTargets = new Dictionary<string, string>();
	}

	public bool getDebugMode()
	{
		return debugMode;
	}

	public void setDebugMode(bool debugMode)
	{
		this.debugMode = debugMode;
	}

	public DateTime? getBirthDate()
	{
		return birthDate;
	}

	public void setBirthDate(DateTime? birthDate)
	{
		this.birthDate = birthDate;
	}

	public void setBirthDate(int year, int month, int day)
	{
		birthDate = new DateTime(year, month, day);
	}

	public Dictionary<string, string> getCustomTargets()
	{
		return customTargets;
	}

	public void setCustomTargets(Dictionary<string, string> customTargets)
	{
		this.customTargets = customTargets;
	}

	public MATAdGender getGender()
	{
		return gender;
	}

	public void setGender(MATAdGender gender)
	{
		this.gender = gender;
	}

	public HashSet<string> getKeywords()
	{
		return keywords;
	}

	public void setKeywords(HashSet<string> keywords)
	{
		this.keywords = keywords;
	}

	public void addKeyword(string keyword)
	{
		if (keywords == null)
		{
			keywords = new HashSet<string>();
		}
		keywords.Add(keyword);
	}

	public float getLatitude()
	{
		return latitude;
	}

	public float getLongitude()
	{
		return longitude;
	}

	public float getAltitude()
	{
		return altitude;
	}

	public void setLocation(float latitude, float longitude, float altitude)
	{
		this.latitude = latitude;
		this.longitude = longitude;
		this.altitude = altitude;
	}
}
