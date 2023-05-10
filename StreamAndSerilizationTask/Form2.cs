using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace StreamAndSerilizationTask
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateDirectory_Click(object sender, EventArgs e)
        {
            string path = @"F:\TestDirectory3";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            try
            {
                if (directoryInfo.Exists)
                {
                    MessageBox.Show("Directory is exist");
                }
                else
                {
                    directoryInfo.Create();
                    MessageBox.Show("Directory Created");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            string path = @"F:\TestDirectory3\TestFile3.txt";
            FileInfo fileInfo = new FileInfo(path);
            try
            {
                if (fileInfo.Exists)
                {
                    MessageBox.Show("File is exsist");
                }
                else
                {
                    fileInfo.Create();
                    MessageBox.Show("File Created");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnBSerilizeWrite_Click(object sender, EventArgs e)
        {

            try
            {
                FileStream fs = new FileStream(@"F:\TestDirectory3\BinaryFile2.data", FileMode.Create, FileAccess.Write);
                Student student = new Student();
                student.RollNo = Convert.ToInt32(txtRollNo.Text);
                student.Name = txtName.Text;
                student.Per = Convert.ToInt32(txtPercentage.Text);
                student.City = txtCity.Text;

                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, student);
                fs.Close();
                txtRollNo.Clear();
                txtName.Clear();
                txtPercentage.Clear();
                txtCity.Clear();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBSerilizeRead_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"F:\TestDirectory3\binaryFile2.data", FileMode.Open, FileAccess.Read);
                Student student = new Student();
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                student = (Student)binaryFormatter.Deserialize(fs);
                txtRollNo.Text = student.RollNo.ToString();
                txtName.Text = student.Name;
                txtPercentage.Text = student.Per.ToString();
                txtCity.Text = student.City;

                fs.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXmlWrite_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"F:\TestDirectory3\xmlFile2.xml", FileMode.Create, FileAccess.Write);
                Student student = new Student();
                student.RollNo = Convert.ToInt32(txtRollNo.Text);
                student.Name = txtName.Text;
                student.Per = Convert.ToInt32(txtPercentage.Text);
                student.City = txtCity.Text;
                XmlSerializer serializer = new XmlSerializer(typeof(Student));

                serializer.Serialize(fs, student);
                fs.Close();
                txtRollNo.Clear();
                txtName.Clear();
                txtPercentage.Clear();
                txtCity.Clear();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXmlRead_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"F:\TestDirectory3\xmlFile2.xml", FileMode.Open, FileAccess.Read);
                Student student = new Student();
                XmlSerializer serializer = new XmlSerializer(typeof(Student));
                student = (Student)serializer.Deserialize(fs);
                txtRollNo.Text = student.RollNo.ToString();
                txtName.Text = student.Name;
                txtPercentage.Text = student.Per.ToString();
                txtCity.Text = student.City;

                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSoapWrite_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"F:\TestDirectory3\soapFile2.soap", FileMode.Create, FileAccess.Write);
                Student student = new Student();
                student.RollNo = Convert.ToInt32(txtRollNo.Text);
                student.Name = txtName.Text;
                student.Per = Convert.ToInt32(txtPercentage.Text);
                student.City = txtCity.Text;
                SoapFormatter soapFormatter = new SoapFormatter();
                soapFormatter.Serialize(fs, student);
                fs.Close();
                txtRollNo.Clear();
                txtName.Clear();
                txtPercentage.Clear();
                txtCity.Clear();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSoapRead_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"F:\TestDirectory3\soapFile2.soap", FileMode.Open, FileAccess.Read);
                Student student = new Student();
                SoapFormatter soapFormatter = new SoapFormatter();
                student = (Student)soapFormatter.Deserialize(fs);
                txtRollNo.Text = student.RollNo.ToString();
                txtName.Text = student.Name;
                txtPercentage.Text = student.Per.ToString();
                txtCity.Text = student.City;

                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnJsonWrite_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"F:\TestDirectory3\jsonFile2.json", FileMode.Create, FileAccess.Write);
                Student student = new Student();
                student.RollNo = Convert.ToInt32(txtRollNo.Text);
                student.Name = txtName.Text;
                student.Per = Convert.ToInt32(txtPercentage.Text);
                student.City = txtCity.Text;
                JsonSerializer.Serialize<Student>(fs, student);
                fs.Close();
                txtRollNo.Clear();
                txtName.Clear();
                txtPercentage.Clear();
                txtCity.Clear();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnJsonRead_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"F:\TestDirectory3\jsonFile2.json", FileMode.Open, FileAccess.Read);
                Student student = new Student();
                student = JsonSerializer.Deserialize<Student>(fs);
                txtRollNo.Text = student.RollNo.ToString();
                txtName.Text = student.Name;
                txtPercentage.Text = student.Per.ToString();
                txtCity.Text = student.City;

                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
