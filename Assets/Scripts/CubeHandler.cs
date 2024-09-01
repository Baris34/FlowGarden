using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    public bool cubeHasMoved;
    public static CubeHandler instance;
    private void Awake()
    {
        if (instance!=null&&instance!=this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
}
