using Newtonsoft.Json;
using SimpleJSON;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SkinDataManager : MonoBehaviour
{
	public JSONNode data;

	public GameObject skinContent;
	public GameObject skinBox;

	public void DataToFile()
	{
		FileStream fs = File.Create("Assets/Datas/Skins.json");
		StreamWriter sw = new StreamWriter(fs);

		sw.Write(JsonConvert.SerializeObject(data));

		sw.Close();
		fs.Close();
	}

	public void FileToData()
	{
		StreamReader sr = new StreamReader("Assets/Datas/Skins.json");

		if(sr == null)
		{
			return;
		}

		data = JSON.Parse(sr.ReadToEnd());

		sr.Close();
	}

	public void UpdateContent()
	{
		int sortX = 250;

		foreach(var iter in data)
		{
			GameObject tmp = Instantiate(skinBox);

			SkinData skinData = tmp.GetComponent<SkinData>();
			RectTransform rectTransform = tmp.GetComponent<RectTransform>();

			skinData.skinName = iter.Value["skinName"];
			skinData.displayName = iter.Value["displayName"];
			skinData.info = iter.Value["info"];
			skinData.price = iter.Value["price"];
			skinData.UpdateDatas();

			rectTransform.position = new Vector2(sortX, 0);
			rectTransform.SetParent(skinContent.transform);
			rectTransform.localScale = new Vector3(1, 1, 1);
			sortX += 500;

			RectTransform contentRectTransform = skinContent.GetComponent<RectTransform>();

			contentRectTransform.sizeDelta += new Vector2(500, 0);
		}
	}

	private void Awake()
	{
		FileToData();
		UpdateContent();
	}
};
