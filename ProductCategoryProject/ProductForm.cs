using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductCategoryProject.Services;
using ProductCategoryProject.Models;

namespace ProductCategoryProject
{
    public partial class ProductForm : Form
    {
        Services.ProductBusiness business = new ProductBusiness();
        Services.CategoriesBusiness categories = new CategoriesBusiness();
        public ProductForm()
        {
            InitializeComponent();
            foreach (var item in categories.GetCategories())
            {
                comboBox1.Items.Add(item.Name);
            }
            foreach (var item in business.GetProducts())
            {
                comboBox2.Items.Add(item.Name);
            }
            foreach (var item in business.GetProducts())
            {
                comboBox5.Items.Add(item.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = business.GetProducts();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Models.Products products = new Products();
            products.Name = textBox1.Text;
            products.Price = float.Parse(textBox2.Text);
            products.Description = textBox3.Text;
            Models.Categories category = categories.GetCategories().Where(x => x.Name == comboBox1.Text).Select(n => n).FirstOrDefault();
            products.Category = category;
            products.CategoryId = category.Id;
            products.CategoryName = category.Name;
            business.Add(products);
            MessageBox.Show("Ürün başarıyla eklendi.", "Başarılı");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            Models.Products products = business.GetProducts().Where(x => x.Name == comboBox2.Text).Select(n => n).FirstOrDefault();
            textBox6.Text = products.Name;
            textBox5.Text = products.Price.ToString();
            textBox4.Text = products.Description;
            comboBox3.Text = products.CategoryName;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Models.Products products = business.GetProducts().Where(x => x.Name == comboBox2.Text).Select(n => n).FirstOrDefault();
            products.Name = textBox6.Text;
            products.Price = float.Parse(textBox5.Text);
            products.Description = textBox4.Text;
            business.Edit(products);
            MessageBox.Show("Ürün başarıyla düzenlendi.", "Başarılı");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            Models.Products products = business.GetProducts().Where(x => x.Name == comboBox5.Text).Select(n => n).FirstOrDefault();
            textBox9.Text = products.Name;
            textBox8.Text = products.Price.ToString();
            textBox7.Text = products.Description;
            comboBox4.Text = products.CategoryName;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Models.Products products = new Products();
            products.Name = textBox9.Text;
            products.Price = float.Parse(textBox8.Text);
            products.Description = textBox7.Text;
            business.Remove(products);
            MessageBox.Show("Ürün başarıyla silindi.", "Başarılı");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            this.Hide();
            main.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            this.Hide();
            main.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            this.Hide();
            main.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            this.Hide();
            main.Show();
        }
    }
}
