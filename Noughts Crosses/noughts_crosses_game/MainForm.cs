using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace noughts_crosses_game
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		
		PictureBox oldL = new PictureBox();
		PictureBox example = new PictureBox();
		
		void MainFormLoad(object sender, EventArgs e)
		{
			this.BackColor = Color.White;
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			
			oldL.SizeMode = PictureBoxSizeMode.StretchImage;
			oldL.Width = 100; oldL.Height = 100;
			oldL.BackColor = Color.Transparent;
			oldL.Load("old_lady.png"); oldL.Parent = this;
			oldL.Top = (this.Height / 2) - 80;
			oldL.Left = 25;
			
			example.SizeMode = PictureBoxSizeMode.StretchImage;
			example.Width = 100; example.Height = 100;
			example.BackColor = Color.Transparent;
			example.Load("example_game.png"); example.Parent = this;
			example.Top = (this.Height / 2) - 70;
			example.Left = this.Width - 130;
			
			for (int i = 0; i < 9; i++) 
			{
				Button btnTest = new Button();
				btnTest.Parent = this;
				btnTest.BackColor = Color.White;
				btnTest.Width = 50;
				btnTest.Height = 50;
				
				if (i < 3)
				{
					btnTest.Top = (this.Height / 2) - 100;
					btnTest.Left = (this.Width / 2 - 150) + 60 * (i + 1);
				}
				else if (i >= 3 && i < 6)
				{
					btnTest.Top = (this.Height / 2) - 50;
					btnTest.Left = (this.Width / 2 - 150) + 60 * (i + 1 - 3);
				}
				else
				{
					btnTest.Top = this.Height / 2;
					btnTest.Left = (this.Width / 2 - 150) + 60 * (i + 1 - 6);
				}
			}
		}
	}
}
