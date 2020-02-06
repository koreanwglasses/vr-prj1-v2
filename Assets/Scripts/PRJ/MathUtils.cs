using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class MathUtils
{
    public static void OLS(IEnumerable<float> xs, IEnumerable<float> ys, out float a, out float b)
    {
        if(xs.Count() != ys.Count())
        {
            throw new System.Exception("lengths of input arrays do not match");
        }

        int n = xs.Count();

        float sumX = xs.Sum();
        float sumY = ys.Sum();
        float sumX2 = xs.Select(x => x * x).Sum();
        float sumXY = Enumerable.Zip(xs, ys, (x, y) => x * y).Sum();

        a = (n * sumXY - sumX * sumY) / (n * sumX2 - sumX * sumX);
        b = (sumY - a * sumX) / n;
    }

    public static void OLS(IEnumerable<float> xs, IEnumerable<Vector3> ys, out Vector3 a, out Vector3 b)
    {
        if(xs.Count() != ys.Count())
        {
            throw new System.Exception("lengths of input arrays do not match");
        }

        a = new Vector3();
        b = new Vector3();

        OLS(xs, ys.Select(y => y.x), out a.x, out b.x);
        OLS(xs, ys.Select(y => y.y), out a.y, out b.y);
        OLS(xs, ys.Select(y => y.z), out a.z, out b.z);
    }
}