
public partial class FormEdit : Form
{
    private TextBox txtEntranceNumber;
    private TextBox txtApartmentNumber;
    private TextBox txtRoomCount;
    private TextBox txtTotalArea;
    private TextBox txtLastName;
    private TextBox txtFirstName;
    private TextBox txtMiddleName;
    private TextBox txtPhoneNumber;

    private CheckBox chkHasDebts;
    private CheckBox chkHasChildren;
    private Button buttonSave;
    private Button buttonCancel;

    public Action<DataGridViewRow> DataEdited { get; internal set; }

    private DataGridView dataGridView;
    private DataGridViewRow selectedRow;

    public FormEdit(DataGridViewRow selectedRow, DataGridView dataGridView)
    {
        InitializeComponent();
        this.dataGridView = dataGridView ?? throw new ArgumentNullException(nameof(dataGridView));
        this.selectedRow = selectedRow ?? throw new ArgumentNullException(nameof(selectedRow));
        LoadData(selectedRow);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.StartPosition = FormStartPosition.CenterScreen;
    }

    private void LoadData(DataGridViewRow row)
    {
        SetTextBoxValue(row, txtEntranceNumber, "Номер дома");
        SetTextBoxValue(row, txtApartmentNumber, "Номер квартиры");
        SetTextBoxValue(row, txtRoomCount, "Количество комнат");
        SetTextBoxValue(row, txtTotalArea, "Общая площадь");

        // Новые значения (используем фамилию, имя, отчество и номер телефона)
        SetTextBoxValue(row, family, "Фамилия");
        SetTextBoxValue(row, name, "Имя");
        SetTextBoxValue(row, otche, "Отчество");
        SetTextBoxValue(row, number, "Номер телефона");

        chkHasDebts.Checked = GetBooleanValue(row, "Есть ли задолженность");
        chkHasChildren.Checked = GetBooleanValue(row, "Есть ли дети");
    }

    private void SetTextBoxValue(DataGridViewRow row, TextBox textBox, string columnName)
    {
        if (row.Cells[columnName].Value != null)
        {
            textBox.Text = row.Cells[columnName].Value.ToString();
        }
        else
        {
            textBox.Text = string.Empty;
        }
    }

    private bool GetBooleanValue(DataGridViewRow row, string columnName)
    {
        return row.Cells[columnName].Value is bool value && value;
    }

    private void BtnSave_Click(object sender, EventArgs e)
    {
        // Обновите значения в строке
        selectedRow.Cells["Номер дома"].Value = txtEntranceNumber.Text;
        selectedRow.Cells["Номер квартиры"].Value = txtApartmentNumber.Text;
        selectedRow.Cells["Количество комнат"].Value = txtRoomCount.Text;
        selectedRow.Cells["Общая площадь"].Value = txtTotalArea.Text;
        selectedRow.Cells["Есть ли задолженность"].Value = chkHasDebts.Checked;
        selectedRow.Cells["Есть ли дети"].Value = chkHasChildren.Checked;

        // Новые значения (для фамилии, имени, отчества и номера телефона)
        selectedRow.Cells["Фамилия"].Value = family.Text;
        selectedRow.Cells["Имя"].Value = name.Text;
        selectedRow.Cells["Отчество"].Value = otche.Text;
        selectedRow.Cells["Номер телефона"].Value = number.Text;

        // Вызовите событие, если оно подписано
        DataEdited?.Invoke(selectedRow);

        this.Close();
    }


    private void FormEdit_Load(object sender, EventArgs e)
    {
        // Можно добавить дополнительную логику загрузки данных, если необходимо.
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
        this.Close();

    }

    private void family_TextChanged(object sender, EventArgs e)
    {

    }
}
