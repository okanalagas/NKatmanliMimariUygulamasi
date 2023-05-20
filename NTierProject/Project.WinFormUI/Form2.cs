using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.Entities.Models;
using Project.WinFormUI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.WinFormUI
{
    public partial class Form2 : Form
    {
        ProductRepository _productRepository;  //bu sınıflarla ilgili işlem yapğacağımız için...
        CategoryRepository _categoryRepository;
        ProductVM _selected;
        public Form2()
        {
            InitializeComponent();
            _categoryRepository = new CategoryRepository();
            _productRepository = new ProductRepository();
        }
        void ListCategories()
        {
            comboBoxCategories.DataSource = _categoryRepository.Select(x => new CategoryVM
            {
                Id = x.Id,
                CategoryName = x.CategoryName,
                Description = x.Description
            }).ToList();
            comboBoxCategories.DisplayMember = "CategoryName";       //vm varsa bunlara gerek yoktur üstelik vm de birden fazla property                                                                gösterilebilir. 
            comboBoxCategories.ValueMember = "Id";
        }
        void ListProducts()
        {
            listBoxProducts.DataSource = _productRepository.Select(x => new ProductVM
            {
                Id = x.Id,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                CategoryName = x.Category == null ? "Kategorisi Yok" : x.Category.CategoryName, //ternary if
                CategoryId = x.CategoryId
            }).ToList(); //queryable oldugundan to list yapıyoruz sonunu
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            ListCategories();
            ListProducts();
        }

        private void buttonList_Click(object sender, EventArgs e)
        {
            ListProducts();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try    //fiyata sayısal değer girip girmediğini kontrol etmek için .... 
            {
                Product p = new Product();
                p.ProductName = txtName.Text;
                p.UnitPrice = Convert.ToDecimal(txtPrice.Text);
                if (comboBoxCategories.SelectedIndex > -1)
                {
                    p.CategoryId = Convert.ToInt32(comboBoxCategories.SelectedValue);
                }
                _productRepository.Add(p);
                ListProducts();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selected != null)
                {
                    Product toBeUpdated = _productRepository.Find(_selected.Id);
                    toBeUpdated.ProductName = txtName.Text;
                    toBeUpdated.UnitPrice = Convert.ToDecimal(txtPrice.Text);
                    if (comboBoxCategories.SelectedIndex > -1)
                    {
                        toBeUpdated.CategoryId = Convert.ToInt32(comboBoxCategories.SelectedValue);
                    }
                    _productRepository.Update(toBeUpdated);
                    ListProducts();
                    _selected = null;
                    txtName.Text = txtPrice.Text = null; 
                    comboBoxCategories.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Lütfen bir ürün seçiniz...");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (_selected != null)
            {
                Product toBeDeleted = _productRepository.Find(_selected.Id);
                _productRepository.Delete(toBeDeleted);
                ListProducts();
                _selected = null;
                txtName.Text = txtPrice.Text = null;
                comboBoxCategories.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Lütfen bir ürün seçiniz...");
            }
        }

        private void listBoxProducts_Click(object sender, EventArgs e)
        {
            if (listBoxProducts.SelectedIndex > -1)
            {
                _selected = (ProductVM)listBoxProducts.SelectedItem;
                txtName.Text = _selected.ProductName;
                txtPrice.Text = _selected.UnitPrice.ToString();
                comboBoxCategories.SelectedValue = _selected.CategoryId != null ? _selected.CategoryId.Value : -1; //kategori id boş değilse value olarak id ver boş ise hiç bir şey çıkmasın...
            }
        }
    }
}
