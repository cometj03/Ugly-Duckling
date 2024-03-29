﻿using System.Runtime.InteropServices;
using UniRx;
using UnityEngine;
using System.Collections.Generic;

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
    
    // Global
    public GameState currentState;
    public int currentLevel;

    // saved data variable
    public SaveUserData userData;
    public SaveSettingData settingData;
    public SaveSkinListData skinListData;
    
    public ReactiveProperty<int> MoneyProperty = new ReactiveProperty<int>();
    public Dictionary<string, bool> skinList = new Dictionary<string, bool>();
    public string currentSkin;
    public float musicVolume, sfxVolume;

    public void Save(eSaveType saveType)
    {
        switch (saveType)
        {
            case eSaveType.eAll:
                userData.Save(eSaveType.eUser);
                settingData.Save(eSaveType.eSetting);
                skinListData.Save(eSaveType.eSkinList);
                break;
            case eSaveType.eUser:
                userData.Save(saveType);
                break;
            case eSaveType.eSetting:
                settingData.Save(eSaveType.eSetting);
                break;
            case eSaveType.eSkinList:
                skinListData.Save(eSaveType.eSkinList);
                break;
        }
    }
    
    public void Load(eSaveType saveType)
    {
        switch (saveType)
        {
            case eSaveType.eAll:
                userData.Load(eSaveType.eUser);
                settingData.Load(eSaveType.eSetting);
                skinListData.Load(eSaveType.eSkinList);
                break;
            case eSaveType.eUser:
                userData.Load(saveType);
                break;
            case eSaveType.eSetting:
                settingData.Load(eSaveType.eSetting);
                break;
            case eSaveType.eSkinList:
                skinListData.Load(eSaveType.eSkinList);
                break;
        }
    }
}
