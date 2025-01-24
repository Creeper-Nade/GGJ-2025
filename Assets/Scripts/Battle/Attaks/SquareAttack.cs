using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmpFC.Battle
{
    // unused for now, but can be used for future development (if we have time)
    public class SquareAttack : Attack
    {
        public float? width;
        public float? height;

        public override bool IsInRange(Vector2 center, Vector2 target)
        {
            return Mathf.Abs(center.x - target.x) <= width / 2 && Mathf.Abs(center.y - target.y) <= height / 2;
        }
    }
}