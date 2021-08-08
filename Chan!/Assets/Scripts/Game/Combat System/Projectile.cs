using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Projectile : MonoBehaviour
    {
        public int Damage;
        public DamageableTeam Team;

        private void Start()
        {
            StartCoroutine(DesactivateProjectile_Coroutune());
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {

        }

        private IEnumerator DesactivateProjectile_Coroutune()
        {
            yield return new WaitForSeconds(3f);
            gameObject.SetActive(false);
        }
    }
}