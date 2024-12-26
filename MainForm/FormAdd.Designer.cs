using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public partial class FormAdd1 : Form
{
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private TextBox txtEntranceNumber;
    private TextBox txtApartmentNumber;
    private TextBox txtRoomCount;
    private TextBox txtTotalArea;
    private Button btnSave;
    private Button btnCancel; // Исправлено с Cansel на btnCancel
    private CheckBox chkHasDebts;
    private CheckBox chkHasChildren;


    private IContainer components = null; // Для хранения компонентов

    public FormAdd1()
    {
        InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            // Освобождение управляемых ресурсов
            if (components != null)
            {
                components.Dispose();
            }
        }
        // Освобождение неуправляемых ресурсов (если есть)

        base.Dispose(disposing); // Вызов базового метода Dispose
    }



    private void InitializeComponent()
    {
        this.label1 = new Label();
        this.label2 = new Label();
        this.label3 = new Label();
        this.label4 = new Label();
        this.label5 = new Label();
        this.label6 = new Label();
        this.txtEntranceNumber = new TextBox();
        this.txtApartmentNumber = new TextBox();
        this.txtRoomCount = new TextBox();
        this.txtTotalArea = new TextBox();
        this.btnSave = new Button();
        this.btnCancel = new Button(); // Исправлено с Cansel на btnCancel
        this.chkHasDebts = new CheckBox();
        this.chkHasChildren = new CheckBox();

        // Настройка элементов управления
        // 
        // label1
        this.label1.Text = "Номер подъезда:";
        this.label1.Location = new Point(12, 20);

        // txtEntranceNumber
        this.txtEntranceNumber.Location = new Point(153, 17);

        // label2
        this.label2.Text = "Номер квартиры:";
        this.label2.Location = new Point(12, 50);

        // txtApartmentNumber
        this.txtApartmentNumber.Location = new Point(153, 47);

        // label3
        this.label3.Text = "Количество комнат:";
        this.label3.Location = new Point(12, 80);

        // txtRoomCount
        this.txtRoomCount.Location = new Point(153, 77);

        // label4
        this.label4.Text = "Общая площадь:";
        this.label4.Location = new Point(12, 110);

        // txtTotalArea
        this.txtTotalArea.Location = new Point(153, 107);

        // btnSave
        this.btnSave.Text = "Сохранить";
        this.btnSave.Location = new Point(12, 231);
        this.btnSave.Click += new EventHandler(this.btnSave_Click);

        // btnCancel
        this.btnCancel.Text = "Отмена";
        this.btnCancel.Location = new Point(93, 231);
        this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

        // chkHasDebts
        this.chkHasDebts.Text = "Имеются долги";
        this.chkHasDebts.Location = new Point(12, 140);

        // chkHasChildren
        this.chkHasChildren.Text = "Есть дети";
        this.chkHasChildren.Location = new Point(12, 170);

        // Добавление элементов управления на форму
        Controls.Add(label1);
        Controls.Add(txtEntranceNumber);
        Controls.Add(label2);
        Controls.Add(txtApartmentNumber);
        Controls.Add(label3);
        Controls.Add(txtRoomCount);
        Controls.Add(label4);
        Controls.Add(txtTotalArea);
        Controls.Add(btnSave);
        Controls.Add(btnCancel);
        Controls.Add(chkHasDebts);
        Controls.Add(chkHasChildren);

        // Настройки формы
        this.ClientSize = new Size(330, 311);
        this.Text = "Добавление данных";
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        // Логика сохранения данных
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        // Логика отмены действий
        this.Close(); // Закрытие формы
    }
}
