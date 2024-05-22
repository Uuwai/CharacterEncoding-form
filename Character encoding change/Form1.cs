using System.Text;
namespace Character_encoding_change
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        optionform1 optionform1 = new optionform1();
        List<Encoding> encodings = new List<Encoding>();
        private void Form1_Load(object sender, EventArgs e)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            foreach (EncodingInfo encInfo in Encoding.GetEncodings())
            {
                Encoding enc = Encoding.GetEncoding(encInfo.Name);
                encodings.Add(enc);
            }
            foreach (Encoding encInfo in encodings)
            {
                comboBox1.Items.Add(String.Format(optionform1.textBox1.Text, encInfo.EncodingName, encInfo.WebName, encInfo.HeaderName, encInfo.BodyName, encInfo.CodePage.ToString()));
                comboBox2.Items.Add(String.Format(optionform1.textBox1.Text, encInfo.EncodingName, encInfo.WebName, encInfo.HeaderName, encInfo.BodyName, encInfo.CodePage.ToString()));
            }
            comboBox1.SelectedIndex = 1;
            comboBox2.SelectedIndex = 1;
            encodingToolStripMenuItem.Click += textBox1_TextChanged;
            textToolStripMenuItem.Click += textBox1_TextChanged;
            bothToolStripMenuItem.Click += textBox1_TextChanged;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Encoding inp = Encoding.GetEncoding(encodings[comboBox1.SelectedIndex].CodePage);
                Encoding outp = Encoding.GetEncoding(encodings[comboBox2.SelectedIndex].CodePage);
                byte[] bytes = inp.GetBytes(textBox1.Text);
                Encoding.Convert(inp, outp, bytes);
                textBox2.Text = outp.GetString(bytes);
            }
            catch { }
        }

        private void nameFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            optionform1.ShowDialog();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            int cbox1 = comboBox1.SelectedIndex;
            int cbox2 = comboBox2.SelectedIndex;
            foreach (Encoding encInfo in encodings)
            {
                comboBox1.Items.Add(String.Format(optionform1.textBox1.Text, encInfo.EncodingName, encInfo.WebName, encInfo.HeaderName, encInfo.BodyName, encInfo.CodePage.ToString()));
                comboBox2.Items.Add(String.Format(optionform1.textBox1.Text, encInfo.EncodingName, encInfo.WebName, encInfo.HeaderName, encInfo.BodyName, encInfo.CodePage.ToString()));
            }
            comboBox1.SelectedIndex = cbox1;
            comboBox2.SelectedIndex = cbox2;
        }

        private void switchEncodingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cbox1 = comboBox1.SelectedIndex;
            int cbox2 = comboBox2.SelectedIndex;
            comboBox1.SelectedIndex = cbox2;
            comboBox2.SelectedIndex = cbox1;
        }

        private void switchTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string t1 = textBox1.Text;
            string t2 = textBox2.Text;
            textBox1.Text = t2;
            textBox2.Text = t1;
        }

        private void switchBothToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string t1 = textBox1.Text;
            string t2 = textBox2.Text;
            textBox1.Text = t2;
            textBox2.Text = t1;
            int cbox1 = comboBox1.SelectedIndex;
            int cbox2 = comboBox2.SelectedIndex;
            comboBox1.SelectedIndex = cbox2;
            comboBox2.SelectedIndex = cbox1;

        }
    }
}
