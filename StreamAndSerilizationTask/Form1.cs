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
using System.Xml.Linq;
using System.Xml.Serialization;

namespace StreamAndSerilizationTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateDirectory_Click(object sender, EventArgs e)
        {
            string path = @"F:\TestDirectory2";
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
            string path = @"F:\TestDirectory2\TestFile2.txt";
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

        private void btnBserilizeWrite_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"F:\TestDirectory2\BinaryFile1.data", FileMode.Create, FileAccess.Write);
                SerilizeProduct prod = new SerilizeProduct();
                prod.Id = Convert.ToInt32(txtProductId.Text);
                prod.Name = txtProductName.Text;
                prod.Company = txtCompany.Text;
                prod.price = Convert.ToInt32(txtPrice.Text);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, prod);
                fs.Close();
                txtProductId.Clear();
                txtProductName.Clear();
                txtCompany.Clear();
                txtPrice.Clear();
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
                FileStream fs = new FileStream(@"F:\TestDirectory2\binaryFile1.data", FileMode.Open, FileAccess.Read);
                SerilizeProduct prod = new SerilizeProduct();
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                prod = (SerilizeProduct)binaryFormatter.Deserialize(fs);
                txtProductId.Text = prod.Id.ToString();
                txtProductName.Text = prod.Name;
                txtCompany.Text = prod.Company;
                txtPrice.Text = prod.price.ToString();

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
                FileStream fs = new FileStream(@"F:\TestDirectory2\xmlFile1.xml", FileMode.Create, FileAccess.Write);
                SerilizeProduct prod = new SerilizeProduct();
                prod.Id = Convert.ToInt32(txtProductId.Text);
                prod.Name = txtProductName.Text;
                prod.Company = txtCompany.Text;
                prod.price = Convert.ToInt32(txtPrice.Text);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(SerilizeProduct));
                xmlSerializer.Serialize(fs, prod);
                fs.Close();
                txtProductId.Clear();
                txtProductName.Clear();
                txtCompany.Clear();
                txtPrice.Clear();
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
                FileStream fs = new FileStream(@"F:\TestDirectory2\xmlFile1.xml", FileMode.Open, FileAccess.Read);
                SerilizeProduct prod = new SerilizeProduct();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(SerilizeProduct));
                prod = (SerilizeProduct)xmlSerializer.Deserialize(fs);

                txtProductId.Text = prod.Id.ToString();
                txtProductName.Text = prod.Name;
                txtCompany.Text = prod.Company;
                txtPrice.Text = prod.price.ToString();

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
                FileStream fs = new FileStream(@"F:\TestDirectory2\soapFile1.soap", FileMode.Create, FileAccess.Write);
                SerilizeProduct prod = new SerilizeProduct();
                prod.Id = Convert.ToInt32(txtProductId.Text);
                prod.Name = txtProductName.Text;
                prod.Company = txtCompany.Text;
                prod.price = Convert.ToInt32(txtPrice.Text);
                SoapFormatter soapFormatter = new SoapFormatter();
                soapFormatter.Serialize(fs, prod);
                fs.Close();
                txtProductId.Clear();
                txtProductName.Clear();
                txtCompany.Clear();
                txtPrice.Clear();
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
                FileStream fs = new FileStream(@"F:\TestDirectory2\soapFile1.soap", FileMode.Open, FileAccess.Read);
                SerilizeProduct prod = new SerilizeProduct();
                SoapFormatter soapFormatter = new SoapFormatter();
                prod = (SerilizeProduct)soapFormatter.Deserialize(fs);
                txtProductId.Text = prod.Id.ToString();
                txtProductName.Text = prod.Name;
                txtCompany.Text = prod.Company;
                txtPrice.Text = prod.price.ToString();

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
                FileStream fs = new FileStream(@"F:\TestDirectory2\jsonFile1.json", FileMode.Create, FileAccess.Write);
                SerilizeProduct prod = new SerilizeProduct();
                prod.Id = Convert.ToInt32(txtProductId.Text);
                prod.Name = txtProductName.Text;
                prod.Company = txtCompany.Text;
                prod.price = Convert.ToInt32(txtPrice.Text);
                JsonSerializer.Serialize<SerilizeProduct>(fs, prod);
                fs.Close();
                txtProductId.Clear();
                txtProductName.Clear();
                txtCompany.Clear();
                txtPrice.Clear();
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
                FileStream fs = new FileStream(@"F:\TestDirectory2\jsonFile1.json", FileMode.Open, FileAccess.Read);
                SerilizeProduct prod = new SerilizeProduct();
                prod = JsonSerializer.Deserialize<SerilizeProduct>(fs);
                txtProductId.Text = prod.Id.ToString();
                txtProductName.Text = prod.Name;
                txtCompany.Text = prod.Company;
                txtPrice.Text = prod.price.ToString();

                fs.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
    

