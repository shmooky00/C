namespace joke
{
    partial class jokepunchline
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
            this.setupButton = new System.Windows.Forms.Button();
            this.jokeButton = new System.Windows.Forms.Button();
            this.jokeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // setupButton
            // 
            this.setupButton.Location = new System.Drawing.Point(216, 206);
            this.setupButton.Name = "setupButton";
            this.setupButton.Size = new System.Drawing.Size(75, 23);
            this.setupButton.TabIndex = 0;
            this.setupButton.Text = "Setup";
            this.setupButton.UseVisualStyleBackColor = true;
            this.setupButton.Click += new System.EventHandler(this.setupButton_Click);
            // 
            // jokeButton
            // 
            this.jokeButton.Location = new System.Drawing.Point(396, 206);
            this.jokeButton.Name = "jokeButton";
            this.jokeButton.Size = new System.Drawing.Size(75, 23);
            this.jokeButton.TabIndex = 1;
            this.jokeButton.Text = "Joke";
            this.jokeButton.UseVisualStyleBackColor = true;
            this.jokeButton.Click += new System.EventHandler(this.jokeButton_Click);
            // 
            // jokeLabel
            // 
            this.jokeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jokeLabel.Location = new System.Drawing.Point(216, 148);
            this.jokeLabel.Name = "jokeLabel";
            this.jokeLabel.Size = new System.Drawing.Size(255, 23);
            this.jokeLabel.TabIndex = 2;
            this.jokeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // jokepunchline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.jokeLabel);
            this.Controls.Add(this.jokeButton);
            this.Controls.Add(this.setupButton);
            this.Name = "jokepunchline";
            this.Text = "jokepunchline";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button setupButton;
        private System.Windows.Forms.Button jokeButton;
        private System.Windows.Forms.Label jokeLabel;
    }
}

