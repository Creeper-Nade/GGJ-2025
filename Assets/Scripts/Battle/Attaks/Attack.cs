using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmpFC.Battle
{
    public abstract class Attack : ScriptableObject
    {
        public float coolDownTime; // time before the warning starts
        public float warningTime; // time before the attack executes
        public int damage;
        public AttackExecuter prefab;
        public GameObject warningPrefab;

        public delegate void AttackEvent();
        public event AttackEvent OnAttackExecuted;

        /// <summary>
        /// Initializes the attack, normally instantiating the prefab of the attack
        /// The prefab should contain the visual representation of the attack, 
        /// normally displayed in the first place.
        /// the prefab is supposed to have an AttackExecuter component.
        /// </summary>
        /// <returns>The created attack GameObject</returns>
        public virtual GameObject Initialize()
        {
            return Instantiate(prefab.gameObject);
        }

        /// <summary>
        /// Does the warning of the attack. 
        /// Normally showing the area where the attack is going to land.
        /// Should have it's own visual representation for different attacks.
        /// </summary>
        /// <param name="source">The GameObjcet that creates this attack</param>
        /// <returns>The created warning GameObject</returns> 
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual GameObject DoWarning(GameObject source)
        {
            Debug.Log("Warning Done");
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Executes the attack. Cause damage to the player, or do something else.
        /// </summary>
        /// <param name="target">The GameObjcet that creates this attack</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual void Execute(GameObject source)
        {
            Debug.Log("Attack Executed");
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Checks if the target is in range of the attack.
        /// </summary>
        /// <param name="center">the transform position of the attack</param>
        /// <param name="target">the position of the player</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual bool IsInRange(Vector2 center, Vector2 target)
        {
            Debug.Log("Checking if target is in range");
            throw new System.NotImplementedException();
        }

        protected void InvokeOnAttackExecuted()
        {
            OnAttackExecuted?.Invoke();
        }

        public void SubscribeToOnAttackExecuted(AttackEvent attackEvent)
        {
            OnAttackExecuted += attackEvent;
        }

        public void UnsubscribeToOnAttackExecuted(AttackEvent attackEvent)
        {
            OnAttackExecuted -= attackEvent;
        }

        public void UnsubscribeAllToOnAttackExecuted()
        {
            OnAttackExecuted = null;
        }
    }
}