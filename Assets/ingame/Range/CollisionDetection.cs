using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    
    public GameObject player;
    private List<Collider2D> collisionList= new List<Collider2D>();
    private void Awake() {
        player=GameObject.FindGameObjectWithTag("Player");
        //data=GameObject.FindObjectOfType<DataManager>().GetComponent<DataManager>();
        //data.FanTime=data.MaxFanTime;
    }
    private void OnTriggerEnter2D(Collider2D other) {
                if (other.gameObject==player)
        {
            collisionList.Add(other);
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
            DataManager.FanTime-=Time.deltaTime;
        }
        else if (DataManager.FanSum>0)
        {
            DataManager.UnsubTime-=(Time.deltaTime*CheckPlayerPos());
        }
        //cooldown for adding fans
        if(DataManager.FanTime<=0)
        {
            AddFans();
            DataManager.FanTime=DataManager.MaxFanTime;
        }
        if(DataManager.UnsubTime<=0 && DataManager.FanSum>0)
        {
            Unsubscribe();
            DataManager.UnsubTime=DataManager.MaxFanTime;
        }
        //accelerate the fan growing speed
        if(DataManager.FanSum>=DataManager.MultiplyGoal)
        {
            DataManager.MultiplyGoal*=2;
            DataManager.MaxFanTime*=0.8f;
            DataManager.MaxUnsubTime*=0.8f;
        }
        else if (DataManager.FanSum<DataManager.MultiplyGoal/2 && DataManager.MultiplyGoal>10)
        {
            DataManager.MultiplyGoal/=2;
            DataManager.MaxFanTime/=0.8f;
            DataManager.MaxUnsubTime/=0.8f;
        }
        //Debug.Log("total Fans "+ DataManager.FanSum + "Good" + DataManager.Likers+"bad "+DataManager.Haters);

    }
    public void AddFans()
    {
        float rand = Random.value;
        if(rand<=0.1f)
        {
            DataManager.Haters+=DataManager.Subscription_Amplifier;
            DataManager.FanSum+=DataManager.Subscription_Amplifier;
        }
        else
        {
            DataManager.Likers+=DataManager.Subscription_Amplifier;
            DataManager.FanSum+=DataManager.Subscription_Amplifier;
        }
        
    }
    public void Unsubscribe()
    {
        float rand = Random.value;
        if(rand<=0.1f)
        {
            DataManager.Likers--;
            DataManager.Haters++;
        }
        else if(DataManager.Likers>0 && rand<=0.9f)
        {
            DataManager.Likers--;
            DataManager.FanSum--;
        }
        else if (DataManager.Haters>0)
        {
            DataManager.Haters--;
            DataManager.FanSum--;
        }
    }
    float CheckPlayerPos()
    {
        float difference;
        difference=transform.position.y-player.transform.position.y;
        return Mathf.Abs(difference);
    }
}
