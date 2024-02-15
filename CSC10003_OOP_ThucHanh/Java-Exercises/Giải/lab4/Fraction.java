public class Fraction
{ 	
		private int numerator=0;
		private int denominator=1;
		public Fraction()
		{ 
				this.numerator=0;
				this.denominator=1;
		}
		public Fraction(int num,int den)
		{	
			this.numerator=num;
			this.denominator=den;
		}
		public Fraction add(Fraction f,Fraction f1)
		{ 
			this.numerator=f.numerator*f1.denominator+f1.numerator*f.denominator;
			this.denominator=f.denominator*f1.denominator;
			return this;
		}
		public Fraction sub(Fraction f,Fraction f1)
		{ 
			
			this.numerator=f.numerator*f1.denominator-f1.numerator*f.denominator;
			this.denominator=f.denominator*f1.denominator;
			return this;
		}
		public Fraction mul(Fraction f,Fraction f1)
		{ 
			
			this.numerator=f.numerator*f1.numerator;
			this.denominator=f.denominator*f1.denominator;
			return this;
		}
		public Fraction div(Fraction f,Fraction f1)
		{ 
			
		this.numerator=f.numerator*f1.denominator;
			this.denominator=f.denominator*f1.numerator;
			return this;
		}
		public int GCD(int n1,int n2)
		{	
				n1=Math.abs(n1);
				n2=Math.abs(n2);
					while(n1 != n2)
			{
				if(n1 > n2)
					n1 -= n2;
				else
					n2 -= n1;
			}
			return n1;
		}			
		public void reducer()
		{
		if(numerator!=0&&denominator!=0)
		{int gcd=GCD(numerator,denominator);
			numerator=numerator/gcd;
		denominator=denominator/gcd;}
		}
			
		@Override
		public String toString()
		{
			return ("Fraction(num="+numerator+",den="+denominator+")");
		}
		
}		