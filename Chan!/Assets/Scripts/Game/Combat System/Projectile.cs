using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Projectile : MonoBehaviour
    {
        public int Damage;
        public DamageableTeam Team;

        private void OnCollisionEnter2D(Collision2D collision)
        {

        }
    }
}