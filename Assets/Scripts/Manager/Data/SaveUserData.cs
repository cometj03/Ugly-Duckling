[System.Serializable]
public class SaveUserData : SaveData
{
    public override void Save(eSaveType saveType)
    {
        strSave = "";

        strSave += "money:" + PlayerData.Instance.money;
        strSave += "/currentSkin:" + PlayerData.Instance.currentSkin;

        base.Save(saveType);
    }

    public override void Load(eSaveType saveType)
    {
        base.Load(saveType);

        PlayerData.Instance.money = System.Convert.ToInt32(loadDataDictionary["money"]);
        PlayerData.Instance.currentSkin = loadDataDictionary["currentSkin"];
    }
}