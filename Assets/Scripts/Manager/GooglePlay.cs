using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GooglePlay : MonoBehaviour
{
    public void DoAutoLogin()
	{
		if (!Social.localUser.authenticated)
		{
			Social.localUser.Authenticate((bool bSuccess) =>
			{
				if (bSuccess)
				{
					Debug.Log("Google Login Success : " + Social.localUser.userName);
				}
				else
				{
					Debug.Log("Google Login Fail");
				}
			});
		}
	}

	public void DoLogOut()
	{
		((PlayGamesPlatform)Social.Active).SignOut();	
	}

	private void Awake()
	{
		PlayGamesPlatform.InitializeInstance(new PlayGamesClientConfiguration.Builder().Build());
		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate();
	}

	private void Start()
	{
		DoAutoLogin();
	}
}
