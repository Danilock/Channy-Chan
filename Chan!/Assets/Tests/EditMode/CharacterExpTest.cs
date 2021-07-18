using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Game;

namespace Tests
{
    public class CharacterExpTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void CharacterExpTestSimplePasses()
        {
            ScriptableCharacterProfile loganProfile = ScriptableCharacterCreator.CreateCharacterProfile(
                "Logan",
                10,
                100,
                ElementGenerator.GetFireElement,
                "Test Description"
                );

            Character instance = new Character();

            instance.CharacterEXP.GainExp(250f);

            Assert.AreEqual(3, instance.CharacterEXP.CurrentLevel);
        }
    }
}