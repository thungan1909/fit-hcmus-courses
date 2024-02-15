
public class StudentTest
{
public static void main(String[] args)
{
Student st = new Student(19120302,"Ngan","Doan");
System.out.println("First Name is: "+ st.getFirstName());
System.out.println("Last Name is: "+ st.getLastName());
System.out.println("Change info");
st.setID(199);
st.setFirstName("An");
st.setLastName("Nguyen");
System.out.println("Name is:"+ st.getName());
System.out.println(st.toString());
}}