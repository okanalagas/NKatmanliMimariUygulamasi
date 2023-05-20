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
    public partial class Form1 : Form
    {
        CategoryRepository _categoryRepository; // kategori işlemlerini yapacak kısım
        CategoryVM _selected; //güncelle sil ve listele işlemleri için....
        public Form1()
        {
            InitializeComponent();
            _categoryRepository = new CategoryRepository(); // form yüklendiğinde instance alıyoruz. 
        }
        void ListCategories() //Her işlemden sonra listeleme yapacağımız için tekrar tekrar yazmaktansa metot oluşturduk. //silinmiş öğeleri getirmemesi için bll gidip baserepository queryable select metoduna where şartı getiriyoruz.
        {
            listBoxCategories.DataSource = _categoryRepository.Select(x => new CategoryVM
            {
                Id = x.Id,
                CategoryName = x.CategoryName,
                Description = x.Description,
                Products = x.Products
            }).ToList();
            //kullanıcının karşısına categoryvm çıkaracağımız için onu kullanacak bir metot yazdık. CAtegory repository tipinde oldugu için x categorye dönüşür ve onun verileri category vm ye taşınır....
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ListCategories();
        }

        private void buttonList_Click(object sender, EventArgs e)
        {
            ListCategories();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim())) //textbox name boşlukları kaldırırp dolu mu değil mi kontrol ediyoruz. 
            {
                MessageBox.Show("Lütfen kategori ismi giriniz...");  //boşsa hata verecek
                return;
            }

            //iften kurtulursa kod aşağı devam edecek

            Category c = new Category    //yeni nesne ürettiğimizfden veritabanına gideceği için category classı ile işlem yapılır
            {
                CategoryName = txtName.Text,
                Description = txtDescription.Text
            };
            _categoryRepository.Add(c); // c yi ekle 
            ListCategories();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (_selected != null)
            {
                Category toBeUpdatedCategory = _categoryRepository.Find(_selected.Id);
                toBeUpdatedCategory.CategoryName = txtName.Text;
                toBeUpdatedCategory.Description = txtDescription.Text;
                _categoryRepository.Update(toBeUpdatedCategory);
                ListCategories();
                _selected = null;
                txtName.Text = null;
                txtDescription.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Lütfen bir kategori seçiniz..");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (_selected != null) //seçilen öğe varsa... 
            {
                Category toBedeletedCategory = _categoryRepository.Find(_selected.Id); // seçtiğimiz itemin idsini bul ve category tipinde yakala.
                _categoryRepository.Delete(toBedeletedCategory); //Vm üzerinden bulduğunu sil
                ListCategories();
                _selected = null; // işimiz bittikten sonra nulluyoruz...
                txtName.Text = string.Empty;
                txtDescription.Text = string.Empty; //textboxları boşaltıyoruz... 
            }
            else
            {
                MessageBox.Show("Lütfen bir kategori seçiniz..");
            }
        }

        private void listBoxCategories_Click(object sender, EventArgs e) //listboxta bir yere tıkladığımızda o veririn textleri texboxlara gelsin diye yazdık...
        {
            if (listBoxCategories.SelectedIndex > -1)
            {
                _selected = listBoxCategories.SelectedItem as CategoryVM;
                txtName.Text = _selected.CategoryName;
                txtDescription.Text = _selected.Description;
            }
        }

        private void buttonForm2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog(); //Dialog ile gösterilinde form1 üzerinden bir işlem gerçekleştirilmez...
        }
    }
}
