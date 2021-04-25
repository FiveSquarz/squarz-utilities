namespace SquarzUtilities.Maths {
    public static class MathUtils {

        public static int Mod(int x, int m) {
            return (x %= m) < 0 ? x + m : x;
        }

        public static float Mod(float x, float m) {
            return (x %= m) < 0f ? x + m : x;
        }

        public static double Mod(double x, double m) {
            return (x %= m) < 0d ? x + m : x;
        }
    }
}