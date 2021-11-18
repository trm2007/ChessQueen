/******************************************************************************

Расстановка 8 ферзей на шахматной доске, чтобы они не били друг-друга

See https://aka.ms/new-console-template for more information

*******************************************************************************/

class ChessQueen
{
    static readonly char[] Alphabetical = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
    static int[,] Board = new int[8, 8];

    static int Kol = 0;

    static void Main()
    {
        Console.Clear();
        Console.WriteLine("Hello chess");
        Recurs();
        Console.WriteLine("Kol = " + Kol);
    }

    static int Recurs(int n = 0)
    {
        int i, j, st = 0;
        int k, p;
        if (n == 8)
        {
            Kol++;
            Console.WriteLine("\n***************************** - " + Kol + " - ********************************");
            for (i = 0; i < n; i++)
            {
                Console.Write((8 - i) + " ");
                for (j = 0; j < 8; j++)
                {
                    Console.Write("[" + (Board[i, j] == 0 ? " " : "*") + "]");
                }
                // for(j=0;j<8;j++) { Board[n,j]=0; }
                Console.WriteLine();
            }
            Console.Write("/ ");
            for (j = 0; j < 8; j++)
            {
                Console.Write(" " + Alphabetical[j] + " ");
            }
            Console.WriteLine();
        }
        for (k = st, p = 1; k < 8; k++, p = 1)
        {
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < 8; j++)
                {
                    if (Board[i, j] == 1)
                    {
                        if (k == j || Math.Abs(n - i) == Math.Abs(k - j))
                        {
                            p = 0;
                            i = n; j = 8;
                        }

                    }
                }
            }
            if (p != 0)
            {
                Board[n, k] = 1;
                if (Recurs(n + 1) != 0 && n != 0 && st < 8)
                {
                    return 1;
                }
                else if (n == 0 && st < 8) { st++; }
                Board[n, k] = 0;
                p = 0;
            }
        }
        return 0;
    }
}
