using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class RandomGenerator
    {

        public Vector2 leftBotBounding  { get; private set; }
        public Vector2 rightTopBounding { get; private set; }
        public float MinOffset { get; private set; }
        public float MaxOffset { get; private set; }

        public RandomGenerator(Vector2 leftBotBounding, Vector2 rightTopBounding, float minOffset, float maxOffset)
        {
            this.leftBotBounding = leftBotBounding;
            this.rightTopBounding = rightTopBounding;
            MinOffset = minOffset;
            MaxOffset = maxOffset;
        }

        public Vector3 GetRandomPosition(Vector3 currentPosition)
        {
            var offset = new Vector3(
                GetcorrespondingRandomOffset(),
                0,
                GetcorrespondingRandomOffset());

            var newPosition = currentPosition + offset;

            float xs = GetSight(leftBotBounding.x, rightTopBounding.x, newPosition.x);
            float zs = GetSight(leftBotBounding.y, rightTopBounding.y, newPosition.z);

            newPosition += new Vector3(xs * offset.x * 2, 0, zs * offset.z * 2);

            return newPosition;
        }

        private float GetSight(float min, float max, float value)
        {
            if (value < min || value > max)
                return -1;
            return 0;
        }

        private float GetcorrespondingRandomOffset()
        {
            float offset = UnityEngine.Random.Range(-MaxOffset + MinOffset, MaxOffset - MinOffset);

            float sign = offset / Mathf.Abs(offset);
            offset += sign * MinOffset;

            return offset;
        }

    }
}
