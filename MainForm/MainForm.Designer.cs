
namespace MainForm
{
    partial class MainForm
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
        private void InitializeComponent1()
        {
            dataGridView1 = new DataGridView();
            Номер_подъезда = new DataGridViewTextBoxColumn();
            Номер_квартиры = new DataGridViewTextBoxColumn();
            Количество_комнат = new DataGridViewTextBoxColumn();
            Общая_площадь = new DataGridViewTextBoxColumn();
            Есть_ли_задолжности = new DataGridViewTextBoxColumn();
            Есть_ли_дети = new DataGridViewTextBoxColumn();
            Домоуправление = new Label();
            btnAdd = new Button();
            btnEdit = new Button();
            btnHelp = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Номер_подъезда, Номер_квартиры, Количество_комнат, Общая_площадь, Есть_ли_задолжности, Есть_ли_дети });
            dataGridView1.Location = new Point(50, 246);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(646, 300);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Номер_подъезда
            // 
            Номер_подъезда.HeaderText = "Номер подъезда";
            Номер_подъезда.Name = "Номер_подъезда";
            Номер_подъезда.ReadOnly = true;
            // 
            // Номер_квартиры
            // 
            Номер_квартиры.HeaderText = "Номер квартиры";
            Номер_квартиры.Name = "Номер_квартиры";
            Номер_квартиры.ReadOnly = true;
            // 
            // Количество_комнат
            // 
            Количество_комнат.HeaderText = "Количество комнат";
            Количество_комнат.Name = "Количество_комнат";
            Количество_комнат.ReadOnly = true;
            // 
            // Общая_площадь
            // 
            Общая_площадь.HeaderText = "Общая площадь";
            Общая_площадь.Name = "Общая_площадь";
            Общая_площадь.ReadOnly = true;
            // 
            // Есть_ли_задолжности
            // 
            Есть_ли_задолжности.HeaderText = "Есть ли задолжности";
            Есть_ли_задолжности.Name = "Есть_ли_задолжности";
            Есть_ли_задолжности.ReadOnly = true;
            // 
            // Есть_ли_дети
            // 
            Есть_ли_дети.HeaderText = "Есть ли дети";
            Есть_ли_дети.Name = "Есть_ли_дети";
            Есть_ли_дети.ReadOnly = true;
            Есть_ли_дети.Resizable = DataGridViewTriState.True;
            Есть_ли_дети.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Домоуправление
            // 
            Домоуправление.AutoSize = true;
            Домоуправление.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Домоуправление.ForeColor = SystemColors.ActiveCaptionText;
            Домоуправление.Location = new Point(261, 9);
            Домоуправление.Name = "Домоуправление";
            Домоуправление.Size = new Size(187, 30);
            Домоуправление.TabIndex = 1;
            Домоуправление.Text = "Домоуправление";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(193, 110);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(113, 46);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(660, 62);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(113, 46);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Редактирование";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnHelp
            // 
            btnHelp.Location = new Point(660, 12);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(113, 44);
            btnHelp.TabIndex = 4;
            btnHelp.Text = "Помощь";
            btnHelp.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(785, 558);
            Controls.Add(btnHelp);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(Домоуправление);
            Controls.Add(dataGridView1);
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Номер_подъезда;
        private DataGridViewTextBoxColumn Номер_квартиры;
        private DataGridViewTextBoxColumn Количество_комнат;
        private DataGridViewTextBoxColumn Общая_площадь;
        private DataGridViewTextBoxColumn Есть_ли_задолжности;
        private DataGridViewTextBoxColumn Есть_ли_дети;
        private Label Домоуправление;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnHelp;
        private Button btnExport;
        private Button btnImport;
        private PictureBox pictureBox1;
        private Button delete;
        private DataGridViewTextBoxColumn номерДомаDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn номерКвартирыDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn количествоКомнатDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn общаяПлощадьDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn естьЛиЗадолженностьDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn естьЛиДетиDataGridViewCheckBoxColumn;
        private System.Data.DataTable table;
        private TextBox textBoxSearch;
        private Button buttonSearch;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Button rasch;
    }
}
