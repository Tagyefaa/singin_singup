using System;
using System.Collections;
using System.Windows.Forms;

namespace singin_singup
{
    public partial class Form1 : Form
    {
        // İstifadəçi məlumatlarını müvəqqəti saxlamaq üçün siyahılar
        ArrayList usernames = new ArrayList();
        ArrayList passwords = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }

        // Form yüklənəndə şifrələri gizlətmək
        private void Form1_Load(object sender, EventArgs e)
        {
            if (textBox2 != null) textBox2.UseSystemPasswordChar = true;
            if (textBox3 != null) textBox3.UseSystemPasswordChar = true;
        }

        // SIGN UP (Qeydiyyat) düyməsi - button2
        private void button2_Click(object sender, EventArgs e)
        {
            string user = textBox4.Text.Trim();
            string pass = textBox3.Text;

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Xana boş olmaz", "Bildiriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (usernames.Contains(user))
            {
                MessageBox.Show("Bu istifadəçi adı artıq mövcuddur", "Bildiriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            usernames.Add(user);
            passwords.Add(pass);

            MessageBox.Show("Qeydiyyat uğurla tamamlandı!", "Bildiriş", MessageBoxButtons.OK, MessageBoxIcon.Information);

            textBox4.Clear();
            textBox3.Clear();
            checkBox2.Checked = false;
        }

        // SIGN IN (Daxil olma) düyməsi - button1
        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text.Trim();
            string pass = textBox2.Text;

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Xana boş olmaz", "Bildiriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = usernames.IndexOf(user);

            if (index >= 0 && passwords[index].ToString() == pass)
            {
                MessageBox.Show("Sistemə daxil oldunuz!", "Bildiriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                textBox2.Clear();
                checkBox1.Checked = false;
            }
            else
            {
                MessageBox.Show("İstifadəçi adı və ya şifrə yanlışdır", "Bildiriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sign In üçün şifrəni göstər/gizlə - checkBox1
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }

        // Sign Up üçün şifrəni göstər/gizlə - checkBox2
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.UseSystemPasswordChar = !checkBox2.Checked;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
