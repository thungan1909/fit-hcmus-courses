import java.util.StringTokenizer;
import java.util.Scanner;
import java.util.*;
import java.util.HashMap;
public class LAB3
{
//Split the full name into first name and last name (using StringTokenizer)
	public static void Cau1(String fullName)
	{
		StringTokenizer st1 = new StringTokenizer(fullName);
		String firstName = st1.nextToken();
		StringBuilder middleName = new StringBuilder();
		String lastName = st1.nextToken();
			while (st1.hasMoreTokens())
			{
			  middleName.append(lastName + " ");
			  lastName = st1.nextToken();
			}

			System.out.println("First name is: "+ firstName);
			System.out.println("Last Name is: "+ lastName);
	}
// Return the first name and last name, except the middle name. (Ex: Nguyen Van Chien → Nguyen Chien)
	public static StringBuilder Cau2New(String fullName)
	{
		StringTokenizer st1 = new StringTokenizer(fullName);
		String firstName = st1.nextToken();
		String lastName = st1.nextToken();
		while (st1.hasMoreTokens())
		  {
			  lastName = st1.nextToken();
		  }

		StringBuilder sb = new StringBuilder(firstName);
		sb.append(" ");
		sb.append(lastName);
		return sb;
	}

// Return tne middle name. (Ex: Nguyen Thi Thu Thao → Thi Thu)
	public static StringBuilder Cau3New(String fullName)
	{
		StringTokenizer st1 = new StringTokenizer(fullName);
		String firstName = st1.nextToken();
		StringBuilder middleName = new StringBuilder();
		String lastName = st1.nextToken();
		while (st1.hasMoreTokens())
		{
		  middleName.append(lastName + " ");
		  lastName = st1.nextToken();
		}
	   return middleName;
	}
// Capitalize the full name. (Ex: nguyen van chien → Nguyen Van Chien)
	public static StringBuilder Cau4New(String fullName)
	{ 	
		StringTokenizer st1=new StringTokenizer(fullName," ");
		StringBuilder newName=new StringBuilder();
		while (st1.hasMoreTokens())
		{
			String Temp=st1.nextToken();
			String Str = Temp.substring(0, 1).toUpperCase() + Temp.substring(1);
			newName.append(Str+" ");
		}
	 return newName;
	}
		
// Uppercase all consonants  and lowercase all vowels. (Ex: Nguyen Van Chien → NGuYeN VaN CHieN)
	public static StringBuilder Cau5New(String fullName)
		{ 	
			StringTokenizer st1=new StringTokenizer(fullName," ");
			StringBuilder newName=new StringBuilder();
			
			while (st1.hasMoreTokens())
			{
				String Temp=st1.nextToken();
				for(int i=0;i<Temp.length();i++)
				{	if(Temp.charAt(i)!='e'&&Temp.charAt(i)!='o'&&Temp.charAt(i)!='a'&&Temp.charAt(i)!='u'&&Temp.charAt(i)!='i')
					{
					   Temp=Temp.replace(Temp.charAt(i),Character.toUpperCase(Temp.charAt(i)));
					}
					if(Temp.charAt(i)=='E'||Temp.charAt(i)=='O'||Temp.charAt(i)=='A'||Temp.charAt(i)=='U'||Temp.charAt(i)=='I')
					{
					   Temp=Temp.replace(Temp.charAt(i),Character.toLowerCase(Temp.charAt(i)));
					}
				}
				newName.append(Temp+" ");
			}
		 return newName;
		}
//Count number of words in string (using StringTokenizer)
		public static int Cau2a(String fullName)
		{	 
			int count=0;
			StringTokenizer st1=new StringTokenizer(fullName," ");
			return st1.countTokens();
		}
//Concatenate one string contents to another (using StringBuffer or StringBuilder).
		public static StringBuilder Cau2b(String chuoi1, String chuoi2)
		{ 	
				StringBuilder newString = new StringBuilder();
				newString.append(chuoi1);
				newString.append(" ");
				newString.append(chuoi2);
				return newString;
		}

//Check a string is palindrome or not (using StringBuffer or StringBuilder).
		public static void Cau2c(String chuoi1)
		{ 	
				StringBuilder sb = new StringBuilder(chuoi1);
				StringBuilder sb1=sb.reverse();
				System.out.println(sb1);
				if(sb1.toString() == sb.toString())

				{
					System.out.println("yes, it is a palindrome");
				}
				else
				{
					System.out.println("No, it is not a palindrome");
				}
		}
	//Remove leading white spaces from a string (using StringTokenizer and StringBuffer/StringBuilder).
	public static StringBuilder Cau3a(String str1)
	{  
		StringTokenizer st1=new StringTokenizer(str1);
		String firstStr=st1.nextToken();
		StringBuilder sb=new StringBuilder(firstStr);
		int i=0;
		while (firstStr.charAt(i)==' ')
		{	sb.delete(0,1);
			i=i+1;
		}
		while (st1.hasMoreTokens())
		{
			String temp=st1.nextToken();
			sb.append(" ");
			sb.append(temp);
		}
		return sb;
	}
		
// Remove trailing white spaces from a string (using StringTokenizer and StringBuffer/StringBuilder).
	public static String Cau3b(String str1)
		{  
			if (str1 == null)
            return null;
			int len = str1.length();
			for (; len > 0; len--) {
				if (!Character.isWhitespace(str1.charAt(len - 1)))
					break;
			}
			return str1.substring(0, len);
		}
		
// Remove extra spaces from a string (using StringTokenizer and StringBuffer/StringBuilder)
	public static StringBuilder Cau3c(String str1)
	{ 
		StringBuilder sb=new StringBuilder();
		StringTokenizer st1=new StringTokenizer(str1);
		while (st1.hasMoreTokens())
		{
			String temp=st1.nextToken();	
			sb.append(temp);
			sb.append(" ");
		}
		return sb;
	}
	processes a String paragraph, count occurrences of each word in the paragraph, and store them in a 2D-array.
	// public static void Cau4(String para)
	// { 	
		// StringTokenizer st1=new StringTokenizer(para);
		// Integer count=st1.countTokens();
		// HashMap<Integer, String> hashMap = new HashMap<Integer, String>();
		// while (st1.hasMoreTokens())
		// {	
			// String temp=st1.nextToken();		
				// Integer key=0;
			// if(hashMap.get(key).equals(temp))
						// {
							// key=key+1;
						// }
						// else
						// {
							// hashMap.put(key,temp);
							// key=1;
						// }
						// count=count-1;
			
