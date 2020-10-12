using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class GooglePlay : MonoBehaviour
{
	const string googleLoginText = "Sign in with Google";
	const string googleLogoutText = "Sign out";

	public Text googleLoginButtonText;

    public void DoAutoLogin()
	{
		if (!Social.localUser.authenticated)
		{
			Social.localUser.Authenticate((bool bSuccess) =>
			{
				if (bSuccess)
				{
					Debug.Log("Google Login Success : " + Social.localUser.userName);
					googleLoginButtonText.text = googleLogoutText;
				}
				else
				{
					Debug.Log("Google Login Fail");
					googleLoginButtonText.text = googleLoginText;
				}
			});
		}
	}

	public void DoLogOut()
	{
		googleLoginButtonText.text = googleLoginText;
		((PlayGamesPlatform)Social.Active).SignOut();
	}

	public void OnBtnLoginClicked()
	{
		if (Social.localUser.authenticated)
		{
			googleLoginButtonText.text = googleLoginText;
			((PlayGamesPlatform)Social.Active).SignOut();
		}
		else
		{
			Social.localUser.Authenticate((bool success) =>
			{
				if (success)
				{
					googleLoginButtonText.text = googleLogoutText;
				}
				else
				{
					Debug.Log("Login Failed");
					googleLoginButtonText.text = googleLoginText;
				}
			});
		}
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
