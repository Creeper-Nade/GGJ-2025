using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmpFC.Battle
{
    public class AttackExecuter : MonoBehaviour
    {
        private Attack _attack;

        public void ExecuteAttack(Attack attack)
        {
            _attack = attack;
            StartCoroutine(ExecuteAttackCoroutine());
        }

        private IEnumerator ExecuteAttackCoroutine()
        {
            yield return new WaitForSeconds(_attack.coolDownTime);
            GameObject warningGO = _attack.DoWarning(gameObject);
            yield return new WaitForSeconds(_attack.warningTime);
            Destroy(warningGO);
            _attack.Execute(gameObject);
            // if (_attack.IsInRange(Vector2.zero, Vector2.zero)) // this should be player position
            // {
            //     Debug.Log("Target is in range");
            // }
            // else
            // {
            //     Debug.Log("Target is out of range");
            // }
            Destroy(gameObject);
        }
    }
}