using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RangeMovement : MonoBehaviour
{
    private int pattern_NO;
    Vector3 BoarderTop;
    Vector3 BoarderBottom;
    [Header("data")]
    public float constantSPEED;
    int stage=2;
    int add_stage=1;
    bool stageCheck=false;
    bool PatternCheck=false;
    bool SizeCheck=false;
    [Range(0,200)]public float lerpSpeed;

    Vector3 FinalPos=Vector3.zero;
    Vector3 velocity=Vector3.zero;
    Vector3 newScale = new Vector3(20, 4, 1);
    private void Awake() {
        Camera cam = Camera.main;
        BoarderTop = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, 0));
        BoarderBottom = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, 0, 0));
        pattern_NO=Random.Range(1,4);
    }
    void ConstantMove()
    {
            Vector3 movePos=transform.position;
            movePos.y+= constantSPEED* Time.deltaTime;
            transform.position=movePos;
            if(transform.position.y>=BoarderTop.y-1 || transform.position.y<=BoarderBottom.y+1)
            {
                constantSPEED*=-1;
            }
        
    }
    public void tripleStageMove()
    {
        if(!stageCheck)
        {
            stageCheck=true;
            StartCoroutine(StageWait());
        }        
        switch (stage)
        {
            default:
                FinalPos.y=BoarderBottom.y+1;
                break;
            case 1:
                FinalPos.y=BoarderBottom.y+1;
                break;
            case 2:
                FinalPos.y=BoarderBottom.y+(BoarderTop.y-BoarderBottom.y)/2;
                break;
            case 3:
                FinalPos.y=BoarderTop.y-1;
                break;
        }
        //Vector3 movePos=transform.position;
        //float speed=2f;
        //var step= speed*Time.deltaTime;
        transform.position=Vector3.SmoothDamp(transform.position,FinalPos,ref velocity,Time.deltaTime*lerpSpeed);
        //transform.position=Vector3.MoveTowards(transform.position,FinalPos,step);
    }
        private IEnumerator StageWait()
    {
        
        yield return new WaitForSeconds(3); 
        stage+=add_stage; 
        stageCheck=false;
        if(stage>=3||stage<=1)
        add_stage*=-1;
             
    }
    public void SizeChange()
    {
        if(!SizeCheck)
        {
            SizeCheck=true;
            StartCoroutine(SizeChangeWait());
        }
        FinalPos.y=BoarderBottom.y+(BoarderTop.y-BoarderBottom.y)/2;
        transform.position=Vector3.SmoothDamp(transform.position,FinalPos,ref velocity,Time.deltaTime*lerpSpeed);    
        transform.localScale=Vector3.Lerp(transform.localScale,newScale,2.0f*Time.deltaTime);
    }
    private IEnumerator SizeChangeWait()
    {
        
        yield return new WaitForSeconds(5);
        if(newScale.y==4) 
        newScale.y=1;
        else
        newScale.y=4;
        SizeCheck=false;
             
    }
    void Update()
    {
        switch(pattern_NO)
        {
            default:
                ConstantMove();
                break;
            case 1:
                ConstantMove();
                break;
            case 2:
                tripleStageMove();
                break;
            case 3:
                SizeChange();
                break;
        }
        if(!PatternCheck)
        {
            StartCoroutine(patternDecision());
            PatternCheck=true;
        }
        if(pattern_NO!=3)
        {
            
            transform.localScale=Vector3.Lerp(transform.localScale,new Vector3(20,2,1),2.0f*Time.deltaTime);
        }
    }

    private IEnumerator patternDecision()
    {
        yield return new WaitForSeconds(15);
        if(pattern_NO!=2)
        stage=2;
        pattern_NO=Random.Range(1,4);
        int previous= pattern_NO;
        PatternCheck=false;
    }
}
