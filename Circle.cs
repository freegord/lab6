// ReSharper disable TooManyDependencies
namespace lab6
{
	using System;
	using System.Drawing;

	public class Circle : Figure
	{
		private readonly float _radius;

		public override bool Contains(PointF pointf) =>
			Math.Pow(Center.X-pointf.X, 2)+Math.Pow(Center.X-pointf.X, 2)<=Math.Pow(_radius,2);

		protected override void DrawImpl()
		{
			var r = new RectangleF(Center.X-_radius, Center.Y-_radius, 2*_radius, 2*_radius);
			var col=Color.FromArgb(64, Color);
			Graphics.FillEllipse(new SolidBrush(col), r);
			Graphics.DrawEllipse(new Pen(Color, BorderThickness), r);

		}

		public override double Area => Math.PI*Math.Pow(_radius, 2);

		public Circle(float radius, PointF center, Color color, float borderThickness)
			: base(center, color, borderThickness) =>
			_radius=radius;
	}
}
