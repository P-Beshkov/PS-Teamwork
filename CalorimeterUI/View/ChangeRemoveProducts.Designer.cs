namespace CalorimeterUI.View
{
    partial class ChangeRemoveProducts
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeRemoveProducts));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caloriesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carbohydratesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proteinsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.localDataSetForPorducts = new CalorimeterLocalDataSet();
            this.productsTableAdapter = new CalorimeterLocalDataSetTableAdapters.ProductsTableAdapter();
            this.localDataSetForPorducts1 = new CalorimeterLocalDataSet();
            this.buttonSaveToDB = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localDataSetForPorducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localDataSetForPorducts1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.categoryDataGridViewTextBoxColumn,
            this.productNameDataGridViewTextBoxColumn,
            this.caloriesDataGridViewTextBoxColumn,
            this.fatDataGridViewTextBoxColumn,
            this.carbohydratesDataGridViewTextBoxColumn,
            this.proteinsDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.productsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(662, 415);
            this.dataGridView1.TabIndex = 0;
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Category";
            this.categoryDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "Meat",
            "Fruit",
            "Nuts",
            "Vegetables",
            "Fish",
            "Cereals",
            "Bread",
            "Alchohol",
            "SoftDrinks"});
            this.categoryDataGridViewTextBoxColumn.MaxDropDownItems = 9;
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            this.categoryDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.categoryDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.categoryDataGridViewTextBoxColumn.Width = 74;
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            this.productNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.productNameDataGridViewTextBoxColumn.DataPropertyName = "ProductName";
            this.productNameDataGridViewTextBoxColumn.HeaderText = "ProductName";
            this.productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            this.productNameDataGridViewTextBoxColumn.Width = 97;
            // 
            // caloriesDataGridViewTextBoxColumn
            // 
            this.caloriesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.caloriesDataGridViewTextBoxColumn.DataPropertyName = "Calories";
            this.caloriesDataGridViewTextBoxColumn.HeaderText = "Calories";
            this.caloriesDataGridViewTextBoxColumn.Name = "caloriesDataGridViewTextBoxColumn";
            this.caloriesDataGridViewTextBoxColumn.Width = 69;
            // 
            // fatDataGridViewTextBoxColumn
            // 
            this.fatDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fatDataGridViewTextBoxColumn.DataPropertyName = "Fat";
            this.fatDataGridViewTextBoxColumn.HeaderText = "Fat";
            this.fatDataGridViewTextBoxColumn.Name = "fatDataGridViewTextBoxColumn";
            this.fatDataGridViewTextBoxColumn.Width = 47;
            // 
            // carbohydratesDataGridViewTextBoxColumn
            // 
            this.carbohydratesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.carbohydratesDataGridViewTextBoxColumn.DataPropertyName = "Carbohydrates";
            this.carbohydratesDataGridViewTextBoxColumn.HeaderText = "Carbohydrates";
            this.carbohydratesDataGridViewTextBoxColumn.Name = "carbohydratesDataGridViewTextBoxColumn";
            // 
            // proteinsDataGridViewTextBoxColumn
            // 
            this.proteinsDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.proteinsDataGridViewTextBoxColumn.DataPropertyName = "Proteins";
            this.proteinsDataGridViewTextBoxColumn.HeaderText = "Proteins";
            this.proteinsDataGridViewTextBoxColumn.Name = "proteinsDataGridViewTextBoxColumn";
            this.proteinsDataGridViewTextBoxColumn.Width = 70;
            // 
            // productsBindingSource
            // 
            this.productsBindingSource.DataMember = "Products";
            this.productsBindingSource.DataSource = this.localDataSetForPorducts;
            // 
            // localDataSetForPorducts
            // 
            this.localDataSetForPorducts.DataSetName = "LocalDataSetForPorducts";
            this.localDataSetForPorducts.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productsTableAdapter
            // 
            this.productsTableAdapter.ClearBeforeFill = true;
            // 
            // localDataSetForPorducts1
            // 
            this.localDataSetForPorducts1.DataSetName = "LocalDataSetForPorducts1";
            this.localDataSetForPorducts1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // buttonSaveToDB
            // 
            this.buttonSaveToDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonSaveToDB.Image = ((System.Drawing.Image)(resources.GetObject("buttonSaveToDB.Image")));
            this.buttonSaveToDB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSaveToDB.Location = new System.Drawing.Point(12, 13);
            this.buttonSaveToDB.Name = "buttonSaveToDB";
            this.buttonSaveToDB.Size = new System.Drawing.Size(160, 40);
            this.buttonSaveToDB.TabIndex = 1;
            this.buttonSaveToDB.Text = "Save to database";
            this.buttonSaveToDB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSaveToDB.UseVisualStyleBackColor = true;
            this.buttonSaveToDB.Click += new System.EventHandler(this.BtnSaveGridDataClick);
            // 
            // buttonClose
            // 
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonClose.Image = ((System.Drawing.Image)(resources.GetObject("buttonClose.Image")));
            this.buttonClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonClose.Location = new System.Drawing.Point(559, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.buttonClose.Size = new System.Drawing.Size(115, 40);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
            // 
            // ChangeRemoveProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(686, 486);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSaveToDB);
            this.Controls.Add(this.dataGridView1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChangeRemoveProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ChangeRemoveProducts";
            this.Load += new System.EventHandler(this.ChangeRemoveProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localDataSetForPorducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localDataSetForPorducts1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private CalorimeterLocalDataSet localDataSetForPorducts;
        private System.Windows.Forms.BindingSource productsBindingSource;
        private CalorimeterLocalDataSetTableAdapters.ProductsTableAdapter productsTableAdapter;
        private CalorimeterLocalDataSet localDataSetForPorducts1;
        private System.Windows.Forms.Button buttonSaveToDB;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.DataGridViewComboBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn caloriesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn carbohydratesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proteinsDataGridViewTextBoxColumn;
    }
}