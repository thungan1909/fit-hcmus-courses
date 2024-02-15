
public class FractionTest
{
	public static void main(String[] args)
		{
			Fraction f=new Fraction(1,2);
			Fraction f1=new Fraction(2,4);
			Fraction f2=new Fraction();
			f2=f2.add(f,f1);
			f2.reducer();
			System.out.println("Add: "+f2.toString());
			f2=f2.sub(f,f1);
			f2.reducer();
			System.out.println("Sub: "+f2.toString());
			f2=f2.mul(f,f1);
			f2.reducer();
			System.out.println("Mul: "+f2.toString());
			f2=f2.div(f,f1);
			f2.reducer();
			System.out.println("Div: "+f2.toString());
		}
}