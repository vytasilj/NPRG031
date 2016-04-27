using System;

namespace Palindrom
{
    public class Palindrom
    {
        public int GetMaxLength(string text)
        {
            if (text == null)
                throw new ArgumentNullException("text");
            if (text == string.Empty)
                return 0;

            int n = text.Length;
            int[,] v = new int[n, n];
            for (int i = 0; i < n; i++)
                v[i, i] = 1;
            for (int i = 1; i < n; i++)
                v[i, i - 1] = 0;

            for (int delka = 2; delka <= n; delka++)
                for (int i = 0; i < n - delka + 1; i++)
                {
                    int j = i + delka - 1;
                    if (text[i] == text[j])
                        v[i, j] = v[i + 1, j - 1] + 2;
                    else if (v[i + 1, j] > v[i, j - 1])
                        v[i, j] = v[i + 1, j];
                    else
                        v[i, j] = v[i, j - 1];
                }
            return v[0, n - 1];
        }
    }
}
