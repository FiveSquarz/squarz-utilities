using UnityEngine;

namespace SquarzUtilities.Unity {
    public static class UnityUtils {

        public static string GetPath(Transform current) {
            if (current.parent == null)
                return "/" + current.name;
            return GetPath(current.parent) + "/" + current.name;
        }

        public static Transform FindTransform(Transform parent, string name) {
            foreach (Transform transform in parent.GetComponentsInChildren<Transform>()) {
                if (transform.name == name) return transform;
            }
            return null;
        }

        public static Vector2 RotateVector2(Vector2 original, float radians)
        {
            return new Vector2(original.x * Mathf.Cos(radians) - original.y * Mathf.Sin(radians), original.x * Mathf.Sin(radians) + original.y * Mathf.Cos(radians));
        }

        public static float AngleBetween(Vector3 a, Vector3 b)
        {
            return Mathf.Acos(Vector3.Dot(a, b) / (a.magnitude * b.magnitude));
        }

        public static bool LayerMaskContains(LayerMask mask, int layer)
        {
            return mask == (mask | (1 << layer));
        }
    }
}