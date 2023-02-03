using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ropecontroller : MonoBehaviour
{
   public static ropecontroller Instance { get; private set; }


    public int Value { get; set; }

    [SerializeField] private Transform topline;
    [SerializeField] private Transform botline;
    [SerializeField] private Vector2 minMaxValue;

    public GameObject RedWin;
    public GameObject BlueWin;
    public GameObject tryAgain;
    public GameObject exitt;

    


    private Vector2 minMaxverticalPosition;
    private void Awake()
    {
        Instance = this; 
    }

    private void Start()
    {
        minMaxverticalPosition = new Vector2(botline.position.y, topline.position.y);
        Time.timeScale= 1f;
    }

    private void FixedUpdate()
    {
        
        var position= transform.position;
        var normalize = Mathf.InverseLerp(minMaxValue.x, minMaxValue.y, Value);
        var verticalPosition = Mathf.Lerp(minMaxverticalPosition.x, minMaxverticalPosition.y, normalize);
        var currentVerticalPosition = Mathf.Lerp(transform.position.y, verticalPosition, .1f);
        position.y = currentVerticalPosition;
        transform.position = position;

        if (Mathf.Abs(Math.Abs(transform.position.y) - Math.Abs(minMaxverticalPosition.y))< .1f)
        {
            Debug.Log("Game Finish");
            if (transform.position.y > 0)
            {
                BlueWin.SetActive(true);
            }
            else
            {
                RedWin.SetActive(true);
            }
                
            Time.timeScale= 0;
            tryAgain.SetActive(true) ;
            exitt.SetActive(true);

        }
    }
    

}
