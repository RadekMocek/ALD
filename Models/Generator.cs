using System;

namespace ALDSemestral.Models
{
    static class Generator
    {
        public static string[,]? array;
        static int maxC;
        static int maxR;
        static readonly Random random = new();

        public static void Generate(int column, int row)
        {
            maxC = column;
            maxR = row;
            array = new string[maxC, maxR];
            Recursion(random.Next(0, maxC), random.Next(0, maxR));
        }

        static void Recursion(int column, int row)
        {
            // Choose random tile
            char[] value = Convert.ToString(random.Next(0, 16), 2).PadLeft(4, '0').ToCharArray();

            // Update tile according to taken neighbors
            if (IsNeighbor(column, row - 1)) { value[0] = array![column, row - 1][2]; }
            if (IsNeighbor(column + 1, row)) { value[1] = array![column + 1, row][3]; }
            if (IsNeighbor(column, row + 1)) { value[2] = array![column, row + 1][0]; }
            if (IsNeighbor(column - 1, row)) { value[3] = array![column - 1, row][1]; }

            // Set tile value
            array![column, row] = new string(value);

            // Run this func on all free neighbors
            if (IsFree(column, row - 1)) { Recursion(column, row - 1); }
            if (IsFree(column + 1, row)) { Recursion(column + 1, row); }
            if (IsFree(column, row + 1)) { Recursion(column, row + 1); }
            if (IsFree(column - 1, row)) { Recursion(column - 1, row); }

        }

        static bool IsNeighbor(int column, int row)
        {
            return !(column < 0 || column > maxC - 1 || row > maxR - 1 || row < 0 || array![column, row] == null);
        }

        static bool IsFree(int column, int row)
        {
            return !(column < 0 || column > maxC - 1 || row > maxR - 1 || row < 0) && array![column, row] == null;
        }

    }
}
