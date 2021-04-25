using System;

namespace SquarzUtilities.Maths {
    public static class PerlinNoise {

        static readonly int[] p = {
            151,160,137,91,90,15,131,13,201,95,96,53,194,233,7,225,140,36,
            103,30,69,142,8,99,37,240,21,10,23,190,6,148,247,120,234,75,0,
            26,197,62,94,252,219,203,117,35,11,32,57,177,33,88,237,149,56,
            87,174,20,125,136,171,168, 68,175,74,165,71,134,139,48,27,166,
            77,146,158,231,83,111,229,122,60,211,133,230,220,105,92,41,55,
            46,245,40,244,102,143,54, 65,25,63,161,1,216,80,73,209,76,132,
            187,208, 89,18,169,200,196,135,130,116,188,159,86,164,100,109,
            198,173,186, 3,64,52,217,226,250,124,123,5,202,38,147,118,126,
            255,82,85,212,207,206,59,227,47,16,58,17,182,189,28,42,223,183,
            170,213,119,248,152, 2,44,154,163, 70,221,153,101,155,167, 43,
            172,9,129,22,39,253, 19,98,108,110,79,113,224,232,178,185,112,
            104,218,246,97,228,251,34,242,193,238,210,144,12,191,179,162,
            241, 81,51,145,235,249,14,239,107,49,192,214, 31,181,199,106,
            157,184, 84,204,176,115,121,50,45,127, 4,150,254,138,236,205,
            93,222,114,67,29,24,72,243,141,128,195,78,66,215,61,156,180,

            151,160,137,91,90,15,131,13,201,95,96,53,194,233,7,225,140,36,
            103,30,69,142,8,99,37,240,21,10,23,190,6,148,247,120,234,75,0,
            26,197,62,94,252,219,203,117,35,11,32,57,177,33,88,237,149,56,
            87,174,20,125,136,171,168, 68,175,74,165,71,134,139,48,27,166,
            77,146,158,231,83,111,229,122,60,211,133,230,220,105,92,41,55,
            46,245,40,244,102,143,54, 65,25,63,161,1,216,80,73,209,76,132,
            187,208, 89,18,169,200,196,135,130,116,188,159,86,164,100,109,
            198,173,186, 3,64,52,217,226,250,124,123,5,202,38,147,118,126,
            255,82,85,212,207,206,59,227,47,16,58,17,182,189,28,42,223,183,
            170,213,119,248,152, 2,44,154,163, 70,221,153,101,155,167, 43,
            172,9,129,22,39,253, 19,98,108,110,79,113,224,232,178,185,112,
            104,218,246,97,228,251,34,242,193,238,210,144,12,191,179,162,
            241, 81,51,145,235,249,14,239,107,49,192,214, 31,181,199,106,
            157,184, 84,204,176,115,121,50,45,127, 4,150,254,138,236,205,
            93,222,114,67,29,24,72,243,141,128,195,78,66,215,61,156,180
        };

        static double Fade(double x) {
            return 6d * Math.Pow(x, 5d) - 15d * Math.Pow(x, 4d) + 10d * Math.Pow(x, 3d);
  
        }

        static double Lerp(double a, double b, double t) {
            return a + (b - a) * t;
        }

        static double Grad1D(int hash, double x) {
            if (hash % 2 == 0) return x;
            else return -x;
        }

        public static double Noise1D(double x) {
            int xi = MathUtils.Mod((int)Math.Floor(x), 256);
            double xf = MathUtils.Mod(x, 1d);

            return Lerp(Grad1D(p[xi], xf), Grad1D(p[xi + 1], xf - 1d), Fade(xf));
        }

        static double Grad2D(int hash, double x, double y) {
            switch(hash % 4) {
                case 0:
                    return x + y;
                case 1:
                    return x - y;
                case 2:
                    return -x + y;
                default:
                    return -x - y;
            }
        }

