import java.util.Scanner;

public class Test {

	public static void main(String[] args) {
		String name, address, program;
		int year;
		double fee;
		Scanner sc = new Scanner(System.in);
		System.out.println("Demo student:");
		System.out.print("Enter student's name: ");
		name = sc.nextLine();
		System.out.print("Enter student's address: ");
		address = sc.nextLine();
		System.out.print("Enter student's program: ");
		program = sc.nextLine();
		System.out.print("Enter student's year: ");
		year = sc.nextInt();
		System.out.print("Enter student's fee: ");
		fee = sc.nextDouble();
		sc.nextLine();

		Student student = new Student(name, address, program, year, fee);
		System.out.println("Student's name: " + student.getName());
		System.out.println("Student's address: " + student.getAddress());
		System.out.println("Student's program: " + student.getProgram());
		System.out.println("Student's year: " + student.getYear());
		System.out.println("Student's fee: " + student.getFee());
		System.out.println("Student to string:\n" + student.toString());

		System.out.print("Enter new student's name: ");
		name = sc.nextLine();
		student.setName(name);
		System.out.print("Enter new student's address: ");
		address = sc.nextLine();
		student.setAddress(address);
		System.out.print("Enter new student's program: ");
		program = sc.nextLine();
		student.setProgram(program);
		System.out.println("Enter new student's year: ");
		year = sc.nextInt();
		student.setYear(year);
		System.out.println("Enter new student's fee: ");
		fee = sc.nextDouble();
		student.setFee(fee);

		System.out.println("\nAfter set:");
		System.out.println("Student's name: " + student.getName());
		System.out.println("Student's address: " + student.getAddress());
		System.out.println("Student's program: " + student.getProgram());
		System.out.println("Student's year: " + student.getYear());
		System.out.println("Student's fee: " + student.getFee());
		System.out.println("Student to string:\n" + student.toString());
		
		sc.nextLine();
		
		//-----------------------Staff
		System.out.println("\nDemo staff:");
		System.out.print("Enter staff's name: ");
		name = sc.nextLine();
		System.out.print("Enter staff's address: ");
		address = sc.nextLine();
		System.out.print("Enter staff's school: ");
		String school = sc.nextLine();
		System.out.print("Enter staff's pay: ");
		double pay = sc.nextDouble();
		sc.nextLine();

		Staff staff = new Staff(name, address, school, pay);
		System.out.println("Staff's name: " + staff.getName());
		System.out.println("Staff's address: " + staff.getAddress());
		System.out.println("Staff's school: " + staff.getSchool());
		System.out.println("Staff's pay: " + staff.getPay());
		System.out.println("Staff to string:\n" + staff.toString());

		System.out.print("Enter new staff's name: ");
		name = sc.nextLine();
		staff.setName(name);
		System.out.print("Enter new staff's address: ");
		address = sc.nextLine();
		staff.setAddress(address);
		System.out.print("Enter new staff's school: ");
		school = sc.nextLine();
		staff.setSchool(school);
		System.out.println("Enter new staff's pay: ");
		pay = sc.nextDouble();
		staff.setPay(pay);

		System.out.println("\nAfter set:");
		System.out.println("Staff's name: " + staff.getName());
		System.out.println("Staff's address: " + staff.getAddress());
		System.out.println("Staff's school: " + staff.getSchool());
		System.out.println("Staff's pay: " + staff.getPay());
		System.out.println("Staff to string:\n" + staff.toString());
		sc.close();
	}
}
