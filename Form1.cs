namespace lab6
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics.Contracts;
	using System.Drawing;
	using System.Linq;
	using System.Windows.Forms;
	using System.Drawing.Drawing2D;

	public partial class Form1 : Form
	{
		private readonly Random rng=new Random();
		private readonly Graphics g;
		private readonly List<Figure> figures = new List<Figure>();

		public Form1()
		{
			InitializeComponent();
			g=CreateGraphics();
			g.SmoothingMode=SmoothingMode.HighQuality;
			g.SetClip(new System.Drawing.Rectangle(0, 0, 3*Width/2, 3*Height/2));
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			for (var i=0; i<20; i++)
			{
				var f = rng.Next()%2>0 ?
					(Figure)new Circle((float)rng.NextDouble()*150,
									   new PointF((float)rng.NextDouble()*Width,
												  (float)rng.NextDouble()*Width),
									   Color.FromArgb(rng.Next()%0xFF, rng.Next()%0xFF, rng.Next()%0xFF), 2)

					: new Rectangle((float)rng.NextDouble()*150,
									(float)rng.NextDouble()*150,
									new PointF((float)rng.NextDouble()*Width,
											   (float)rng.NextDouble()*Height),
									Color.FromArgb(rng.Next(256), rng.Next(256), rng.Next(256)), 2);

				figures.Add(f);
			}
			Refresh();
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			SuspendLayout();
			g.Clear(Color.White);
			foreach (var figure in figures)
				figure.Draw(g);
			ResumeLayout(false);
		}

		private void Form1_Resize(object sender, EventArgs e) => Refresh();

		private void Form1_MouseClick(object sender, MouseEventArgs e)
		{
			foreach (var figure in figures.Where(figure => figure.Contains(e.Location)))
			{
				figure.ReplaceColor(
					Color.FromArgb(rng.Next()%0xFF, rng.Next()%0xFF, rng.Next()%0xFF),
					figure.BorderThickness+1);
				area.Text=$"{figure.Area:N2} px";
			}
		}



	}
}
