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
            // Making camera bounds
            var cam = Camera.main;
            var leftBottom = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
            var rightTop = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));

            var center = leftBottom + (rightTop - leftBottom) / 2;
            // Warning: assume source is on the cam.nearClipPlane
            var direction = new Vector2(source.transform.position.x, source.transform.position.y) - center;
            var angle = Vector2.SignedAngle(Vector2.right, direction);

            // Calculate the intersection of the ray and the rectangle
            Vector2 intersection;
            float t1 = (leftBottom.x - center.x) / direction.x;
            float t2 = (rightTop.x - center.x) / direction.x;
            float t3 = (leftBottom.y - center.y) / direction.y;
            float t4 = (rightTop.y - center.y) / direction.y;

            float tmin = Mathf.Max(Mathf.Min(t1, t2), Mathf.Min(t3, t4));
            float tmax = Mathf.Min(Mathf.Max(t1, t2), Mathf.Max(t3, t4));

            if (tmax < 0 || tmin > tmax)
            {
                intersection = center; // No intersection, set to center as fallback
            }
            else
            {
                intersection = center + direction * tmin;
            }

            // Set the position of the warningGO to the nearest edge
            warningGO.transform.position = intersection;
            source.transform.position = intersection;
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