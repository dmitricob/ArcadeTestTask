using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.DataStuff
{
    [Serializable]
    public class AllGameDataPresets
    {
        public float playerHp;
        public float playerSpeed;
        public float playerFireRate;
        
        public float groundEnemyHp;
        public float groundEnemySpeed;
        
        public float airEnemyHp;
        public float airEnemySpeed;
        
        public float bossEnemyHp;
        public float bossEnemySpeed;
        
        public float bulletDamage;
        public float bulletSpeed;
        
        public float touchDamage;

        public AllGameDataPresets(float playerHp, float playerSpeed, float playerFireRate, float groundEnemyHp, float groundEnemySpeed, float airEnemyHp, float airEnemySpeed, float bossEnemyHp, float bossEnemySpeed, float bulletDamage, float bulletSpeed, float touchDamage)
        {
            this.playerHp           = playerHp;
            this.playerSpeed        = playerSpeed;
            this.playerFireRate     = playerFireRate;
            this.groundEnemyHp      = groundEnemyHp;
            this.groundEnemySpeed   = groundEnemySpeed;
            this.airEnemyHp         = airEnemyHp;
            this.airEnemySpeed      = airEnemySpeed;
            this.bossEnemyHp        = bossEnemyHp;
            this.bossEnemySpeed     = bossEnemySpeed;
            this.bulletDamage       = bulletDamage;
            this.bulletSpeed        = bulletSpeed;
            this.touchDamage        = touchDamage;
        }

        public void SetHeroValues(GameObject hero)
        {
            SetPlayerCharacter(hero.GetComponent<Character>());
            SetShooter(hero.GetComponent<Shooter>());
        }
        
        public void SetGroundEnemyValues(GameObject enemy)
        {
            SetGroundEnemyCharacter(enemy.GetComponent<Character>());
            SetTouchDamager(enemy.GetComponent<TouchDamager>());
        }
        public void SetAirEnemyValues(GameObject enemy)
        {
            SetAirEnemyCharacter(enemy.GetComponent<Character>());
            SetShooter(enemy.GetComponent<Shooter>());
        }
        public void SetBossValues(GameObject boss)
        {
            SetBossCharacter(boss.GetComponent<Character>());
            SetShooter(boss.GetComponent<Shooter>());
            SetTouchDamager(boss.GetComponent<TouchDamager>());
        }

        public void SetPlayerCharacter(Character character)
        {
            character.maxHp = playerHp;
            character.speed = playerSpeed;
        }
        public void SetGroundEnemyCharacter(Character character)
        {
            character.maxHp = groundEnemyHp;
            character.speed = groundEnemySpeed;
        }
        public void SetAirEnemyCharacter(Character character)
        {
            character.maxHp = airEnemyHp;
            character.speed = airEnemySpeed;
        }
        public void SetBossCharacter(Character character)
        {
            character.maxHp = bossEnemyHp;
            character.speed = bossEnemySpeed;
        }

        public void SetShooter(Shooter shooter)
        {
            shooter.fireRate = playerFireRate;
            shooter.damage = bulletDamage;
            shooter.bulletSpeed = bulletSpeed;
        }
        public void SetTouchDamager(TouchDamager tdm)
        {
            tdm.damage = touchDamage;
        }
    }
}
