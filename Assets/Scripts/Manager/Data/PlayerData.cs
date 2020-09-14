using System.Runtime.InteropServices;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

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

#if UNITY_EDITOR
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
#endif
            return _instance;
        }
    }

    public SaveUserData userData;

    public int money;
    public string currentSkin;
    public float musicVolume, sfxVolume;

    public void Save(eSaveType saveType)
    {
        Debug.Log("Save");
        if (saveType == eSaveType.eAll)
        {
            userData.Save(saveType);
        }
        else if (saveType == eSaveType.eUser)
        {
            userData.Save(saveType);
        }
    }
    
    public void Load(eSaveType saveType)
    {
        if (saveType == eSaveType.eAll)
        {
            userData.Load(saveType);
        } 
        else if (saveType == eSaveType.eUser)
        {
            userData.Load(saveType);
        }
    }
}
