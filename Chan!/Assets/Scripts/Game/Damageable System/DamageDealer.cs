using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public struct DamageDealer
    {
        public Element Element;
        public DamageableTeam Team;

        public void SetupDealer(DamageableComponent dmg)
        {
            Element = dmg.Element;
            Team = dmg.Team;
        }
    }

    public class DamageDealerGenerator
    {
        /// <summary>
        /// Generates a Dealer entity struct based on the damageable passed as a parameter.
        /// </summary>
        /// <param name="dmg"></param>
        /// <returns></returns>
        public static DamageDealer GenerateDealer(DamageableComponent dmg)
        {
            DamageDealer dealer;
            dealer.Team = dmg.Team;
            dealer.Element = dmg.Element;

            return dealer;
        }
    }
}