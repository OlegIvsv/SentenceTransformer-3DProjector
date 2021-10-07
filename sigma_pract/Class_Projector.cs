using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sigma_pract
{
    public static class Projector
    {
        public static (int[,], int[,], int[,]) FindShadows(int[,,] input)
        {
            if (input == null)
                throw new ArgumentNullException("Argument can't be null reference.");

            int[,] ij = new int[input.GetLength(0), input.GetLength(1)];

            for (int i = 0; i < input.GetLength(0); i++)
                for (int j = 0; j < input.GetLength(1); j++)
                    for (int k = 0; k < input.GetLength(2); k++)
                        if (input[i, j, k] != 0)
                        {
                            ij[i, j] = 1;
                            break;
                        }
    
            int[,] jk = new int[input.GetLength(2), input.GetLength(1)];

            for (int k = 0; k < input.GetLength(2); k++)
                for (int j = 0; j < input.GetLength(1); j++)
                    for (int i = 0; i < input.GetLength(0); i++)
                        if (input[i, j, k] != 0)
                        {
                            jk[k, j] = 1;
                            break;
                        }

            int[,] ik = new int[input.GetLength(0), input.GetLength(2)];

            for (int i = 0; i < input.GetLength(0); i++)
                for (int k = 0; k < input.GetLength(2); k++)
                    for (int j = 0; j < input.GetLength(1); j++)
                            if (input[i, j, k] != 0)
                        {
                            ik[i, k] = 1;
                            break;
                        }

            return (ij, jk, ik);
        }
    }
}
