public class Rectangle
{
	private float width=1.0f;
	private float length=1.0f;
		public Rectangle()
		{
		this.width=1.0f;
		this.length=1.0f;
		}
		public Rectangle(float width,float length)
		{
		this.width=width;
		this.length=length;
		}
		public float getWidth()
		{
			return this.width;
		}
		public float getLength()
		{
			return this.length;
		}
		public void setWidth(float width)
		{
				this.width=width;
		}
		public void setLength(float length)
		{ 	
			this.length=length;
		}
		@Override
		public String toString()
		{
			return "Rectangle[width: "+width+",length: "+length+"]";
		}
}