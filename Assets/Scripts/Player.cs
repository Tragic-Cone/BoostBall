public class Player
{
    private string username;
    private string email;
    private string password;
    private int lifetimeCoins;
    private int currentCoins;
    private int highScore;

    public Player(string username, string email, string password, int lifetimeCoins, int currentCoins, int highScore){
        this.username = username;
        this.email = email;
        this.password = password;
        this.lifetimeCoins = lifetimeCoins;
        this.currentCoins = currentCoins;
        this.highScore = highScore;
    }

    public void setUsername(string username){
        
    }
}
