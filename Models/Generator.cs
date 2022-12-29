using System;

namespace ALDSemestral.Models
{
    static class Generator
    {
        public static string[,]? array;
        static int MaxC;
        static int MaxR;
        static readonly Random Random = new();
        public static void Generate(int NCollum, int NRow)
        {
            MaxC = NCollum;
            MaxR = NRow;
            array = new string[MaxC, MaxR];
            Recursion(Random.Next(0, MaxC), Random.Next(0, MaxR));
        }

        static void Recursion(int NCollum, int NRow)
        {
            char[] value = Convert.ToString(Random.Next(0, 16), 2).PadLeft(4, '0').ToCharArray();

            //discover neighbor
            if (IsNeighbor(NCollum, NRow - 1)) { value[0] = array![NCollum, NRow - 1][2]; }
            if (IsNeighbor(NCollum + 1, NRow)) { value[1] = array![NCollum + 1, NRow][3]; }
            if (IsNeighbor(NCollum, NRow + 1)) { value[2] = array![NCollum, NRow + 1][0]; }
            if (IsNeighbor(NCollum - 1, NRow)) { value[3] = array![NCollum - 1, NRow][1]; }

            array![NCollum, NRow] = new string(value);
            if (IsOk(NCollum, NRow - 1)) { Recursion(NCollum, NRow - 1); }
            if (IsOk(NCollum + 1, NRow)) { Recursion(NCollum + 1, NRow); }
            if (IsOk(NCollum, NRow + 1)) { Recursion(NCollum, NRow + 1); }
            if (IsOk(NCollum - 1, NRow)) { Recursion(NCollum - 1, NRow); }

        }

        static bool IsNeighbor(int NCollum, int NRow)
        {
            return !(NCollum < 0 || NCollum > MaxC-1 || NRow > MaxR-1 || NRow < 0 || array![NCollum, NRow] == null);
        }

        static bool IsOk(int NCollum, int NRow)
        {
            return !(NCollum < 0 || NCollum > MaxC-1 || NRow > MaxR-1 || NRow < 0) && array![NCollum, NRow] == null;
        }

    }
}
