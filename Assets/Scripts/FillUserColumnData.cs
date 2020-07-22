using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FillUserColumnData : MonoBehaviour
{
    [SerializeField] private GameObject UserDataColumnPrefab;

    public void SetColumns(string[] userDataColumns)
    {
        foreach (string data in userDataColumns)
        {
            GameObject dataColumn = Instantiate(UserDataColumnPrefab, this.transform);
            dataColumn.GetComponent<Text>().text = data;
        }
    }
}