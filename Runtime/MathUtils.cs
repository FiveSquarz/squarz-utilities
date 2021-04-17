using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SquarzUtilities.MathUtilities {
    public static class MathUtils {
        public static int Mod(int x, int m) {
            return (x %= m) < 0 ? x + m : x;
        }

        public static float Mod(float a, float b) {
            return a - b * Mathf.Floor(a / b);
        }
    }
}