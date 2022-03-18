using Entities.Dtos.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebAPIWindowsForm
{
    public partial class Form1 : Form
    {
        private string url = "http://localhost:11554/api/";
        private int selectedID = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            await DataGridViewFill();
            CmbGenderFill();
        }

        void CmbGenderFill()
        {
            List<Gender> genders = new List<Gender>();
            genders.Add(new Gender() { Id = 1, GenderName = "Erkek" });
            genders.Add(new Gender() { Id = 2, GenderName = "Kadın" });
            cmbGender.DataSource = genders;
            cmbGender.DisplayMember = "GenderName";
            cmbGender.ValueMember = "Id";
        }

        class Gender
        {
            public int Id { get; set; }
            public string GenderName { get; set; }
        }

        private async Task DataGridViewFill()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var users = await httpClient.GetFromJsonAsync<List<UserDetailDto>>(url + "Users/GetList");
                dataGridView1.DataSource = users;
            }
        }

        void ClearForm()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtAdres.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cmbGender.SelectedValue = 0;
            dateDateOfBirth.Value = DateTime.Now;

            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                UserAddDto userAddDto = new UserAddDto()
                {
                    FirstName = txtFirstName.Text,
                    Adress = txtAdres.Text,
                    DateOfBirth = Convert.ToDateTime(dateDateOfBirth.Text),
                    Email = txtEmail.Text,
                    Gender = cmbGender.Text == "Erkek" ? true : false,
                    LastName = txtLastName.Text,
                    Password = txtPassword.Text,
                    UserName = txtUserName.Text
                };
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(url + "Users/Add", userAddDto);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Ekleme İşlemi Başaralı..");
                    await DataGridViewFill();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Ekleme İşlemi Başarısız..");
                }
            }
        }

        private async void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            selectedID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            using (HttpClient httpClient = new HttpClient())
            {
                var users = await httpClient.GetFromJsonAsync<UserDto>(url + "Users/GetById/" + selectedID);

                txtFirstName.Text = users.FirstName;
                txtLastName.Text = users.LastName;
                txtAdres.Text = users.Adress;
                txtUserName.Text = users.UserName;
                txtPassword.Text = string.Empty;
                txtEmail.Text = users.Email;
                cmbGender.SelectedValue = users.Gender == true ? 1 : 2;
                dateDateOfBirth.Value = users.DateOfBirth;
            }

            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                UserUpdateDto userUpdateDto = new UserUpdateDto()
                {
                    Id = selectedID,
                    FirstName = txtFirstName.Text,
                    Adress = txtAdres.Text,
                    DateOfBirth = Convert.ToDateTime(dateDateOfBirth.Text),
                    Email = txtEmail.Text,
                    Gender = cmbGender.Text == "Erkek" ? true : false,
                    LastName = txtLastName.Text,
                    Password = txtPassword.Text,
                    UserName = txtUserName.Text
                };
                HttpResponseMessage response = await httpClient.PutAsJsonAsync(url + "Users/Update", userUpdateDto);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Düzenleme İşlemi Başaralı..");
                    await DataGridViewFill();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Düzenleme İşlemi Başarısız..");
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.DeleteAsync(url + "Users/Delete/" + selectedID);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Silme İşlemi Başaralı..");
                    await DataGridViewFill();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Silme İşlemi Başarısız..");
                }
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await DataGridViewFill();
        }
    }
}
