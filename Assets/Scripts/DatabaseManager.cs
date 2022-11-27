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
    private string connectionString = @"Server=(LocalDB)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\Legen\Documents\GitHub\BoostBall\Assets\Scripts\BoostBall.mdf;";
    private string password;
    private string username;

    public void setPassword(string s){
        password = s;
    }

    public void setUsername(string s){
        username = s;
    }

    public void RegisterUser(){
        txtErrorMessage.text = String.Empty;
        string query = $"INSERT INTO dbo.Player (username, password, lifetime_coins, current_coins, high_score) VALUES ('{username}', '{password}', {0}, {0}, {0})";
        string query2 = $"SELECT * FROM dbo.Player WHERE username='{username}'";

        using(System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connectionString)){
            bool wasRead = false;
            List<string> list = new List<string>();
            System.Data.SqlClient.SqlCommand command1 = new System.Data.SqlClient.SqlCommand(query, conn);
            System.Data.SqlClient.SqlCommand command2 = new System.Data.SqlClient.SqlCommand(query2, conn);
            conn.Open();
            using(System.Data.SqlClient.SqlDataReader reader = command2.ExecuteReader()){
                while(reader.Read()){
                    txtErrorMessage.text = "Username already taken";
                    wasRead = true;
                    break;
                }
            }
            if(!wasRead){
                    command1.ExecuteNonQuery();
                    int ID = -1;
                    using(SqlDataReader reader = command2.ExecuteReader()){
                        while(reader.Read()){
                            ID = reader.GetInt32(reader.GetOrdinal("ID"));
                            break;
                        }
                    }
                    for(int BallID = 0; BallID < 7; BallID++){
                        int isOwned = 1;
                        if(BallID != 0){
                            isOwned = 0;
                        }
                        query = $"INSERT INTO dbo.OwnedBalls (ID, BallID, isOwned) VALUES ({ID}, {BallID}, {isOwned})";
                        command1 = new SqlCommand(query, conn);
                        command1.ExecuteNonQuery();
                    }

                    query = $"INSERT INTO dbo.CurrentBall (ID, BallID) VALUES ({ID}, {0})";
                    command1 = new SqlCommand(query, conn);
                    command1.ExecuteNonQuery();

                    createJSON(ID, conn);
                }
        }
    }

    public void Login(){
        txtErrorMessage.text = String.Empty;
        string query2 = $"SELECT * FROM dbo.Player WHERE username='{username}' and password='{password}'";
        using(System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connectionString)){
            List<string> list = new List<string>();
            System.Data.SqlClient.SqlCommand command2 = new System.Data.SqlClient.SqlCommand(query2, conn);
            conn.Open();
            // command1.ExecuteNonQuery();
            using(System.Data.SqlClient.SqlDataReader reader = command2.ExecuteReader()){
                bool wasRead = false;
                while(reader.Read()){
                    wasRead = true;
                    int ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    createJSON(ID, conn);
                    break;
                }
                if(!wasRead){
                    txtErrorMessage.text = "Invalid username or password";
                }
            }
        }
    }

    public void createJSON(int ID, System.Data.SqlClient.SqlConnection conn){
        if(File.Exists("jsonPlayer.json")){
            File.Delete("jsonPlayer.json");
        }
        int currentCoins = 0;
        int lifetimeCoins = 0;
        string username = String.Empty;
        string password = String.Empty;
        int highScore = 0;
        int currentBall = 0;
        Dictionary<int, int> ownedSkins = new Dictionary<int, int>();

        string query = $"SELECT * FROM dbo.Player WHERE ID={ID}";
        SqlCommand command = new SqlCommand(query, conn); 
        using(SqlDataReader reader = command.ExecuteReader()){
            while(reader.Read()){
                currentCoins = reader.GetInt32(reader.GetOrdinal("current_coins"));
                lifetimeCoins = reader.GetInt32(reader.GetOrdinal("lifetime_coins"));
                username = reader.GetString(reader.GetOrdinal("username"));
                password = reader.GetString(reader.GetOrdinal("password"));
                highScore = reader.GetInt32(reader.GetOrdinal("high_score"));
                break;
            }
        }
        query = $"SELECT * FROM dbo.OwnedBalls WHERE ID={ID}";
        command = new SqlCommand(query, conn);
        using(SqlDataReader reader = command.ExecuteReader()){
            int ballID;
            int owned;
            while(reader.Read()){
                ballID = reader.GetInt32(reader.GetOrdinal("BallID"));
                owned = reader.GetInt32(reader.GetOrdinal("isOwned"));
                ownedSkins.Add(ballID, owned);
            }
        }
        query = $"SELECT * FROM dbo.CurrentBall WHERE ID={ID}";
        command = new SqlCommand(query, conn);
        using(SqlDataReader reader = command.ExecuteReader()){
            while(reader.Read()){
                currentBall = reader.GetInt32(reader.GetOrdinal("BallID"));
                break;
            }
        }
        Player player = new Player(ID, username, password, lifetimeCoins, currentCoins, highScore, ownedSkins, currentBall);
        string jsonPlayer = JsonConvert.SerializeObject(player);
        using(StreamWriter fileWriter = File.AppendText("jsonPlayer.json")){
            fileWriter.Write(jsonPlayer);
        }
        //Player player = JsonConvert.DeserializeObject<Player>(jsonPlayer);
    }
}