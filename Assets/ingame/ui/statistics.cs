using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class statistics : MonoBehaviour
{
    public TextMeshProUGUI Liker;
    public TextMeshProUGUI Hater;

    // Update is called once per frame
    void Update()
    {
        Liker.text=string.Format("{0}",DataManager.Likers);
        Hater.text=string.Format("{0}",DataManager.Haters);
    }
}