        public static double Noise2D(double x, double y) {
            int xi = MathUtils.Mod((int)Math.Floor(x), 256);
            int yi = MathUtils.Mod((int)Math.Floor(y), 256);

            double xf = MathUtils.Mod(x, 1d);
            double yf = MathUtils.Mod(y, 1d);

            double v = Fade(xf);

            int aa = p[p[xi    ] + yi    ];
            int ab = p[p[xi    ] + yi + 1];
            int ba = p[p[xi + 1] + yi    ];
            int bb = p[p[xi + 1] + yi + 1];

            double x1 = Lerp(Grad2D(aa, xf, yf     ), Grad2D(ba, xf - 1d, yf     ), v);
            double x2 = Lerp(Grad2D(ab, xf, yf - 1d), Grad2D(bb, xf - 1d, yf - 1d), v);

            return Lerp(x1, x2, Fade(yf));
        }

        static double Grad3D(int hash, double x, double y, double z) {
            switch (hash % 12) {
                case 0:
                    return x + y;
                case 1:
                    return -x + y;
                case 2:
                    return x - y;
                case 3:
                    return -x - y;
                case 4:
                    return x + z;
                case 5:
                    return -x + z;
                case 6:
                    return x - z;
                case 7:
                    return -x - z;
                case 8:
                    return y + z;
                case 9:
                    return -y + z;
                case 10:
                    return y - z;
                default:
                    return -y - z;
            }
        }

        public static double Noise3D(double x, double y, double z) {
            int xi = MathUtils.Mod((int)Math.Floor(x), 256);
            int yi = MathUtils.Mod((int)Math.Floor(y), 256);
            int zi = MathUtils.Mod((int)Math.Floor(z), 256);

            double xf = MathUtils.Mod(x, 1d);
            double yf = MathUtils.Mod(y, 1d);
            double zf = MathUtils.Mod(z, 1d);

            double u = Fade(xf);
            double v = Fade(yf);

            int aaa = p[p[p[xi    ] + yi    ] + zi    ];
            int aba = p[p[p[xi    ] + yi + 1] + zi    ];
            int aab = p[p[p[xi    ] + yi    ] + zi + 1];
            int abb = p[p[p[xi    ] + yi + 1] + zi + 1];
            int baa = p[p[p[xi + 1] + yi    ] + zi    ];
            int bba = p[p[p[xi + 1] + yi + 1] + zi    ];
            int bab = p[p[p[xi + 1] + yi    ] + zi + 1];
            int bbb = p[p[p[xi + 1] + yi + 1] + zi + 1];

            double x1 = Lerp(Grad3D(aaa, xf, yf     , zf     ), Grad3D(baa, xf - 1d, yf     , zf     ), u);
            double x2 = Lerp(Grad3D(aba, xf, yf - 1d, zf     ), Grad3D(bba, xf - 1d, yf - 1d, zf     ), u);
            double x3 = Lerp(Grad3D(aab, xf, yf     , zf - 1d), Grad3D(bab, xf - 1d, yf     , zf - 1d), u);
            double x4 = Lerp(Grad3D(abb, xf, yf - 1d, zf - 1d), Grad3D(bbb, xf - 1d, yf - 1d, zf - 1d), u);

            double y1 = Lerp(x1, x2, v);
            double y2 = Lerp(x3, x4, v);

            return Lerp(y1, y2, Fade(zf));
        }

        static double Grad4D(int hash, double x, double y, double z, double w) {
            switch (hash % 24) {
                case 0:
                    return x + y + z;
                case 1:
                    return x + y - z;
                case 2:
                    return x - y - z;
                case 3:
                    return -x - y - z;
                case 4:
                    return -x - y + z;
                case 5:
                    return -x + y + z;
                case 6:
                    return x - y + z;
                case 7:
                    return -x + y - z;
                case 8:
                    return x + y + w;
                case 9:
                    return x + y - w;
                case 10:
                    return x - y - w;
                case 11:
                    return -x - y - w;
                case 12:
                    return -x - y + w;
                case 13:
                    return -x + y + w;
                case 14:
                    return x - y + w;
                case 15:
                    return -x + y - w;
                case 16:
                    return x + w + z;
                case 17:
                    return x + w - z;
                case 18:
                    return x - w - z;
                case 19:
                    return -x - w - z;
                case 20:
                    return -x - w + z;
                case 21:
                    return -x + w + z;
                case 22:
                    return x - w + z;
                case 23:
                    return -x + w - z;
                case 24:
                    return w + y + z;
                case 25:
                    return w + y - z;
                case 26:
                    return w - y - z;
                case 27:
                    return -w - y - z;
                case 28:
                    return -w - y + z;
                case 29:
                    return -w + y + z;
                case 30:
                    return w - y + z;
                default:
                    return -w + y - z;
            }
        }

