using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmpFC.Battle
{
    public class Projectile : MonoBehaviour
    {
        public delegate void OnProjectileHit(float damage, float knockback, Vector2 direction);
        public static OnProjectileHit onPlayerHit;
        public static OnProjectileHit onEnemyHit;

        public float speed;
        private Vector2 _direction;
        public float lifeTime = 10;
        public float damage;
        public float range;
        public float knockback;
        public bool is_friendly;

        private void Start()
        {
            StartCoroutine(DestroyAfterTime());
            _direction = transform.right;
        }

        private void Update()
        {
            transform.Translate(_direction * speed * Time.deltaTime);
        }

        private IEnumerator DestroyAfterTime()
        {
            yield return new WaitForSeconds(lifeTime);
            Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Player") && !is_friendly)
            {
                var direction = collision.transform.position - transform.position;
                onPlayerHit?.Invoke(damage, knockback, direction);
                Destroy(gameObject);
            }
            else if (collision.collider.CompareTag("Enemy") && is_friendly)
            {
                var direction = collision.transform.position - transform.position;
                onEnemyHit?.Invoke(damage, knockback, direction);
                Destroy(gameObject);
            }
            else if (collision.collider.CompareTag("Boarder"))
            {
                Destroy(gameObject);
            }
        }
    }
}