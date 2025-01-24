using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmpFC.Battle
{
    [CreateAssetMenu(fileName = "Projectile Attack", menuName = "Battle/Attack/Projectile Attack")]
    public class ProjectileAttack : Attack
    {
        public float speed = 1f;
        public float range;
        public float knockback;
        public GameObject projectilePrefab;

        public override GameObject DoWarning(GameObject source)
        {
            GameObject warningGO = Instantiate(warningPrefab);
            warningGO.transform.position = Camera.main.WorldToScreenPoint(source.transform.position);
            warningGO.transform.rotation = source.transform.rotation;

            Vector3 screenPos = warningGO.transform.position;
            screenPos.x = Mathf.Clamp(screenPos.x, 0, Screen.width);
            screenPos.y = Mathf.Clamp(screenPos.y, 0, Screen.height);
            warningGO.transform.position = screenPos;

            if (screenPos.x > 0 && screenPos.x < Screen.width && screenPos.y > 0 && screenPos.y < Screen.height)
            {
                if (screenPos.x < Screen.width / 2)
                {
                    screenPos.x = 0;
                }
                else
                {
                    screenPos.x = Screen.width;
                }

                if (screenPos.y < Screen.height / 2)
                {
                    screenPos.y = 0;
                }
                else
                {
                    screenPos.y = Screen.height;
                }
            }
            warningGO.transform.position = screenPos;
            return warningGO;
        }

        public override void Execute(GameObject gameObject)
        {
            // Create a projectile and set its speed and range
            GameObject projectile = Instantiate(
                projectilePrefab,
                gameObject.transform.position,
                gameObject.transform.rotation
            );
            Projectile projectileComponent = projectile.GetComponent<Projectile>();
            projectileComponent.speed = speed;
            projectileComponent.range = range;
            projectileComponent.knockback = knockback;
            projectileComponent.damage = damage;
            InvokeOnAttackExecuted();
        }

        public override bool IsInRange(Vector2 center, Vector2 target)
        {
            // This kind of attack will never really hit the player, it's the projectile
            // created by this attack that will hit the player
            return false;
        }
    }
}