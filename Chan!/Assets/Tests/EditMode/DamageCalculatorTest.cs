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
            Damageable damageable = new Damageable();

            damageable.CurrentHealth = 100f;
            damageable.Element = ElementGenerator.GenerateFireElement;

            damageable.TakeDamage(10f, ElementGenerator.GenerateWaterElement);

            Assert.AreEqual(85f, damageable.CurrentHealth);
        }
    }
}