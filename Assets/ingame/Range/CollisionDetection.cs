using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public int FanSum;
    public int Haters;
    public int Likers;
    [SerializeField] float FanTime=1f;
    [SerializeField] float MaxFanTime=1f;
    public GameObject player;
    private List<Collider2D> collisionList= new List<Collider2D>();
    private void Awake() {
        player=GameObject.FindGameObjectWithTag("Player");
        FanTime=MaxFanTime;
    }
    private void OnTriggerEnter2D(Collider2D other) {
                if (other.gameObject==player)
        {
            collisionList.Add(other);
            Debug.Log("pplayer added");
        } 
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject==player)
        {
            collisionList.Remove(other);
        }  
    }

    // Update is called once per frame
    void Update()
    {
        if(collisionList.Count!=0 && collisionList!=null)
        {
            FanTime-=Time.deltaTime;
        }
        if(FanTime<=0)
        {
            AddFans();
            FanTime=MaxFanTime;
        }
    }
    public void AddFans()
    {
        float rand = Random.value;
        if(rand<=0.2f)
        {
            Haters++;
            FanSum++;
        }
        else
        {
            Likers++;
            FanSum++;
        }
        Debug.Log("Fan: "+FanSum+"Haters: "+Haters+"Likers: "+Likers);
    }

}
