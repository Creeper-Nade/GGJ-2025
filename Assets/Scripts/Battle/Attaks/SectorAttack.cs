using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmpFC.Battle
{   
    // unused for now, but can be used for future development (if we have time)
    public class SectorAttack : Attack
    {
        public float radius;
        public float? angleInDegrees;
        public Vector2 direction;

        public override bool IsInRange(Vector2 center, Vector2 target)
        {
            Vector2 targetDirection = target - center;
            float angle = Vector2.Angle(direction, targetDirection);
            return targetDirection.magnitude <= radius && angle <= angleInDegrees / 2;
        }
    }
}