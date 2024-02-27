using System;
using UnityEngine;

public class RecordingGUI : MonoBehaviour
{
	public Font buttonFont;

	private bool firstVideoRecorded;

	private Rect startRecordingButtonRect;

	private Rect stopRecordingButtonRect;

	private Rect showViewButtonRect;

	private Rect showWatchViewButtonRect;

	private DateTime recordingStartedAt;

	private void Awake()
	{
		RegisterCallbacks();
	}

	private void Start()
	{
		firstVideoRecorded = false;
		InitGUI();
	}

	private void InitGUI()
	{
		int num = 265;
		int num2 = 100;
		int num3 = 20;
		startRecordingButtonRect = new Rect(num3, num3, num, num2);
		stopRecordingButtonRect = new Rect(num3, 2 * num3 + num2, num, num2);
		showViewButtonRect = new Rect(num3, 3 * num3 + 2 * num2, num, num2);
		showWatchViewButtonRect = new Rect(2 * num3 + num, num3, num, num2);
	}

	private void RegisterCallbacks()
	{
		Kamcord.kamcordDidStartRecording += MyKamcordDidStartRecording;
		Kamcord.kamcordDidStopRecording += MyKamcordDidStopRecording;
		Kamcord.kamcordViewDidAppear += MyKamcordViewDidAppear;
		Kamcord.kamcordViewWillDisappear += MyKamcordViewWillDisappear;
		Kamcord.kamcordViewDidDisappear += MyKamcordViewDidDisappear;
		Kamcord.kamcordViewDidNotAppear += MyKamcordViewDidNotAppear;
		Kamcord.kamcordWatchViewDidAppear += MyKamcordWatchViewDidAppear;
		Kamcord.kamcordWatchViewWillDisappear += MyKamcordWatchViewWillDisappear;
		Kamcord.kamcordWatchViewDidDisappear += MyKamcordWatchViewDidDisappear;
		Kamcord.videoThumbnailReadyAtFilePath += MyVideoThumbnailReadyAtFilePath;
		Kamcord.shareButtonPressed += MyShareButtonPressed;
		Kamcord.videoWillBeginUploading += MyVideoWillBeginUploading;
		Kamcord.videoUploadProgressed += MyVideoUploadProgressed;
		Kamcord.videoFinishedUploading += MyVideoFinishedUploading;
		Kamcord.videoSharedToFacebook += MyVideoSharedToFacebook;
		Kamcord.videoSharedToTwitter += MyVideoSharedToTwitter;
		Kamcord.videoSharedToYoutube += MyVideoSharedToYoutube;
		Kamcord.videoSharedToNicoNico += MyVideoSharedToNicoNico;
		Kamcord.snapshotReadyAtFilePath += MySnapshotReadyAtFilePath;
		Kamcord.pushNotifCallToActionButtonPressed += MyPushNotifCallToActionButtonPressed;
		Kamcord.adjustAndroidWhitelist += MyAdjustAndroidWhitelist;
		Kamcord.isEnabledChanged += MyIsEnabledChanged;
	}

	private void OnDestroy()
	{
		UnregisterCallbacks();
	}

	private void UnregisterCallbacks()
	{
		Kamcord.kamcordDidStartRecording -= MyKamcordDidStartRecording;
		Kamcord.kamcordDidStopRecording -= MyKamcordDidStopRecording;
		Kamcord.kamcordViewDidAppear -= MyKamcordViewDidAppear;
		Kamcord.kamcordViewWillDisappear -= MyKamcordViewWillDisappear;
		Kamcord.kamcordViewDidDisappear -= MyKamcordViewDidDisappear;
		Kamcord.kamcordViewDidNotAppear -= MyKamcordViewDidNotAppear;
		Kamcord.kamcordWatchViewDidAppear -= MyKamcordWatchViewDidAppear;
		Kamcord.kamcordWatchViewWillDisappear -= MyKamcordWatchViewWillDisappear;
		Kamcord.kamcordWatchViewDidDisappear -= MyKamcordWatchViewDidDisappear;
		Kamcord.videoThumbnailReadyAtFilePath -= MyVideoThumbnailReadyAtFilePath;
		Kamcord.shareButtonPressed -= MyShareButtonPressed;
		Kamcord.videoWillBeginUploading -= MyVideoWillBeginUploading;
		Kamcord.videoUploadProgressed -= MyVideoUploadProgressed;
		Kamcord.videoFinishedUploading -= MyVideoFinishedUploading;
		Kamcord.videoSharedToFacebook -= MyVideoSharedToFacebook;
		Kamcord.videoSharedToTwitter -= MyVideoSharedToTwitter;
		Kamcord.videoSharedToYoutube -= MyVideoSharedToYoutube;
		Kamcord.videoSharedToNicoNico -= MyVideoSharedToNicoNico;
		Kamcord.snapshotReadyAtFilePath -= MySnapshotReadyAtFilePath;
		Kamcord.pushNotifCallToActionButtonPressed -= MyPushNotifCallToActionButtonPressed;
		Kamcord.adjustAndroidWhitelist -= MyAdjustAndroidWhitelist;
		Kamcord.isEnabledChanged -= MyIsEnabledChanged;
	}

