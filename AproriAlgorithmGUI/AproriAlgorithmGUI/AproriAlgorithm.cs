namespace AproriAlgorithmGUI;

public static class AproriAlgorithm
{
    private static List<SortedSet<string>> Combine(Dictionary<SortedSet<string>, int> itemSet)
    {
        List<SortedSet<string>> combinationTable = new List<SortedSet<string>>();

        var keys = itemSet.Keys.ToList();

        for (int i = 0; i < keys.Count - 1; i++)
        {
            for (int j = i + 1; j < keys.Count; j++)
            {
                var combinedRecord = new SortedSet<string>();

                foreach (var key in keys[i]) combinedRecord.Add(key);
                foreach (var key in keys[j]) combinedRecord.Add(key);

                // Check if combinationTable already contains a set with the same elements as combinedRecord
                bool alreadyExists = false;
                foreach (var set in combinationTable)
                {
                    if (set.SetEquals(combinedRecord))
                    {
                        alreadyExists = true;
                        break;
                    }
                }

                if (!alreadyExists) combinationTable.Add(combinedRecord);
            }
        }

        return combinationTable;
    }

    private static bool Contains(SortedSet<string> combinedRecord, Record record)
    {
        foreach (var cr in combinedRecord)
            if (!record.items.Contains(cr)) return false;

        return true;
    }

    private static void Eleminate(int miniSup, Dictionary<SortedSet<string>, int> itemSet)
    {
        foreach (var ele in itemSet)
            if (ele.Value < miniSup) itemSet.Remove(ele.Key);
    }


    private static Dictionary<SortedSet<string>, int> ReturnNewItemSet(List<SortedSet<string>> combinationTable, List<Record> database)
    {
        var newItemSet = new Dictionary<SortedSet<string>, int>();

        foreach (var combinedRecord in combinationTable)
        {
            newItemSet.Add(combinedRecord, 0);

            foreach (var record in database)
                if (Contains(combinedRecord, record)) newItemSet[combinedRecord]++;
        }

        return newItemSet;
    }

    public static Dictionary<SortedSet<string>, int> Scan(int minSup, List<Record> database, Dictionary<SortedSet<string>, int> itemSet)
    {
        Eleminate(minSup, itemSet);

        // first basecase: if itemSet equals 0 after eleminatation || second basecase: if itemSet items equals 1
        if (itemSet.Count == 0 || itemSet.Count == 1) return itemSet;

        var CombinedRecords = Combine(itemSet);

        var newItemSet = ReturnNewItemSet(CombinedRecords, database);

        itemSet = newItemSet;

        return Scan(minSup, database, itemSet);
    }

    public static Dictionary<SortedSet<string>, int> Solve(int minSup, List<Record> database)
    {

        var itemSet = new Dictionary<SortedSet<string>, int>();

        var keys = new SortedSet<string>();

        foreach (var row in database)
            foreach (var item in row.items)
                keys.Add(item);

        foreach (var key in keys)
        {
            int freq = 0;

            foreach (var row in database)
                if (row.items.Contains(key)) freq++;

            var current = new SortedSet<string>();
            current.Add(key);

            itemSet.Add(current, freq);
        }


        itemSet = Scan(minSup, database, itemSet);

        return itemSet;
    }
}

/*
4
2
A,C,D
B,C,E
A,B,C,E
B,E
*/
