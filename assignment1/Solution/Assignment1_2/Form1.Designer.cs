namespace Assignment1_2
{
    partial class Form1
    {
        // Existing code...

        #region Windows Form Designer generated code

        // Existing code...

        private void InitializeComponent()
        {
            // Existing code...

            // Initialize textBox1
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.Controls.Add(this.textBox1);

            // Initialize textBox2
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox2.Location = new System.Drawing.Point(12, 40);
            this.Controls.Add(this.textBox2);

            // Initialize comboBox
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.comboBox.Items.AddRange(new object[] { "+", "-", "*", "/" });
            this.comboBox.Location = new System.Drawing.Point(12, 68);
            this.Controls.Add(this.comboBox);

            // Initialize calculateButton
            this.calculateButton = new System.Windows.Forms.Button();
            this.calculateButton.Text = "Calculate";
            this.calculateButton.Location = new System.Drawing.Point(12, 96);
            this.calculateButton.Size = new System.Drawing.Size(200, 40); // Adjusted size
            this.Controls.Add(this.calculateButton);

            // Initialize resultLabel
            this.resultLabel = new System.Windows.Forms.Label();
            this.resultLabel.Location = new System.Drawing.Point(12, 144);
            this.Controls.Add(this.resultLabel);

            // Event handler assignments
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);

            // Existing code...
        }

        // Existing code...

        #endregion

        // Event handler methods
        private void calculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                double num1 = Convert.ToDouble(this.textBox1.Text);
                double num2 = Convert.ToDouble(this.textBox2.Text);
                string op = this.comboBox.SelectedItem.ToString();
                double result = 0;

                switch (op)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        if (num2 != 0)
                        {
                            result = num1 / num2;
                        }
                        else
                        {
                            MessageBox.Show("除数不能为零");
                            return;
                        }
                        break;
                    default:
                        MessageBox.Show("请选择一个有效的运算符");
                        return;
                }

                this.resultLabel.Text = "Result: " + result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入无效: " + ex.Message);
            }
        }

        // Declare controls
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Label resultLabel;
    }
}
