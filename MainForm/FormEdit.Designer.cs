partial class FormEdit
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEdit));
        txtEntranceNumber = new TextBox();
        txtApartmentNumber = new TextBox();
        txtRoomCount = new TextBox();
        txtTotalArea = new TextBox();
        chkHasDebts = new CheckBox();
        chkHasChildren = new CheckBox();
        buttonSave = new Button();
        buttonCancel = new Button();
        family = new TextBox();
        name = new TextBox();
        otche = new TextBox();
        number = new TextBox();
        SuspendLayout();
        // 
        // txtEntranceNumber
        // 
        txtEntranceNumber.Location = new Point(73, 12);
        txtEntranceNumber.Margin = new Padding(4, 3, 4, 3);
        txtEntranceNumber.Name = "txtEntranceNumber";
        txtEntranceNumber.Size = new Size(116, 23);
        txtEntranceNumber.TabIndex = 0;
        // 
        // txtApartmentNumber
        // 
        txtApartmentNumber.Location = new Point(73, 41);
        txtApartmentNumber.Margin = new Padding(4, 3, 4, 3);
        txtApartmentNumber.Name = "txtApartmentNumber";
        txtApartmentNumber.Size = new Size(116, 23);
        txtApartmentNumber.TabIndex = 1;
        // 
        // txtRoomCount
        // 
        txtRoomCount.Location = new Point(73, 70);
        txtRoomCount.Name = "txtRoomCount";
        txtRoomCount.Size = new Size(116, 23);
        txtRoomCount.TabIndex = 2;
        // 
        // txtTotalArea
        // 
        txtTotalArea.Location = new Point(73, 99);
        txtTotalArea.Name = "txtTotalArea";
        txtTotalArea.Size = new Size(116, 23);
        txtTotalArea.TabIndex = 3;
        // 
        // chkHasDebts
        // 
        chkHasDebts.AutoSize = true;
        chkHasDebts.Location = new Point(79, 255);
        chkHasDebts.Name = "chkHasDebts";
        chkHasDebts.Size = new Size(84, 19);
        chkHasDebts.TabIndex = 4;
        chkHasDebts.Text = "Есть долги";
        chkHasDebts.UseVisualStyleBackColor = true;
        // 
        // chkHasChildren
        // 
        chkHasChildren.AutoSize = true;
        chkHasChildren.Location = new Point(79, 280);
        chkHasChildren.Name = "chkHasChildren";
        chkHasChildren.Size = new Size(76, 19);
        chkHasChildren.TabIndex = 5;
        chkHasChildren.Text = "Есть дети";
        chkHasChildren.UseVisualStyleBackColor = true;
        // 
        // buttonSave
        // 
        buttonSave.Image = Tyuiu.SavtsovNE.Sprint7.Project.V7.Properties.Resources.save_icon_icons_com_53618;
        buttonSave.Location = new Point(52, 326);
        buttonSave.Name = "buttonSave";
        buttonSave.Size = new Size(59, 52);
        buttonSave.TabIndex = 6;
        buttonSave.UseVisualStyleBackColor = true;
        buttonSave.Click += buttonSave_Click;
        // 
        // buttonCancel
        // 
        buttonCancel.Image = Tyuiu.SavtsovNE.Sprint7.Project.V7.Properties.Resources.Cancel_40972;
        buttonCancel.Location = new Point(143, 324);
        buttonCancel.Name = "buttonCancel";
        buttonCancel.Size = new Size(62, 56);
        buttonCancel.TabIndex = 7;
        buttonCancel.UseVisualStyleBackColor = true;
        buttonCancel.Click += buttonCancel_Click;
        // 
        // family
        // 
        family.Location = new Point(75, 130);
        family.Name = "family";
        family.Size = new Size(114, 23);
        family.TabIndex = 8;
        family.TextChanged += family_TextChanged;
        // 
        // name
        // 
        name.Location = new Point(75, 159);
        name.Name = "name";
        name.Size = new Size(114, 23);
        name.TabIndex = 9;
        // 
        // otche
        // 
        otche.BackColor = Color.Honeydew;
        otche.Location = new Point(75, 188);
        otche.Name = "otche";
        otche.Size = new Size(114, 23);
        otche.TabIndex = 10;
        // 
        // number
        // 
        number.Location = new Point(75, 217);
        number.Name = "number";
        number.Size = new Size(114, 23);
        number.TabIndex = 11;
        // 
        // FormEdit
        // 
        AutoScaleMode = AutoScaleMode.None;
        BackColor = SystemColors.ActiveCaption;
        ClientSize = new Size(285, 475);
        Controls.Add(number);
        Controls.Add(otche);
        Controls.Add(name);
        Controls.Add(family);
        Controls.Add(buttonCancel);
        Controls.Add(buttonSave);
        Controls.Add(chkHasChildren);
        Controls.Add(chkHasDebts);
        Controls.Add(txtTotalArea);
        Controls.Add(txtRoomCount);
        Controls.Add(txtEntranceNumber);
        Controls.Add(txtApartmentNumber);
        ForeColor = SystemColors.MenuBar;
        Icon = (Icon)resources.GetObject("$this.Icon");
        Margin = new Padding(4, 3, 4, 3);
        Name = "FormEdit";
        Text = "Редактирование";
        Load += FormEdit_Load;
        ResumeLayout(false);
        PerformLayout();
    }
    private TextBox family;
    private TextBox name;
    private TextBox otche;
    private TextBox number;

    private void buttonSave_Click(object sender, EventArgs e)
    {
        // Обновите значения в строке
        selectedRow.Cells["Номер дома"].Value = txtEntranceNumber.Text;
        selectedRow.Cells["Номер квартиры"].Value = txtApartmentNumber.Text;
        selectedRow.Cells["Количество комнат"].Value = txtRoomCount.Text;
        selectedRow.Cells["Общая площадь"].Value = txtTotalArea.Text;

        // Новые поля (проверьте, что имена столбцов точно совпадают)
        selectedRow.Cells["Фамилия"].Value = family.Text;
        selectedRow.Cells["Имя"].Value = name.Text;
        selectedRow.Cells["Отчество"].Value = otche.Text;
        selectedRow.Cells["Номер телефона"].Value = number.Text;

        selectedRow.Cells["Есть ли задолженность"].Value = chkHasDebts.Checked;
        selectedRow.Cells["Есть ли дети"].Value = chkHasChildren.Checked;


        // Вызовите событие, если оно подписано
        DataEdited?.Invoke(selectedRow);

        this.Close();
    }

   
}