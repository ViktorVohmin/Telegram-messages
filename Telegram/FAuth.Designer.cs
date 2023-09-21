namespace Telegram
{
    partial class FAuth
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label1 = new Label();
            PhoneNumber = new TextBox();
            Login = new Button();
            tabPage2 = new TabPage();
            AuthTokenLabel = new Label();
            label2 = new Label();
            CodeTextBox = new TextBox();
            entry = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.Padding = new Point(0, 0);
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(348, 141);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(PhoneNumber);
            tabPage1.Controls.Add(Login);
            tabPage1.Location = new Point(4, 5);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(340, 132);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 10);
            label1.Name = "label1";
            label1.Size = new Size(104, 15);
            label1.TabIndex = 2;
            label1.Text = "Номер телефона:";
            // 
            // PhoneNumber
            // 
            PhoneNumber.Location = new Point(17, 28);
            PhoneNumber.Name = "PhoneNumber";
            PhoneNumber.Size = new Size(204, 23);
            PhoneNumber.TabIndex = 1;
            // 
            // Login
            // 
            Login.Location = new Point(17, 57);
            Login.Name = "Login";
            Login.Size = new Size(91, 23);
            Login.TabIndex = 0;
            Login.Text = "Авторизация";
            Login.UseVisualStyleBackColor = true;
            Login.Click += Login_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(AuthTokenLabel);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(CodeTextBox);
            tabPage2.Controls.Add(entry);
            tabPage2.Location = new Point(4, 5);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(340, 132);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // AuthTokenLabel
            // 
            AuthTokenLabel.AutoSize = true;
            AuthTokenLabel.Location = new Point(17, 87);
            AuthTokenLabel.Name = "AuthTokenLabel";
            AuthTokenLabel.Size = new Size(38, 15);
            AuthTokenLabel.TabIndex = 6;
            AuthTokenLabel.Text = "label3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 14);
            label2.Name = "label2";
            label2.Size = new Size(103, 15);
            label2.TabIndex = 5;
            label2.Text = "Код авторизаций:";
            // 
            // CodeTextBox
            // 
            CodeTextBox.Location = new Point(17, 32);
            CodeTextBox.Name = "CodeTextBox";
            CodeTextBox.Size = new Size(204, 23);
            CodeTextBox.TabIndex = 4;
            // 
            // entry
            // 
            entry.Location = new Point(17, 61);
            entry.Name = "entry";
            entry.Size = new Size(91, 23);
            entry.TabIndex = 3;
            entry.Text = "Вход";
            entry.UseVisualStyleBackColor = true;
            entry.Click += entry_Click;
            // 
            // FAuth
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(348, 141);
            Controls.Add(tabControl1);
            Name = "FAuth";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button Login;
        private TextBox PhoneNumber;
        private Label label1;
        private Label label2;
        private TextBox CodeTextBox;
        private Button entry;
        private Label AuthTokenLabel;
    }
}