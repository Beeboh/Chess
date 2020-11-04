using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame.Utils
{
    public static class RatioReducer
    {
        public static XYCouple Reduce(int x, int y)
        {
            int commonFactor = GetCommonFactor(x, y);
            int ReducedX = x / commonFactor;
            int ReducedY = y / commonFactor;
            return new XYCouple(ReducedX, ReducedY);
        }
        private static int GetCommonFactor(int x, int y)
        {
            int XMagnitude = Math.Abs(x);
            int YMagnitude = Math.Abs(y);
            int divisor = 1;

            if (x == 0)
            {
                if (y != 0)
                {
                    divisor = YMagnitude;
                }
            }
            else if (y == 0)
            {
                if (x != 0)
                {
                    divisor = XMagnitude;
                }
            }
            else
            {
                if (XMagnitude == YMagnitude)
                {
                    divisor = XMagnitude;
                }
                else
                {
                    int HighestPossibleFactor = XMagnitude > YMagnitude ? YMagnitude : XMagnitude;
                    int GreatestCommonFactor = 1;

                    for (int i = 1; i <= HighestPossibleFactor; i++)
                    {
                        if (XMagnitude % i == 0 && YMagnitude % i == 0)
                        {
                            GreatestCommonFactor = i;
                        }
                    }
                    divisor = GreatestCommonFactor;
                }
            }
            return divisor;
        }
    }
}
