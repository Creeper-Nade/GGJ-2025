using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmpFC.Battle
{
    public enum PlayType
    {
        WaitForComplete,
        PlayImmediately
    }

    [System.Serializable]
    public struct AttackItem
    {
        [Tooltip("Attack to be executed")]
        public Attack attack;
        [Tooltip("Position in world space where the attack will be spawned")]
        public Vector3 position;
        [Tooltip("Rotation in degrees, the attack will follow this rotation")]
        public Vector3 rotation;
        [Tooltip("How the attack will be played")]
        public PlayType nextPlayType;
    }

    [CreateAssetMenu(fileName = "New Sequence", menuName = "Battle/Sequence")]
    public class Sequence : ScriptableObject
    {
        public List<AttackItem> attacks;
        private int currentAttackIndex = 0;
        public bool running = false;

        public void Initialize()
        {
            currentAttackIndex = 0;
        }

        /// <summary>
        /// Execute the next attack in the sequence, if there are
        /// no more attacks to execute, return false
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        private bool ExecuteNextAttack()
        {
            if (currentAttackIndex < attacks.Count)
            {
                AttackItem attackItem = attacks[currentAttackIndex];
                Attack attack = attackItem.attack;
                GameObject attackGO = attack.Initialize();
                attackGO.transform.position = attackItem.position;
                attackGO.transform.rotation = Quaternion.Euler(attackItem.rotation);
                AttackExecuter attackExecuter = attackGO.GetComponent<AttackExecuter>();
                attackExecuter.ExecuteAttack(attack);
                currentAttackIndex++;
                if (attackItem.nextPlayType == PlayType.PlayImmediately && running)
                {
                    ExecuteNextAttack();
                }
                else
                {
                    attack.UnsubscribeAllToOnAttackExecuted();
                    attack.SubscribeToOnAttackExecuted(TryNext);
                }
            }
            else
            {
                running = false;
            }
            //Debug.Log("Running: " + running);
            return running;
        }

        private void TryNext()
        {
            if (running)
                ExecuteNextAttack();
        }

        /// <summary>
        /// Play the sequence, executing the attacks one after another
        /// </summary>
        public void Play()
        {
            running = true;
            //Debug.Log("asd");
            ExecuteNextAttack();
        }

        /// <summary>
        /// Pause the sequence
        /// </summary>
        public void Pause()
        {
            running = false;
        }
    }
}