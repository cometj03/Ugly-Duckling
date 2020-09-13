using Newtonsoft.Json;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using UnityEngine;

public class SkinData : MonoBehaviour
{
	public JSONNode data;

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

		data = JSON.Parse(sr.ReadToEnd());

		sr.Close();
	}

	private void Awake()
	{
		
	}
};
