using System.Collections.Immutable;
using System.Text;
using System.Text.Json;

namespace AproriAlgorithmGUI;

public partial class Form1 : Form
{
    protected int size, minSup, submits = 0;
    protected List<Record> database = new List<Record>();
    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
        if(!string.IsNullOrEmpty(textBox1.Text))
            size = Convert.ToInt32(textBox1.Text);

        textBox1.Text = string.Empty;
    }

    private void button2_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(textBox2.Text))
            minSup = Convert.ToInt32(textBox2.Text);

        textBox2.Text = string.Empty;
    }

    private void button3_Click(object sender, EventArgs e)
    {

        if (!string.IsNullOrEmpty(textBox3.Text))
        {
            string text = textBox3.Text.ToUpper();
            
            string[] seperated = text.Split(',');

            var record = new Record();
            record.FillList(seperated);
            database.Add(record);
        }

        textBox3.Text = string.Empty;
        submits++;

        if (submits == size)
        {
            var solved = AproriAlgorithm.Solve(minSup, database);
            
            List<string> strings = new List<string>();

            foreach (var key in solved.Keys)
                foreach (var k in key)
                    strings.Add(k);

            int f = solved.Values.First();
            string ss = $"{f}";

            strings.Add(ss);

            textBox4.Text = JsonSerializer.Serialize(strings);
        }
    }

    private void textBox4_TextChanged(object sender, EventArgs e)
    {
    }
}