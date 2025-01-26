using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vtuber : MonoBehaviour
{
    public PlayerMovement player;
    float timeOfTravel = 0.1f; //time after object reach a target place 
    float currentTime = 0; // actual floting time 
    Vector3 Rectvelocity = Vector3.zero;
    float normalizedValue;
    Vector3 topPos = new Vector3(65, -46, 0);
    Vector3 bottomPos = new Vector3(65, -64, 0);
    Vector3 StartPos;
    Vector3 TargetPos;

    RectTransform rectTransform; //getting reference to this component 
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    IEnumerator LerpObject()
    {

        while (currentTime <= timeOfTravel)
        {
            currentTime += Time.deltaTime;
            normalizedValue = currentTime / timeOfTravel; // we normalize our time 

            rectTransform.anchoredPosition = Vector3.Lerp(rectTransform.anchoredPosition, TargetPos, normalizedValue);
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.moveDir.y == 0)
        {
            TargetPos = bottomPos;
        }
        else
        {
            TargetPos = topPos;
        }
        //StartCoroutine(LerpObject());

        rectTransform.localPosition = Vector3.SmoothDamp(rectTransform.localPosition, TargetPos, ref Rectvelocity, timeOfTravel);
    }
}
