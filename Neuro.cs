using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
internal class Neuro
{
    public Neuro()
    {
        computeWeights();
    }

    private void rotate(int to, ref float[,,] w, int from, in float[,,] p)
    {
        for (int i = 0; i < w.GetLength(1); i++)
            for (int j = 0; j < w.GetLength(2); j++)
            {
                w[to, j, i] = p[from, w.GetLength(1) - 1 - i, j];
            }
    }

    private void copy(int to, ref float[,,] w, int from, in float[,,] p)
    {
        for (int i = 0; i < w.GetLength(1); i++)
            for (int j = 0; j < w.GetLength(2); j++)
            {
                w[to, j, i] = p[from, j, i];
            }
    }

    public float[,,] w = new float[8, 3, 3];
    public void computeWeights()
    {
        float[,,] p = {
            {
                {  -0.1f, -2, -0.1f},
                {   1,     0,  1},
                {   0.1f,  2,  0.1f}
            },
            {
                {  0,   -1, -0.3f },
                {  1,    0, -1 },
                {  0.3f, 1, 0 }
            },
        };

        copy(0, ref w, 0, p);
        copy(1, ref w, 1, p);
        rotate(2, ref w, 0, p);
        rotate(3, ref w, 1, p);
        rotate(4, ref w, 2, w);
        rotate(5, ref w, 3, w);
        rotate(6, ref w, 4, w);
        rotate(7, ref w, 5, w);
    }

    public float evaluate(int[,] a, int k)
    {
        Debug.Assert(w.GetLongLength(1) == a.GetLength(0));
        Debug.Assert(w.GetLongLength(2) == a.GetLength(1));
        float r = 0;
        for (int i = 0; i < w.GetLength(1); i++)
            for (int j = 0; j < w.GetLength(2); j++)
            {
                var x = (i == j) ? 1 : a[i, j];
                r += w[k, i, j] * x;
            }
        return r;
    }

    public float[] evaluate(int[,] a)
    {
        var r = new float[w.GetLength(0)];
        for (int k = 0; k < w.GetLength(0); k++)
        {
            r[k] = evaluate(a, k);
        }
        return r;
    }

    public static int argmax(float[] a)
    {
        float EPSILON = 1e-4f;

        int n = -1;
        float m = float.NegativeInfinity;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] > m + EPSILON)
            {
                m = a[i];
                n = i;
            }
        }
        return n;
    }

    public int classify(int[,] a)
    {
        return argmax(evaluate(a));
    }
}
