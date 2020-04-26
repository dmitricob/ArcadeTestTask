using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace Assets.Scripts.Components
{
    [RequireComponent(typeof(Character))]
    class HpHandler : MonoBehaviour
    {
        public HpBarController hpBarController;

        public Character character;


        private void Start()
        {
            character = GetComponent<Character>();

            character.onDamaged += OnDamged;

            if (!hpBarController)
                hpBarController = GetComponent<HpBarController>();
            hpBarController.SetMaxHp(character.maxHp);

            if (!hpBarController)
                Debug.Log(gameObject + " havent hpbar");

        }

        public void OnDamged()
        {
            hpBarController.SetHp(character.GetHp);
        }
    }
}
