namespace Knjižnica
{
    partial class FormPosudbe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Refresh = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.Delete = new System.Windows.Forms.Button();
            this.Update = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDatumPovratka = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtDatumPreuzimanja = new System.Windows.Forms.TextBox();
            this.comboBoxKnjigaID = new System.Windows.Forms.ComboBox();
            this.comboBoxClanID = new System.Windows.Forms.ComboBox();
            this.comboBoxZaposlenikID = new System.Windows.Forms.ComboBox();
            this.comboBoxKnjiznicaID = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Refresh
            // 
            this.Refresh.Location = new System.Drawing.Point(978, 65);
            this.Refresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(112, 35);
            this.Refresh.TabIndex = 24;
            this.Refresh.Text = "Refresh";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(474, 245);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 20);
            this.label8.TabIndex = 23;
            this.label8.Text = "Search By Name";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(639, 241);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(164, 26);
            this.txtSearch.TabIndex = 22;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(824, 65);
            this.Delete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(112, 35);
            this.Delete.TabIndex = 43;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(668, 65);
            this.Update.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(112, 35);
            this.Update.TabIndex = 42;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(526, 65);
            this.Clear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(112, 35);
            this.Clear.TabIndex = 41;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(390, 65);
            this.Add.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(112, 35);
            this.Add.TabIndex = 18;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(248, 73);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 20);
            this.label7.TabIndex = 39;
            this.label7.Text = "Knjižnica ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(248, 130);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 38;
            this.label6.Text = "Knjiga ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(248, 187);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 37;
            this.label5.Text = "Član ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(248, 245);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 36;
            this.label4.Text = "Zaposlenik ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(248, 305);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "Datum Preuzimanja";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 367);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "Datum Povratka";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "ID";
            // 
            // txtDatumPovratka
            // 
            this.txtDatumPovratka.Location = new System.Drawing.Point(18, 362);
            this.txtDatumPovratka.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDatumPovratka.Name = "txtDatumPovratka";
            this.txtDatumPovratka.Size = new System.Drawing.Size(180, 26);
            this.txtDatumPovratka.TabIndex = 32;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(18, 10);
            this.txtID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(180, 26);
            this.txtID.TabIndex = 31;
            // 
            // txtDatumPreuzimanja
            // 
            this.txtDatumPreuzimanja.Location = new System.Drawing.Point(18, 301);
            this.txtDatumPreuzimanja.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDatumPreuzimanja.Name = "txtDatumPreuzimanja";
            this.txtDatumPreuzimanja.Size = new System.Drawing.Size(180, 26);
            this.txtDatumPreuzimanja.TabIndex = 30;
            // 
            // comboBoxKnjigaID
            // 
            this.comboBoxKnjigaID.FormattingEnabled = true;
            this.comboBoxKnjigaID.Location = new System.Drawing.Point(18, 125);
            this.comboBoxKnjigaID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxKnjigaID.Name = "comboBoxKnjigaID";
            this.comboBoxKnjigaID.Size = new System.Drawing.Size(180, 28);
            this.comboBoxKnjigaID.TabIndex = 29;
            // 
            // comboBoxClanID
            // 
            this.comboBoxClanID.FormattingEnabled = true;
            this.comboBoxClanID.Location = new System.Drawing.Point(18, 182);
            this.comboBoxClanID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxClanID.Name = "comboBoxClanID";
            this.comboBoxClanID.Size = new System.Drawing.Size(180, 28);
            this.comboBoxClanID.TabIndex = 28;
            // 
            // comboBoxZaposlenikID
            // 
            this.comboBoxZaposlenikID.FormattingEnabled = true;
            this.comboBoxZaposlenikID.Location = new System.Drawing.Point(18, 241);
            this.comboBoxZaposlenikID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxZaposlenikID.Name = "comboBoxZaposlenikID";
            this.comboBoxZaposlenikID.Size = new System.Drawing.Size(180, 28);
            this.comboBoxZaposlenikID.TabIndex = 27;
            // 
            // comboBoxKnjiznicaID
            // 
            this.comboBoxKnjiznicaID.FormattingEnabled = true;
            this.comboBoxKnjiznicaID.Items.AddRange(new object[] {
            "Select"});
            this.comboBoxKnjiznicaID.Location = new System.Drawing.Point(18, 68);
            this.comboBoxKnjiznicaID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxKnjiznicaID.Name = "comboBoxKnjiznicaID";
            this.comboBoxKnjiznicaID.Size = new System.Drawing.Size(180, 28);
            this.comboBoxKnjiznicaID.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 430);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1200, 262);
            this.dataGridView1.TabIndex = 25;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // FormPosudbe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDatumPovratka);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtDatumPreuzimanja);
            this.Controls.Add(this.comboBoxKnjigaID);
            this.Controls.Add(this.comboBoxClanID);
            this.Controls.Add(this.comboBoxZaposlenikID);
            this.Controls.Add(this.comboBoxKnjiznicaID);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormPosudbe";
            this.Text = "FormPosudbe";
            this.Load += new System.EventHandler(this.FormPosudbe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private new System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button Delete;
        private new System.Windows.Forms.Button Update;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDatumPovratka;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtDatumPreuzimanja;
        private System.Windows.Forms.ComboBox comboBoxKnjigaID;
        private System.Windows.Forms.ComboBox comboBoxClanID;
        private System.Windows.Forms.ComboBox comboBoxZaposlenikID;
        private System.Windows.Forms.ComboBox comboBoxKnjiznicaID;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}