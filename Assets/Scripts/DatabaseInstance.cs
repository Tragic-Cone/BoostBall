using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UnityEngine;

public static class DatabaseInstance
{
    public static string connectionString = @"Data Source=.\SQLEXPRESS;
                                        AttachDbFilename=C:\Users\Legen\Documents\GitHub\BoostBall\Assets\Scripts\BoostBall.mdf;
                                        Integrated Security=True;
                                        User Instance=True";
    public static SqlConnection initializeDatabase(){
        return new SqlConnection(connectionString);
    }
}
