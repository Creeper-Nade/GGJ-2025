using UnityEngine;

namespace AmpFC.Battle
{
    public class SequencePlayer : MonoBehaviour
    {
        public Sequence sequence;

        public void Start()
        {
            // just start the sequence and play it one after another
            sequence.Initialize();
            sequence.Play();
        }
    }
}