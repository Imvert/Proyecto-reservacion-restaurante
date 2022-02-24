
namespace Project_restaurant_reservation
{
    partial class plantilla_Admin
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
            this.panelLateralMenu = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Mantenimiento = new System.Windows.Forms.Button();
            this.panelManteSubMenu = new System.Windows.Forms.Panel();
            this.btn_Tusuario = new System.Windows.Forms.Button();
            this.btn_roles = new System.Windows.Forms.Button();
            this.btn_Treservas = new System.Windows.Forms.Button();
            this.btn_Tplatos = new System.Windows.Forms.Button();
            this.btn_TiPlatos = new System.Windows.Forms.Button();
            this.panelchild = new System.Windows.Forms.Panel();
            this.panelLateralMenu.SuspendLayout();
            this.panelManteSubMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLateralMenu
            // 
            this.panelLateralMenu.BackColor = System.Drawing.Color.Khaki;
            this.panelLateralMenu.Controls.Add(this.panelManteSubMenu);
            this.panelLateralMenu.Controls.Add(this.btn_Mantenimiento);
            this.panelLateralMenu.Controls.Add(this.panel1);
            this.panelLateralMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLateralMenu.Location = new System.Drawing.Point(0, 0);
            this.panelLateralMenu.Name = "panelLateralMenu";
            this.panelLateralMenu.Size = new System.Drawing.Size(200, 527);
            this.panelLateralMenu.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Project_restaurant_reservation.Properties.Resources.logo_login;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 77);
            this.panel1.TabIndex = 0;
            // 
            // btn_Mantenimiento
            // 
            this.btn_Mantenimiento.BackColor = System.Drawing.Color.Goldenrod;
            this.btn_Mantenimiento.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Mantenimiento.Location = new System.Drawing.Point(0, 77);
            this.btn_Mantenimiento.Name = "btn_Mantenimiento";
            this.btn_Mantenimiento.Size = new System.Drawing.Size(200, 40);
            this.btn_Mantenimiento.TabIndex = 1;
            this.btn_Mantenimiento.Text = "Mantenimiento";
            this.btn_Mantenimiento.UseVisualStyleBackColor = false;
            this.btn_Mantenimiento.Click += new System.EventHandler(this.btn_Mantenimiento_Click);
            // 
            // panelManteSubMenu
            // 
            this.panelManteSubMenu.Controls.Add(this.btn_TiPlatos);
            this.panelManteSubMenu.Controls.Add(this.btn_Tplatos);
            this.panelManteSubMenu.Controls.Add(this.btn_Treservas);
            this.panelManteSubMenu.Controls.Add(this.btn_roles);
            this.panelManteSubMenu.Controls.Add(this.btn_Tusuario);
            this.panelManteSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelManteSubMenu.Location = new System.Drawing.Point(0, 117);
            this.panelManteSubMenu.Name = "panelManteSubMenu";
            this.panelManteSubMenu.Size = new System.Drawing.Size(200, 157);
            this.panelManteSubMenu.TabIndex = 2;
            // 
            // btn_Tusuario
            // 
            this.btn_Tusuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Tusuario.Location = new System.Drawing.Point(0, 0);
            this.btn_Tusuario.Name = "btn_Tusuario";
            this.btn_Tusuario.Size = new System.Drawing.Size(200, 30);
            this.btn_Tusuario.TabIndex = 0;
            this.btn_Tusuario.Text = "Usuarios";
            this.btn_Tusuario.UseVisualStyleBackColor = true;
            this.btn_Tusuario.Click += new System.EventHandler(this.btn_Tusuario_Click);
            // 
            // btn_roles
            // 
            this.btn_roles.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_roles.Location = new System.Drawing.Point(0, 30);
            this.btn_roles.Name = "btn_roles";
            this.btn_roles.Size = new System.Drawing.Size(200, 30);
            this.btn_roles.TabIndex = 1;
            this.btn_roles.Text = "Roles";
            this.btn_roles.UseVisualStyleBackColor = true;
            this.btn_roles.Click += new System.EventHandler(this.btn_roles_Click);
            // 
            // btn_Treservas
            // 
            this.btn_Treservas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Treservas.Location = new System.Drawing.Point(0, 60);
            this.btn_Treservas.Name = "btn_Treservas";
            this.btn_Treservas.Size = new System.Drawing.Size(200, 30);
            this.btn_Treservas.TabIndex = 2;
            this.btn_Treservas.Text = "Reservas";
            this.btn_Treservas.UseVisualStyleBackColor = true;
            this.btn_Treservas.Click += new System.EventHandler(this.btn_Treservas_Click);
            // 
            // btn_Tplatos
            // 
            this.btn_Tplatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Tplatos.Location = new System.Drawing.Point(0, 90);
            this.btn_Tplatos.Name = "btn_Tplatos";
            this.btn_Tplatos.Size = new System.Drawing.Size(200, 30);
            this.btn_Tplatos.TabIndex = 3;
            this.btn_Tplatos.Text = "Registro platos";
            this.btn_Tplatos.UseVisualStyleBackColor = true;
            this.btn_Tplatos.Click += new System.EventHandler(this.btn_Tplatos_Click);
            // 
            // btn_TiPlatos
            // 
            this.btn_TiPlatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_TiPlatos.Location = new System.Drawing.Point(0, 120);
            this.btn_TiPlatos.Name = "btn_TiPlatos";
            this.btn_TiPlatos.Size = new System.Drawing.Size(200, 30);
            this.btn_TiPlatos.TabIndex = 4;
            this.btn_TiPlatos.Text = "Tipo plato";
            this.btn_TiPlatos.UseVisualStyleBackColor = true;
            this.btn_TiPlatos.Click += new System.EventHandler(this.btn_TiPlatos_Click);
            // 
            // panelchild
            // 
            this.panelchild.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.panelchild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelchild.Location = new System.Drawing.Point(200, 0);
            this.panelchild.Name = "panelchild";
            this.panelchild.Size = new System.Drawing.Size(735, 527);
            this.panelchild.TabIndex = 1;
            // 
            // plantilla_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(935, 527);
            this.Controls.Add(this.panelchild);
            this.Controls.Add(this.panelLateralMenu);
            this.Name = "plantilla_Admin";
            this.Text = "Adminstrador";
            this.Load += new System.EventHandler(this.plantilla_Load);
            this.panelLateralMenu.ResumeLayout(false);
            this.panelManteSubMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLateralMenu;
        private System.Windows.Forms.Panel panelManteSubMenu;
        private System.Windows.Forms.Button btn_Mantenimiento;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Tusuario;
        private System.Windows.Forms.Button btn_Tplatos;
        private System.Windows.Forms.Button btn_Treservas;
        private System.Windows.Forms.Button btn_roles;
        private System.Windows.Forms.Button btn_TiPlatos;
        private System.Windows.Forms.Panel panelchild;
    }
}