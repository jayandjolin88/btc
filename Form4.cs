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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        ACCESS_HELPER acc = new ACCESS_HELPER();
        private void Form4_Load(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {

            ShowUpdate();
            this.Close();
        }


        /// <summary>
        /// 创建类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "") { label5.Visible = true; return; }

            //写入类型XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Environment.CurrentDirectory + "/UrlType_Set.xml");
            XmlNode nodeList = xmlDoc.SelectSingleNode("URL_TYPE");
            XmlElement xe1 = xmlDoc.CreateElement("NAME");//创建一个<name>节点 
            xe1.InnerText = textBox1.Text.Trim();
            nodeList.AppendChild(xe1);
            xmlDoc.Save(Environment.CurrentDirectory + "/UrlType_Set.xml");

            //写入urlset.XML
            XmlDocument xmlDoc1 = new XmlDocument();
            xmlDoc1.Load(Environment.CurrentDirectory + "/UrlSet.xml");
            XmlNode nodeList1 = xmlDoc1.SelectSingleNode("URL");
            XmlElement xe11 = xmlDoc1.CreateElement("URL_TYPE");//创建一个<URL_TYPE>节点 
            nodeList1.AppendChild(xe11);
            XmlElement xe12 = xmlDoc1.CreateElement("name");//创建一个<name>节点 
            xe12.InnerText = "|||||" + textBox1.Text.Trim() + "|" + Guid.NewGuid();
            xe11.AppendChild(xe12);
            xmlDoc1.Save(Environment.CurrentDirectory + "/UrlSet.xml");



            MessageBox.Show("设置成功");
            ShowUpdate();
            this.Close();

            //string sql = string.Format("insert into URL_TYPELIST values('{0}','{1}','{2}')",
            //Guid.NewGuid(), textBox1.Text.Trim(), "--");
            //int i = acc.InsertData(sql);
            //if (i > 0)
            //{
            //    MessageBox.Show("设置成功"); this.Close(); ShowUpdate();
            //}

            //else
            //    MessageBox.Show("设置失败");
        }


        //声明一个委托    
        public delegate void DisplayUpdate();
        //声明事件    
        public event DisplayUpdate ShowUpdate;

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                GetXml();

            }
        }
        /// <summary>
        /// 加载收藏夹类型
        /// </summary>
        private void GetXml()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NAME", typeof(string));
            //将XML文件加载进来
            XDocument document = XDocument.Load(Environment.CurrentDirectory + "/UrlType_Set.xml");
            //获取到XML的根元素进行操作
            XElement root = document.Root;
            IEnumerable<XElement> types = root.Elements();
            foreach (XElement item in types)
            {
                if (item.Value.ToString().Trim() != "")
                    dt.Rows.Add(new object[] { item.Value });
            }
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            XmlDocument xmlDoc1 = new XmlDocument();
            xmlDoc1.Load(Environment.CurrentDirectory + "/UrlType_Set.xml");
            XmlNode ele = xmlDoc1.SelectSingleNode("URL_TYPE");
            XmlNodeList ele1 = ele.SelectNodes("NAME");
            foreach (XmlNode item in ele1)
            {
                if (item.InnerText == dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString())
                {
                    item.RemoveAll();
                    xmlDoc1.Save(Environment.CurrentDirectory + "/UrlType_Set.xml");
                    break;
                }     
            }
            GetXml();
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            ShowUpdate();
        }
    }
}
