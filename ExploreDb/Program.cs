using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ExploreDb
{
    class Program
    {
       
        public void InsertBooks()
        {
            SqlConnection con = new SqlConnection("data source=LAPTOP-H1V2TQC9;database=BooksDb;Trusted_Connection=True");
            //SqlCommand cmd = new SqlCommand("insert into tbl_books values('Dear John',9,250)", con);
            string qry = "insert into tbl_books values(@Title,@authorID,@Price)";
            SqlCommand cmd = new SqlCommand(qry,con);
            cmd.Parameters.AddWithValue("@Title", "The Notebook");
            cmd.Parameters.AddWithValue("@AuthorID", 9);
            cmd.Parameters.AddWithValue("@Price", 500);
            //cmd.Connection = con;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Server not Working");
            }
            finally
            {
                con.Close();
            }
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();
        }
        public void InsertAuthor()
        {
            SqlConnection con = new SqlConnection("data source=LAPTOP-H1V2TQC9;database=BooksDb;Trusted_Connection=True");
            SqlCommand cmd = new SqlCommand("insert into tbl_author values('Alex Michaelides')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateBooks()
        {
            SqlConnection con = new SqlConnection("data source=LAPTOP-H1V2TQC9;database=BooksDb;Trusted_Connection=True");
            SqlCommand cmd = new SqlCommand("update tbl_books set Title='Secret of Nagas' where Title='Meluha'", con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Server not Working");
            }
            finally
            {
                con.Close();
            }

        }
        public void UpdateAuthor()
        {
            SqlConnection con = new SqlConnection("data source=LAPTOP-H1V2TQC9;database=BooksDb;Trusted_Connection=True");
            SqlCommand cmd = new SqlCommand("update tbl_author set AuthorName='Ravinder Singh' where AuthorName='Mind Master'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deletebooks() 
        {
            SqlConnection con = new SqlConnection("data source=LAPTOP-H1V2TQC9;database=BooksDb;Trusted_Connection=True");
            SqlCommand cmd = new SqlCommand("delete from tbl_Books where BookID=1013", con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Server not Working");
            }
            finally
            {
                con.Close();
            }
        }
        public void DeleteAuthor()
        {
            SqlConnection con = new SqlConnection("data source=LAPTOP-H1V2TQC9;database=BooksDb;Trusted_Connection=True");
            SqlCommand cmd = new SqlCommand("delete from tbl_author where AuthorID=10", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public string InsertBookSP(string title, int aid, double price)
        {
            string res = null;
            SqlConnection con = new SqlConnection("data source=LAPTOP-H1V2TQC9;database=BooksDb;Trusted_Connection=True");
            SqlCommand cmd = new SqlCommand("sp_InsBook", con);
            //con.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Title", SqlDbType.NVarChar).Value = title;
            cmd.Parameters.AddWithValue("@AuthorID", SqlDbType.Int).Value = aid;
            cmd.Parameters.AddWithValue("@Price", SqlDbType.Money).Value = price;

            //SqlParameter p1 = new SqlParameter();
            //p1.ParameterName = "@Title";
            //p1.SqlDbType = SqlDbType.VarChar;
            //p1.Value = title;
            //cmd.Parameters.Add(p1);
            //SqlParameter p2 = new SqlParameter();
            //p1.ParameterName = "@AuthorID";
            //p1.SqlDbType = SqlDbType.Int;
            //p1.Value = aid;
            //cmd.Parameters.Add(p2);
            //SqlParameter p3 = new SqlParameter();
            //p1.ParameterName = "@Price";
            //p1.SqlDbType = SqlDbType.Money;
            //p1.Value = price;
            //cmd.Parameters.Add(p3);
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();

           
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            res = "Success";
            return res;
        }
        public string InsertAuthorSP(string AUName)
        {
            string res = null;
            SqlConnection con = new SqlConnection("data source=LAPTOP-H1V2TQC9;database=BooksDb;Trusted_Connection=True");
            SqlCommand cmd = new SqlCommand("sp_InAuthor", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AuthorName", SqlDbType.NVarChar).Value = AUName;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            res = "Success";
            return res;
        }
        public string UpdateBookSP(string title, int aid, double price, int bid)
        {
            string res = null;
            SqlConnection con = new SqlConnection("data source=LAPTOP-H1V2TQC9;database=BooksDb;Trusted_Connection=True");
            SqlCommand cmd = new SqlCommand("sp_UpdateBook", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Title", SqlDbType.NVarChar).Value = title;
            cmd.Parameters.AddWithValue("@AuthorID", SqlDbType.Int).Value = aid;
            cmd.Parameters.AddWithValue("@Price", SqlDbType.Money).Value = price;
            cmd.Parameters.AddWithValue("@BookId", SqlDbType.Int).Value = bid;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            res = "Success";
            return res;
        }
        public string UpdateAuthor(string AUName,int aid)
        {
            string res = null;
            SqlConnection con = new SqlConnection("data source=LAPTOP-H1V2TQC9;database=BooksDb;Trusted_Connection=True");
            SqlCommand cmd = new SqlCommand("sp_UpdateAuthor", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AuthorName", SqlDbType.NVarChar).Value = AUName;
            cmd.Parameters.AddWithValue("@AuthorID", SqlDbType.Int).Value = aid;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            res = "Success";
            return res;

        }
        public string DeleteBookSP(int bid)
        {
            string res = null;
            SqlConnection con = new SqlConnection("data source=LAPTOP-H1V2TQC9;database=BooksDb;Trusted_Connection=True");
            SqlCommand cmd = new SqlCommand("sp_DeleteBook", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookId", SqlDbType.Int).Value = bid;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            res = "Success";
            return res;
        }
        public string DeleteAuthor(int AuthorID)
        {
            string res = null;
            SqlConnection con = new SqlConnection("data source=LAPTOP-H1V2TQC9;database=BooksDb;Trusted_Connection=True");
            SqlCommand cmd = new SqlCommand("sp_DeleteAuthor", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AuthorID", SqlDbType.Int).Value = AuthorID;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            res = "Success";
            return res;

        }
        static void Main(string[] args)
        {
            Program obj = new Program();
            //obj.InsertBooks();
            // obj.InsertAuthor();
            //obj.UpdateBooks();
            //obj.UpdateAuthor();
            // obj.deletebooks();
            //obj.DeleteAuthor();
            //obj.InsertBookSP("I too had a story", 8, 170);
            //obj.InsertAuthorSP("Shivani");
            //obj.UpdateBookSP("Like it happened",8,290,1008);
            //obj.UpdateAuthor("Sandilyan", 2);
            //obj.DeleteBookSP(1012);
            obj.DeleteAuthor(11);

            SqlConnection con = new SqlConnection(@"data source=LAPTOP-H1V2TQC9;database=BooksDb;Trusted_Connection=True");
            //SqlCommand cmd = new SqlCommand("select * from tbl_books", con);

            //con.Open();
            //SqlDataReader rdr = cmd.ExecuteReader();
            //while (rdr.Read())
            //    Console.WriteLine(rdr["BookId"] + " " + rdr["Title"] + " " + rdr["Price"].ToString());
            //con.Close();
            //Console.ReadLine();

            SqlCommand cmd = new SqlCommand("select * from tbl_author", con);

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
                Console.WriteLine(rdr["AuthorID"] + " " + rdr["AuthorName"] + " " .ToString());
            con.Close();
            Console.ReadLine();
        }
    }
}