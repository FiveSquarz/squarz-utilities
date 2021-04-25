using System.Collections.Generic;
using System;

namespace SquarzUtilities.Maths {
    public static class Tweens {

        public enum Direction { In, Out, InOut }
        public enum Style { Linear, Sine, Quad, Cubic, Quart, Quint, Expo, Circ, Back, Elastic, Bounce }

        public static double GetValue(double raw, Direction direction, Style style) {
            return functions[direction.ToString() + style.ToString()](raw);
        }

        public static float GetValue(float raw, Direction direction, Style style) {
            return (float)GetValue((double)raw, direction, style);
        }

        static readonly Dictionary<string, Func<double, double>> functions = new Dictionary<string, Func<double, double>>() {
            {"InSine", x => 1d - Math.Cos(x * Math.PI / 2d)},
            {"OutSine", x => Math.Sin(x * Math.PI / 2d)},
            {"InOutSine", x => -(Math.Cos(Math.PI * x) - 1d) / 2d},

            {"InQuad", x => x * x},
            {"OutQuad", x => 1d - (1d - x) * (1d - x)},
            {"InOutQuad", x => x < 0.5d ? 2d * x * x : 1d - Math.Pow(-2d * x + 2d, 2d) / 2d},

            {"InCubic", x =>  x * x * x},
            {"OutCubic", x => 1d - Math.Pow(1d - x, 3d)},
            {"InOutCubic", x => x < 0.5d ? 4d * x * x * x : 1d - Math.Pow(-2d * x + 2d, 3d) / 2d},

            {"InQuart", x => x * x * x * x},
            {"OutQuart", x => 1d - Math.Pow(1d - x, 4d)},
            {"InOutQuart", x => x < 0.5d ? 8d * x * x * x * x : 1d - Math.Pow(-2d * x + 2d, 4d) / 2d},

            {"InQuint", x => x * x * x * x * x},
            {"OutQuint", x => 1d - Math.Pow(1d - x, 5d)},
            {"InOutQuint", x => x < 0.5d ? 16d * x * x * x * x * x : 1d - Math.Pow(-2d * x + 2d, 5d) / 2d},

            {"InExpo", x => x == 0d ? 0d : Math.Pow(2d, 10d * x - 10d)},
            {"OutExpo", x => x == 1d ? 1d : 1d - Math.Pow(2d, -10d * x)},
            {"InOutExpo", x => x == 0d ? 0d : x == 1d ? 1d : x < 0.5d ? Math.Pow(2d, 20d * x - 10d) / 2d : (2d - Math.Pow(2d, -20d * x + 10d)) / 2d},

            {"InCirc", x => 1d - Math.Sqrt(1d - Math.Pow(x, 2d))},
            {"OutCirc", x => Math.Sqrt(1d - Math.Pow(x - 1d, 2d))},
            {"InOutCirc", x => x < 0.5d ? (1d - Math.Sqrt(1d - Math.Pow(2d * x, 2d))) / 2d : (Math.Sqrt(1d - Math.Pow(-2d * x + 2d, 2d)) + 1d) / 2d},

            {"InBack", x => 2.70158d * x * x * x - 1.70158d * x * x},
            {"OutBack", x => 1d + 2.70158d * Math.Pow(x - 1d, 3d) + 1.70158d * Math.Pow(x - 1d, 2d)},
            {"InOutBack", x => x < 0.5d ? Math.Pow(2d * x, 2d) * (3.5949095d * 2d * x - 2.5949095d) / 2d : (Math.Pow(2d * x - 2d, 2d) * (3.5949095d * (x * 2d - 2d) + 2.5949095d) + 2d) / 2d},

            {"InElastic", x => x == 0d ? 0d : x == 1d ? 1d : -Math.Pow(2d, 10d * x - 10d) * Math.Sin((x * 10d - 10.75d) * 2d * Math.PI / 3d)},
            {"OutElastic", x => x == 0d ? 0d : x == 1d ? 1d : Math.Pow(2d, -10d * x) * Math.Sin((x * 10d - 0.75d) * 2d * Math.PI / 3d) + 1d},
            {"InOutElastic", x => x == 0d ? 0d : x == 1d ? 1d : x < 0.5d ? -Math.Pow(2d, 20d * x - 10d) * Math.Sin((20d * x - 11.125d) * 2d * Math.PI / 4.5d) / 2d : Math.Pow(2d, -20d * x + 10d) * Math.Sin((20d * x - 11.125d) * 2d * Math.PI / 4.5d) / 2d + 1d},

            {"InBounce", x => 1d - functions["OutBounce"](1d - x)},
            {"OutBounce", x => x < 1d / 2.75d ? 7.5625d * x * x : x < 2d / 2.75d ? 7.5625d * (x -= 1.5d / 2.75d) * x + 0.75d : x < 2.5d / 2.75d ? 7.5625d * (x -= 2.25d / 2.75d) * x + 0.9375d : 7.5625d * (x -= 2.625d / 2.75d) * x + 0.984375d},
            {"InOutBounce", x => x < 0.5d ? (1d - functions["OutBounce"](1d - 2d * x)) / 2d : (1d + functions["OutBounce"](2d * x - 1d)) / 2d}
        };
    }
}