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
		Label actual = new Label();
		
		sbyte player = 0;
		int[] listSelected = new int[9]
		{
			9, 9, 9, 9, 9, 9, 9, 9, 9
		};
		
		void MainFormLoad(object sender, EventArgs e)
		{
			this.BackColor = Color.White;
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.MaximizeBox = false; this.Focus();
			
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
				btnTest.Tag = i;
				btnTest.Parent = this;
				btnTest.BackColor = Color.White;
				btnTest.Width = 50;
				btnTest.Height = 50;
				btnTest.Click += ButtonClick;
				
				if (i < 3)
				{
					btnTest.Top = (this.Height / 2) - 110;
					btnTest.Left = (this.Width / 2 - 150) + 60 * (i + 1);
				}
				else if (i >= 3 && i < 6)
				{
					btnTest.Top = (this.Height / 2) - 50;
					btnTest.Left = (this.Width / 2 - 150) + 60 * (i + 1 - 3);
				}
				else
				{
					btnTest.Top = (this.Height / 2) + 10;
					btnTest.Left = (this.Width / 2 - 150) + 60 * (i + 1 - 6);
				}
			}
			
			actual.AutoSize = true; actual.Parent = this;
			actual.BorderStyle = BorderStyle.FixedSingle;
			actual.Top = this.Height - 125;
			actual.Left = (this.Width / 2) - 58;
			actual.Font = new Font("Times New Roman", 15f);
			actual.Text = "PLAYER: " + (player + 1).ToString();
		}
		
		void ButtonClick(object sender, EventArgs e) 
		{
			Button b = sender as Button;
			b.BackgroundImageLayout = ImageLayout.Stretch;
			
			switch (player)
			{
				case 0:
					b.BackgroundImage = Image.FromFile("pl1.png");
					listSelected[Convert.ToInt32(b.Tag)] = 0;
					player = 1;
					break;
				case 1:
					b.BackgroundImage = Image.FromFile("pl2.png");
					listSelected[Convert.ToInt32(b.Tag)] = 1;
					player = 0;
					break;
			}
			
			b.Enabled = false;
			CheckWinner(Convert.ToInt32(b.Tag));
			
			actual.Text = "PLAYER: " + (player + 1).ToString();
			this.ActiveControl = null; 
		}
		
		void CheckWinner(int tag)
		{
			bool draw = false;
			
			int[] listVertical = new int[9]
			{
				0, 3, 6, 1, 4, 7, 2, 5, 8
			};
			
			int[] listDiagonal = new int[6]
			{
				0, 4, 8, 2, 4, 6
			};
				
			for (int i = 0; i < 2; i++)
			{
				bool validation = false;
				int horizontal = 0;
				int vertical = 0;
				int diagonal = 0;

				for (int index = 0; index < 9; index++)
				{
					if (listSelected[index] == i)
					{
						horizontal++;
					}
					
					if (listSelected[listVertical[index]] == i)
					{
						vertical++;
					} 
					
					if (index < 6)
					{
						if (listSelected[listDiagonal[index]] == i)
						{
							diagonal++;
						} 
					}
					
					if (horizontal >= 3 || vertical >= 3 || diagonal >= 3)
					{
						validation = true;
						break;
					}
					
					if (index == 2 || index == 5 || index == 8)
					{
						horizontal = 0;	vertical = 0; diagonal = 0;
					}
				}
				
				
				if (validation == true)
				{
					MessageBox.Show("O Player " + (i + 1).ToString() + " Venceu o jogo!!!");
					GameRestart();
					break;
				}
				
				if (i == 1)
				{
					draw = true;
				}
			}
			
			if (draw = true && Array.Exists(listSelected, element => element == 9) == false)
			{
				MessageBox.Show("VELHA!!! Infelizmente (?), ninguém venceu o jogo.");
				GameRestart();
			}
		}
		
		void GameRestart()
		{
			Application.Restart();
		}
	}
}
