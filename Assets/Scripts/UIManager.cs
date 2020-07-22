using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text Title;
    [SerializeField] private Transform ColumnsParent;
    [SerializeField] private Transform UserDataParent;
    [SerializeField] private UIData UIData;
    [SerializeField] private GameObject ColumnPrefab;
    [SerializeField] private GameObject UserDataPrefab;

    private void Start()
    {
        SetUI();
    }

    public void SetUI()
    {
        Common.DestroyChildrenOfTransform(ColumnsParent);
        Common.DestroyChildrenOfTransform(UserDataParent);
        UIData.DecodeJson();
        Title.text = UIData.GetTitle();
        string[] columns = UIData.GetColumns();
        List<List<KeyValuePair<string, string>>> userDataList = UIData.GetUsersData();

        foreach (string column in columns)
        {
            GameObject columnObject = Instantiate(ColumnPrefab, ColumnsParent);
            columnObject.GetComponent<Text>().text = column;
        }
        foreach (List<KeyValuePair<string, string>> userData in userDataList)
        {
            GameObject userDataObject = Instantiate(UserDataPrefab, UserDataParent);
            userDataObject.GetComponent<FillUserColumnData>().SetColumns(userData.Select(x => x.Value).ToArray());
        }
    }
}