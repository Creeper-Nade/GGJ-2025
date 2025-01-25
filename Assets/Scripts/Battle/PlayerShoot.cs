using UnityEngine;

namespace AmpFC.Battle
{
    public class PlayerShoot : MonoBehaviour {
        public float chargingTime = 1f;

        // charge is a value between 0 and 1, 
        // where 0 is no charge and 1 is full charge
        public float currentCharge {get; private set;} = 0f;

        public bool isCharging = false;

        public Projectile bulletPrefab;
        public Transform bulletSpawn;

        public void Update() {
            if (isCharging) {
                currentCharge += Time.deltaTime * 1f / chargingTime;
            }
            if (currentCharge >= 1f) {
                Shoot();
                currentCharge = 0f;
            }
        }

        public void Shoot() {
            
        }
    }
}