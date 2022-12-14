using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc;

/* 
Monkey 0:
  Starting items: 79, 98
  Operation: new = old * 19
  Test: divisible by 23
    If true: throw to monkey 2
    If false: throw to monkey 3

 Monkey 0:
  Monkey inspects an item with a worry level of 79.
    Worry level is multiplied by 19 to 1501.
    Monkey gets bored with item. Worry level is divided by 3 to 500.
    Current worry level is not divisible by 23.
    Item with worry level 500 is thrown to monkey 3.
  Monkey inspects an item with a worry level of 98.
    Worry level is multiplied by 19 to 1862.
    Monkey gets bored with item. Worry level is divided by 3 to 620.
    Current worry level is not divisible by 23.
    Item with worry level 620 is thrown to monkey 3.
*/

internal class Monkey
{
    public Queue<int> Items { get; set; }
    public int TestValue { get; set; }
    public Func<int, int> Operation { get; set; }

    public int NextMonkeyTrue;
    public int NextMonkeyFalse;

    public int AnalysedItems = 0;


    public Monkey(int[] startingItems, Func<int, int> operation, int testValue, int nextMonkeyTrue, int nextMonkeyFalse)
    {
        Items = new Queue<int>(startingItems);
        TestValue = testValue;
        Operation = operation;
        NextMonkeyTrue = nextMonkeyTrue;
        NextMonkeyFalse = nextMonkeyFalse;
    }

    private int GetNewWorryLevel(int currentItemWorry)
    {
        return Operation(currentItemWorry);
    }

    private int ThrowChoice(int worryLevel)
    {
        if (worryLevel % TestValue == 0)
        {
            return NextMonkeyTrue;
        }
        else
        {
            return NextMonkeyFalse;
        }
    }

    public List<PassedItem<int>> AnalyseItems()
    {
        List<PassedItem<int>> result = new List<PassedItem<int>>();

        while (Items.Count > 0)
        {
            AnalysedItems++;
            var worry = Items.Dequeue();
            worry = GetNewWorryLevel(worry);
            worry = worry / 3;
            result.Add(new PassedItem<int> { DestinationMonkey = ThrowChoice(worry), WorryLevel = worry });

        }
        return result;
    }

    public override string ToString()
    {
        string result = "Items: ";
        foreach (var item in Items.ToArray())
        {
            result += ", " + item.ToString();
        }
        result += "// Analysed Items: " + AnalysedItems.ToString();
        return result;
    }
}
