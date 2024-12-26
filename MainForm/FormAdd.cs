using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System;
using System.Windows.Forms;


public class FormAdd : Form
{
    private TextBox txtEntranceNumber; // Номер подъезда
    private TextBox txtApartmentNumber; // Номер квартиры
    private TextBox txtRoomCount; // Количество комнат
    private TextBox txtTotalArea; // Общая площадь
    private CheckBox chkHasDebts; // Есть ли задолженности
    private CheckBox chkHasChildren; // Есть ли дети
    private Button btnSave; // Кнопка "Сохранить"
    private Button btnCancel; // Кнопка "Отмена"

    public FormAdd()
    {
        InitializeComponent();
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.StartPosition = FormStartPosition.CenterScreen;
    }

    private void InitializeComponent()
    {
        ComponentResourceManager resources = new ComponentResourceManager(typeof(FormAdd));
        txtEntranceNumber = new TextBox();
        txtApartmentNumber = new TextBox();
        txtRoomCount = new TextBox();
        txtTotalArea = new TextBox();
        chkHasDebts = new CheckBox();
        chkHasChildren = new CheckBox();
        btnSave = new Button();
        btnCancel = new Button();
        family = new TextBox();
        name = new TextBox();
        otche = new TextBox();
        number = new TextBox();
        SuspendLayout();
        // 
        // txtEntranceNumber
        // 
        txtEntranceNumber.Location = new Point(52, 12);
        txtEntranceNumber.Name = "txtEntranceNumber";
        txtEntranceNumber.PlaceholderText = "Номер подъезда";
        txtEntranceNumber.Size = new Size(200, 23);
        txtEntranceNumber.TabIndex = 0;
        // 
        // txtApartmentNumber
        // 
        txtApartmentNumber.Location = new Point(52, 39);
        txtApartmentNumber.Name = "txtApartmentNumber";
        txtApartmentNumber.PlaceholderText = "Номер квартиры";
        txtApartmentNumber.Size = new Size(200, 23);
        txtApartmentNumber.TabIndex = 1;
        // 
        // txtRoomCount
        // 
        txtRoomCount.Location = new Point(52, 68);
        txtRoomCount.Name = "txtRoomCount";
        txtRoomCount.PlaceholderText = "Количество комнат";
        txtRoomCount.Size = new Size(200, 23);
        txtRoomCount.TabIndex = 2;
        // 
        // txtTotalArea
        // 
        txtTotalArea.Location = new Point(52, 97);
        txtTotalArea.Name = "txtTotalArea";
        txtTotalArea.PlaceholderText = "Общая площадь (м²)";
        txtTotalArea.Size = new Size(200, 23);
        txtTotalArea.TabIndex = 3;
        // 
        // chkHasDebts
        // 
        chkHasDebts.ForeColor = SystemColors.ActiveCaptionText;
        chkHasDebts.Location = new Point(52, 262);
        chkHasDebts.Name = "chkHasDebts";
        chkHasDebts.Size = new Size(148, 24);
        chkHasDebts.TabIndex = 4;
        chkHasDebts.Text = "Есть задолженности?";
        // 
        // chkHasChildren
        // 
        chkHasChildren.ForeColor = SystemColors.ActiveCaptionText;
        chkHasChildren.Location = new Point(52, 292);
        chkHasChildren.Name = "chkHasChildren";
        chkHasChildren.Size = new Size(101, 24);
        chkHasChildren.TabIndex = 5;
        chkHasChildren.Text = "Есть дети?";
        // 
        // btnSave
        // 
        btnSave.Image = Tyuiu.SavtsovNE.Sprint7.Project.V7.Properties.Resources.save_icon_icons_com_53618;
        btnSave.Location = new Point(52, 335);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(57, 56);
        btnSave.TabIndex = 6;
        btnSave.Click += BtnSave_Click;
        // 
        // btnCancel
        // 
        btnCancel.Image = Tyuiu.SavtsovNE.Sprint7.Project.V7.Properties.Resources.Cancel_40972;
        btnCancel.Location = new Point(192, 335);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(60, 56);
        btnCancel.TabIndex = 7;
        btnCancel.Click += BtnCancel_Click;
        // 
        // family
        // 
        family.BackColor = SystemColors.ButtonFace;
        family.Location = new Point(53, 139);
        family.Name = "family";
        family.PlaceholderText = "фамилия";
        family.Size = new Size(199, 23);
        family.TabIndex = 8;
        family.TextChanged += family_TextChanged;
        // 
        // name
        // 
        name.Location = new Point(53, 168);
        name.Name = "name";
        name.PlaceholderText = "Имя";
        name.Size = new Size(199, 23);
        name.TabIndex = 9;
        name.TextChanged += name_TextChanged;
        // 
        // otche
        // 
        otche.Location = new Point(52, 197);
        otche.Name = "otche";
        otche.PlaceholderText = "Отчество";
        otche.Size = new Size(200, 23);
        otche.TabIndex = 10;
        otche.TextChanged += otche_TextChanged;
        // 
        // number
        // 
        number.Location = new Point(52, 226);
        number.Name = "number";
        number.PlaceholderText = "Номер телефона";
        number.Size = new Size(200, 23);
        number.TabIndex = 11;
        number.TextChanged += number_TextChanged;
        // 
        // FormAdd
        // 
        AutoScaleMode = AutoScaleMode.None;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        BackColor = SystemColors.ActiveCaption;
        ClientSize = new Size(295, 417);
        Controls.Add(number);
        Controls.Add(otche);
        Controls.Add(name);
        Controls.Add(family);
        Controls.Add(txtEntranceNumber);
        Controls.Add(txtApartmentNumber);
        Controls.Add(txtRoomCount);
        Controls.Add(txtTotalArea);
        Controls.Add(chkHasDebts);
        Controls.Add(chkHasChildren);
        Controls.Add(btnSave);
        Controls.Add(btnCancel);
        ForeColor = SystemColors.ActiveCaption;
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "FormAdd";
        Text = "Добавить информацию";
        Load += FormAdd_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    public event Action<string, string, int, double, bool, bool, string, string, string, string> DataAdded;

    private void BtnSave_Click(object sender, EventArgs e)
    {
        // Логика сохранения данных (например, в базу данных или файл)

        MessageBox.Show("Данные сохранены!");

        // Собираем данные из текстовых полей
        string entranceNumber = txtEntranceNumber.Text; // Номер подъезда
        string apartmentNumber = txtApartmentNumber.Text; // Номер квартиры
        int roomCount = int.TryParse(txtRoomCount.Text, out int rooms) ? rooms : 0; // Количество комнат
        double totalArea = double.TryParse(txtTotalArea.Text, out double area) ? area : 0; // Общая площадь
        bool hasDebts = chkHasDebts.Checked; // Есть ли задолженности
        bool hasChildren = chkHasChildren.Checked; // Есть ли дети

        // Получаем данные из новых текстовых полей
        string familyValue = family.Text; // Фамилия
        string nameValue = name.Text; // Имя
        string otcheValue = otche.Text; // Отчество
        string numberValue = number.Text; // Номер телефона

        // Вызываем событие и передаем данные
        DataAdded?.Invoke(entranceNumber, apartmentNumber, roomCount, totalArea, hasDebts, hasChildren, familyValue, nameValue, otcheValue, numberValue);

        // Закрываем форму после добавления
        this.Close();
    }


    private void BtnCancel_Click(object sender, EventArgs e)
    {
        // Закрыть форму без сохранения
        this.Close();
    }
    private void OpenAddForm()
    {
        FormAdd addForm = new FormAdd();
        addForm.ShowDialog(); // Открывает форму как модальное окно
    }

    private void FormAdd_Load(object sender, EventArgs e)
    {

    }

    private TextBox family;
    private TextBox name;
    private TextBox otche;
    private TextBox number;

    private void family_TextChanged(object sender, EventArgs e)
    {

    }

    private void name_TextChanged(object sender, EventArgs e)
    {

    }

    private void otche_TextChanged(object sender, EventArgs e)
    {

    }

    private void number_TextChanged(object sender, EventArgs e)
    {

    }
}
