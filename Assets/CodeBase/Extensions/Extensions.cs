using UnityEngine;

namespace CodeBase.Extensions
{
    public static class Extensions
    {
        #region Vector3

        public static Vector3 RandomPointInAnnulus(this Vector3 origin, float minRadius, float maxRadius)
        {
            var angle = Random.value * Mathf.PI * 2f;
            var direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            var minRadiusSquared = minRadius * minRadius;
            var maxRadiusSquared = maxRadius * maxRadius;
            var distance = Mathf.Sqrt(Random.value * (maxRadiusSquared - minRadiusSquared) + minRadiusSquared);

            var position = new Vector3(direction.x, 0, direction.y) * distance;
            return origin + position;
        }

        #endregion

        #region Color

        public static Color WithAlpha(this Color color, float alpha) =>
            new Color(color.r, color.g, color.b, alpha);

        #endregion
    }
}
