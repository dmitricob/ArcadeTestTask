using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    interface IMoverTo
    {
        void MoveTo(Vector3 Traget);
        void StartMove();
        void StopMove();
    }
}
