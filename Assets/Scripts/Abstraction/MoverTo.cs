using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{

    [RequireComponent(typeof(IMoveable))]
    public abstract class MoverTo : MonoBehaviour, IMoverTo
    {
        public float speed = 10;
        private Vector3 targetPosition;
        public Action OnArrive;
        

        private IMoveable moveable;
        private float positiongBias = 0.1f;


        private bool isMoveAllowed;
        public bool IsMoveAllowed => isMoveAllowed;



        private void Start()
        {
            moveable = GetComponent<IMoveable>();

            if (moveable == null)
                Debug.LogError(gameObject +" no moveable");
        }

        protected void TryToMove()
        {
            if (isMoveAllowed)
            {
                if (IsCame)
                {
                    EndMove();
                    return;
                }
                //transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);

                //step equal 1 * deltaTime
                Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime);

                Vector3 direction = newPosition - transform.position;
                moveable.Move(direction);
            }
        }

        /// <summary>
        /// begin move to target position
        /// </summary>
        /// <param name="targetPosition"></param>
        public void MoveTo(Vector3 targetPosition)
        {
            this.targetPosition = targetPosition;
            this.StartMove();
        }

        public void StartMove()
        {
            isMoveAllowed = true;
        }
        public void StopMove()
        {
            isMoveAllowed = false;
        }

        public void EndMove()
        {
            isMoveAllowed = false;
            OnArrive?.Invoke();
            this.targetPosition = default(Vector3);
        }

        private bool IsCame => Vector3.Distance(transform.position, targetPosition) < positiongBias;
    }
}
