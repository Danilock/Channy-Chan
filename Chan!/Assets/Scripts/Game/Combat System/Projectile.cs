using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Projectile : MonoBehaviour
    {
        public int Damage;
        public DamageableTeam Team;
        private Rigidbody2D _rgb;

        public Vector2 Direction;

        private void Awake()
        {
            _rgb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            StartCoroutine(DesactivateProjectile_Coroutune());

            _rgb.AddForce(Direction * 30f, ForceMode2D.Impulse);
        }

        private IEnumerator DesactivateProjectile_Coroutune()
        {
            yield return new WaitForSeconds(3f);
            gameObject.SetActive(false);
        }
    }
}