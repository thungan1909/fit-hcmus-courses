import java.util.Scanner;
public class LAB2
{
	//1. findMax(int arr[]) to find the maximum value of an array.
	public static int Cau1(int arr[])
	{
		int MAX=arr[0];
		for(int i=0;i<arr.length;i++)
		{
			if (arr[i] > MAX)
			{
				MAX=arr[i];
			}
		}
		return MAX;
	}
	//2. Find the minimum value of an array
		public static int Cau2(int arr[])
	{
		int MIN=arr[0];
		for(int i=0;i<arr.length;i++)
		{
			if (arr[i] < MIN)
			{
				MIN=arr[i];
			}
		}
		return MIN;
	}
	//3. Write a function to sum all even numbers of an array
	public static int Cau3(int arr[])
	{ 
	int Sum=0;
		for(int i=0;i<arr.length;i++)
		 {	
			if(arr[i]%2==0)
			{
				Sum=Sum+arr[i];
			}
		 }
		 return Sum;
	}

	//Write a function to count how many prime number in an array
	public static boolean IsPrime(int n) {
       if (n <2) {
           return false;
       }
       for (int i = 2; i <= Math.sqrt(n); i++) {
           if (n % i == 0) {
               return false;
           }
       }
       return true;
   }
	public static  int Cau4(int arr[])
	{
		int count=0;
		for(int i=0;i<arr.length;i++)
		{ 
			if(IsPrime(arr[i]))
			{
			count=count+1;
			}
		}
		return count;
	}
	//to find the index of an element k in an array, if the element doesn’t exist in an array return -1
	public static  int Cau5(int arr[],int k)
	{
		
		for(int i=0;i<arr.length;i++)
		{ 
			if(arr[i]==k)
			{
			return i;
			}
		}
		return -1;
	}
	//Write a function to square all elements of an array
	public static void Cau6(int arr[]) 
	{
		
		for(int i=0;i<arr.length;i++)
		{ 
			
			arr[i]=arr[i]*arr[i];
		}
		for(int i=0;i<arr.length;i++)
		{ 
			System.out.println(arr[i]);
		}
	}
	//Write a function public static Integer findMax(Integer []arr) to find the maximum value of an Integer object array
	public static Integer Cau7(Integer []arr)
	{
		Integer MAX=arr[0];
		for(int i=0;i<arr.length;i++)
		{
			if (arr[i] > MAX)
			{
				MAX=arr[i];
			}
		}
		return MAX;
	}
	//Write a function to find the elements which divisible by k in an array. (Ex: a = [1,2,3,4,5,6,7] with k = 2 → [2,4,6])
	public static int[] Cau8(int arr[], int k) 
	{
		int[] temp=new int[10];
		int m=0;
		for(int i=0;i<arr.length;i++)
		{
			if(arr[i]%k==0)
			{
				temp[m]=arr[i];
				m=m+1;
			}
		}
		int[] temp1=new int[m];
		System.arraycopy(temp,0,temp1,0,m);
		return temp1;
	}
	//Write a function to find the third largest element in an array.
	public static int[] DeleTNum(int arr[], int k) 
	{
		int []tempArr=new int[arr.length-1];
		for(int i=0;i<arr.length;i++)
		{
			if(arr[i]==k)
			{

			    System.arraycopy(arr,0,tempArr,0,i+1);
				System.arraycopy(arr,i+1,tempArr,i,arr.length-i-1);
				 return tempArr;
			}
		}
		
		return tempArr;
	}
	public static int Cau9(int arr[])
	{
		
		if(arr.length>2)
		{	int temp=Cau1(arr);
			arr=DeleTNum(arr,temp);
			temp=Cau1(arr);
			arr=DeleTNum(arr,temp);	
			temp=Cau1(arr);
			return temp;}
		System.out.println("It have < 3 elements");
		return 0;
	}
		public static void main(String [] args)
	{
		int[] arr = {6, 9, 5, 7, 2,3,4,1};
		Scanner sc=new Scanner(System.in);
		int k;
		Integer[] arr1=new Integer[arr.length];
		 for (int i = 0; i < arr.length; i++) {
            arr1[i] = (Integer)arr[i];
        }
		System.out.println("MAX of array is: "+Cau1(arr));
		System.out.println("MIN of array is: "+Cau2(arr));
		System.out.println("SUM of even numbers of array is: "+Cau3(arr));
		System.out.println("The numbers of prime in a array is: "+Cau4(arr));
		System.out.println("Input k");
		k=sc.nextInt();
		System.out.println("The INDEX of element k in a array is: "+Cau5(arr,k));
		System.out.println("square all elements of an array:");
		Cau6(arr);
		System.out.println("MAX of Integer array is: "+Cau7(arr1));
		System.out.println("find the elements which divisible by k in an array");
		System.out.println("Input k");
		k=sc.nextInt();
		int[] temp=Cau8(arr,k);
		for(int i=0;i<temp.length;i++)
		{ 
			
			System.out.println(temp[i]);
		}
		System.out.println("Write a function to find the third largest element in an array"+Cau9(arr));
	}
}