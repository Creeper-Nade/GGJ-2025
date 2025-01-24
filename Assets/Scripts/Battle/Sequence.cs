using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmpFC.Battle
{
    [System.Serializable]
    public struct AttackItem
    {
        public Attack attack;
        public Vector3 position;
        public Vector3 rotation;
    }

    [CreateAssetMenu(fileName = "New Sequence", menuName = "Battle/Sequence")]
    public class Sequence : ScriptableObject
    {
        public List<AttackItem> attacks;
        private int currentAttackIndex = 0;

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
        public bool ExecuteNextAttack()
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
                attack.SubscribeToOnAttackExecuted(() =>
                {
                    ExecuteNextAttack();
                });
                currentAttackIndex++;
            }
            return currentAttackIndex < attacks.Count;
        }
    }
}