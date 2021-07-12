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

            damageable.CurrentHealth = 100;
            damageable.ScriptableElement = (ScriptableElement) ScriptableObject.CreateInstance("ScriptableElement");
            damageable.ScriptableElement.Element = ElementGenerator.GetFireElement;

            damageable.TakeDamage(10, ElementGenerator.GetWaterElement);

            Assert.AreEqual(85, damageable.CurrentHealth);
        }
    }
}