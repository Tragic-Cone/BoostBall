using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    //Customization panel variables
    public int selectedBall = 1;
    
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showMainMenuPanel()
    {
        mainMenuPanel.SetActive(true);
        leaderboardPanel.SetActive(false);
        customizationPanel.SetActive(false);
        accountPanel.SetActive(false);
        gameOverlay.SetActive(false);
        registerLoginPanel.SetActive(false);
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
        mainMenuPanel.SetActive(false);
        leaderboardPanel.SetActive(false);
        customizationPanel.SetActive(true);
        accountPanel.SetActive(false);
        gameOverlay.SetActive(false);
        registerLoginPanel.SetActive(false);
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

    public void buyBeachBall(){
        DatabaseInstance.buyBeachBall();
        //equip and bring to Main Menu
    }

    public void buyBowlingBall(){
        DatabaseInstance.buyBowlingBall();
        //something
    }

    public void buyGreenBall(){
        DatabaseInstance.buyBowlingBall();
        //something
    }

    public void buyPinkBall(){
        DatabaseInstance.buyPinkBall();
        //something
    }

    public void buyRedBall(){
        DatabaseInstance.buyRedBall();
        //something
    }

    public void buyYellowBall(){
        DatabaseInstance.buyYellowBall();
        //something
    }

    public void pressSelectButton(){
        /* If selected ball is unlocked, select the 
        ball and then go back to main menu */
        showMainMenuPanel();
    }


}
