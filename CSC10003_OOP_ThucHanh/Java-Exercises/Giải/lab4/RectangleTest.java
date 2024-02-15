public class RectangleTest
{
	public static void main(String[] args)
		{
		
				Rectangle rectangle=new Rectangle();
				rectangle.setWidth(5f);
				rectangle.setLength(9f);
				System.out.println("Width:"+ rectangle.getWidth());
				System.out.println("Length:"+ rectangle.getLength());
				System.out.println("New size");
				rectangle.setWidth(10f);
				rectangle.setLength(6f);
				System.out.println(rectangle.toString());
		}
}