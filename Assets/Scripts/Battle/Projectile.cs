using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmpFC.Battle
{
    public class Projectile : MonoBehaviour
    {
        public float speed;
        private Vector2 _direction;
        public float lifeTime = 10;
        public float damage;
        public float range;
        public float knockback;

        private void Start()
        {
            StartCoroutine(DestroyAfterTime());
            _direction = transform.forward;
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
                //[TODO]: Apply knockback and damage to player
                Destroy(gameObject);
            }
        }
    }
}