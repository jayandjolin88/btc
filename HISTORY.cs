using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class HISTORY : Form
    {
        public HISTORY()
        {
            InitializeComponent();
        }

        private void GetHisTory()
        {
            try
            {
               
                DataTable dtt = new DataTable();
                dtt.Columns.Add("NAME", typeof(string));
                dtt.Columns.Add("URL_", typeof(string));
                //dtt.Columns.Add("ID", typeof(string));
                dtt.Columns.Add("CREATE_TIME", typeof(string));
                dtt.Columns.Add("WEBKIT", typeof(string));
                //dtt.Columns.Add("IS_HOME", typeof(int));
                //dtt.Columns.Add("URL_TYPE", typeof(string));
                //将XML文件加载进来
                XDocument document1 = XDocument.Load(Environment.CurrentDirectory + "/UrlSet_History.xml");
                //获取到XML的根元素进行操作
                XElement root1 = document1.Root;
                IEnumerable<XElement> types1 = root1.Elements();
                int index1 = 1;


                //dt.Rows.Add(new object[] { index, item.Value, "", "" });
                //index++;
                foreach (XElement item1 in types1)
                {
                    IEnumerable<XElement> sys = item1.Elements();
                    foreach (XElement item2 in sys)
                    {
                        string s = item2.Value;
                        if (s != "")
                        {
                            if (s.StartsWith("||||")) continue;
                            string ss = s.Split('|')[0] + "    " + s.Split('|')[1];
                            if (Convert.ToDateTime(s.Split('|')[4]) <= Convert.ToDateTime(dateEdit2.Text).AddDays(1) && Convert.ToDateTime(s.Split('|')[4]) >= Convert.ToDateTime(dateEdit1.Text))
                                //dtt.Rows.Add(new object[] { s.Split('|')[6], s.Split('|')[0], s.Split('|')[1], s.Split('|')[2], s.Split('|')[3], s.Split('|')[4], s.Split('|')[5] });
                                dtt.Rows.Add(new object[] { ss, s.Split('|')[1], s.Split('|')[4], s.Split('|')[2] });
                            index1++;
                        }

                    }
                }

                //DataTable dt = acc.GetData("select * from URL_LIST");
                dataGridView1.DataSource = dtt;

            }
            catch (Exception)
            {

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xmlDoc1 = new XmlDocument();
                xmlDoc1.Load(Environment.CurrentDirectory + "/UrlSet_History.xml");
                XmlNodeList ele = xmlDoc1.SelectNodes("URL");
                foreach (XmlNode item in ele)
                {
                 
                    XmlNodeList el = item.SelectNodes("URL_TYPE");
                    foreach (XmlNode item_ in el)
                    {
                        

                        XmlNodeList el1 = item_.SelectNodes("name");
                        foreach (XmlNode item_1 in el1)
                        {
                            if (item_1.InnerText == "")
                            {
                                item_.RemoveChild(item_1);
                                continue;
                            }

                            if (item_1.InnerText != "")
                            {
                                if (item_1.InnerText.StartsWith("||||")) continue;
                                if (Convert.ToDateTime(item_1.InnerText.Split('|')[4])<= Convert.ToDateTime(dateEdit2.Text).AddDays(1)&& Convert.ToDateTime(item_1.InnerText.Split('|')[4]) >= Convert.ToDateTime(dateEdit1.Text))
                                {
                                    item_1.RemoveAll();
                                }
                            }
                            else
                            {
                                item_1.RemoveAll();
                            }
                        }

                    }
                }
                xmlDoc1.Save(Environment.CurrentDirectory + "/UrlSet_History.xml");
                GetHisTory();

            }
            catch (Exception)
            {

            }
        }

        private void HISTORY_Load(object sender, EventArgs e)
        {
            dateEdit1.Text = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            dateEdit2.Text = DateTime.Now.AddDays(0).ToString("yyyy-MM-dd");
            GetHisTory();
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[0].Width = 400;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetHisTory();
        }

        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {
            GetHisTory();
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            GetHisTory();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string url = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string webket = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            //调用子窗体的Foo()方法 
            if (webket.Equals("IE"))
                Form1.Init_XtraTabPage("IE内核TAB", "IE内核TAB", url, _WEBB_TYPE.IE, "_Bweb_NAME1", url);
            if (webket.Equals("谷歌"))
                Form1.Init_XtraTabPage("谷歌内核TAB", "谷歌内核TAB", url, _WEBB_TYPE.WebKit, "_Bweb_NAME1", url);
            if (webket.Equals("火狐"))
                Form1.Init_XtraTabPage("火狐内核TAB", "火狐内核TAB", url, _WEBB_TYPE.Gecko, "_Bweb_NAME1", url);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
