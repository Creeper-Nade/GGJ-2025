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
    [Range(0,200)]public float lerpSpeed;

    Vector3 FinalPos=Vector3.zero;
    Vector3 velocity=Vector3.zero;
    private void Awake() {
        Camera cam = Camera.main;
        BoarderTop = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, 0));
        BoarderBottom = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, 0, 0));
        pattern_NO=Random.Range(1,3);
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
        }
        if(!PatternCheck)
        {
            StartCoroutine(patternDecision());
            PatternCheck=true;
        }
    }

    private IEnumerator patternDecision()
    {
        yield return new WaitForSeconds(10);
        if(pattern_NO!=2)
        stage=2;
        pattern_NO=Random.Range(1,3);
        int previous= pattern_NO;
        PatternCheck=false;
    }
}
