using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace aoc;

internal static class MonkeyLoader
{
    internal static Monkey[] GetTest()
    {
        Monkey[] result = new Monkey[4];


        //       Monkey 0:
        //Starting items: 79, 98
        //Operation: new = old * 19
        //Test: divisible by 23
        //  If true: throw to monkey 2
        //  If false: throw to monkey 3
        result[0] = new Monkey(
            new int[] { 79, 98 },
            x => x * 19,
            23,
            2,
            3
            );

        //Monkey 1:
        //  Starting items: 54, 65, 75, 74
        //  Operation: new = old + 6
        //  Test: divisible by 19
        //    If true: throw to monkey 2
        //    If false: throw to monkey 0
        result[1] = new Monkey(
            new int[] { 54, 65, 75, 74 },
            x => x + 6,
            19,
            2,
            0
            );

        //Monkey 2:
        //  Starting items: 79, 60, 97
        //  Operation: new = old * old
        //  Test: divisible by 13
        //    If true: throw to monkey 1
        //    If false: throw to monkey 3
        result[2] = new Monkey(
            new int[] { 79, 60, 97 },
            x => x * x,
            13,
            1,
            3
            );

        //Monkey 3:
        //  Starting items: 74
        //  Operation: new = old + 3
        //  Test: divisible by 17
        //    If true: throw to monkey 0
        //    If false: throw to monkey 1
        result[3] = new Monkey(
            new int[] { 74},
            x => x + 3,
            17,
            0,
            1
            );

        return result;
    }

    internal static Monkey[] GetProd()
    {
        Monkey[] result = new Monkey[8];

        //Monkey 0:
        //  Starting items: 50, 70, 89, 75, 66, 66
        //  Operation: new = old * 5
        //  Test: divisible by 2
        //    If true: throw to monkey 2
        //    If false: throw to monkey 1
        result[0] = new Monkey(
            new int[] { 50, 70, 89, 75, 66, 66 },
            x => x * 5,
            2,
            2,
            1
            );

        //Monkey 1:
        //  Starting items: 85
        //  Operation: new = old * old
        //  Test: divisible by 7
        //    If true: throw to monkey 3
        //    If false: throw to monkey 6
        result[1] = new Monkey(
    new int[] { 85 },
    x => x * x,
    7,
    3,
    6
    );

        //Monkey 2:
        //  Starting items: 66, 51, 71, 76, 58, 55, 58, 60
        //  Operation: new = old + 1
        //  Test: divisible by 13
        //    If true: throw to monkey 1
        //    If false: throw to monkey 3
        result[2] = new Monkey(
    new int[] { 66, 51, 71, 76, 58, 55, 58, 60 },
    x => x +1,
    13,
    1,
    3
    );

        //Monkey 3:
        //  Starting items: 79, 52, 55, 51
        //  Operation: new = old + 6
        //  Test: divisible by 3
        //    If true: throw to monkey 6
        //    If false: throw to monkey 4
        result[3] = new Monkey(
    new int[] { 79, 52, 55, 51 },
    x => x + 6,
    3,
    6,
    4
    );

        //Monkey 4:
        //  Starting items: 69, 92
        //  Operation: new = old * 17
        //  Test: divisible by 19
        //    If true: throw to monkey 7
        //    If false: throw to monkey 5
        result[4] = new Monkey(
new int[] { 69, 92 },
x => x * 17,
19,
7,
5
);

        //Monkey 5:
        //  Starting items: 71, 76, 73, 98, 67, 79, 99
        //  Operation: new = old + 8
        //  Test: divisible by 5
        //    If true: throw to monkey 0
        //    If false: throw to monkey 2
        result[5] = new Monkey(
new int[] { 71, 76, 73, 98, 67, 79, 99 },
x => x + 8,
5,
0,
2
);


        //Monkey 6:
        //  Starting items: 82, 76, 69, 69, 57
        //  Operation: new = old + 7
        //  Test: divisible by 11
        //    If true: throw to monkey 7
        //    If false: throw to monkey 4
        result[6] = new Monkey(
new int[] { 82, 76, 69, 69, 57 },
x => x + 7,
11,
7,
4
);

        //Monkey 7:
        //  Starting items: 65, 79, 86
        //  Operation: new = old + 5
        //  Test: divisible by 17
        //    If true: throw to monkey 5
        //    If false: throw to monkey 0
        result[7] = new Monkey(
new int[] { 65, 79, 86 },
x => x + 5,
17,
5,
0
);


        return result;
    }
}
