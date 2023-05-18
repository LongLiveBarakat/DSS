using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AproriAlgorithmGUI;

public class Record
{
    #nullable disable

    public string[] items;

    public void FillList(string[] items)
    {
        this.items = new string[items.Length];
        this.items = items;
    }
}
