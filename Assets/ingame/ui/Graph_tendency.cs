using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Graph_tendency : MonoBehaviour
{
        public LineRenderer myLineRenderer;
    public int points;
    public float movementSpeed = 1;
    private Transform startpoint;
    private Transform endpoint;
    private Transform Highestpoint;
    private Transform Lowestpoint;

    private float[] currentpointNO=new float[999];
    private float[] lastpointNO=new float[999];
    private int lastfanNO=0;
    private float TimeElapse=0.5f;
    void Awake()
    {
        myLineRenderer = GetComponent<LineRenderer>();
        startpoint=transform.Find("startPoint");
        endpoint=transform.Find("EndPoint");
        Highestpoint=transform.Find("HighestPoint");
        Lowestpoint=transform.Find("LowestPoint");
        TimeElapse=0.5f;
        Draw(0,1);
    }
    
    public void Draw(int positive,int times)
    {
        float xStart = endpoint.position.x;
        float xFinish =startpoint.position.x;
        float lowest=Lowestpoint.position.y;
        float highest=Highestpoint.position.y;
 
        myLineRenderer.positionCount = points;
        for(int currentPoint = 0; currentPoint<points;currentPoint++)
        {
            lastpointNO[currentPoint]=currentpointNO[currentPoint];
            if(currentPoint==0)
            {
                switch(positive)
                {
                    case 1:
                        if(currentpointNO[currentPoint]+0.01f*times+lowest<=highest)
                        {
                            currentpointNO[currentPoint]+=0.01f*times;
                        }
                        break;
                    case -1:
                        if(currentpointNO[currentPoint]-0.01f*times+lowest>=lowest)
                        {
                            currentpointNO[currentPoint]-=0.01f*times;
                        }
                        break;
                    case 0:
                    currentpointNO[currentPoint]=0;
                    break;
                }
                
            }
            else currentpointNO[currentPoint]=lastpointNO[currentPoint-1];
            float progress = (float)currentPoint/(points-1);
            float x = Mathf.Lerp(xStart,xFinish,progress);
            float y = lowest + currentpointNO[currentPoint];
            //amplitude*Mathf.Sin((Tau*frequency*x)+(Time.timeSinceLevelLoad*movementSpeed));
            myLineRenderer.SetPosition(currentPoint, new Vector3(x,y,0));
        }
    }
    private void CalculateDifference()
    {
        int currentFanNO;
        currentFanNO=DataManager.FanSum-lastfanNO;
        //UnityEngine.Debug.Log(currentFanNO);
        switch(currentFanNO)
        {
            case >=0:
            Draw(1,currentFanNO);
            break;
            case <0:
            Draw(-1,Mathf.Abs(currentFanNO));
            break;
        }
        lastfanNO=DataManager.FanSum;
    }
    void Update()
    {
        if(TimeElapse>0)
        {
            TimeElapse-=Time.deltaTime;
        }
        else
        {
            CalculateDifference();
            TimeElapse=0.5f;
        }
    }
}
