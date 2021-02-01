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
    public partial class CategoryFormcs : Form
    {
        Services.ProductBusiness business = new ProductBusiness();
        Services.CategoriesBusiness categories = new CategoriesBusiness();
        public CategoryFormcs()
        {
            InitializeComponent();
            foreach (var item in categories.GetCategories())
            {
                comboBox1.Items.Add(item.Name);
            }
            foreach (var item in categories.GetCategories())
            {
                comboBox2.Items.Add(item.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var list = categories.GetCategories();
            listBox1.Items.Clear();
            foreach (var item in list)
            {
                listBox1.Items.Add(item.Name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Models.Categories categories_add = new Categories();
            categories_add.Name = textBox1.Text;
            categories.Add(categories_add);
            MessageBox.Show("Kategori başarıyla eklendi.", "Başarılı");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            Models.Categories category = categories.GetCategories().Where(x => x.Name == comboBox1.Text).Select(n => n).FirstOrDefault();
            textBox2.Text = category.Name;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Models.Categories category = categories.GetCategories().Where(x => x.Name == comboBox1.Text).Select(n => n).FirstOrDefault();
            category.Name = textBox2.Text;
            categories.Edit(category);
            MessageBox.Show("Kategori başarıyla düzenlendi.", "Başarılı");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Models.Categories category = categories.GetCategories().Where(x => x.Name == comboBox2.Text).Select(n => n).FirstOrDefault();
            if(!(category.Products == null))
            {
                categories.Remove(category);
                MessageBox.Show("Kategori başarıyla silindi.", "Başarılı");
            }
            else
            {
                MessageBox.Show("Kategori içerisinde ürün tanımlı.","HATA");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            this.Hide();
            main.Show();
        }

        private void button7_Click(object sender, EventArgs e)
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
    }
}
