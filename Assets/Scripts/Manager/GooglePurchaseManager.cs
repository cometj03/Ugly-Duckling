using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooglePurchaseManager : MonoBehaviour
{
    public void FeatherPurchase10()
	{
		PlayerData.Instance.MoneyProperty.Value += 10;
	}
}
