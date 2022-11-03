using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TMPro;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    public GameObject txtRegisterUsername;
    public GameObject txtRegisterPassword;
    public GameObject btnRegisterUser;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RegisterUser(){
        string txtUsername = txtRegisterUsername.GetComponent<TMP_InputField>().text;
        string txtPassword = txtRegisterPassword.GetComponent<TMP_InputField>().text;
        using(SqlConnection conn = DatabaseInstance.initializeDatabase()){
            string query = $"INSERT INTO PLAYER VALUES('{txtUsername}', '{txtPassword}', {0})";
            using(SqlCommand command = new SqlCommand(query, conn)){
                conn.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}