		// }					
							
            // System.out.println(hashMap);
       
	// }
			
  public static void main(String[] args) 
  {
	Scanner sc= new Scanner(System.in); 
	System.out.print("Enter a fullname: ");  
	String fullName= sc.nextLine();  
	Cau1(fullName);
	StringBuilder sb=Cau2New(fullName);
	System.out.println(sb);
	sb=Cau3New(fullName);
	System.out.println(sb);
	sb=Cau4New(fullName);
	System.out.println(sb);
	sb=Cau5New(fullName);
	System.out.println(sb);
	int count=Cau2a(fullName);
	System.out.println("So tu xuat hien trong  chuoi: "+count);
	System.out.println("Concatenate String");
	System.out.println("First String");
	String str1=sc.nextLine();
	System.out.println("Second String");
	String str2=sc.nextLine();
	System.out.println("After concatenate String: "+Cau2b(str1,str2));
	System.out.println("Check a string is palindrome ");
	System.out.println("Input String");
	str1=sc.nextLine();
	Cau2c(str1);
	System.out.println("Remove leading white spaces from a string ");
	System.out.println("Input String");
	str1=sc.nextLine();
	System.out.println("Result:"+Cau3a(str1));
	System.out.println("Remove trailing white spaces from a string ");
	System.out.println("Input String");
	str1=sc.nextLine();
	System.out.println("Result:"+Cau3b(str1));
	System.out.println("Remove extra spaces from a string ");
	System.out.println("Input String");
	str1=sc.nextLine();
	System.out.println("Result:"+Cau3c(str1));
	// System.out.println("processes a String paragraph, count occurrences of each word in the paragraph");
	// System.out.println("Input String");
	// str1=sc.nextLine();
	// Cau4(str1);
	
	
	
  }
}	