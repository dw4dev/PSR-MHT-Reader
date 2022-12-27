using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PsrMhtReader
{
    public partial class fMain : Form
    {
        string output_folder = "";

        public fMain()
        {
            InitializeComponent();
            txtFilePath.Text = "";
        }

        private void fMain_Load(object sender, EventArgs e)
        {

        }

        private void ProcessFile_DragDrop(object sender, DragEventArgs e)
        {
            object ofiles = e.Data.GetData(DataFormats.FileDrop);
            if (ofiles is string[] paths)
            {
                string mht = paths.FirstOrDefault();
                if (!string.IsNullOrEmpty(mht))
                {
                    string ext = Path.GetExtension(mht).ToUpper();
                    if (ext == ".MHT")
                    {
                        txtFilePath.Text = mht;
                        ProcessMHTFile(mht);
                    }
                    else
                    {
                        MessageBox.Show("Only filenames with .mht are accepted.", "Incorrect file",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            e.Effect = DragDropEffects.None;
        }

        private void ProcessFileDrop_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;
        }

        void ProcessMHTFile(string mht_path)
        {
            //FileInfo mht = new FileInfo(mht_path);
            string content = File.ReadAllText(mht_path);
            string[] lines = content.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);


            string tmpname = Path.GetTempFileName().Replace(".tmp", "");
            string output_path = Path.Combine(Path.GetTempPath(), tmpname);

            output_folder = output_path;

            if (!Directory.Exists(output_path))
                Directory.CreateDirectory(output_path);

            #region Disassemble MHT File
            string boundary = "", boundaryEnd = "";
            int lineidx = 0;
            #region Find boundary string
            for (; lineidx < lines.Length; lineidx++)
            {
                string item = lines[lineidx];

                if (item.Contains("boundary"))
                {
                    int pos1 = item.IndexOf("\"", 0);
                    int pos2 = item.IndexOf("\"", pos1 + 1);
                    boundary = $"--{item.Substring(pos1 + 1, (pos2 - pos1 - 1))}";
                    boundaryEnd = boundary + "--";
                    break;
                }
                if (lineidx > 10)
                {
                    MessageBox.Show("Unable to disassemble MHT file.", "Unknow mht file.",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (item == boundary) break;
            }
            #endregion

            lineidx++;
            string ContentType = "";
            string Charset = "";
            string FileName = "";
            string TransferEncoding = "";
            List<string> subContent = new List<string>();
            for (; lineidx < lines.Length; lineidx++)
            {
                string item = lines[lineidx];
                if (item.StartsWith("Content-Type"))
                {
                    string[] parts = item.Replace(" ", "").Replace("\"", "")
                        .Split(new string[] { ":", ";", "=" }, StringSplitOptions.RemoveEmptyEntries);
                    ContentType = parts[1];
                    Charset = (item.Contains("charset") ? parts[3] : "");
                    continue;
                }
                if (item.StartsWith("Content-Transfer-Encoding"))
                {
                    string[] parts = item.Split(':');
                    TransferEncoding = parts[1].Trim();
                    continue;
                }
                if (item.StartsWith("Content-Location"))
                {
                    string[] parts = item.Split(':');
                    FileName = parts[1].Trim();
                    continue;
                }

                if (item == boundary || item == boundaryEnd)
                {
                    switch (ContentType)
                    {
                        case "text/html":
                        case "text/css":
                            WriteTextFile(Path.Combine(output_path, FileName), Encoding.UTF8, subContent);
                            break;
                        case "image/jpeg":
                            WriteImageFile(Path.Combine(output_path, FileName), TransferEncoding, subContent);
                            break;
                    }

                    if (item == boundaryEnd) break;

                    subContent.Clear();
                }
                else
                    subContent.Add(item);
            }
            #endregion

            string startUrl = "file:///" + $@"{output_path.Replace("\\", "/")}/main.htm";

            webView21.Source = new Uri(startUrl);
        }

        void WriteTextFile(string fn, Encoding encoding, List<string> content)
        {
            StreamWriter sw = new StreamWriter(fn, false, encoding);
            foreach (var item in content)
            {
                sw.WriteLine(item);
            }
            sw.Flush();
            sw.Close();
        }

        void WriteImageFile(string fn, string transferEncoding, List<string> content)
        {
            byte[] img = null;
            if (transferEncoding == "base64")
            {
                string allcontent = string.Join("", content);
                img = Convert.FromBase64String(allcontent);
            }
            else return; //DO NOTHING

            BinaryWriter bw = new BinaryWriter(File.OpenWrite(fn));
            bw.Write(img);
            bw.Close();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            string init_folder = "";
            if (txtFilePath.Text != "")
                init_folder = Path.GetDirectoryName(txtFilePath.Text);

            ofdOpenFile.InitialDirectory =
                init_folder == "" ? Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
                : init_folder;
            if (ofdOpenFile.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = ofdOpenFile.FileName;
                ProcessMHTFile(ofdOpenFile.FileName);
            }
        }

        private void btnSrcFile_Click(object sender, EventArgs e)
        {
            if (output_folder != "")
                Process.Start(output_folder);
        }

        private void btnClosePage_Click(object sender, EventArgs e)
        {
            if (output_folder != "")
            {
                webView21.Source = new Uri("about:blank");
                txtFilePath.Text = "";
                output_folder = "";
            }
        }
    }
}
