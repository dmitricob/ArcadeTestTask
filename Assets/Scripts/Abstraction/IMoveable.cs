using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    interface IMoveable
    {
        /// <summary>
        /// move on specified direction (motion) with seted speed (speed)
        /// </summary>
        /// <param name="dir"> must be normalized for update move direction</param>
        void Move(Vector3 dir);
    }
}
