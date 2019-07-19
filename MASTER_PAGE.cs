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

namespace WindowsFormsApp1
{
    public partial class MASTER_PAGE : Form
    {
        public MASTER_PAGE()
        {
            InitializeComponent();
        }

        private void MASTER_PAGE_Load(object sender, EventArgs e)
        {
           
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {



                if (textBox1.Text.Trim() == "") { label5.Visible = true; return; }
                if (textBox2.Text.Trim() == "") { label6.Visible = true; return; }
              
                //写入类型XML
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Environment.CurrentDirectory + "/UrlSetMaster.xml");
                XmlNode nodeList = xmlDoc.SelectSingleNode("URL");

                nodeList.RemoveAll();
                XmlElement xe1 = xmlDoc.CreateElement("NAME");//创建一个<name>节点 
                xe1.InnerText = textBox1.Text.Trim() + "|" + textBox2.Text.Trim() + "|" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                nodeList.AppendChild(xe1);
                xmlDoc.Save(Environment.CurrentDirectory + "/UrlSetMaster.xml");

                MessageBox.Show("设置成功");
                this.Close();


            }
            catch (Exception ee)
            {

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
