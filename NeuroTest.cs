using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NeuroTest
{
    Neuro neuro;
    public void computeWeights()
    {
        neuro = new Neuro();

        for (int k = 0; k < 8; k++)
        {
            Console.WriteLine();
            Console.WriteLine(k);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{neuro.w[k, i, j],5} ");
                }
                Console.WriteLine();
            }
        }
    }

    public void ShowMatrix<T>(T[,] m)
    {
        for (int i = 0; i < m.GetLength(0); i++)
        {
            for (int j = 0; j < m.GetLength(1); j++)
            {
                Console.Write($"{m[i, j],5} ");
            }
            Console.WriteLine();
        }
    }

    private bool allok = true;

    public void test(int expect, string map)
    {
        test(map, expect);
    }

    public void test(string map, int expect = -1)
    {
        int[,] a = new int[3, 3];
        var lines = map.Split("\n").Where(x => x.StartsWith("|")).ToList();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
                a[i, j] = lines[i][j + 1] == 'X' ? 1 : 0;
        }

        Console.WriteLine();
        ShowMatrix(a);

        float[] r = neuro.evaluate(a);
        int k = Neuro.argmax(r);
        for (int i = 0; i < r.Length; i++)
        {
            Console.WriteLine($"{i} {r[i],7:0.##} {(i == k ? "*" : "")}");
        }
        if (expect >= 0)
        {
            if (expect != k) allok = false;
            Console.WriteLine($"{(expect == k ? "Ok" : "Wrong!")}");
        }
    }

    public void summary()
    {
        Console.WriteLine(allok ? "All OK!" : "Some tests failed!");
    }
}

