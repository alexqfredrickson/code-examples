using System.Linq;

namespace practice_exercises.Project_Euler.Helpers
{
    public static class ArrayHelper
    {
        public static bool IsOneThroughNinePandigital(char[] c)
        {
            return c.Distinct().Count() == 9 && c.Count() == 9 && !c.Contains('0');
        }
    }
}
