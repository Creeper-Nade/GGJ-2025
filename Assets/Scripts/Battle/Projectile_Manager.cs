using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AmpFC.Battle;
using UnityEngine;

public class Projectile_Manager : MonoBehaviour
{
    [SerializeField] List<SequencePlayer> sequencePlayers;
    //[SerializeField] List<SequencePlayer> enabledSequencePlayers;
    private void Awake()
    {
        for (int i = 0; i < GetComponents<SequencePlayer>().Count(); i++)
        {
            sequencePlayers.Add(GetComponents<SequencePlayer>()[i]);
        }

    }
    void Update()
    {
        //foreach (SequencePlayer sequencePlayer in sequencePlayers)
        //{
        //    if (sequencePlayer.sequence.ExecuteNextAttack() == false)
        //    {
        //        sequencePlayer.sequence.Initialize();
        //        sequencePlayer.sequence.Play();
        //    }
        //}
    }
}
