using Newtonsoft.Json;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SkinData : MonoBehaviour
{
	public List<Hashtable> data;

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
			data = new List<Hashtable>();
			return;
		}

		var tmp = JSON.Parse(sr.ReadToEnd());

		List<Hashtable> l_data = new List<Hashtable>();

		foreach(var iter in tmp)
		{
			Hashtable h_data = new Hashtable
			{
				{ "skinName", iter.Value["skinName"] },
				{ "displayName", iter.Value["displayName"] },
				{ "price", iter.Value["price"].AsInt }
			};

			l_data.Add(h_data);
		}

		data = l_data;

		sr.Close();
	}

	public void Insert(string skinName, string displayName, int price)
	{
		Hashtable h_data = new Hashtable
		{
			{ "skinName", skinName },
			{ "displayName", displayName },
			{ "price", price }
		};

		data.Add(h_data);
	}

	private void Awake()
	{
		FileToData();
	}
};
