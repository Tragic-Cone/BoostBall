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

    //Customization panel variables
    public int selectedBall = 1;
    public enum ballSelection{
        DefaultBall,
        GreenBall,
        RedBall,
        YellowBall,
        PinkBall,
        BowlingBall,
        BeachBall
    }
    // Start is called before the first frame update
    void Start()
    {
        mainMenuPanel.SetActive(true);
        leaderboardPanel.SetActive(false);
        customizationPanel.SetActive(false);
        accountPanel.SetActive(false);
        gameOverlay.SetActive(false);
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
    }

    public void showLeaderboardPanel()
    {
        mainMenuPanel.SetActive(false);
        leaderboardPanel.SetActive(true);
        customizationPanel.SetActive(false);
        accountPanel.SetActive(false);
        gameOverlay.SetActive(false);
    }

    public void showCustomizationPanel()
    {
        mainMenuPanel.SetActive(false);
        leaderboardPanel.SetActive(false);
        customizationPanel.SetActive(true);
        accountPanel.SetActive(false);
        gameOverlay.SetActive(false);
    }

    public void showAccountPanel()
    {
        mainMenuPanel.SetActive(false);
        leaderboardPanel.SetActive(false);
        customizationPanel.SetActive(false);
        accountPanel.SetActive(true);
        gameOverlay.SetActive(false);
    }

    public void showGameplayPanel()
    {
        mainMenuPanel.SetActive(false);
        leaderboardPanel.SetActive(false);
        customizationPanel.SetActive(false);
        accountPanel.SetActive(true);
        gameOverlay.SetActive(false);
    }

    public void loadGameplayScene()
    {
        mainMenuPanel.SetActive(false);
        leaderboardPanel.SetActive(false);
        customizationPanel.SetActive(false);
        accountPanel.SetActive(false);
        gameOverlay.SetActive(true);
    }

    public void buyBeachBall(){
        //something
    }

    public void buyBowlingBall(){
        //something
    }

    public void buyGreenBall(){
        //something
    }

    public void buyPinkBall(){
        //something
    }

    public void buyRedBall(){
        //something
    }

    public void buyYellowBall(){
        //something
    }

    public void pressSelectButton(){
        /* If selected ball is unlocked, select the 
        ball and then go back to main menu */
        showMainMenuPanel();
    }


}