        public static double Noise4D(double x, double y, double z, double w) {
            int xi = MathUtils.Mod((int)Math.Floor(x), 256);
            int yi = MathUtils.Mod((int)Math.Floor(y), 256);
            int zi = MathUtils.Mod((int)Math.Floor(z), 256);
            int wi = MathUtils.Mod((int)Math.Floor(w), 256);

            double xf = MathUtils.Mod(x, 1d);
            double yf = MathUtils.Mod(y, 1d);
            double zf = MathUtils.Mod(z, 1d);
            double wf = MathUtils.Mod(w, 1d);

            double s = Fade(xf);
            double t = Fade(yf);
            double u = Fade(zf);

            int aaaa = p[p[p[p[xi    ] + yi    ] + zi    ] + wi    ];
            int abaa = p[p[p[p[xi    ] + yi + 1] + zi    ] + wi    ];
            int aaba = p[p[p[p[xi    ] + yi    ] + zi + 1] + wi    ];
            int abba = p[p[p[p[xi    ] + yi + 1] + zi + 1] + wi    ];
            int aaab = p[p[p[p[xi    ] + yi    ] + zi    ] + wi + 1];
            int abab = p[p[p[p[xi    ] + yi + 1] + zi    ] + wi + 1];
            int aabb = p[p[p[p[xi    ] + yi    ] + zi + 1] + wi + 1];
            int abbb = p[p[p[p[xi    ] + yi + 1] + zi + 1] + wi + 1];
            int baaa = p[p[p[p[xi + 1] + yi    ] + zi    ] + wi    ];
            int bbaa = p[p[p[p[xi + 1] + yi + 1] + zi    ] + wi    ];
            int baba = p[p[p[p[xi + 1] + yi    ] + zi + 1] + wi    ];
            int bbba = p[p[p[p[xi + 1] + yi + 1] + zi + 1] + wi    ];
            int baab = p[p[p[p[xi + 1] + yi    ] + zi    ] + wi + 1];
            int bbab = p[p[p[p[xi + 1] + yi + 1] + zi    ] + wi + 1];
            int babb = p[p[p[p[xi + 1] + yi    ] + zi + 1] + wi + 1];
            int bbbb = p[p[p[p[xi + 1] + yi + 1] + zi + 1] + wi + 1];

            double x1 = Lerp(Grad4D(aaaa, xf, yf     , zf     , wf     ), Grad4D(baaa, xf - 1d, yf     , zf     , wf     ), s);
            double x2 = Lerp(Grad4D(abaa, xf, yf - 1d, zf     , wf     ), Grad4D(bbaa, xf - 1d, yf - 1d, zf     , wf     ), s);
            double x3 = Lerp(Grad4D(aaba, xf, yf     , zf - 1d, wf     ), Grad4D(baba, xf - 1d, yf     , zf - 1d, wf     ), s);
            double x4 = Lerp(Grad4D(abba, xf, yf - 1d, zf - 1d, wf     ), Grad4D(bbba, xf - 1d, yf - 1d, zf - 1d, wf     ), s);
            double x5 = Lerp(Grad4D(aaab, xf, yf     , zf     , wf - 1d), Grad4D(baab, xf - 1d, yf     , zf     , wf - 1d), s);
            double x6 = Lerp(Grad4D(abab, xf, yf - 1d, zf     , wf - 1d), Grad4D(bbab, xf - 1d, yf - 1d, zf     , wf - 1d), s);
            double x7 = Lerp(Grad4D(aabb, xf, yf     , zf - 1d, wf - 1d), Grad4D(babb, xf - 1d, yf     , zf - 1d, wf - 1d), s);
            double x8 = Lerp(Grad4D(abbb, xf, yf - 1d, zf - 1d, wf - 1d), Grad4D(bbbb, xf - 1d, yf - 1d, zf - 1d, wf - 1d), s);

            double y1 = Lerp(x1, x2, t);
            double y2 = Lerp(x3, x4, t);
            double y3 = Lerp(x5, x6, t);
            double y4 = Lerp(x7, x8, t);

            double z1 = Lerp(y1, y2, u);
            double z2 = Lerp(y3, y4, u);

            return Lerp(z1, z2, Fade(wf));
        }
    }
}