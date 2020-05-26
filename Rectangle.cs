// ReSharper disable TooManyDependencies
namespace lab6
{
	using System.Drawing;
	using System;

	class Rectangle : Figure
	{
		private readonly float _width;
		private readonly float _height;

		public override bool Contains(PointF pointf) =>
			Math.Abs(pointf.X-Center.X)<=_width/2
		 && Math.Abs(pointf.Y-Center.Y)<=_height/2;

		protected override void DrawImpl()
		{
			var r=new RectangleF(Center.X-_width/2, Center.Y-_height/2, _width, _height);
			var col=Color.FromArgb(64, Color);
			Graphics.FillRectangle(new SolidBrush(col), r);
			Graphics.DrawRectangle(new Pen(Color, BorderThickness), System.Drawing.Rectangle.Ceiling(r));

		}
		public override double Area => _width*_height;

		public Rectangle(float width, float height, PointF center, Color color, float borderThickness)
			: base(center, color, borderThickness) =>
			(_width, _height)=(width,height);
	}
}
