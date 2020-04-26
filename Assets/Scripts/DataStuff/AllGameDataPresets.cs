using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
