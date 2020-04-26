using Assets.Scripts.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Components
{
    public class PlayerHpHandler : HpHandler
    {
        public override void CharacterFinder()
        {
            character = FindObjectOfType<HeroCharacter>();
        }

        public override void HpBarFinder()
        {
            var hpBars = FindObjectsOfType<HpBarController>();
            foreach (var item in hpBars)
            {
                if (item.CompareTag("PlayerStuff"))
                {
                    hpBarController = item;
                    break;
                }
            }
        }
    }
}
