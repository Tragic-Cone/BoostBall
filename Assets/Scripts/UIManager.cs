using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    //GameObjects for panels
    public GameObject mainMenuPanel;
    public GameObject leaderboardPanel;
    public GameObject customizationPanel;
    public GameObject accountPanel;
    public GameObject gameOverlay;
    public GameObject registerLoginPanel;
    public GameObject accountDetailsPanel;
    public GameObject playerBall;
    public GameObject txtRegisterUsername;
    public GameObject txtRegisterPassword;
    public TMP_Text txtErrorMessage;
    private string password;
    private string username;
    public TMP_Text costMessage;
    public GameObject buyButton;

    //Customization panel variables
    public int selectedBall = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        mainMenuPanel.SetActive(true);
        leaderboardPanel.SetActive(false);
        customizationPanel.SetActive(false);
        accountPanel.SetActive(false);
        gameOverlay.SetActive(false);
        registerLoginPanel.SetActive(false);
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
        gameOverlay.SetActive(false);
        registerLoginPanel.SetActive(false);
    }
    public void changeBallSkin(int ballID){

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
        }
        showMainMenuPanel();
    }

    public void Login(){
        txtErrorMessage.text = string.Empty;
        if(DatabaseInstance.Login(username, password)){
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
        gameOverlay.SetActive(false);
        registerLoginPanel.SetActive(false);
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
            gameOverlay.SetActive(false);
            registerLoginPanel.SetActive(false);
        }
        
    }

    public void showAccountPanel()
    {
        mainMenuPanel.SetActive(false);
        leaderboardPanel.SetActive(false);
        customizationPanel.SetActive(false);
        gameOverlay.SetActive(false);


        if(Player.ID == -1){
            registerLoginPanel.SetActive(true);
            accountPanel.SetActive(false);

        } else {
            registerLoginPanel.SetActive(false);
            accountPanel.SetActive(true);
        }
    }

    public void showGameplayPanel()
    {
        mainMenuPanel.SetActive(false);
        leaderboardPanel.SetActive(false);
        customizationPanel.SetActive(false);
        accountPanel.SetActive(true);
        gameOverlay.SetActive(false);
        registerLoginPanel.SetActive(false);
    }

    public void loadGameplayScene()
    {
        mainMenuPanel.SetActive(false);
        leaderboardPanel.SetActive(false);
        customizationPanel.SetActive(false);
        accountPanel.SetActive(false);
        gameOverlay.SetActive(true);
        registerLoginPanel.SetActive(false);
    }

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
        selectedBall = 0;
        buyButton.SetActive(false);
        costMessage.text = "";
    }

    public void buyBeachBall(){
        DatabaseInstance.buyBeachBall();
        showMainMenuPanel();
    }
    public void selectBeachBall(){
        selectedBall = 1;
        if(doesPlayerOwnBall(selectedBall)){
            buyButton.SetActive(false);
            costMessage.text = "";
        } else {
            buyButton.SetActive(true);
            costMessage.text = $"Cost: {DatabaseInstance.getBallCost(6)}";
        }
    }

    public void buyBowlingBall(){
        DatabaseInstance.buyBowlingBall();
        showMainMenuPanel();
    }
    public void selectBowlingBall(){
        selectedBall = 2;
        if(doesPlayerOwnBall(selectedBall)){
            buyButton.SetActive(false);
            costMessage.text = "";
        } else {
            buyButton.SetActive(true);
            costMessage.text = $"Cost: {DatabaseInstance.getBallCost(2)}";
        }
    }
    public void buyGreenBall(){
        DatabaseInstance.buyBowlingBall();
        showMainMenuPanel();
    }
    public void selectGreenBall(){
        selectedBall = 3;
        if(doesPlayerOwnBall(selectedBall)){
            buyButton.SetActive(false);
            costMessage.text = "";
        } else {
            buyButton.SetActive(true);
            costMessage.text = $"Cost: {DatabaseInstance.getBallCost(3)}";
        }
    }

    public void buyPinkBall(){
        DatabaseInstance.buyPinkBall();
        showMainMenuPanel();
    }
    public void selectPinkBall(){
        selectedBall = 4;
        if(doesPlayerOwnBall(selectedBall)){
            buyButton.SetActive(false);
            costMessage.text = "";
        } else {
            buyButton.SetActive(true);
            costMessage.text = $"Cost: {DatabaseInstance.getBallCost(4)}";
        }
    }

    public void buyRedBall(){
        DatabaseInstance.buyRedBall();
        showMainMenuPanel();
    }
    public void selectRedBall(){
        selectedBall = 5;
        if(doesPlayerOwnBall(selectedBall)){
            buyButton.SetActive(false);
            costMessage.text = "";
        } else {
            buyButton.SetActive(true);
            costMessage.text = $"Cost: {DatabaseInstance.getBallCost(5)}";
        }
    }

    public void buyYellowBall(){
        DatabaseInstance.buyYellowBall();
        showMainMenuPanel();
    }
    public void selectYellowBall(){
        selectedBall = 6;
        if(doesPlayerOwnBall(selectedBall)){
            buyButton.SetActive(false);
            costMessage.text = "";
        } else {
            buyButton.SetActive(true);
            costMessage.text = $"Cost: {DatabaseInstance.getBallCost(6)}";
        }
    }

    public void pressSelectButton(){
        if(doesPlayerOwnBall(selectedBall)){
            //finish
        }
        showMainMenuPanel();
    }

    public void checkCoinsAndHS(){
        int coins = 0;
        int score = 0;
        DatabaseInstance.addCoins(coins);
        if(score > Player.highScore){
            DatabaseInstance.setHighScore(score);
        }
    }
    public bool doesPlayerOwnBall(int ballID){
        if(Player.ownedSkins[ballID] == 1){
            return true;
        }
        return false;
    }
}
