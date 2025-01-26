using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AmpFC.Battle;
using UnityEngine;

public class Projectile_Manager : MonoBehaviour
{
    //[SerializeField] List<SequencePlayer> sequencePlayers;
    [SerializeField] List<SequencePlayer> enabledSequencePlayers;
    SequencePlayer SelectedPattern;
    private void Awake()
    {
        //for (int i = 0; i < GetComponents<SequencePlayer>().Count(); i++)
        //{
        //    sequencePlayers.Add(GetComponents<SequencePlayer>()[i]);
        //}
        DataManager.Haters = 38;
        InitList();
    }

    void InitList()
    {
        for (int i = 0; i < DataManager.Projectile_level; i++)
        {
            enabledSequencePlayers.Add(GetComponents<SequencePlayer>()[i]);
        }
        if (enabledSequencePlayers.Count() > 0)
            RandomizeSequence();
    }
    void Update()
    {
        if (DataManager.Haters >= DataManager.HaterMultiplyGoal)
        {
            DataManager.HaterMultiplyGoal *= 2;
            DataManager.Projectile_level++;
            enabledSequencePlayers.Add(GetComponents<SequencePlayer>()[DataManager.Projectile_level - 1]);
            if (SelectedPattern == null)
                RandomizeSequence();
        }
        else if (DataManager.Haters < DataManager.HaterMultiplyGoal / 2 && DataManager.HaterMultiplyGoal >= 20)
        {
            DataManager.HaterMultiplyGoal /= 2;
            enabledSequencePlayers.Remove(GetComponents<SequencePlayer>()[DataManager.Projectile_level - 1]);
            DataManager.Projectile_level--;

        }

        if (enabledSequencePlayers.Count() == 0)
        {
            SelectedPattern = null;
        }
        if (SelectedPattern != null && SelectedPattern.sequence.running == false)
        {
            RandomizeSequence();

        }

    }
    void RandomizeSequence()
    {
        if (enabledSequencePlayers.Count() > 1)
            SelectedPattern = enabledSequencePlayers[Random.Range(0, enabledSequencePlayers.Count() - 1)];
        else
            SelectedPattern = enabledSequencePlayers[0];
        SelectedPattern.sequence.Initialize();
        SelectedPattern.sequence.Play();
    }
}
