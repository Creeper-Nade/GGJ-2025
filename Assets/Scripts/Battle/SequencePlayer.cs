using UnityEngine;

namespace AmpFC.Battle
{
    public class SequencePlayer : MonoBehaviour
    {
        public Sequence sequence;

        public void Start()
        {
            sequence.Initialize();
            sequence.ExecuteNextAttack();
        }
    }
}