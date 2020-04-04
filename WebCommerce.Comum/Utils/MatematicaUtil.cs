using System;

namespace Aula09.Comum
{
    public class MatematicaUtil
    {
        public static decimal Divisao(decimal a, decimal b)
        {
            if (b == 0)
                return 0;

            return a / b;
        }
    }
}