	private GUIStyle GetStyle()
	{
		return new GUIStyle(GUI.skin.button);
	}

	private void OnGUI()
	{
		GUIStyle style = GetStyle();
		if ((Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android) && GUI.Button(showWatchViewButtonRect, "Show Watch View", style))
		{
			Kamcord.ShowWatchView();
		}
		if (!Kamcord.IsEnabled())
		{
			string disabledReason = Kamcord.GetDisabledReason();
			GUI.Label(startRecordingButtonRect, "Kamcord Disabled:\n" + disabledReason);
		}
		else if (Kamcord.IsRecording() || Kamcord.IsPaused())
		{
			if (Kamcord.IsPaused())
			{
				if (GUI.Button(startRecordingButtonRect, "Resume", style))
				{
					Kamcord.Resume();
				}
			}
			else if (GUI.Button(startRecordingButtonRect, "Pause", style))
			{
				Kamcord.Pause();
			}
			if (GUI.Button(stopRecordingButtonRect, "Stop Recording", style))
			{
				Kamcord.StopRecording();
				Kamcord.SetVideoTitle("An Awesome Gameplay - " + (DateTime.Now - recordingStartedAt).TotalSeconds.ToString("F2") + " sec");
				Kamcord.SetDeveloperMetadata(Kamcord.MetadataType.level, "Level", "1");
				Kamcord.SetDeveloperMetadata(Kamcord.MetadataType.score, "Score", "1000");
				Kamcord.SetDeveloperMetadata(Kamcord.MetadataType.other, "Key", "Value");
				Kamcord.SetDeveloperMetadataWithNumericValue(Kamcord.MetadataType.other, "Key", "Value", 1000.0);
				firstVideoRecorded = true;
			}
		}
		else
		{
			if (GUI.Button(startRecordingButtonRect, "Start Recording", style))
			{
				Kamcord.StartRecording();
				recordingStartedAt = DateTime.Now;
			}
			if (firstVideoRecorded && GUI.Button(showViewButtonRect, "Show Last Video", style))
			{
				Kamcord.ShowView();
			}
		}
	}

	private void MyKamcordDidStartRecording()
	{
		Debug.Log("Hello MyKamcordDidStartRecording");
	}

	private void MyKamcordDidStopRecording()
	{
		Debug.Log("Hello MyKamcordDidStopRecording");
	}

	private void MyKamcordViewDidAppear()
	{
		Debug.Log("Hello MyKamcordViewDidAppear");
	}

	private void MyKamcordViewWillDisappear()
	{
		Debug.Log("Hello MyKamcordViewWillDisappear");
	}

	private void MyKamcordViewDidDisappear()
	{
		Debug.Log("Hello MyKamcordViewDidDisappear");
	}

	private void MyKamcordViewDidNotAppear()
	{
		Debug.Log("Hello MyKamcordViewDidNotAppear");
	}

	private void MyKamcordWatchViewDidAppear()
	{
		Debug.Log("Hello MyKamcordWatchViewDidAppear");
	}

	private void MyKamcordWatchViewWillDisappear()
	{
		Debug.Log("Hello MyKamcordWatchViewWillDisappear");
	}

	private void MyKamcordWatchViewDidDisappear()
	{
		Debug.Log("Hello MyKamcordWatchViewDidDisappear");
	}

	private void MyVideoThumbnailReadyAtFilePath(string filepath)
	{
		Debug.Log("Thumbnail ready at: " + filepath);
	}

	private void MyShareButtonPressed()
	{
		Debug.Log("ShareButtonPressed.");
	}

	private void MyVideoWillBeginUploading(string videoID, string url)
	{
		Debug.Log("Video " + videoID + " will begin uploading: " + url);
	}

	private void MyVideoUploadProgressed(string videoID, float progress)
	{
		Debug.Log("Video " + videoID + " upload progressed: " + progress);
	}

	private void MyVideoFinishedUploading(string videoID, bool success)
	{
		Debug.Log("Video " + videoID + " finished uploading: " + success);
	}

	private void MyVideoSharedToFacebook(string videoID, bool success)
	{
		Debug.Log("VideoSharedToFacebook: " + videoID);
	}

	private void MyVideoSharedToTwitter(string videoID, bool success)
	{
		Debug.Log("VideoSharedToTwitter: " + videoID);
	}

	private void MyVideoSharedToYoutube(string videoID, bool success)
	{
		Debug.Log("VideoSharedToYoutube: " + videoID);
	}

	private void MyVideoSharedToNicoNico(string videoID, bool success)
	{
		Debug.Log("VideoSharedToNicoNico: " + videoID);
	}

	private void MySnapshotReadyAtFilePath(string filepath)
	{
		Debug.Log("Snapshot ready at filepath: " + filepath);
	}

	private void MyPushNotifCallToActionButtonPressed()
	{
		Debug.Log("PushNotifCallToActionButtonPressed");
	}

	private void MyAdjustAndroidWhitelist()
	{
	}

	private void MyIsEnabledChanged(bool enabled)
	{
		Debug.Log("IsEnabledChanged: " + enabled);
	}
}
