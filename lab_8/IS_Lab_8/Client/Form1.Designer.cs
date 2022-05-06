namespace Client
{
    partial class Form1
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
        private void InitializeComponent()
        {
            this.signInButton = new System.Windows.Forms.Button();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.jwtTokenLabel = new System.Windows.Forms.Label();
            this.jwtTokenTextBox = new System.Windows.Forms.TextBox();
            this.getUserCountLabel = new System.Windows.Forms.Label();
            this.getMagicNumberLabel = new System.Windows.Forms.Label();
            this.getAllUsersLabel = new System.Windows.Forms.Label();
            this.getUserCountButton = new System.Windows.Forms.Button();
            this.getMagicNumberButton = new System.Windows.Forms.Button();
            this.getAllUsersButton = new System.Windows.Forms.Button();
            this.userListTextBox = new System.Windows.Forms.TextBox();
            this.userCountLabel = new System.Windows.Forms.Label();
            this.magicNumberLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // signInButton
            // 
            this.signInButton.Location = new System.Drawing.Point(143, 102);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(75, 23);
            this.signInButton.TabIndex = 0;
            this.signInButton.Text = "Sign In";
            this.signInButton.UseVisualStyleBackColor = true;
            this.signInButton.Click += new System.EventHandler(this.signInButton_Click);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(132, 44);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(100, 23);
            this.usernameTextBox.TabIndex = 1;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(132, 73);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(100, 23);
            this.passwordTextBox.TabIndex = 2;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(63, 47);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(63, 15);
            this.usernameLabel.TabIndex = 3;
            this.usernameLabel.Text = "Username:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(66, 76);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(60, 15);
            this.passwordLabel.TabIndex = 4;
            this.passwordLabel.Text = "Password:";
            // 
            // jwtTokenLabel
            // 
            this.jwtTokenLabel.AutoSize = true;
            this.jwtTokenLabel.Location = new System.Drawing.Point(66, 146);
            this.jwtTokenLabel.Name = "jwtTokenLabel";
            this.jwtTokenLabel.Size = new System.Drawing.Size(65, 15);
            this.jwtTokenLabel.TabIndex = 5;
            this.jwtTokenLabel.Text = "JWT Token:";
            // 
            // jwtTokenTextBox
            // 
            this.jwtTokenTextBox.Location = new System.Drawing.Point(66, 173);
            this.jwtTokenTextBox.Multiline = true;
            this.jwtTokenTextBox.Name = "jwtTokenTextBox";
            this.jwtTokenTextBox.ReadOnly = true;
            this.jwtTokenTextBox.Size = new System.Drawing.Size(166, 223);
            this.jwtTokenTextBox.TabIndex = 6;
            // 
            // getUserCountLabel
            // 
            this.getUserCountLabel.AutoSize = true;
            this.getUserCountLabel.Location = new System.Drawing.Point(349, 50);
            this.getUserCountLabel.Name = "getUserCountLabel";
            this.getUserCountLabel.Size = new System.Drawing.Size(87, 15);
            this.getUserCountLabel.TabIndex = 7;
            this.getUserCountLabel.Text = "Get user count:";
            // 
            // getMagicNumberLabel
            // 
            this.getMagicNumberLabel.AutoSize = true;
            this.getMagicNumberLabel.Location = new System.Drawing.Point(327, 78);
            this.getMagicNumberLabel.Name = "getMagicNumberLabel";
            this.getMagicNumberLabel.Size = new System.Drawing.Size(109, 15);
            this.getMagicNumberLabel.TabIndex = 8;
            this.getMagicNumberLabel.Text = "Get magic number:";
            // 
            // getAllUsersLabel
            // 
            this.getAllUsersLabel.AutoSize = true;
            this.getAllUsersLabel.Location = new System.Drawing.Point(363, 142);
            this.getAllUsersLabel.Name = "getAllUsersLabel";
            this.getAllUsersLabel.Size = new System.Drawing.Size(73, 15);
            this.getAllUsersLabel.TabIndex = 9;
            this.getAllUsersLabel.Text = "Get all users:";
            // 
            // getUserCountButton
            // 
            this.getUserCountButton.Location = new System.Drawing.Point(442, 46);
            this.getUserCountButton.Name = "getUserCountButton";
            this.getUserCountButton.Size = new System.Drawing.Size(75, 23);
            this.getUserCountButton.TabIndex = 10;
            this.getUserCountButton.Text = "Send";
            this.getUserCountButton.UseVisualStyleBackColor = true;
            this.getUserCountButton.Click += new System.EventHandler(this.getUserCountButton_Click);
            // 
            // getMagicNumberButton
            // 
            this.getMagicNumberButton.Location = new System.Drawing.Point(442, 73);
            this.getMagicNumberButton.Name = "getMagicNumberButton";
            this.getMagicNumberButton.Size = new System.Drawing.Size(75, 23);
            this.getMagicNumberButton.TabIndex = 11;
            this.getMagicNumberButton.Text = "Send";
            this.getMagicNumberButton.UseVisualStyleBackColor = true;
            this.getMagicNumberButton.Click += new System.EventHandler(this.getMagicNumberButton_Click);
            // 
            // getAllUsersButton
            // 
            this.getAllUsersButton.Location = new System.Drawing.Point(442, 138);
            this.getAllUsersButton.Name = "getAllUsersButton";
            this.getAllUsersButton.Size = new System.Drawing.Size(75, 23);
            this.getAllUsersButton.TabIndex = 12;
            this.getAllUsersButton.Text = "Send";
            this.getAllUsersButton.UseVisualStyleBackColor = true;
            this.getAllUsersButton.Click += new System.EventHandler(this.getAllUsersButton_Click);
            // 
            // userListTextBox
            // 
            this.userListTextBox.Location = new System.Drawing.Point(349, 173);
            this.userListTextBox.Multiline = true;
            this.userListTextBox.Name = "userListTextBox";
            this.userListTextBox.ReadOnly = true;
            this.userListTextBox.Size = new System.Drawing.Size(190, 223);
            this.userListTextBox.TabIndex = 13;
            // 
            // userCountLabel
            // 
            this.userCountLabel.AutoSize = true;
            this.userCountLabel.Location = new System.Drawing.Point(523, 50);
            this.userCountLabel.Name = "userCountLabel";
            this.userCountLabel.Size = new System.Drawing.Size(0, 15);
            this.userCountLabel.TabIndex = 14;
            // 
            // magicNumberLabel
            // 
            this.magicNumberLabel.AutoSize = true;
            this.magicNumberLabel.Location = new System.Drawing.Point(523, 76);
            this.magicNumberLabel.Name = "magicNumberLabel";
            this.magicNumberLabel.Size = new System.Drawing.Size(0, 15);
            this.magicNumberLabel.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 438);
            this.Controls.Add(this.magicNumberLabel);
            this.Controls.Add(this.userCountLabel);
            this.Controls.Add(this.userListTextBox);
            this.Controls.Add(this.getAllUsersButton);
            this.Controls.Add(this.getMagicNumberButton);
            this.Controls.Add(this.getUserCountButton);
            this.Controls.Add(this.getAllUsersLabel);
            this.Controls.Add(this.getMagicNumberLabel);
            this.Controls.Add(this.getUserCountLabel);
            this.Controls.Add(this.jwtTokenTextBox);
            this.Controls.Add(this.jwtTokenLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.signInButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button signInButton;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Label usernameLabel;
        private Label passwordLabel;
        private Label jwtTokenLabel;
        private TextBox jwtTokenTextBox;
        private Label getUserCountLabel;
        private Label getMagicNumberLabel;
        private Label getAllUsersLabel;
        private Button getUserCountButton;
        private Button getMagicNumberButton;
        private Button getAllUsersButton;
        private TextBox userListTextBox;
        private Label userCountLabel;
        private Label magicNumberLabel;
    }
}