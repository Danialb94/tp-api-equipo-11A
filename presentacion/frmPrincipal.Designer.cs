namespace presentacion
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.articuloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarArticulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDeCategoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarCategoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarCategoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarCategoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDeMarcaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarMarcaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pbxArticulo = new System.Windows.Forms.PictureBox();
            this.lblFiltroArticulos = new System.Windows.Forms.Label();
            this.txtboxFiltroArticulos = new System.Windows.Forms.TextBox();
            this.lblCampoArticulo = new System.Windows.Forms.Label();
            this.cboCampoArticulo = new System.Windows.Forms.ComboBox();
            this.cboCriterioArticulos = new System.Windows.Forms.ComboBox();
            this.lblCriterioArticulos = new System.Windows.Forms.Label();
            this.lblFiltroAvanzadoArticulos = new System.Windows.Forms.Label();
            this.txtboxFiltroAvanzadoArticulos = new System.Windows.Forms.TextBox();
            this.btnFiltroAvanzado = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnDetalle = new System.Windows.Forms.Button();
            this.btnNavegarAtras = new System.Windows.Forms.Button();
            this.btnNavegarAdelante = new System.Windows.Forms.Button();
            this.gbxNavegadorImg = new System.Windows.Forms.GroupBox();
            this.btnAgregarImg = new System.Windows.Forms.Button();
            this.btnModificarImg = new System.Windows.Forms.Button();
            this.btnEliminarImg = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).BeginInit();
            this.gbxNavegadorImg.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.articuloToolStripMenuItem,
            this.categoriaToolStripMenuItem,
            this.marcaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1220, 29);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // articuloToolStripMenuItem
            // 
            this.articuloToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarArticulosToolStripMenuItem});
            this.articuloToolStripMenuItem.Font = new System.Drawing.Font("Bookman Old Style", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.articuloToolStripMenuItem.Name = "articuloToolStripMenuItem";
            this.articuloToolStripMenuItem.Size = new System.Drawing.Size(99, 25);
            this.articuloToolStripMenuItem.Text = "Artículos";
            // 
            // agregarArticulosToolStripMenuItem
            // 
            this.agregarArticulosToolStripMenuItem.Name = "agregarArticulosToolStripMenuItem";
            this.agregarArticulosToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.agregarArticulosToolStripMenuItem.Text = "Agregar Artículos";
            this.agregarArticulosToolStripMenuItem.Click += new System.EventHandler(this.agregarArticulosToolStripMenuItem_Click);
            // 
            // categoriaToolStripMenuItem
            // 
            this.categoriaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listadoDeCategoriaToolStripMenuItem,
            this.agregarCategoriaToolStripMenuItem,
            this.modificarCategoriaToolStripMenuItem,
            this.eliminarCategoriaToolStripMenuItem});
            this.categoriaToolStripMenuItem.Font = new System.Drawing.Font("Bookman Old Style", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoriaToolStripMenuItem.Name = "categoriaToolStripMenuItem";
            this.categoriaToolStripMenuItem.Size = new System.Drawing.Size(113, 25);
            this.categoriaToolStripMenuItem.Text = "Categorías";
            // 
            // listadoDeCategoriaToolStripMenuItem
            // 
            this.listadoDeCategoriaToolStripMenuItem.Name = "listadoDeCategoriaToolStripMenuItem";
            this.listadoDeCategoriaToolStripMenuItem.Size = new System.Drawing.Size(266, 26);
            this.listadoDeCategoriaToolStripMenuItem.Text = "Listado de Categoría";
            this.listadoDeCategoriaToolStripMenuItem.Click += new System.EventHandler(this.listadoDeCategoriaToolStripMenuItem_Click);
            // 
            // agregarCategoriaToolStripMenuItem
            // 
            this.agregarCategoriaToolStripMenuItem.Name = "agregarCategoriaToolStripMenuItem";
            this.agregarCategoriaToolStripMenuItem.Size = new System.Drawing.Size(266, 26);
            this.agregarCategoriaToolStripMenuItem.Text = "Agregar Categoría";
            this.agregarCategoriaToolStripMenuItem.Click += new System.EventHandler(this.agregarCategoriaToolStripMenuItem_Click);
            // 
            // modificarCategoriaToolStripMenuItem
            // 
            this.modificarCategoriaToolStripMenuItem.Name = "modificarCategoriaToolStripMenuItem";
            this.modificarCategoriaToolStripMenuItem.Size = new System.Drawing.Size(266, 26);
            this.modificarCategoriaToolStripMenuItem.Text = "Modificar Categoría";
            this.modificarCategoriaToolStripMenuItem.Click += new System.EventHandler(this.modificarCategoriaToolStripMenuItem_Click);
            // 
            // eliminarCategoriaToolStripMenuItem
            // 
            this.eliminarCategoriaToolStripMenuItem.Name = "eliminarCategoriaToolStripMenuItem";
            this.eliminarCategoriaToolStripMenuItem.Size = new System.Drawing.Size(266, 26);
            this.eliminarCategoriaToolStripMenuItem.Text = "Eliminar Categoría";
            this.eliminarCategoriaToolStripMenuItem.Click += new System.EventHandler(this.eliminarCategoriaToolStripMenuItem_Click);
            // 
            // marcaToolStripMenuItem
            // 
            this.marcaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listadoDeMarcaToolStripMenuItem,
            this.agregarMarcaToolStripMenuItem});
            this.marcaToolStripMenuItem.Font = new System.Drawing.Font("Bookman Old Style", 10.2F);
            this.marcaToolStripMenuItem.Name = "marcaToolStripMenuItem";
            this.marcaToolStripMenuItem.Size = new System.Drawing.Size(85, 25);
            this.marcaToolStripMenuItem.Text = "Marcas";
            // 
            // listadoDeMarcaToolStripMenuItem
            // 
            this.listadoDeMarcaToolStripMenuItem.Name = "listadoDeMarcaToolStripMenuItem";
            this.listadoDeMarcaToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.listadoDeMarcaToolStripMenuItem.Text = "Listado de Marcas";
            this.listadoDeMarcaToolStripMenuItem.Click += new System.EventHandler(this.listadoDeMarcaToolStripMenuItem_Click);
            // 
            // agregarMarcaToolStripMenuItem
            // 
            this.agregarMarcaToolStripMenuItem.Font = new System.Drawing.Font("Bookman Old Style", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agregarMarcaToolStripMenuItem.Name = "agregarMarcaToolStripMenuItem";
            this.agregarMarcaToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.agregarMarcaToolStripMenuItem.Text = "Agregar Marca";
            this.agregarMarcaToolStripMenuItem.Click += new System.EventHandler(this.agregarMarcaToolStripMenuItem_Click);
            // 
            // dgvArticulos
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dgvArticulos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvArticulos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArticulos.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvArticulos.Location = new System.Drawing.Point(27, 116);
            this.dgvArticulos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvArticulos.MultiSelect = false;
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.RowHeadersWidth = 51;
            this.dgvArticulos.RowTemplate.Height = 24;
            this.dgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulos.Size = new System.Drawing.Size(881, 413);
            this.dgvArticulos.TabIndex = 1;
            this.dgvArticulos.SelectionChanged += new System.EventHandler(this.dgvArticulos_SelectionChanged);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Bookman Old Style", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(26, 40);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(329, 36);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Listado de Artículos";
            // 
            // pbxArticulo
            // 
            this.pbxArticulo.BackColor = System.Drawing.Color.LightGray;
            this.pbxArticulo.Location = new System.Drawing.Point(931, 116);
            this.pbxArticulo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbxArticulo.MaximumSize = new System.Drawing.Size(267, 314);
            this.pbxArticulo.MinimumSize = new System.Drawing.Size(267, 314);
            this.pbxArticulo.Name = "pbxArticulo";
            this.pbxArticulo.Size = new System.Drawing.Size(267, 314);
            this.pbxArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxArticulo.TabIndex = 3;
            this.pbxArticulo.TabStop = false;
            this.pbxArticulo.Click += new System.EventHandler(this.pbxArticulo_Click);
            // 
            // lblFiltroArticulos
            // 
            this.lblFiltroArticulos.AutoSize = true;
            this.lblFiltroArticulos.Font = new System.Drawing.Font("Bookman Old Style", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroArticulos.Location = new System.Drawing.Point(29, 84);
            this.lblFiltroArticulos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltroArticulos.Name = "lblFiltroArticulos";
            this.lblFiltroArticulos.Size = new System.Drawing.Size(137, 23);
            this.lblFiltroArticulos.TabIndex = 4;
            this.lblFiltroArticulos.Text = "Filtro Rápido:";
            // 
            // txtboxFiltroArticulos
            // 
            this.txtboxFiltroArticulos.Font = new System.Drawing.Font("Bookman Old Style", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxFiltroArticulos.Location = new System.Drawing.Point(170, 80);
            this.txtboxFiltroArticulos.Margin = new System.Windows.Forms.Padding(4);
            this.txtboxFiltroArticulos.Name = "txtboxFiltroArticulos";
            this.txtboxFiltroArticulos.Size = new System.Drawing.Size(346, 29);
            this.txtboxFiltroArticulos.TabIndex = 0;
            this.txtboxFiltroArticulos.TextChanged += new System.EventHandler(this.txtboxFiltroArticulos_TextChanged);
            // 
            // lblCampoArticulo
            // 
            this.lblCampoArticulo.AutoSize = true;
            this.lblCampoArticulo.Font = new System.Drawing.Font("Bookman Old Style", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCampoArticulo.Location = new System.Drawing.Point(25, 607);
            this.lblCampoArticulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCampoArticulo.Name = "lblCampoArticulo";
            this.lblCampoArticulo.Size = new System.Drawing.Size(63, 17);
            this.lblCampoArticulo.TabIndex = 6;
            this.lblCampoArticulo.Text = "Campo:";
            // 
            // cboCampoArticulo
            // 
            this.cboCampoArticulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCampoArticulo.Font = new System.Drawing.Font("Bookman Old Style", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCampoArticulo.FormattingEnabled = true;
            this.cboCampoArticulo.Location = new System.Drawing.Point(104, 602);
            this.cboCampoArticulo.Margin = new System.Windows.Forms.Padding(4);
            this.cboCampoArticulo.Name = "cboCampoArticulo";
            this.cboCampoArticulo.Size = new System.Drawing.Size(160, 26);
            this.cboCampoArticulo.TabIndex = 8;
            this.cboCampoArticulo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cboCriterioArticulos
            // 
            this.cboCriterioArticulos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriterioArticulos.Font = new System.Drawing.Font("Bookman Old Style", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCriterioArticulos.FormattingEnabled = true;
            this.cboCriterioArticulos.Location = new System.Drawing.Point(364, 602);
            this.cboCriterioArticulos.Margin = new System.Windows.Forms.Padding(4);
            this.cboCriterioArticulos.Name = "cboCriterioArticulos";
            this.cboCriterioArticulos.Size = new System.Drawing.Size(160, 26);
            this.cboCriterioArticulos.TabIndex = 9;
            // 
            // lblCriterioArticulos
            // 
            this.lblCriterioArticulos.AutoSize = true;
            this.lblCriterioArticulos.Font = new System.Drawing.Font("Bookman Old Style", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCriterioArticulos.Location = new System.Drawing.Point(287, 607);
            this.lblCriterioArticulos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCriterioArticulos.Name = "lblCriterioArticulos";
            this.lblCriterioArticulos.Size = new System.Drawing.Size(69, 17);
            this.lblCriterioArticulos.TabIndex = 9;
            this.lblCriterioArticulos.Text = "Criterio:";
            // 
            // lblFiltroAvanzadoArticulos
            // 
            this.lblFiltroAvanzadoArticulos.AutoSize = true;
            this.lblFiltroAvanzadoArticulos.Font = new System.Drawing.Font("Bookman Old Style", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroAvanzadoArticulos.Location = new System.Drawing.Point(547, 607);
            this.lblFiltroAvanzadoArticulos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltroAvanzadoArticulos.Name = "lblFiltroAvanzadoArticulos";
            this.lblFiltroAvanzadoArticulos.Size = new System.Drawing.Size(132, 17);
            this.lblFiltroAvanzadoArticulos.TabIndex = 10;
            this.lblFiltroAvanzadoArticulos.Text = "Filtro Avanzado:";
            // 
            // txtboxFiltroAvanzadoArticulos
            // 
            this.txtboxFiltroAvanzadoArticulos.Font = new System.Drawing.Font("Bookman Old Style", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxFiltroAvanzadoArticulos.Location = new System.Drawing.Point(691, 605);
            this.txtboxFiltroAvanzadoArticulos.Margin = new System.Windows.Forms.Padding(4);
            this.txtboxFiltroAvanzadoArticulos.Name = "txtboxFiltroAvanzadoArticulos";
            this.txtboxFiltroAvanzadoArticulos.Size = new System.Drawing.Size(165, 23);
            this.txtboxFiltroAvanzadoArticulos.TabIndex = 10;
            // 
            // btnFiltroAvanzado
            // 
            this.btnFiltroAvanzado.AutoEllipsis = true;
            this.btnFiltroAvanzado.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnFiltroAvanzado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltroAvanzado.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnFiltroAvanzado.FlatAppearance.BorderSize = 2;
            this.btnFiltroAvanzado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnFiltroAvanzado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.btnFiltroAvanzado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltroAvanzado.Font = new System.Drawing.Font("Bookman Old Style", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltroAvanzado.Location = new System.Drawing.Point(877, 602);
            this.btnFiltroAvanzado.Margin = new System.Windows.Forms.Padding(4);
            this.btnFiltroAvanzado.Name = "btnFiltroAvanzado";
            this.btnFiltroAvanzado.Size = new System.Drawing.Size(100, 32);
            this.btnFiltroAvanzado.TabIndex = 11;
            this.btnFiltroAvanzado.Text = "Buscar";
            this.btnFiltroAvanzado.UseVisualStyleBackColor = false;
            this.btnFiltroAvanzado.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.AutoEllipsis = true;
            this.btnAgregar.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnAgregar.FlatAppearance.BorderSize = 2;
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(219, 542);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(187, 37);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar un Artículo";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.agregarArticulosToolStripMenuItem_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.AutoEllipsis = true;
            this.btnModificar.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnModificar.FlatAppearance.BorderSize = 2;
            this.btnModificar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnModificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(580, 542);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(161, 37);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.modificarArticulosToolStripMenuItem_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.AutoEllipsis = true;
            this.btnEliminar.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnEliminar.FlatAppearance.BorderSize = 2;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(747, 542);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(161, 37);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.eliminarArticuloToolStripMenuItem_Click);
            // 
            // btnDetalle
            // 
            this.btnDetalle.AutoEllipsis = true;
            this.btnDetalle.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnDetalle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetalle.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnDetalle.FlatAppearance.BorderSize = 2;
            this.btnDetalle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnDetalle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.btnDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetalle.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalle.Location = new System.Drawing.Point(412, 542);
            this.btnDetalle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(161, 37);
            this.btnDetalle.TabIndex = 2;
            this.btnDetalle.Text = "Ver Detalle";
            this.btnDetalle.UseVisualStyleBackColor = false;
            this.btnDetalle.Click += new System.EventHandler(this.verDetalleArticuloToolStripMenuItem_Click);
            // 
            // btnNavegarAtras
            // 
            this.btnNavegarAtras.AutoEllipsis = true;
            this.btnNavegarAtras.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnNavegarAtras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavegarAtras.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnNavegarAtras.FlatAppearance.BorderSize = 2;
            this.btnNavegarAtras.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnNavegarAtras.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.btnNavegarAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavegarAtras.Font = new System.Drawing.Font("Bookman Old Style", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavegarAtras.Location = new System.Drawing.Point(0, 4);
            this.btnNavegarAtras.Name = "btnNavegarAtras";
            this.btnNavegarAtras.Size = new System.Drawing.Size(88, 37);
            this.btnNavegarAtras.TabIndex = 0;
            this.btnNavegarAtras.Text = "<";
            this.btnNavegarAtras.UseVisualStyleBackColor = false;
            this.btnNavegarAtras.Click += new System.EventHandler(this.btnNavegarAtras_Click);
            // 
            // btnNavegarAdelante
            // 
            this.btnNavegarAdelante.AutoEllipsis = true;
            this.btnNavegarAdelante.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnNavegarAdelante.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavegarAdelante.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnNavegarAdelante.FlatAppearance.BorderSize = 2;
            this.btnNavegarAdelante.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnNavegarAdelante.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.btnNavegarAdelante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavegarAdelante.Font = new System.Drawing.Font("Bookman Old Style", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavegarAdelante.Location = new System.Drawing.Point(179, 4);
            this.btnNavegarAdelante.Name = "btnNavegarAdelante";
            this.btnNavegarAdelante.Size = new System.Drawing.Size(88, 37);
            this.btnNavegarAdelante.TabIndex = 1;
            this.btnNavegarAdelante.Text = ">";
            this.btnNavegarAdelante.UseVisualStyleBackColor = false;
            this.btnNavegarAdelante.Click += new System.EventHandler(this.btnNavegarAdelante_Click);
            // 
            // gbxNavegadorImg
            // 
            this.gbxNavegadorImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gbxNavegadorImg.Controls.Add(this.btnNavegarAtras);
            this.gbxNavegadorImg.Controls.Add(this.btnNavegarAdelante);
            this.gbxNavegadorImg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbxNavegadorImg.Location = new System.Drawing.Point(933, 437);
            this.gbxNavegadorImg.Name = "gbxNavegadorImg";
            this.gbxNavegadorImg.Size = new System.Drawing.Size(267, 41);
            this.gbxNavegadorImg.TabIndex = 19;
            this.gbxNavegadorImg.TabStop = false;
            // 
            // btnAgregarImg
            // 
            this.btnAgregarImg.AutoEllipsis = true;
            this.btnAgregarImg.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnAgregarImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarImg.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnAgregarImg.FlatAppearance.BorderSize = 2;
            this.btnAgregarImg.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnAgregarImg.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.btnAgregarImg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarImg.Font = new System.Drawing.Font("Bookman Old Style", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarImg.Location = new System.Drawing.Point(931, 485);
            this.btnAgregarImg.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregarImg.MaximumSize = new System.Drawing.Size(93, 53);
            this.btnAgregarImg.MinimumSize = new System.Drawing.Size(93, 53);
            this.btnAgregarImg.Name = "btnAgregarImg";
            this.btnAgregarImg.Size = new System.Drawing.Size(93, 53);
            this.btnAgregarImg.TabIndex = 5;
            this.btnAgregarImg.Text = "Agregar Imagen";
            this.btnAgregarImg.UseVisualStyleBackColor = false;
            this.btnAgregarImg.Click += new System.EventHandler(this.btnAgregarImg_Click);
            // 
            // btnModificarImg
            // 
            this.btnModificarImg.AutoEllipsis = true;
            this.btnModificarImg.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnModificarImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificarImg.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnModificarImg.FlatAppearance.BorderSize = 2;
            this.btnModificarImg.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnModificarImg.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.btnModificarImg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarImg.Font = new System.Drawing.Font("Bookman Old Style", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarImg.Location = new System.Drawing.Point(1023, 485);
            this.btnModificarImg.Margin = new System.Windows.Forms.Padding(4);
            this.btnModificarImg.MinimumSize = new System.Drawing.Size(94, 53);
            this.btnModificarImg.Name = "btnModificarImg";
            this.btnModificarImg.Size = new System.Drawing.Size(100, 53);
            this.btnModificarImg.TabIndex = 6;
            this.btnModificarImg.Text = "Modificar Imagen";
            this.btnModificarImg.UseVisualStyleBackColor = false;
            this.btnModificarImg.Click += new System.EventHandler(this.btnModificarImg_Click);
            // 
            // btnEliminarImg
            // 
            this.btnEliminarImg.AutoEllipsis = true;
            this.btnEliminarImg.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnEliminarImg.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnEliminarImg.FlatAppearance.BorderSize = 2;
            this.btnEliminarImg.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnEliminarImg.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.btnEliminarImg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarImg.Font = new System.Drawing.Font("Bookman Old Style", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarImg.Location = new System.Drawing.Point(1122, 485);
            this.btnEliminarImg.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminarImg.MaximumSize = new System.Drawing.Size(93, 53);
            this.btnEliminarImg.Name = "btnEliminarImg";
            this.btnEliminarImg.Size = new System.Drawing.Size(93, 53);
            this.btnEliminarImg.TabIndex = 7;
            this.btnEliminarImg.Text = "Eliminar Imagen";
            this.btnEliminarImg.UseVisualStyleBackColor = false;
            this.btnEliminarImg.Click += new System.EventHandler(this.btnEliminarImg_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1220, 650);
            this.Controls.Add(this.btnEliminarImg);
            this.Controls.Add(this.btnModificarImg);
            this.Controls.Add(this.btnAgregarImg);
            this.Controls.Add(this.gbxNavegadorImg);
            this.Controls.Add(this.btnDetalle);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnFiltroAvanzado);
            this.Controls.Add(this.txtboxFiltroAvanzadoArticulos);
            this.Controls.Add(this.lblFiltroAvanzadoArticulos);
            this.Controls.Add(this.lblCriterioArticulos);
            this.Controls.Add(this.cboCriterioArticulos);
            this.Controls.Add(this.cboCampoArticulo);
            this.Controls.Add(this.lblCampoArticulo);
            this.Controls.Add(this.txtboxFiltroArticulos);
            this.Controls.Add(this.lblFiltroArticulos);
            this.Controls.Add(this.pbxArticulo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dgvArticulos);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1238, 697);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1238, 697);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal Catálogo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).EndInit();
            this.gbxNavegadorImg.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem articuloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarArticulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoDeCategoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarCategoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarCategoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarCategoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarMarcaToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvArticulos;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox pbxArticulo;
        private System.Windows.Forms.ToolStripMenuItem listadoDeMarcaToolStripMenuItem;
        private System.Windows.Forms.Label lblFiltroArticulos;
        private System.Windows.Forms.TextBox txtboxFiltroArticulos;
        private System.Windows.Forms.Label lblCampoArticulo;
        private System.Windows.Forms.ComboBox cboCampoArticulo;
        private System.Windows.Forms.ComboBox cboCriterioArticulos;
        private System.Windows.Forms.Label lblCriterioArticulos;
        private System.Windows.Forms.Label lblFiltroAvanzadoArticulos;
        private System.Windows.Forms.TextBox txtboxFiltroAvanzadoArticulos;
        private System.Windows.Forms.Button btnFiltroAvanzado;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnDetalle;
        private System.Windows.Forms.Button btnNavegarAtras;
        private System.Windows.Forms.Button btnNavegarAdelante;
        private System.Windows.Forms.GroupBox gbxNavegadorImg;
        private System.Windows.Forms.Button btnAgregarImg;
        private System.Windows.Forms.Button btnModificarImg;
        private System.Windows.Forms.Button btnEliminarImg;
    }
}

