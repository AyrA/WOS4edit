using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WOS4edit
{
    public partial class frmMain : Form
    {
        private Dictionary<string, string> Help;
        private Config C;
        private string FileName;

        public frmMain()
        {
            C = null;
            FileName = null;
            InitializeComponent();
            string Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "WOS4 - New York");
            OFD.InitialDirectory = Directory.Exists(Dir) ? Dir : Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Help = new Dictionary<string, string>();
            if (File.Exists("help.txt"))
            {
                string[] Lines = File.ReadAllLines("help.txt");
                foreach (string Line in Lines)
                {
                    if (Line.Contains("="))
                    {
                        Help.Add(Line.Split('=')[0].ToLower(), Line.Substring(Line.IndexOf('=') + 1));
                    }
                }
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    C = WOS4.Read(FileName = OFD.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Cannot read settings file. Error:\r\n{0}\r\nPlease make sure, the file is an actual savegame file and WOS4 is not running",ex.Message), "Cannot read file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                cbSetting.Items.Clear();
                foreach (Setting S in C.Settings)
                {
                    cbSetting.Items.Add(S.Name);
                }
            }
        }

        private void cbSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (C.Find(cbSetting.SelectedItem.ToString()) >= 0)
            {
                Setting S = C.Settings[C.Find(cbSetting.SelectedItem.ToString())];
                lblType.Text =GetDescription(S.Type);
                if (Help.ContainsKey(S.Name.ToLower()))
                {
                    lblHelp.Text = Help[S.Name.ToLower()];
                }
                else
                {
                    lblHelp.Text = "No help present for " + S.Name;
                }
                tbValue.Text = S.Data.ToString();
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (C.Find(cbSetting.SelectedItem.ToString()) >= 0)
            {
                int index = C.Find(cbSetting.SelectedItem.ToString());
                Setting S = C.Settings[index];

                switch (S.Type)
                {
                    case DataType.Boolean:
                        bool b=false;
                        if (bool.TryParse(tbValue.Text, out b))
                        {
                            S.Data = b;
                        }
                        else
                        {
                            MessageBox.Show("Invalid value: " + tbValue.Text, "Error setting value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case DataType.Byte:
                        byte bb = 0;
                        if (byte.TryParse(tbValue.Text, out bb))
                        {
                            S.Data = bb;
                        }
                        else
                        {
                            MessageBox.Show("Invalid value: " + tbValue.Text, "Error setting value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case DataType.Int32:
                        int i = 0;
                        if (int.TryParse(tbValue.Text, out i))
                        {
                            S.Data = i;
                        }
                        else
                        {
                            MessageBox.Show("Invalid value: " + tbValue.Text, "Error setting value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case DataType.Int64:
                        long l = 0;
                        if (long.TryParse(tbValue.Text, out l))
                        {
                            S.Data = l;
                        }
                        else
                        {
                            MessageBox.Show("Invalid value: " + tbValue.Text, "Error setting value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case DataType.Single:
                        float f = 0;
                        if (float.TryParse(tbValue.Text, out f))
                        {
                            S.Data = f;
                        }
                        else
                        {
                            MessageBox.Show("Invalid value: " + tbValue.Text, "Error setting value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case DataType.String:
                        string s = tbValue.Text;
                            S.Data = s;
                            break;
                    default:
                        MessageBox.Show("Invalid data type: " + S.Type.ToString(), "Error setting value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                C.Settings[index] = S;
                MessageBox.Show("Value set. Use the Save button to write changes to file", "Value set", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string GetDescription(DataType DT)
        {
            switch (DT)
            {
                case DataType.Boolean:
                    return "Boolean; 'True' or 'False'";
                case DataType.Byte:
                    return "Integer; 0 - 255";
                case DataType.Int32:
                    return "Integer; Usual: -100 - +100; Possible: " + int.MinValue.ToString() + " - +" + int.MaxValue.ToString();
                case DataType.Int64:
                    return "Integer; Usual: -1000 - +1000; Possible: " + long.MinValue.ToString() + " - +" + long.MaxValue.ToString();
                case DataType.Single:
                    return "Decimal number; Usual: -100 - +100; Possible: " + float.MinValue.ToString() + " - +" + float.MaxValue.ToString();
                case DataType.String:
                    return "Any chars";
                default:
                    return "Invalid data type: " + DT;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FileName) && MessageBox.Show("Save settings? This overwrites existing files", "Overwrite savegame", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                WOS4.Write(C, FileName);
                MessageBox.Show("Settings saved", "Settings saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
