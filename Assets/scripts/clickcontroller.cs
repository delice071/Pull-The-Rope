using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class clickcontroller : MonoBehaviour, IPointerDownHandler
{
    private int pullValue = 10;
    [SerializeField] private bool isAI;
    [SerializeField] private bool isBot;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (isAI) return;


        
        Pull();
    }


    private void Pull()
    {
        ropecontroller.Instance.Value += pullValue;
    }

    private void Start()
    {
        pullValue = gameManager.Instance.pullPower;
        if (isBot)
        {
            pullValue *= -1;
        }

        if (isAI)
        {
            StartCoroutine(AutoClick());
        }
    }


    IEnumerator AutoClick()
    {
        while(true)
        {
            var second =Random.Range(.1f, .4f);
            yield return new WaitForSeconds(second);
            Pull();
        }
    }


}
