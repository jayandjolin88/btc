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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        ACCESS_HELPER acc = new ACCESS_HELPER();
        private void Form3_Load(object sender, EventArgs e)
        {
            GetMyDataType();
        }

        public void Refresh_Method()
        {
            GetMyDataType();
        }

        /// <summary>
        /// 获得类型
        /// </summary>
        private void GetMyDataType()
        {
            comboBox2.Items.Clear();
            XDocument document1 = XDocument.Load(Environment.CurrentDirectory + "/UrlType_Set.xml");
            //获取到XML的根元素进行操作
            XElement root1 = document1.Root;
            IEnumerable<XElement> types1 = root1.Elements();
            foreach (XElement item in types1)
            {
                if (item.Value.Trim() != "")
                    comboBox2.Items.Add(item.Value.Trim());
                else
                    item.RemoveAll();
            }
            document1.Save(Environment.CurrentDirectory + "/UrlType_Set.xml");
            //DataTable userDt = acc.GetData(" select * from URL_TYPELIST ");
            //foreach (DataRow row in userDt.Rows)
            //{
            //    comboBox2.Items.Add(row["TYPE_NAME"]);
            //}

        }
        private void GetMyData()
        {
            DataTable userDt = acc.GetData(" select * from URL_TYPE_ID ");
            if (userDt.Rows.Count != 0)
            {
                //bangdiMune(userDt.Rows[0]["PrivilegeCode"].ToString());
            }
        }


       

     
       

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
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("TYPE", typeof(string));
            dt.Columns.Add("UTL_NAME", typeof(string));
            dt.Columns.Add("UTL", typeof(string));
            //将XML文件加载进来
            XDocument document = XDocument.Load(Environment.CurrentDirectory + "/UrlType_Set.xml");
            //获取到XML的根元素进行操作
            XElement root = document.Root;
            IEnumerable<XElement> types = root.Elements();
            int index = 1;
            //foreach (XElement item in types)
            //{
            //    string s=  item.Value;
            //    string sw= item.Name.ToString();
            //}

            DataTable dtt = new DataTable();
            dtt.Columns.Add("ID", typeof(string));
            dtt.Columns.Add("NAME", typeof(string));
            dtt.Columns.Add("URL_", typeof(string));
            dtt.Columns.Add("WEBKIT", typeof(string));
            dtt.Columns.Add("IS_HOME", typeof(int));
            dtt.Columns.Add("CREATE_TIME", typeof(string));
            dtt.Columns.Add("URL_TYPE", typeof(string));
            //将XML文件加载进来
            XDocument document1 = XDocument.Load(Environment.CurrentDirectory + "/UrlSet.xml");
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
                        dtt.Rows.Add(new object[] { s.Split('|')[6], s.Split('|')[0], s.Split('|')[1], s.Split('|')[2], s.Split('|')[3], s.Split('|')[4], s.Split('|')[5] });
                        index1++;
                    }
                  
                }
            }

            //DataTable dt = acc.GetData("select * from URL_LIST");
            dataGridView1.DataSource = dtt;

        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                string value1 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                XmlDocument xmlDoc1 = new XmlDocument();
                xmlDoc1.Load(Environment.CurrentDirectory + "/UrlSet.xml");
                XmlNodeList ele = xmlDoc1.SelectNodes("URL");
                int stop = 0;
                foreach (XmlNode item in ele)
                {
                    if (stop == 1) break;
                    XmlNodeList el = item.SelectNodes("URL_TYPE");
                    foreach (XmlNode item_ in el)
                    {
                        if (stop == 1) break;
                        XmlNodeList el1 = item_.SelectNodes("name");
                        foreach (XmlNode item_1 in el1)
                        {
                            if (item_1.InnerText == "")
                            {
                                item_.RemoveChild(item_1);
                                xmlDoc1.Save(Environment.CurrentDirectory + "/UrlSet.xml");
                                continue;
                            }

                            if (item_1.InnerText != "")
                            {
                                if (item_1.InnerText.StartsWith("||||")) continue;
                                if (item_1.InnerText.Split('|')[6].ToString() == value1)
                                {
                                    item_1.RemoveAll();
                                    xmlDoc1.Save(Environment.CurrentDirectory + "/UrlSet.xml");
                                    stop = 1;
                                    break;
                                }
                            }
                            else {
                                item_1.RemoveAll();
                            }
                        }
                       
                    }

                }


                GetXml();
                //string value1 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                //string val = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                //string vawl = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                //int i = acc.DeleteData("delete  from URL_LIST where URL_ID='" + value1 + "'");
                //if (i > 0)
                //{
                //    DataTable dt = acc.GetData("select * from URL_LIST");
                //    dataGridView1.DataSource = dt;
                //}
            }
            catch (Exception)
            {

            }
            
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim() == "") { label5.Visible = true; return; }
                if (textBox2.Text.Trim() == "") { label6.Visible = true; return; }
                if (comboBox2.Text.Trim() == "") { label7.Visible = true; return; }
                if (comboBox1.Text.Trim() == "") { label8.Visible = true; return; }

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Environment.CurrentDirectory + "/UrlSet.xml");
                XmlNode nodeList = xmlDoc.SelectSingleNode("URL");
                XmlNodeList nodeList1 = nodeList.SelectNodes("URL_TYPE");
                int stop = 0;
                foreach (XmlNode node in nodeList1)
                {
                    if (!node.HasChildNodes)
                    {
                        node.RemoveAll();
                        xmlDoc.Save(Environment.CurrentDirectory + "/UrlSet.xml");
                        continue;
                    }
                      

                    if (stop == 1) break;
                    XmlNodeList nodename = node.SelectNodes("name");
                    foreach (XmlNode obj in nodename)
                    {
                        if (obj.InnerText != "")
                        {

                            if (obj.InnerText.Split('|')[5].ToString() == comboBox2.Text.Trim())
                            {
                                XmlElement xe1 = xmlDoc.CreateElement("name");//创建一个<name>节点 
                                int is_home = checkBox1.Checked == true ? 1 : 0;
                                xe1.InnerText = textBox1.Text.Trim() + "|" + textBox2.Text.Trim() + "|" + comboBox1.Text.Trim() + "|" + is_home + "|" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "|" + comboBox2.Text.Trim() + "|" + Guid.NewGuid();
                                node.AppendChild(xe1);
                                xmlDoc.Save(Environment.CurrentDirectory + "/UrlSet.xml");
                                MessageBox.Show("设置成功");
                                stop = 1;
                                break;
                            }
                        }
                        else
                            obj.RemoveAll();
                    }

                }


                //string sql = string.Format("insert into URL_LIST values('{0}','{1}','{2}','{3}','{4}','{5}',{6})",
                //Guid.NewGuid(), textBox1.Text.Trim(), textBox2.Text.Trim(), comboBox1.Text.Trim(), comboBox2.Text.Trim(),
                //DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), is_nome);
                //int i = acc.InsertData(sql);
                //if (i > 0)
                //    MessageBox.Show("设置成功");
                //else
                //    MessageBox.Show("设置失败");
            }
            catch (Exception)
            {

            }
          
        }

        //声明一个委托    
        public delegate void DisplayUpdate();
        //声明事件    
        public event DisplayUpdate ShowUpdate;
        private void button2_Click_1(object sender, EventArgs e)
        {
            ShowUpdate();
            this.Close();

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form4 f2 = new Form4();
            f2.ShowUpdate += Refresh_Method;
            f2.ShowDialog();
        }
    }
}
