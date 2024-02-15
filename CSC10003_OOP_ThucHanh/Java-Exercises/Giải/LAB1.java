import java.util.Scanner;
public class LAB1
{
	public static void Cau1()
	{
	Scanner sc=new Scanner(System.in);
	System.out.println("Input your Info (Name, DOB, StudentID)");
	String name=sc.nextLine();
	String DOB=sc.nextLine();
	String StudentID=sc.nextLine();
	System.out.println("Name: "+name);
	System.out.println("DOB: "+DOB);
	System.out.println("Student ID: "+StudentID);
	}
	
	public static void Cau2()
	{ //Compute the area off a rectangle (HCN)
	Scanner sc=new Scanner(System.in);
	float base, height,area;
	System.out.println("Input base:");
	base=sc.nextFloat();
	System.out.println("Input height:");
	height=sc.nextFloat();
	area=base*height*1/2;
	System.out.println("Base = "+base);
	System.out.println("Height = "+height);
	System.out.println("Area = "+ area);
	}
	
	
	public static void Cau3(){
		//convert the temperature from Fahrenheit to Celsius
		Scanner sc=new Scanner(System.in);
		float F,C;
		System.out.println("convert the temperature from Fahrenheit to Celsius");
		System.out.println("Input Fahrenheit");
		F=sc.nextFloat();
		F=F-273;
		System.out.println("Celsius = " +F);
		System.out.println("convert the temperature from Celsius to Fahrenheit");
		System.out.println("Input Celsius");
		C=sc.nextFloat();
		C=C+273;
		System.out.println("Fahrenheit = " +C);
	}
	
	
	public static void Cau4(){
		//check LeapYear
	Scanner sc=new Scanner(System.in);
	int year;
	System.out.println("Check leap year! Please input a year");
	year=sc.nextInt();
	if((year%400==0)||(year%4==0&&year%100!=0))
	{
	System.out.println("Yes, this is leap year");}
	else
	{System.out.println("No, it isn't");}
	}
	
	
	public static void Cau5(){
	Scanner sc=new Scanner(System.in);
	int a,b,c,min;
	System.out.println("Find minimum number. Please input 3 numbers");
	a=sc.nextInt();
	b=sc.nextInt();
	c=sc.nextInt();
	min=a;
	if(b<min) min=b;
	if(c<min) min=c;
	System.out.println("Minimum number is " +min);}
	
	

	public static void Cau6(){
		Scanner sc=new Scanner(System.in);
		int num;
		System.out.println("Check even or odd. Please input a number");	
		num=sc.nextInt();
		if(num%2==0)
		System.out.println("It is even number");
		else 
			System.out.println("It is odd number");
	}
	
	public static boolean isAlphaNumberic(char c)
	{ if(!(c>='A'&&c<='Z')&&!(c>='a'&&c<='z')&&!(c>='0'&&c<='9'))
	return false;
	else return true;}
	
	
	public static void Cau7(){
		Scanner sc=new Scanner(System.in);
		char num;
		
		System.out.println("Check whether it is alphanumeric or not. Please input a number");	
		num=sc.next().charAt(0); //Do khong the dung nextChar()
		if(isAlphaNumberic(num))
		System.out.println("yes, it is alpnumberic");
		else
       	System.out.println("no, it isn't");}
	
		public static int Cau8A(int n){
			if(n<0) return 0;
		return n+Cau8A(n-1);}
	
		public static int Cau8B(int n){
			if(n==1) return 1;
		return n*Cau8B(n-1);}
		
		public static double Cau8C(int n){
			if(n==0) return 1;
		return Math.pow(2,n)+Cau8C(n-1);}
		
		public static double Cau8D(int n){
			if(n==1) return 1;
		return 1/(2*n)+Cau8D(n-1);}
		
		
		public static double Cau8E(int n){
			if(n==0) return 0;
		return Math.pow(n,2)+Cau8E(n-1);}
		
		
	public static void Cau8(){
		Scanner sc=new Scanner(System.in);
		int n;
		System.out.println("Input n");
		n=sc.nextInt();
		System.out.println("Cau 8a= " +Cau8A(n));
		System.out.println("Cau 8b= " +Cau8B(n));
		System.out.println("Cau 8c= " +Cau8C(n));
		System.out.println("Cau 8d= " +Cau8D(n));
		System.out.println("Cau 8e= " +Cau8E(n));
	}		
	
	
	public static void Cau9(){
		Scanner sc=new Scanner(System.in);
		int n, first, last;
		System.out.println("Input n");
		n=sc.nextInt();
		last=n%10;
		while(n>=10)
		{
			n=n/10;
		}
		first=n;
		System.out.println("First digit "+first);
		System.out.println("Last digit "+last);
	}
	
	public static void main(String [] args)
	{ 
	Cau1();
	Cau2();
	Cau3();
	Cau4();
	Cau5();
	Cau6();
	Cau7();
	Cau8();
	Cau9();
	}
}
