namespace lab6
{
	using System.Drawing;

	public abstract class Figure
	{
		private Color _color;
		public readonly PointF Center;
		public Color Color => _color;
		public float BorderThickness;
		protected Graphics Graphics;

		protected Figure(PointF center, Color color, float borderThickness) =>
			(Center,_color, BorderThickness)=(center,color, borderThickness);

		public void ReplaceColor(Color newColor, float borderThickness=2)
		{
			_color=newColor;
			BorderThickness=borderThickness;
			Draw(Graphics);
		}

		public bool Contains(Point point) => Contains(new PointF(point.X, point.Y));
		public abstract bool Contains(PointF pointf);

		public void Draw(Graphics graphics)
		{
			Graphics=graphics;
			DrawImpl();
		}

		protected abstract void DrawImpl();


		public abstract double Area
		{
			get;
		}
	}
}
