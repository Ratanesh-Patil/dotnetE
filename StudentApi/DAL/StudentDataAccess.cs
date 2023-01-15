using MySql.Data.MySqlClient;
using StudentApi.Model;
using System.Data;

namespace StudentApi.DAL;


public class StudentDataAccess
{
    public static string conString=@"server=localhost; port=3306; user=root; password=Ratnesh@8; database=test";

    public static List<Student> GetAllStudents()
    {
        List<Student> allstud =new List<Student>();
        MySqlConnection con =new MySqlConnection(conString);
    
        try
        {
            string query ="select * from student";
            DataSet ds =new DataSet();
            MySqlCommand cmd =new MySqlCommand(query,con);
            MySqlDataAdapter da =new MySqlDataAdapter(cmd);
            da.Fill(ds);

            DataTable dt = ds.Tables[0];
            DataRowCollection rows =dt.Rows;
            foreach (DataRow row in rows)
            {
                Student stud =new Student
                {
                    name=row["name"].ToString(),
                   rollno=row["rollno"].ToString(),
                    email=row["email"].ToString(),
                     batch=row["batch"].ToString()

                };
                allstud.Add(stud);
            }



        }catch(Exception e){
            Console.WriteLine(e.Message);
        }
        return allstud;
    }

    public static void SaveStudent(Student stud)
    {
        MySqlConnection con =new MySqlConnection(conString);
        try
        {
            con.Open();

            string query = $"insert into student values('{stud.name}','{stud.rollno}','{stud.email}','{stud.batch}')";
            MySqlCommand cmd = new MySqlCommand(query,con);
            cmd.ExecuteNonQuery();

        }catch(Exception e){
            Console.WriteLine(e.Message);
        }
        finally{
            con.Close();
        }
    }

    public static void DeleteStudentByname(string name)
    {
        MySqlConnection con = new MySqlConnection(conString);

        try{
            con.Open();
            string query="delete from student where name="+"name";
            MySqlCommand cmd =new MySqlCommand(query,con);
            cmd.ExecuteNonQuery();
            con.Close();

        }catch(Exception e){
            Console.WriteLine(e.Message);
        }
        finally{
            con.Close();
        }
    }

}