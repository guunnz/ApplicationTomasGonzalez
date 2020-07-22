using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Common : MonoBehaviour
{

    static public void DestroyChildrenOfTransform(Transform transform)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
