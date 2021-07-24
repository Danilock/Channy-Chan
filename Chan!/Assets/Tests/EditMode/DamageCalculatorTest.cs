using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Game;

namespace Tests
{
    public class DamageCalculatorTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void DamageCalculatorTestSimplePasses()
        {
            GameObject obj = new GameObject("Obj");

            DamageableComponent damageable = obj.AddComponent<DamageableComponent>();

            damageable.SetHealth(100);
            damageable.Element = ElementGenerator.GetFireElement;
            damageable.Team = DamageableTeam.Enemy;

            DamageDealer dealer;
            dealer.Team = DamageableTeam.PlayerFriendly;
            dealer.Element = ElementGenerator.GetWaterElement;

            damageable.TakeDamage(10, dealer);

            Assert.AreEqual(85, damageable.CurrentHealth);
        }
    }
}