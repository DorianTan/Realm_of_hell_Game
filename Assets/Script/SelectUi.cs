using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUi : MonoBehaviour
{

    private Node select;

    public void SetTarget(Node target)
    {
        select = target;

        transform.position = target.GetBuildPosition();
    }  
}
