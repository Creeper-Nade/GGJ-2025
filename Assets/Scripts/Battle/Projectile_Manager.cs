using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AmpFC.Battle;
using UnityEngine;

public class Projectile_Manager : MonoBehaviour
{
    [SerializeField] List<SequencePlayer> sequencePlayers;

    private void Awake()
    {
        for (int i = 0; i < GetComponents<SequencePlayer>().Count(); i++)
            sequencePlayers.Add(GetComponents<SequencePlayer>()[i]);
    }
    void Update()
    {
        foreach (SequencePlayer sequencePlayers)
        {

        }
    }
}
