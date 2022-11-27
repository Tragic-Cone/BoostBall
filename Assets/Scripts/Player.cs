using System.Collections.Generic;

public class Player
{
    private int ID;
    private string username;
    private string password;
    private int lifetimeCoins;
    private int currentCoins;
    private int highScore;
    private Dictionary<int, int> ownedSkins;
    private int currentSkin;

    public Player(int ID, string username, string password, int lifetimeCoins, int currentCoins, int highScore, Dictionary<int, int> ownedSkins, int currentSkin){
        this.username = username;
        this.password = password;
        this.lifetimeCoins = lifetimeCoins;
        this.currentCoins = currentCoins;
        this.highScore = highScore;
        this.ownedSkins = ownedSkins;
        this.currentSkin = currentSkin;
    }

    public void setUsername(string username){
        this.username = username;
    }

    public string getUsername(){
        return this.username;
    }

    public void setPassword(string password){
        this.password = password;
    }

    public string getPassword(){
        return this.password;
    }

    public void setLifetimeCoins(int lifetimeCoins){
        this.lifetimeCoins = lifetimeCoins;
    }

    public int getLifetimeCoins(){
        return this.lifetimeCoins;
    }

    public void setCurrentCoins(int currentCoins){
        this.currentCoins = currentCoins;
    }

    public int getCurrentCoins(){
        return this.currentCoins;
    }

    public void setHighScore(int highScore){
        this.highScore = highScore;
    }

    public int getHighScore(){
        return this.highScore;
    }

    public void setOwnedSkins(Dictionary<int, int> ownedSkins){
        this.ownedSkins = ownedSkins;
    }

    public Dictionary<int, int> getOwnedSkins(){
        return this.ownedSkins;
    }

    public int getID(){
        return this.ID;
    }

    public void setID(int ID){
        this.ID = ID;
    }

    public int getCurrentSkin(){
        return this.currentSkin;
    }

    public void setCurrentSkin(int BallID){
        this.currentSkin = BallID;
    }
}
