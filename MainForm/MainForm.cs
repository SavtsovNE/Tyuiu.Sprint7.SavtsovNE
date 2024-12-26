using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Excel = Microsoft.Office.Interop.Excel;

namespace MainForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = table;
            try
            {
                // Инициализируем таблицу
                DataTable table = new DataTable();

                // Добавляем колонки
                table.Columns.Add("Номер дома", typeof(string));
                table.Columns.Add("Номер квартиры", typeof(string));
                table.Columns.Add("Количество комнат", typeof(int));
                table.Columns.Add("Общая площадь", typeof(double));
                table.Columns.Add("Есть ли задолженность", typeof(bool));
                table.Columns.Add("Есть ли дети", typeof(bool));

                table.Columns.Add("Фамилия", typeof(string)); // Исправлено: тип данных на string
                table.Columns.Add("Имя", typeof(string));     // Исправлено: тип данных на string
                table.Columns.Add("Отчество", typeof(string)); // Исправлено: тип данных на string
                table.Columns.Add("Номер телефона", typeof(string)); // Исправлено: тип данных на string и название столбца

                // Добавляем строки с данными
                table.Rows.Add("1", "101", 2, 50.5, false, true, "Иванов", "Иван", "Иванович", "+79123456789");
                table.Rows.Add("3", "102", 3, 75.0, true, false, "Петрова", "Мария", "Петровна", "+79991234567");
                table.Rows.Add("2", "205", 1, 35.2, false, false, "Сидоров", "Сергей", "", "+78005553535"); // Пример без отчества
                table.Rows.Add("1", "103", 4, 100.0, true, true, "Кузнецова", "Анна", "Алексеевна", null); // Пример с отсутствующим номером телефона
                table.Rows.Add("4", "1", 2, 48.7, false, false, "Смирнов", "Дмитрий", "Васильевич", "+79112223333");

                // Привязываем данные к DataGridView
                dataGridView1.DataSource = table;

                // Принудительное обновление привязки данных
                dataGridView1.Refresh();

                // Проверка, если привязка успешна
                if (dataGridView1.DataSource != null)
                {
                    Console.WriteLine("Привязка данных к DataGridView успешна.");
                }
                else
                {
                    Console.WriteLine("Ошибка: Привязка данных не выполнена.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке данных: {ex.Message}");
            }
        }






        private DataTable GetData()
        {
            // Добавляем колонки
            table.Columns.Add("Номер дома", typeof(string));
            table.Columns.Add("Номер квартиры", typeof(string));
            table.Columns.Add("Количество комнат", typeof(int));
            table.Columns.Add("Общая площадь", typeof(double));
            table.Columns.Add("Есть ли задолженность", typeof(bool));
            table.Columns.Add("Есть ли дети", typeof(bool));

            table.Columns.Add("Фамилия", typeof(string)); // Исправлено: тип данных на string
            table.Columns.Add("Имя", typeof(string));     // Исправлено: тип данных на string
            table.Columns.Add("Отчество", typeof(string)); // Исправлено: тип данных на string
            table.Columns.Add("Номер телефона", typeof(string)); // Исправлено: тип данных на string и название столбца

            // Добавляем строки с данными
            table.Rows.Add("1", "101", 2, 50.5, false, true, "Иванов", "Иван", "Иванович", "+79123456789");
            table.Rows.Add("3", "102", 3, 75.0, true, false, "Петрова", "Мария", "Петровна", "+79991234567");
            table.Rows.Add("2", "205", 1, 35.2, false, false, "Сидоров", "Сергей", "", "+78005553535"); // Пример без отчества
            table.Rows.Add("1", "103", 4, 100.0, true, true, "Кузнецова", "Анна", "Алексеевна", null); // Пример с отсутствующим номером телефона
            table.Rows.Add("4", "1", 2, 48.7, false, false, "Смирнов", "Дмитрий", "Васильевич", "+79112223333");

            return table;
        }


        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FormAdd formAdd = new FormAdd();
            formAdd.DataAdded += OnDataAdded; // Subscribe to the DataAdded event
            formAdd.ShowDialog();
        }



        private void OnDataAdded(string entranceNumber, string apartmentNumber, int roomCount, double totalArea, bool hasDebts, bool hasChildren, string family, string name, string otche, string number)
        {
            // Получаем текущую DataTable
            DataTable data = (DataTable)dataGridView1.DataSource;

            // Проверка на наличие DataTable
            if (data != null)
            {
                // Добавляем новую строку в таблицу
                data.Rows.Add(entranceNumber, apartmentNumber, roomCount, totalArea, hasDebts, hasChildren, family, name, otche, number);

                // Обновляем DataGridView
                dataGridView1.Refresh();
            }
            else
            {
                MessageBox.Show("Ошибка: таблица данных не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BtnEdit_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                FormEdit formEdit = new FormEdit(selectedRow, dataGridView1); // Передаем выбранную строку и DataGridView для редактирования
                formEdit.DataEdited += OnDataEdited; // Подписка на событие редактирования данных
                formEdit.ShowDialog();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите жильца для редактирования.");
            }
        }

        private void OnDataEdited(DataGridViewRow editedRow)
        {
            // Обновление данных в DataGridView после редактирования
            dataGridView1.Refresh();
        }

        private void BtnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Это окно помощи. Здесь вы можете получить информацию о программе.");
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            ChartArea chartArea1 = new ChartArea();
            Legend legend1 = new Legend();
            Series series1 = new Series();
            dataGridView1 = new DataGridView();
            table = new DataTable();
            btnAdd = new Button();
            btnEdit = new Button();
            btnHelp = new Button();
            btnExport = new Button();
            btnImport = new Button();
            pictureBox1 = new PictureBox();
            delete = new Button();
            textBoxSearch = new TextBox();
            buttonSearch = new Button();
            chart1 = new Chart();
            rasch = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)table).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.DataSource = table;
            dataGridView1.Location = new Point(89, 10);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(562, 206);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // table
            // 
            table.Namespace = "";
            // 
            // btnAdd
            // 
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.ForeColor = System.Drawing.Color.Transparent;
            btnAdd.Image = Tyuiu.SavtsovNE.Sprint7.Project.V7.Properties.Resources.add_icon_icons_com_52393;
            btnAdd.Location = new Point(90, 222);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(61, 58);
            btnAdd.TabIndex = 1;
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += BtnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.ForeColor = System.Drawing.Color.Transparent;
            btnEdit.Image = Tyuiu.SavtsovNE.Sprint7.Project.V7.Properties.Resources.edit_icon_icons_com_52382;
            btnEdit.Location = new Point(157, 222);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(61, 58);
            btnEdit.TabIndex = 2;
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += BtnEdit_Click;
            // 
            // btnHelp
            // 
            btnHelp.FlatStyle = FlatStyle.Flat;
            btnHelp.ForeColor = System.Drawing.Color.Transparent;
            btnHelp.Image = Tyuiu.SavtsovNE.Sprint7.Project.V7.Properties.Resources.sign_question_icon_34359;
            btnHelp.Location = new Point(590, 221);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(61, 58);
            btnHelp.TabIndex = 3;
            btnHelp.UseVisualStyleBackColor = true;
            btnHelp.Click += BtnHelp_Click;
            // 
            // btnExport
            // 
            btnExport.BackColor = System.Drawing.Color.Transparent;
            btnExport.BackgroundImageLayout = ImageLayout.None;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new System.Drawing.Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnExport.ForeColor = System.Drawing.Color.Transparent;
            btnExport.Image = Tyuiu.SavtsovNE.Sprint7.Project.V7.Properties.Resources._1486505265_document_file_export_sending_exit_send_81434__1_;
            btnExport.Location = new Point(593, 315);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(72, 64);
            btnExport.TabIndex = 4;
            btnExport.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnImport
            // 
            btnImport.BackColor = System.Drawing.Color.Transparent;
            btnImport.BackgroundImageLayout = ImageLayout.None;
            btnImport.FlatStyle = FlatStyle.Flat;
            btnImport.ForeColor = System.Drawing.Color.Transparent;
            btnImport.Image = Tyuiu.SavtsovNE.Sprint7.Project.V7.Properties.Resources.cloudup_icon_icons_com_54402__1_;
            btnImport.Location = new Point(515, 316);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(72, 64);
            btnImport.TabIndex = 5;
            btnImport.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnImport.UseMnemonic = false;
            btnImport.UseVisualStyleBackColor = false;
            btnImport.Click += btnImport_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Tyuiu.SavtsovNE.Sprint7.Project.V7.Properties.Resources.gargoylehouse_94861;
            pictureBox1.Location = new Point(12, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(61, 73);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // delete
            // 
            delete.BackColor = System.Drawing.Color.Transparent;
            delete.FlatStyle = FlatStyle.Flat;
            delete.ForeColor = System.Drawing.Color.Transparent;
            delete.Image = (Image)resources.GetObject("delete.Image");
            delete.Location = new Point(224, 221);
            delete.Name = "delete";
            delete.Size = new Size(61, 59);
            delete.TabIndex = 9;
            delete.UseVisualStyleBackColor = false;
            delete.Click += delete_Click;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(657, 12);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(100, 23);
            textBoxSearch.TabIndex = 10;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            // 
            // buttonSearch
            // 
            buttonSearch.Image = Tyuiu.SavtsovNE.Sprint7.Project.V7.Properties.Resources.search_locate_find_icon_icons_com_67287;
            buttonSearch.Location = new Point(657, 41);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(38, 34);
            buttonSearch.TabIndex = 11;
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += button1_Click;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(804, 10);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(432, 300);
            chart1.TabIndex = 12;
            chart1.Text = "chart1";
            chart1.Click += chart1_Click;
            // 
            // rasch
            // 
            rasch.Image = Tyuiu.SavtsovNE.Sprint7.Project.V7.Properties.Resources._1491254488_chartflexibledatestatstatistics_82950;
            rasch.Location = new Point(804, 315);
            rasch.Name = "rasch";
            rasch.Size = new Size(70, 63);
            rasch.TabIndex = 13;
            rasch.UseVisualStyleBackColor = true;
            rasch.Click += rasch_Click;
            // 
            // MainForm
            // 
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1248, 391);
            Controls.Add(rasch);
            Controls.Add(chart1);
            Controls.Add(buttonSearch);
            Controls.Add(textBoxSearch);
            Controls.Add(delete);
            Controls.Add(pictureBox1);
            Controls.Add(btnImport);
            Controls.Add(btnExport);
            Controls.Add(dataGridView1);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnHelp);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Домоуправление";
            Load += MainForm_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)table).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Ограничиваем окно фиксированным размером
            this.MaximizeBox = false; // Отключаем кнопку максимизации
            this.MinimizeBox = true; // Если нужно, можно оставить кнопку минимизации

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportToExcel(dataGridView1, saveFileDialog.FileName);
                MessageBox.Show("Данные успешно экспортированы", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xlsx"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ImportFromExcel(dataGridView1, openFileDialog.FileName);
                MessageBox.Show("Данные успешно импортированы", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ExportToExcel(DataGridView dataGridView, string filePath)
        {
            // Create a new spreadsheet document
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
            {
                // Add the workbook and worksheet parts
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet()
                {
                    Id = workbookPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "Sheet1"
                };
                sheets.Append(sheet);

                // Get the SheetData from the worksheet part
                SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                // Create the header row
                Row headerRow = new Row();
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    Cell headerCell = new Cell()
                    {
                        CellValue = new CellValue(column.HeaderText),
                        DataType = CellValues.String
                    };
                    headerRow.AppendChild(headerCell);
                }
                sheetData.AppendChild(headerRow);

                // Add data rows
                foreach (DataGridViewRow dataRow in dataGridView.Rows)
                {
                    // Skip empty rows
                    if (dataRow.IsNewRow) continue;

                    Row row = new Row();
                    foreach (DataGridViewCell cell in dataRow.Cells)
                    {
                        Cell excelCell = new Cell()
                        {
                            CellValue = new CellValue(cell.Value.ToString()),
                            DataType = CellValues.String
                        };
                        row.AppendChild(excelCell);
                    }
                    sheetData.AppendChild(row);
                }

                // Save the document
                workbookPart.Workbook.Save();
            }
        }



        private void ImportFromExcel(DataGridView dataGridView, string filePath)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(filePath, false))
            {
                WorkbookPart workbookPart = document.WorkbookPart;
                Sheet sheet = workbookPart.Workbook.Sheets.GetFirstChild<Sheet>();
                WorksheetPart worksheetPart = (WorksheetPart)workbookPart.GetPartById(sheet.Id);
                SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

                DataTable table = new DataTable();

                bool isHeaderRow = true;

                foreach (Row row in sheetData.Elements<Row>())
                {
                    if (isHeaderRow)
                    {
                        foreach (Cell cell in row.Elements<Cell>())
                        {
                            table.Columns.Add(GetCellValue(cell, workbookPart));
                        }
                        isHeaderRow = false;
                    }
                    else
                    {
                        DataRow dataRow = table.NewRow();
                        int columnIndex = 0;

                        foreach (Cell cell in row.Elements<Cell>())
                        {
                            dataRow[columnIndex] = GetCellValue(cell, workbookPart);
                            columnIndex++;
                        }
                        table.Rows.Add(dataRow);
                    }
                }

                dataGridView.DataSource = table;
            }
        }

        private string GetCellValue(Cell cell, WorkbookPart workbookPart)
        {
            if (cell.CellValue == null) return string.Empty;

            string value = cell.CellValue.Text;

            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(int.Parse(value)).InnerText;
            }

            return value;
        }


        private string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            if (cell == null || cell.CellValue == null)
                return string.Empty;

            string value = cell.CellValue.Text;

            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return document.WorkbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(int.Parse(value)).InnerText;
            }

            return value;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Your cell content click logic here
        }


        private void delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.Remove(row);
                }
                MessageBox.Show("Запись успешно удалена", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите запись для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.ToLower(); // Текст для поиска (приводим к нижнему регистру для нечувствительности к регистру)

            bool found = false; // Флаг, чтобы узнать, найдено ли что-то

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Проходим по всем ячейкам в строке
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchText))
                    {
                        row.Selected = true; // Выделяем найденную строку
                        dataGridView1.FirstDisplayedScrollingRowIndex = row.Index; // Прокручиваем к найденной строке
                        found = true;
                        break; // Если хотя бы одно совпадение найдено, переходим к следующей строке
                    }
                }

                if (found) break; // Если нашли хотя бы одну строку, выходим из внешнего цикла
            }

            if (!found)
            {
                MessageBox.Show("Запись не найдена.");
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void rasch_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();

            for (int j = 1; j < dataGridView1.Columns.Count; j++) // Начинаем со второго столбца (первый - метки)
            {
                Series series = new Series(dataGridView1.Columns[j].HeaderText); // Имя ряда - заголовок столбца
                series.ChartType = SeriesChartType.Column; // Или другой тип графика

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    string xValue = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    double yValue;
                    if (double.TryParse(dataGridView1.Rows[i].Cells[j].Value.ToString(), out yValue))
                    {
                        series.Points.AddXY(xValue, yValue);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка: значение в строке " + (i + 1) + ", столбце " + (j + 1) + " не является числом.");
                        return;
                    }
                }
                chart1.Series.Add(series);
            }
        }
    }
}

