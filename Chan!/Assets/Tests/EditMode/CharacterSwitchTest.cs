using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Game;
namespace Tests
{
    public class CharacterSwitchTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void CharacterSwitchTestSimplePasses()
        {
            ScriptableCharacterProfile loganProfile = ScriptableCharacterCreator.CreateCharacterProfile(
                "Logan",
                10,
                100,
                ElementGenerator.GetFireElement,
                "Test Description"
                );

            ScriptableCharacterProfile ryanProfile = ScriptableCharacterCreator.CreateCharacterProfile(
                "Ryan",
                20,
                200,
                ElementGenerator.GetWaterElement,
                "Test Description"
                );

            Character loganInstance = new Character();
            Character ryanInstance = new Character();

            GameObject obj = new GameObject("MyObj");
            CharacterHandler chHandler = obj.AddComponent<CharacterHandler>();

            chHandler.AddCharacter(loganInstance);
            chHandler.AddCharacter(ryanInstance);

            chHandler.ChangeCharacter(1);

            Assert.AreEqual(ElementTypes.Water, chHandler.CurrentCharacter.Element);
        }
    }
}

public class ScriptableCharacterCreator{
    
    public static ScriptableCharacterProfile CreateCharacterProfile(string name, int baseDamage, int baseHealth, Element element, string description)
    {
        ScriptableCharacterProfile character = (ScriptableCharacterProfile)ScriptableObject.CreateInstance("ScriptableCharacterProfile");

        character.Name = name;
        character.Portrait = null;
        character.BaseDamage = baseDamage;
        character.BaseHealth = baseHealth;
        character.ScriptableElement.Element = element;
        character.Description = description;

        return character;
    }
}