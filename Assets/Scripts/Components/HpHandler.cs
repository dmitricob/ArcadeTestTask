using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace Assets.Scripts.Components
{
    [RequireComponent(typeof(Character))]
    public abstract class HpHandler : MonoBehaviour
    {
        public HpBarController hpBarController;

        public Character character;


        private void Start()
        {
            CharacterFinder();
            HpBarFinder();

            character.onDamaged += OnDamged;

            hpBarController.SetMaxHp(character.maxHp);

            if (!hpBarController)
                Debug.Log(gameObject + " havent hpbar");

        }

        // liskov crying
        public abstract void CharacterFinder();
        public abstract void HpBarFinder();

        public void OnDamged()
        {
            hpBarController.SetHp(character.GetHp);
        }
    }
}
