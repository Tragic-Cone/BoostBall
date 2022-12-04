using System.Collections;
using System.Collections.Generic;

public static class DatabaseInstance
{
    private static string connectionString = @"Server=(LocalDB)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\Legen\Documents\Github\BoostBall\Assets\Scripts\BoostBall.mdf;";
    public enum ballSelection{
        DefaultBall,
        BeachBall,
        BowlingBall,
        GreenBall,
        PinkBall,
        RedBall,
        YellowBall
    }
    public static bool RegisterUser(string username, string password){
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
                    wasRead = true;
                    return false;
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
                return true;
            }
        }
    }

    public static bool Login(string username, string password){
        bool wasRead = false;
        string query2 = $"SELECT * FROM dbo.Player WHERE username='{username}' and password='{password}'";
        using(System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connectionString)){
            List<string> list = new List<string>();
            using(System.Data.SqlClient.SqlCommand command2 = new System.Data.SqlClient.SqlCommand(query2, conn)){
                conn.Open();
                using(System.Data.SqlClient.SqlDataReader reader = command2.ExecuteReader()){
                    while(reader.Read()){
                        wasRead = true;
                        int ID = reader.GetInt32(reader.GetOrdinal("ID"));
                        createJSON(ID, conn);
                        break;
                    }
                }
            }
        }
        return wasRead;
    }

    public static void Logout(){
        Player.ID = -1;
    }

    private static void createJSON(int ID, System.Data.SqlClient.SqlConnection conn){
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
        Player.ID = ID;
        Player.username = username;
        Player.password = password;
        Player.lifetimeCoins = lifetimeCoins;
        Player.currentCoins = currentCoins;
        Player.highScore = highScore;
        Player.ownedSkins = ownedSkins;
        Player.currentSkin = currentBall;
    }

    public static void addCoins(int coins){
        string query = $"SELECT * FROM dbo.Player WHERE ID={Player.ID}";
        using(SqlConnection conn = new SqlConnection(connectionString)){
            conn.Open();
            using(SqlCommand command = new SqlCommand(query, conn)){
                using(SqlDataReader reader = command.ExecuteReader()){
                    while(reader.Read()){
                        currentCoins = reader.GetInt32(reader.GetOrdinal("current_coins"));
                        lifetimeCoins = reader.GetInt32(reader.GetOrdinal("lifetime_coins"));
                        break;
                    }
                }
            }
            Player.currentCoins += coins;
            Player.lifetimeCoins += coins;
            query = $"UPDATE dbo.Player SET current_coins={currentCoins}, lifetimeCoins={lifetimeCoins} WHERE ID={Player.ID}";
            using(SqlCommand command = new SqlCommand(query, conn)){
                command.ExecuteNonQuery();
            }
        }
    }
    public static void buyBall(int cost, int ballID){
        addCoins(cost * -1);
        string query = $"UPDATE dbo.OwnedBalls SET isOwned=1 WHERE ID={Player.ID} and ballID={ballID}";
        using(SqlConnection conn = new SqlConnection(connectionString)){
            using(SqlCommand command = new SqlCommand(query, conn)){
                command.ExecuteNonQuery();
            }
        }
        Player.ownedSkins[ballID] = 1;
    }
    public static int getBallCost(int ballID){
        string query = $"SELECT ball_cost FROM dbo.Balls WHERE ballID={ballID}";
        int cost = 0;
        using(SqlConnection conn = new SqlConnection(connectionString)){
            using(SqlCommand command = new SqlCommand(query, conn)){
                using(SqlDataReader reader = command.ExecuteReader()){
                    while(reader.Read()){
                        cost = reader.GetInt32(reader.GetOrdinal("ball_cost"));
                        break;
                    }
                }
            }
        }
        return cost;
    }
    public static void buyBeachBall(){
        cost = getBallCost(ballSelection.BeachBall);
        buyBall(cost, ballSelection.BeachBall);
        equipSkin(ballSelection.BeachBall);
    }

    public static void buyBowlingBall(){
        cost = getBallCost(ballSelection.BowlingBall);
        buyBall(cost, ballSelection.BowlingBall);
        equipSkin(ballSelection.BowlingBall);
    }
    public static void buyGreenBall(){
        cost = getBallCost(ballSelection.GreenBall);
        buyBall(cost, ballSelection.GreenBall);
        equipskin(ballSelection.GreenBall);
    }
    public static void buyPinkBall(){
        cost = getBallCost(ballSelection.PinkBall);
        buyBall(cost, ballSelection.PinkBall);
        equipSkin(ballSelection.PinkBall);
    }
    public static void buyRedBall(){
        cost = getBallCost(ballSelection.RedBall);
        buyBall(cost, ballSelection.RedBall);
        equipSkin(ballSelection.RedBall);
    }
    public static void buyYellowBall(){
        cost = getBallCost(ballSelection.YellowBall);
        buyBall(cost, ballSelection.YellowBall);
        equipSkin(ballSelection.YellowBall);
    }
    public static List<PlayerScore> getTopTenScores(){
        List<PlayerScore> scores = new List<PlayerScore>();
        string query = $"SELECT high_score FROM dbo.Player ORDER BY high_score DESC";
        using(SqlConnection conn = new SqlConnection(connectionString)){
            using(SqlCommand command = new SqlCommand(connectionString)){
                using(SqlDataReader reader = command.ExecuteReader()){
                    int i = 0;
                    while(reader.Read() && i < 10){
                        string username = reader.GetString(reader.GetOrdinal("username"));
                        int highScore = reader.GetString(reader.GetOrdinal("high_score"));
                        scores.Add(new PlayerScore(username, highScore));
                        i++;
                    }
                }
            }
        }
        return scores;
    }
    public static void equipSkin(int ballID){
        string query = $"UPDATE dbo.CurrentBall SET ballID={ballID} WHERE ID={Player.ID}";
        using(SqlConnection conn = new SqlConnection(connectionString)){
            using(SqlCommand command = new SqlCommand(query, conn)){
                command.ExecuteNonQuery();
            }
        }
        Player.currentSkin = ballID;
    }
    public static void setHighScore(int highScore){
        string query = $"UPDATE dbo.Player SET high_score={highScore}";
        using(SqlConnection conn = new SqlConnection(connectionString)){
            using(SqlCommand command = new SqlCommand(query, conn)){
                command.ExecuteNonQuery();
            }
        }
        Player.highScore = highScore;
    }
}
