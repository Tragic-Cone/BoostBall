using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Data.SqlClient;
using System.Data;
using UnityEngine;
using System;
using Newtonsoft.Json;
using System.IO;

public class DatabaseManager : MonoBehaviour
{
    public GameObject txtRegisterUsername;
    public GameObject txtRegisterPassword;
    public TMP_Text txtErrorMessage;
    private string password;
    private string username;

    public void setPassword(string s){
        password = s;
    }

    public void setUsername(string s){
        username = s;
    }

    public void RegisterUser(){
        bool error = DatabaseInstance.RegisterUser(username, password);
        txtErrorMessage.text = String.Empty;
        if(!error){
            txtErrorMessage.text = "Username already taken.";
        }
    }

    public void Login(){
        txtErrorMessage.text = String.Empty;
        if(!DatabaseInstance.Login(username, password)){
        txtErrorMessage.text = "Invalid username or password";
        }
    }

    public void Logout(){
        DatabaseInstance.Logout();
    }
}