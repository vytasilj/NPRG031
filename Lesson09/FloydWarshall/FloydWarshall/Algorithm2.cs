namespace FloydWarshall
{
    /// <summary>
    /// Druhá třída obsahující Floyd-Warshallův algoritmus.
    /// https://www.algoritmy.net/article/5207/Floyd-Warshalluv-algoritmus
    /// </summary>
    public static class Algorithm2
    {
        /**
         * Floyd-Warshall algorithm. Finds all shortest paths among all pairs of nodes
         * @param d matrix of distances (Integer.MAX_VALUE represents positive infinity)
         * @return matrix of predecessors
         */
        public static int[][] FloydWarshall(int[][] d)
        {
            int[][] p = ConstructInitialMatixOfPredecessors(d);
            for (int k = 0; k < d.Length; k++)
            {
                for (int i = 0; i < d.Length; i++)
                {
                    for (int j = 0; j < d.Length; j++)
                    {
                        if (d[i][k] == int.MaxValue || d[k][j] == int.MaxValue)
                            continue;

                        if (d[i][j] > d[i][k] + d[k][j])
                        {
                            d[i][j] = d[i][k] + d[k][j];
                            p[i][j] = p[k][j];
                        }

                    }
                }
            }
            return p;
        }

        /**
         * Constructs matrix P0
         * @param d matrix of lengths
         * @return P0
         */
        private static int[][] ConstructInitialMatixOfPredecessors(int[][] d)
        {
            int[][] p = new int[d.Length][];
            for (int i = 0; i < p.Length; i++)
                p[i] = new int[d.Length];

            for (int i = 0; i < d.Length; i++)
            {
                for (int j = 0; j < d.Length; j++)
                {
                    if (d[i][j] != 0 && d[i][j] != int.MaxValue)
                        p[i][j] = i;
                    else
                        p[i][j] = -1;
                }
            }
            return p;
        }
    }
}