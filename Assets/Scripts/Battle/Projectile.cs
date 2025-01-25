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

        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.CompareTag("Player"))
            {
                var direction = collision.transform.position - transform.position;
                onPlayerHit?.Invoke(damage, knockback, direction);
                Destroy(gameObject);
            }
            else if (collision.CompareTag("Enemy"))
            {
                var direction = collision.transform.position - transform.position;
                onEnemyHit?.Invoke(damage, knockback, direction);
                Destroy(gameObject);
            }
        }
    }
}