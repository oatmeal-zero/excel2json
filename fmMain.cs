using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel;
using System.IO;

namespace excel2json
{
    public partial class fmMain : Form
    {
        public fmMain()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DialogResult ret = ofdFileList.ShowDialog();
            if (ret == DialogResult.OK)
            {
                foreach (string file in ofdFileList.SafeFileNames)
                {
                    fileList.Items.Add(file);
                }
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            int fileCount = 0;
            //-- 执行导出操作
            try
            {
                if (!Directory.Exists("json"))
                    Directory.CreateDirectory("json");
                foreach (string file in ofdFileList.FileNames)
                {
                    logText.AppendText("正在转换文件:" + file + "\r\n");
                    Run(file);
                    logText.AppendText("转换文件ok.\r\n");
                    fileCount++;
                }

                if (fileCount > 0)
                {
                    logText.AppendText("所有文件转换完毕，请打开json目录查看！\r\n");
                    OpenFolderAndSelectFile("json");
                }
                else
                {
                    logText.AppendText("请先选择需要转换的文件！！！\r\n");
                }
            }
            catch (Exception exp)
            {
                logText.AppendText("Error: " + exp.Message + "\r\n");
            }
        }

        /// <summary>
        /// 根据命令行参数，执行Excel数据导出工作
        /// </summary>
        /// <param name="options">命令行参数</param>
        private static void Run(string excelPath)
        {
            string file = Path.GetFileNameWithoutExtension(excelPath);
            int header = 1;

            // 加载Excel文件
            using (FileStream excelFile = File.Open(excelPath, FileMode.Open, FileAccess.Read))
            {
                // Reading from a OpenXml Excel file (2007 format; *.xlsx)
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(excelFile);

                // The result of each spreadsheet will be created in the result.Tables
                excelReader.IsFirstRowAsColumnNames = true;
                DataSet book = excelReader.AsDataSet();

                // 数据检测
                if (book.Tables.Count < 1)
                {
                    throw new Exception("Excel文件中没有找到Sheet: " + excelPath);
                }

                // 取得数据
                DataTable sheet = book.Tables[0];
                if (sheet.Rows.Count <= 0)
                {
                    throw new Exception("Excel Sheet中没有数据: " + excelPath);
                }

                //-- UTF8编码
                Encoding cd = new UTF8Encoding(false);                

                //-- 导出JSON文件
                JsonExporter exporter = new JsonExporter(sheet, header, false);
                exporter.SaveToFile("json/" + file + ".json", cd);
            }
        }

        private void OpenFolderAndSelectFile(String fileFullName)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + fileFullName;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
