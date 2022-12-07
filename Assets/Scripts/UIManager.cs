using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class UIManager : MonoBehaviour
{
    //GameObjects for panels
    public GameObject mainMenuPanel;
    public GameObject leaderboardPanel;
    public GameObject customizationPanel;
    public GameObject accountPanel;
    public GameObject gameOverScreen;
    public GameObject registerLoginPanel;
    public GameObject playerBall;
    public GameObject txtRegisterUsername;
    public GameObject txtRegisterPassword;
    public TMP_Text txtErrorMessage;
    public string password;
    public string username;
    public TMP_Text costMessage;
    public TMP_Text storeErrorMessage;
    public GameObject buyButton;
    public GameObject selectButton;
    public TMP_Text coinsMessage;
    public TMP_Text usernameMessage;
    public TMP_Text highScoreMessage;
    private string lowFundsErrorMessage = "Cannot afford this item.";
    public Sprite defaultBallSprite;
    public Sprite beachBallSprite;
    public Sprite bowlingBallSprite;
    public Sprite greenBallSprite;
    public Sprite pinkBallSprite;
    public Sprite redBallSprite;
    public Sprite yellowBallSprite;
    private int currentCoins;
    private int currentScore;

    public TMP_Text gameoverCoins;
    public TMP_Text gameoverScore;

    //Customization panel variables
    public int selectedBall = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        showMainMenuPanel();
    }

    void Update(){
        currentCoins = 0;
        currentScore = 0;
        //stuff to call GameOver visible
    }

    public void showMainMenuPanel()
    {
        //code that sets the ball skin under this
        if(Player.ID != 1){
            changeBallSkin(Player.currentSkin);
        } else {
            changeBallSkin(0);
        }
        mainMenuPanel.SetActive(true);
        leaderboardPanel.SetActive(false);
        customizationPanel.SetActive(false);
        accountPanel.SetActive(false);
        gameOverScreen.SetActive(false);
        registerLoginPanel.SetActive(false);
    }
    public void changeBallSkin(int ballID){
        switch(ballID){
            case 0:
                playerBall.GetComponent<SpriteRenderer>().sprite = defaultBallSprite;
                break;
            case 1:
                playerBall.GetComponent<SpriteRenderer>().sprite = beachBallSprite;
                break;
            case 2:
                playerBall.GetComponent<SpriteRenderer>().sprite = bowlingBallSprite;
                break;
            case 3:
                playerBall.GetComponent<SpriteRenderer>().sprite = greenBallSprite;
                break;
            case 4:
                playerBall.GetComponent<SpriteRenderer>().sprite = pinkBallSprite;
                break;
            case 5:
                playerBall.GetComponent<SpriteRenderer>().sprite = redBallSprite;
                break;
            case 6:
                playerBall.GetComponent<SpriteRenderer>().sprite = yellowBallSprite;
                break;
        }
    }

    public void setPassword(string s){
        password = s;
    }

    public void setUsername(string s){
        username = s;
    }

    public void RegisterUser(){
        bool error = DatabaseInstance.RegisterUser(username, password);
        txtErrorMessage.text = string.Empty;
        if(!error){
            txtErrorMessage.text = "Username already taken.";
        } else {
            showMainMenuPanel();
        }
    }

    public void Login(){
        txtErrorMessage.text = string.Empty;
        if(!DatabaseInstance.Login(username, password)){
        txtErrorMessage.text = "Invalid username or password";
        } else {
            showMainMenuPanel();
        }
    }

    public void Logout(){
        DatabaseInstance.Logout();
        showMainMenuPanel();
    }

    public void showLeaderboardPanel()
    {
        mainMenuPanel.SetActive(false);
        leaderboardPanel.SetActive(true);
        customizationPanel.SetActive(false);
        accountPanel.SetActive(false);
        gameOverScreen.SetActive(false);
        registerLoginPanel.SetActive(false);
        leaderBoardMethod();
    }

    public void leaderBoardMethod(){
        List<PlayerScore> scores = DatabaseInstance.getTopTenScores();
        foreach(PlayerScore score in scores){
            //code to spawn in stuff here
        }
    }

    public void showCustomizationPanel()
    {
        if(Player.ID == -1){
            showAccountPanel();
        } else {
            mainMenuPanel.SetActive(false);
            leaderboardPanel.SetActive(false);
            customizationPanel.SetActive(true);
            accountPanel.SetActive(false);
            gameOverScreen.SetActive(false);
            registerLoginPanel.SetActive(false);
            storeErrorMessage.text = "";
            costMessage.text = "";
            buyButton.SetActive(false);
            selectButton.SetActive(false);
        }
        
    }

    public void showAccountPanel()
    {
        mainMenuPanel.SetActive(false);
        leaderboardPanel.SetActive(false);
        customizationPanel.SetActive(false);
        gameOverScreen.SetActive(false);


        if(Player.ID == -1){
            registerLoginPanel.SetActive(true);
            accountPanel.SetActive(false);

        } else {
            registerLoginPanel.SetActive(false);
            accountPanel.SetActive(true);
            coinsMessage.text = $"Coins: {Player.currentCoins}";
            highScoreMessage.text = $"High Score: {Player.highScore}";
            usernameMessage.text = $"Username: {Player.username}";
        }
    }

    public void showGameOverPanel()
    {
        mainMenuPanel.SetActive(false);
        leaderboardPanel.SetActive(false);
        customizationPanel.SetActive(false);
        accountPanel.SetActive(false);
        gameOverScreen.SetActive(true);
        registerLoginPanel.SetActive(false);
        gameoverCoins.text = $"Coins: {currentCoins}";
        gameoverScore.text = $"Score: {currentScore}";
    }

    // public void loadGameplayScene()
    // {
    //     mainMenuPanel.SetActive(false);
    //     leaderboardPanel.SetActive(false);
    //     customizationPanel.SetActive(false);
    //     accountPanel.SetActive(false);
    //     // gameOverlay.SetActive(true);
    //     registerLoginPanel.SetActive(false);
    // }

    public void buyBall(){
        switch (selectedBall){
            case 1:
                buyBeachBall();
                break;
            case 2:
                buyBowlingBall();
                break;
            case 3:
                buyGreenBall();
                break;
            case 4:
                buyPinkBall();
                break;
            case 5:
                buyRedBall();
                break;
            case 6:
                buyYellowBall();
                break;
            default:
                showMainMenuPanel();
                break;
        }
    }

    public void selectDefaultBall(){
        selectedBall = (int)DatabaseInstance.ballSelection.DefaultBall;
        if(doesPlayerOwnBall(selectedBall)){
            buyButton.SetActive(false);
            selectButton.SetActive(true);
            costMessage.text = "";
        } else {
            buyButton.SetActive(true);
            selectButton.SetActive(false);
            costMessage.text = $"Cost: {DatabaseInstance.getBallCost(selectedBall)}";
        }
        
    }

    public void buyBeachBall(){
        if(DatabaseInstance.getBallCost(selectedBall) <= Player.currentCoins){
            storeErrorMessage.text = "";
            DatabaseInstance.buyBeachBall();
            equipBallSkin(selectedBall);
            showMainMenuPanel();
        } else {
            storeErrorMessage.text = lowFundsErrorMessage;
        }
        
    }
    public void selectBeachBall(){
        selectedBall = (int)DatabaseInstance.ballSelection.BeachBall;
        if(doesPlayerOwnBall(selectedBall)){
            buyButton.SetActive(false);
            selectButton.SetActive(true);
            costMessage.text = "";
        } else {
            buyButton.SetActive(true);
            selectButton.SetActive(false);
            costMessage.text = $"Cost: {DatabaseInstance.getBallCost(selectedBall)}";
        }
    }

    public void buyBowlingBall(){
        if(DatabaseInstance.getBallCost(selectedBall) <= Player.currentCoins){
            DatabaseInstance.buyBowlingBall();
            equipBallSkin(selectedBall);
            showMainMenuPanel();
        } else {
            storeErrorMessage.text = lowFundsErrorMessage;
        }
        
    }
    public void selectBowlingBall(){
        selectedBall = (int)DatabaseInstance.ballSelection.BowlingBall;
        if(doesPlayerOwnBall(selectedBall)){
            buyButton.SetActive(false);
            selectButton.SetActive(true);
            costMessage.text = "";
        } else {
            buyButton.SetActive(true);
            selectButton.SetActive(false);
            costMessage.text = $"Cost: {DatabaseInstance.getBallCost(selectedBall)}";
        }
    }
    public void buyGreenBall(){
        if(DatabaseInstance.getBallCost(selectedBall) <= Player.currentCoins){
            DatabaseInstance.buyBowlingBall();
            equipBallSkin(selectedBall);
            showMainMenuPanel();
        } else {
            storeErrorMessage.text = lowFundsErrorMessage;
        }
        
    }
    public void selectGreenBall(){
        selectedBall = (int)DatabaseInstance.ballSelection.GreenBall;
        storeErrorMessage.text = "";
        if(doesPlayerOwnBall(selectedBall)){
            buyButton.SetActive(false);
            selectButton.SetActive(true);
            costMessage.text = "";
        } else {
            buyButton.SetActive(true);
            selectButton.SetActive(false);
            costMessage.text = $"Cost: {DatabaseInstance.getBallCost(selectedBall)}";
        }
    }

    public void buyPinkBall(){
        if(DatabaseInstance.getBallCost(selectedBall) <= Player.currentCoins){
            DatabaseInstance.buyPinkBall();
            equipBallSkin(selectedBall);
            showMainMenuPanel();
        } else {
            storeErrorMessage.text = lowFundsErrorMessage;
        }
        
    }
    public void selectPinkBall(){
        selectedBall = (int)DatabaseInstance.ballSelection.PinkBall;
        if(doesPlayerOwnBall(selectedBall)){
            buyButton.SetActive(false);
            selectButton.SetActive(true);
            costMessage.text = "";
        } else {
            buyButton.SetActive(true);
            selectButton.SetActive(false);
            costMessage.text = $"Cost: {DatabaseInstance.getBallCost(selectedBall)}";
        }
    }

    public void buyRedBall(){
        if(DatabaseInstance.getBallCost(selectedBall) <= Player.currentCoins){
            DatabaseInstance.buyRedBall();
            equipBallSkin(selectedBall);
            showMainMenuPanel();
        } else {
            storeErrorMessage.text = lowFundsErrorMessage;
        }
        
    }
    public void selectRedBall(){
        selectedBall = (int)DatabaseInstance.ballSelection.RedBall;
        if(doesPlayerOwnBall(selectedBall)){
            buyButton.SetActive(false);
            selectButton.SetActive(true);
            costMessage.text = "";
        } else {
            buyButton.SetActive(true);
            selectButton.SetActive(false);
            costMessage.text = $"Cost: {DatabaseInstance.getBallCost(selectedBall)}";
        }
    }

    public void buyYellowBall(){
        if(DatabaseInstance.getBallCost(selectedBall) <= Player.currentCoins){
            DatabaseInstance.buyYellowBall();
            equipBallSkin(selectedBall);
            showMainMenuPanel();
        } else {
            storeErrorMessage.text = lowFundsErrorMessage;
        }
    }
    public void selectYellowBall(){
        selectedBall = (int)DatabaseInstance.ballSelection.YellowBall;
        if(doesPlayerOwnBall(selectedBall)){
            buyButton.SetActive(false);
            selectButton.SetActive(true);
            costMessage.text = "";
        } else {
            buyButton.SetActive(true);
            selectButton.SetActive(false);
            costMessage.text = $"Cost: {DatabaseInstance.getBallCost(selectedBall)}";
        }
    }

    public void pressSelectButton(){
        equipBallSkin(selectedBall);
        showMainMenuPanel();
    }

    public void checkCoinsAndHS(){
        DatabaseInstance.addCoins(currentCoins);
        if(currentScore > Player.highScore){
            DatabaseInstance.setHighScore(currentScore);
        }
    }
    public bool doesPlayerOwnBall(int ballID){
        if(Player.ownedSkins[ballID] == 1){
            return true;
        }
        return false;
    }
    public void equipBallSkin(int ballID){
        DatabaseInstance.equipSkin(ballID);
    }
}
