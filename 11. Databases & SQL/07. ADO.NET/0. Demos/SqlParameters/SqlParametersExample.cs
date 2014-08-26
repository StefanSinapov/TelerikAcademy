using System;
using System.Data.SqlClient;
using SqlParametersDemo;
using System.Configuration;

class SqlParametersExample
{
    private SqlConnection dbCon;

    private void ConnectToDB()
    {
        // see app.config if chang to ConnectionString needed
        ConnectionStringSettings dBConnectionString = ConfigurationManager.ConnectionStrings["SQLDB"];
        dbCon = new SqlConnection(dBConnectionString.ConnectionString);//Settings.Default.DBConnectionString);
        dbCon.Open();
    }

    private void DisconnectFromDB()
    {
        if (dbCon != null)
        {
            dbCon.Close();
        }
    }

    private Project GetProjectById(int id)
    {
        SqlCommand cmdSelectProject = new SqlCommand(
            "SELECT * FROM Projects WHERE ProjectID = @id", this.dbCon);
        cmdSelectProject.Parameters.AddWithValue("@id", id);
        SqlDataReader reader = cmdSelectProject.ExecuteReader();
        using (reader)
        {
            if (reader.Read())
            {
                string name = (string)reader["Name"];
                string description = (string)reader["Description"];
                DateTime startDate = (DateTime)reader["StartDate"];
                object endDateObj = reader["EndDate"];
                DateTime? endDate = null;
                if (endDateObj != DBNull.Value)
                {
                    endDate = (DateTime)endDateObj;
                }

                Project project = new Project(id, name, description, startDate, endDate);
                return project;
            }
            else
            {
                throw new ArgumentException(
                    String.Format("Invalid project (ID = {0}).", id));
            }
        }
    }

    private int InsertProject(string name, string description,
        DateTime startDate, DateTime? endDate)
    {
        SqlCommand cmdInsertProject = new SqlCommand(
            "INSERT INTO Projects(Name, Description, StartDate, EndDate) " +
            "VALUES (@name, @description, @startDate, @endDate)", dbCon);
        cmdInsertProject.Parameters.AddWithValue("@name", name);
        cmdInsertProject.Parameters.AddWithValue("@description", description);
        cmdInsertProject.Parameters.AddWithValue("@startDate", startDate);
        SqlParameter sqlParameterEndDate = new SqlParameter("@endDate", endDate);
        if (endDate == null)
        {
            sqlParameterEndDate.Value = DBNull.Value;
        }
        cmdInsertProject.Parameters.Add(sqlParameterEndDate);
        cmdInsertProject.ExecuteNonQuery();

        SqlCommand cmdSelectIdentity = new SqlCommand("SELECT @@Identity", dbCon);
        int insertedRecordId = (int)(decimal)cmdSelectIdentity.ExecuteScalar();
        return insertedRecordId;
    }

    static void Main()
    {
        SqlParametersExample example = new SqlParametersExample();
        try
        {
            example.ConnectToDB();

            // Retrieve a project from the "Projects" table
            Project project = example.GetProjectById(10);
            Console.WriteLine(project);

            // Insert new project in the "Projects" table
            int newProjectId = example.InsertProject("New project",
                "Some description", DateTime.Now, null);
            Console.WriteLine("Inserted new project. " +
                "ProjectID = {0}", newProjectId);
        }
        finally
        {
            example.DisconnectFromDB();
        }
    }
}
