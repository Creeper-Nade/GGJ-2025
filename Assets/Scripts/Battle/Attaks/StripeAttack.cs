using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmpFC.Battle
{
    public class StripeAttack : Attack
    {
        public enum Direction
        {
            Horizontal,
            Vertical
        }
        public float? width;
        public Direction direction = Direction.Horizontal;

        public override bool IsInRange(Vector2 center, Vector2 target)
        {
            if (direction == Direction.Horizontal)
            {
                return Mathf.Abs(center.y - target.y) <= width / 2;
            }
            else
            {
                return Mathf.Abs(center.x - target.x) <= width / 2;
            }
        }
    }
}