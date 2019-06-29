using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace UNINET_3._0
{
    public partial class Form1 : Form
    {
        public List<Discipline> dis_s = new List<Discipline>();
        Discipline history = new Discipline();

        int lbszX = 120, lbszY = 30;
        int tbszX = 30, tbszY = 30;
        int btnszX = 75, btnszY = 30;

        int posX = 40, posY = 0;

        int it = 1;

        int att, final;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            XmlSerializer xs = new XmlSerializer(typeof(List<Discipline>));

            FileStream fs1 = new FileStream("Disciplines.xml", FileMode.Open, FileAccess.Read);
            List<Discipline> dis_s1 = xs.Deserialize(fs1) as List<Discipline>;

            if (dis_s1.Count != 0)
            {
                Label name = new Label();
                name.Location = new Point(30, 10);
                name.Size = new Size(lbszX, lbszY);
                name.Font = new Font(button1.Font.Name, button1.Font.Size * 2 / 3, button1.Font.Style);
                name.Text = "Discipline";
                Controls.Add(name);
            }

            foreach (var dis in dis_s1)
            {
                dis_s.Add(dis);

                att = 0;
                final = 0;

                posX = 120;
                posY += 40;

                Label label = new Label();
                label.Location = new Point(30, posY);
                label.Size = new Size(lbszX, lbszY);
                label.Font = new Font(button1.Font.Name, button1.Font.Size, button1.Font.Style);
                label.ForeColor = Color.Chocolate;
                label.Text = it.ToString() + ". " + dis.disname;
                Controls.Add(label);
                it++;

                for (int i = 0; i < 5; i++)
                {
                    posX += tbszX * 5 / 4;

                    Label tbname = new Label();
                    tbname.Location = new Point(posX, 10);
                    tbname.Size = new Size(tbszX, tbszY);
                    tbname.Name = "tbname" + (i + 1);
                    tbname.Font = new Font(button1.Font.Name, button1.Font.Size * 2 / 3, button1.Font.Style);
                    if (i == 0)
                        tbname.Text = "q1";
                    else if (i == 1)
                        tbname.Text = "Mid";
                    else if (i == 2)
                        tbname.Text = "q3";
                    else if (i == 3)
                        tbname.Text = "End";
                    else
                        tbname.Text = "Fin";
                    Controls.Add(tbname);

                    TextBox textBox = new TextBox();
                    textBox.Location = new Point(posX, posY);
                    textBox.Size = new Size(tbszX, tbszY);
                    textBox.Name = "textBox" + (i + 1);
                    textBox.Font = new Font(button1.Font.Name, button1.Font.Size, button1.Font.Style);
                    textBox.BackColor = Color.Chocolate;
                    textBox.ForeColor = Color.White;
                    textBox.TextAlign = HorizontalAlignment.Center;
                    textBox.ReadOnly = true;
                    Controls.Add(textBox);
                    if (textBox.Name == "textBox1")
                    {
                        if (dis.q1 == "")
                            dis.q1 = "0";
                        textBox.Text = dis.q1;
                    }
                    else if (textBox.Name == "textBox2")
                    {
                        if (dis.q2 == "")
                            dis.q2 = "0";
                        textBox.Text = dis.q2;
                    }
                    else if (textBox.Name == "textBox3")
                    {
                        if (dis.q3 == "")
                            dis.q3 = "0";
                        textBox.Text = dis.q3;
                    }
                    else if (textBox.Name == "textBox4")
                    {
                        if (dis.q4 == "")
                            dis.q4 = "0";
                        textBox.Text = dis.q4;
                    }
                    else if (textBox.Name == "textBox5")
                    {
                        if (dis.fin == "")
                            dis.fin = "0";
                        textBox.Text = dis.fin;
                    }
                    if (i != 4)
                    {
                        try
                        {
                            att += Convert.ToInt32(textBox.Text);
                        }
                        catch
                        {
                            MessageBox.Show("Неверный формат значений!");
                        }
                    }
                    else
                    {
                        final = Convert.ToInt32(textBox.Text);
                    }
                }

                Label crlabel = new Label();
                crlabel.Location = new Point(posX + tbszX * 3 / 2, 10);
                crlabel.Size = new Size(tbszX * 2, tbszY);
                crlabel.Font = new Font(button1.Font.Name, button1.Font.Size * 2 / 3, button1.Font.Style);
                crlabel.Text = "Credits";
                Controls.Add(crlabel);

                Label cr = new Label();
                cr.Location = new Point(posX + tbszX * 2, posY);
                cr.Size = new Size(tbszX, tbszY);
                cr.Font = new Font(button1.Font.Name, button1.Font.Size, button1.Font.Style);
                cr.ForeColor = Color.Chocolate;
                cr.Text = dis.credits;
                Controls.Add(cr);

                Button btn = new Button();
                btn.Name = dis.disname;
                btn.Location = new Point(posX + lbszX, posY);
                btn.Size = new Size(btnszX, btnszY);
                btn.Font = new Font(button1.Font.Name, button1.Font.Size, button1.Font.Style);
                btn.BackColor = Color.Maroon;
                btn.ForeColor = Color.White;
                btn.Text = "Delete";
                btn.Click += btn_Clicked;
                Controls.Add(btn);

                Label attres = new Label();
                attres.Location = new Point(posX + 7 * lbszX / 4, posY);
                attres.Size = new Size(lbszX / 2, lbszY);
                attres.Font = new Font(button1.Font.Name, button1.Font.Size, button1.Font.Style);
                attres.ForeColor = Color.Chocolate;
                attres.Text = att.ToString() + " / 60";
                Controls.Add(attres);

                Label finres = new Label();
                finres.Location = new Point(posX + 5 * lbszX / 2, posY);
                finres.Size = new Size(lbszX / 2, lbszY);
                finres.Font = new Font(button1.Font.Name, button1.Font.Size, button1.Font.Style);
                finres.ForeColor = Color.Chocolate;
                finres.Text = final.ToString() + " / 40";
                Controls.Add(finres);
            }
            fs1.Close();

        }

        private void btn_Clicked(object sender, EventArgs e)
        {
            foreach (Discipline dis in dis_s.ToArray())
            {
                if (dis.disname == (sender as Button).Name)
                    dis_s.Remove(dis);
            }
            XmlSerializer xs = new XmlSerializer(typeof(List<Discipline>));

            FileStream fs = new FileStream("Disciplines.xml", FileMode.Create, FileAccess.Write);

            xs.Serialize(fs, dis_s);
            fs.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Create();
        }

        void Create()
        {
            posX = 120;
            posY += 40;
            Discipline dis = new Discipline();

            att = 0;
            final = 0;

            Form2 form2 = new Form2();

            form2.ShowDialog();

            dis.disname = form2.DisName.Text;
            dis.credits = form2.Credits.Text;

            dis_s.Add(dis);

            if (dis_s.Count == 1)
            {
                Label name = new Label();
                name.Location = new Point(30, 10);
                name.Size = new Size(lbszX, lbszY);
                name.Font = new Font(button1.Font.Name, button1.Font.Size * 2 / 3, button1.Font.Style);
                name.Text = "Discipline";
                Controls.Add(name);
            }

            Label label = new Label();
            label.Location = new Point(30, posY);
            label.Size = new Size(lbszX, lbszY);
            label.Font = new Font(button1.Font.Name, button1.Font.Size, button1.Font.Style);
            label.ForeColor = Color.Chocolate;
            label.Text = it.ToString() + ". " + dis.disname;
            Controls.Add(label);
            it++;

            
            for (int i=0;i<5;i++)
            {
                posX += tbszX * 5 / 4;

                dis.q1 = form2.textBox1.Text;
                dis.q2 = form2.textBox2.Text;
                dis.q3 = form2.textBox3.Text;
                dis.q4 = form2.textBox4.Text;
                dis.fin = form2.textBox5.Text;

                if (dis_s.Count == 1)
                {
                    Label tbname = new Label();
                    tbname.Location = new Point(posX, 10);
                    tbname.Size = new Size(tbszX, tbszY);
                    tbname.Name = "tbname" + (i + 1);
                    tbname.Font = new Font(button1.Font.Name, button1.Font.Size * 2 / 3, button1.Font.Style);
                    if (i == 0)
                        tbname.Text = "q1";
                    else if (i == 1)
                        tbname.Text = "Mid";
                    else if (i == 2)
                        tbname.Text = "q3";
                    else if (i == 3)
                        tbname.Text = "End";
                    else
                        tbname.Text = "Fin";
                    Controls.Add(tbname);
                }

                TextBox textBox = new TextBox();
                textBox.Location = new Point(posX, posY);
                textBox.Size = new Size(tbszX, tbszY);
                textBox.Font = new Font(button1.Font.Name, button1.Font.Size, button1.Font.Style);
                textBox.BackColor = Color.Chocolate;
                textBox.ForeColor = Color.White;
                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.ReadOnly = true;
                textBox.Name = "textBox" + (i+1);

                if (textBox.Name == "textBox1")
                {
                    if (dis.q1 == "")
                        dis.q1 = "0";
                    textBox.Text = dis.q1;
                }
                else if (textBox.Name == "textBox2")
                {
                    if (dis.q2 == "")
                        dis.q2 = "0";
                    textBox.Text = dis.q2;
                }
                else if (textBox.Name == "textBox3")
                {
                    if (dis.q3 == "")
                        dis.q3 = "0";
                    textBox.Text = dis.q3;
                }
                else if (textBox.Name == "textBox4")
                {
                    if (dis.q4 == "")
                        dis.q4 = "0";
                    textBox.Text = dis.q4;
                }
                else if (textBox.Name == "textBox5")
                {
                    if (dis.fin == "")
                        dis.fin = "0";
                    textBox.Text = dis.fin;
                }

                Controls.Add(textBox);

                if (i != 4)
                {
                    try
                    {
                        att += Convert.ToInt32(textBox.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Неверный формат значений!");
                    }
                }

            }

            if (dis_s.Count == 1)
            {
                Label crlabel = new Label();
                crlabel.Location = new Point(posX + tbszX * 3 / 2, 10);
                crlabel.Size = new Size(tbszX * 2, tbszY);
                crlabel.Font = new Font(button1.Font.Name, button1.Font.Size * 2 / 3, button1.Font.Style);
                crlabel.Text = "Credits";
                Controls.Add(crlabel);
            }

            Label cr = new Label();
            cr.Location = new Point(posX + tbszX * 2, posY);
            cr.Size = new Size(tbszX, tbszY);
            cr.Font = new Font(button1.Font.Name, button1.Font.Size, button1.Font.Style);
            cr.ForeColor = Color.Chocolate;
            cr.Text = dis.credits;
            Controls.Add(cr);

            Button btn = new Button();
            btn.Name = dis.disname;
            btn.Location = new Point(posX + lbszX, posY);
            btn.Size = new Size(btnszX, btnszY);
            btn.Font = new Font(button1.Font.Name, button1.Font.Size, button1.Font.Style);
            btn.BackColor = Color.Maroon;
            btn.ForeColor = Color.White;
            btn.Text = "Delete";
            btn.Click += btn_Clicked;
            Controls.Add(btn);

            Label attres = new Label();
            attres.Location = new Point(posX + 2 * lbszX, posY);
            attres.Size = new Size(lbszX, lbszY);
            attres.Font = new Font(button1.Font.Name, button1.Font.Size, button1.Font.Style);
            attres.ForeColor = Color.Chocolate;
            attres.Text = att.ToString() + " / 60";
            Controls.Add(attres);

            Label finres = new Label();
            finres.Location = new Point(posX + 3 * lbszX, posY);
            finres.Size = new Size(lbszX, lbszY);
            finres.Font = new Font(button1.Font.Name, button1.Font.Size, button1.Font.Style);
            finres.ForeColor = Color.Chocolate;
            finres.Text = final.ToString() + " / 40";
            Controls.Add(finres);

            XmlSerializer xs = new XmlSerializer(typeof(List<Discipline>));

            FileStream fs = new FileStream("Disciplines.xml", FileMode.Create, FileAccess.Write);

            xs.Serialize(fs, dis_s);
            fs.Close();
        }
    }
}
