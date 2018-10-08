using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JCWK_DEMO
{
    public partial class Form1 : Form
    {
        private  CarInfo carInfo = null;

        public Form1()
        {
            InitializeComponent();
            dgvMain.AutoGenerateColumns = false;
           
            Action action = new Action(()=> {
                while (true)
                {
                    FileNewResult();
                }
            });
            TaskFactory taskFactory = new TaskFactory();
            taskFactory.StartNew(action);

        }

        public void LoadDispatch()
        {
            string strSql = "SELECT TOP 10 * FROM VEHICLE_DISPATCH WHERE LEFT(JCLSH,1) = 'A' AND JCZT_STATUS <> 4 AND JYXM LIKE '%M1%' ORDER BY ID DESC";
            DbHelper dbHelper = new DbHelper(@"JCX-server\localdb", "sa", "", "IVS_NEW");
            List<VEHICLE_DISPATCH> list = dbHelper.QueryList<VEHICLE_DISPATCH>(strSql);
            dgvMain.DataSource = list;

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMsg();
        }


        private void SendMsg()
        {
            try
            {
                carInfo = new CarInfo();
                VEHICLE_DISPATCH vEHICLE_DISPATCH = dgvMain.CurrentRow.DataBoundItem as VEHICLE_DISPATCH;
                carInfo.JCLSH = vEHICLE_DISPATCH.JCLSH;
                carInfo.sendTime = DateTime.Now;
                 StreamWriter streamWriter = null;
                streamWriter = new StreamWriter(File.Open(ConfigHelper.SendTxtPath, FileMode.Create), System.Text.Encoding.GetEncoding("GBK"));
                InfoContex infoContex = new InfoContex(vEHICLE_DISPATCH.JCLSH);
                streamWriter.Write(infoContex.GetStr());
                streamWriter.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SendMsg();
                MessageBox.Show("发送成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FileNewResult()
        {
            try
            {
                if (carInfo != null)
                {
                    FileInfo fileInfo = new FileInfo(ConfigHelper.ReceiveTxtPath);

                    if (fileInfo.LastWriteTime > carInfo.sendTime)
                    {

                        ReciveResult();
                    }                  
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ReciveResult()
        {
            FileStream fileStream = null;
            StreamReader read = null;
            try
            {
                 fileStream = new FileStream(ConfigHelper.ReceiveTxtPath, FileMode.Open, FileAccess.Read);
                 read = new StreamReader(fileStream, Encoding.GetEncoding("GBK"));
                string strReadLine;
                RESULT_OVERALLSIZE rESULT_OVERALLSIZE = new RESULT_OVERALLSIZE();
                rESULT_OVERALLSIZE.JCLSH = carInfo.JCLSH;
                string iC_PD = "3";
                string iK_PD = "3";
                string iG_PD = "3";
                while ((strReadLine = read.ReadLine()) != null)
                {
                    if (strReadLine.Contains("="))
                    {
                        string[] s = strReadLine.Split('=');
                        if (s.Length == 2)
                        {
                            switch (s[0])
                            {
                                case "长":
                                    rESULT_OVERALLSIZE.ZCSCWKCCCD = s[1];
                                    break;
                                case "宽":
                                    rESULT_OVERALLSIZE.ZCSCWKCCKD = s[1];
                                    break;
                                case "高":
                                    rESULT_OVERALLSIZE.ZCSCWKCCGD = s[1];
                                    break;
                                case "长判定":
                                    iC_PD = s[1];
                                    break;
                                case "宽判定":
                                    iK_PD = s[1];
                                    break;
                                case "高判定":
                                    iG_PD = s[1];
                                    break;
                            }
                        }
                    }
                }
                if (iC_PD.ToIntPd() == 1 && iK_PD.ToIntPd() == 1 && iG_PD.ToIntPd() == 1)
                {
                    rESULT_OVERALLSIZE.ZCWKCC_PD = "1";
                }
                else
                {
                    rESULT_OVERALLSIZE.ZCWKCC_PD = "2";
                }

                UpdateTable(rESULT_OVERALLSIZE);
                carInfo = null;

            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                    fileStream = null;
                }
                if (read != null)
                {
                    read.Close();
                    read = null;
                }
            }
            
        }

        private void UpdateTable(RESULT_OVERALLSIZE rESULT_OVERALLSIZE)
        {
            DbHelper dbHelper = new DbHelper(@"JCX-server\localdb", "sa", "", "IVS_NEW");
            string strSql = $"{SqlHelper<RESULT_OVERALLSIZE>.GetSearchSql()} WHERE JCLSH = '{rESULT_OVERALLSIZE.JCLSH}'";
            RESULT_OVERALLSIZE x_LOGIN_VEHICLE_INFO = dbHelper.Query<RESULT_OVERALLSIZE>(strSql);
            string insertSql = string.Empty;
            if (x_LOGIN_VEHICLE_INFO.JCLSH == null)
            {
                insertSql = $"INSERT INTO RESULT_OVERALLSIZE (JCLSH,ZCSCWKCCCD,ZCSCWKCCKD,ZCSCWKCCGD,ZCWKCC_PD) VALUES ('{rESULT_OVERALLSIZE.JCLSH}','{rESULT_OVERALLSIZE.ZCSCWKCCCD}','{rESULT_OVERALLSIZE.ZCSCWKCCKD}','{rESULT_OVERALLSIZE.ZCSCWKCCGD}','{rESULT_OVERALLSIZE.ZCWKCC_PD}')";
            }
            else
            {
                insertSql = $"UPDATE RESULT_OVERALLSIZE SET ZCSCWKCCCD='{rESULT_OVERALLSIZE.ZCSCWKCCCD}',ZCSCWKCCKD = '{rESULT_OVERALLSIZE.ZCSCWKCCKD}',ZCSCWKCCGD='{rESULT_OVERALLSIZE.ZCSCWKCCGD}',ZCWKCC_PD = '{rESULT_OVERALLSIZE.ZCWKCC_PD}' WHERE JCLSH = '{rESULT_OVERALLSIZE.JCLSH}' ";
            }
            dbHelper.ExcuteSql(insertSql);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReciveResult();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDispatch();
        }
    }

    public class CarInfo
    {
        public string JCLSH { get; set; }

        public DateTime sendTime { get; set; }
    }
}
