using UnityEditor;
using UnityEngine;

public class PlayerData : ScriptableObject
{
    private const string DataFileDirectory = "Assets/Resources";
    private const string DataFilePath = "Assets/Resources/PlayerData.asset";

    private static PlayerData _instance;

    // 그냥 싱글톤 인스턴스 불러오는거
    public static PlayerData Instance
    {
        get
        {
            if (_instance != null)
                return _instance;

            _instance = Resources.Load<PlayerData>("PlayerData");

            if (_instance == null)
            {
                if (!AssetDatabase.IsValidFolder(DataFileDirectory))
                    AssetDatabase.CreateFolder("Assets", "Resources");

                _instance = AssetDatabase.LoadAssetAtPath<PlayerData>(DataFilePath);

                if (_instance == null)
                {
                    _instance = CreateInstance<PlayerData>();
                    AssetDatabase.CreateAsset(_instance, DataFilePath);
                }
            }

            return _instance;
        }
    }

    public string currentSkin = "bird";    // default : "bird"
}
