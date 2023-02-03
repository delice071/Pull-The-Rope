using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance { get; private set; }

    public int pullPower;


    private void Awake()
    {
        Instance = this; 
    }

}
