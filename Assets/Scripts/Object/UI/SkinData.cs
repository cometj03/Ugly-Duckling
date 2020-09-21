using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkinData : MonoBehaviour
{
	public string skinName;
	public string displayName;
	public string info;
	public int price;

	public void SelectSkin()
	{
		SoundManager.instance.PlayBtnSFX(eSFX.BtnClick2);
		GameObject.FindGameObjectWithTag("Player").GetComponent<BirdCustomAnimation>().ChangeSkin(skinName);
	}

	public void BuySkin()
	{
		SoundManager.instance.PlayBtnSFX(eSFX.BtnClick1);

		// GameObject buyBtn = EventSystem.current.currentSelectedGameObject;	// 클릭한 버튼 불러옴
		// var priceString = buyBtn.transform.GetChild(0).GetChild(0).GetComponent<Text>().text;
		// int price = System.Convert.ToInt32(priceString);	// 가격 불러옴

		if (PlayerData.Instance.MoneyProperty.Value >= price)
		{
			PlayerData.Instance.MoneyProperty.Value -= price;
		}
	}

	public void UpdateDatas()
	{
		transform.GetChild(0).GetChild(0).GetComponent<Text>().text = displayName;
		transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = info;
		transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = price.ToString();

		transform.GetChild(1).GetComponent<Image>().sprite = Resources.LoadAll<Sprite>("Animations/" + skinName + "/Idle")[0];
	}
}
