using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reg : MonoBehaviour
{   // backend app server URL
    private string regEndPoint = "https://pizzaone-node-app.herokuapp.com/reg"; // "localhost:24567/reg";
    // objects for registration
    [SerializeField] private TextMeshProUGUI alertText;
    [SerializeField] private Button signupButton;
    [SerializeField] private Button updateButton;
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_InputField emailInputField;
    [SerializeField] private TextMeshProUGUI alertText2;
    [SerializeField] private Button signinButton;
    [SerializeField] private TMP_InputField usernameInputField2;
    [SerializeField] private TMP_InputField emailInputField2;

    // Updates User info of Database -> moves to the next stage
    public void OnUpdateClick()
    {
        updateButton.interactable = false;
        StartCoroutine(Updating());
    }
    public IEnumerator Updating()
    {

        float input = GameManager.thisRoundMon;
        // loads the data from saved file "account.info"
        GameAccount newAccount = new GameAccount("", "");
        newAccount.LoadGameAccount();
        print(newAccount.stage);
        newAccount.stage++;
        newAccount.Set_score(input);
        newAccount.Set_ach();
        int newA = 0;
        UnityWebRequest request = UnityWebRequest.Get($"{regEndPoint}?username={newAccount.username}&email={newAccount.email}&level_score={newAccount.score}&level_ach={newAccount.ach}&stage={newAccount.stage}&new_one={newA}");
        var handler = request.SendWebRequest();
        Debug.Log($"{newAccount.username}:{newAccount.email}:{newAccount.stage}");
        float startTime = 0.0f;
        while (!handler.isDone)
        {
            startTime += Time.deltaTime;

            if (startTime > 10.0f)
            {
                break;
            }

            yield return null;

        }

        if (request.result == UnityWebRequest.Result.Success)
        {
            //"Updated!"
            updateButton.interactable = false;
            newAccount.SaveGameAccount();
            print(newAccount.stage);

            Debug.Log($"new update{newAccount.stage} !");

        }
        else
        {
            // "Error connecting to the server..."
            updateButton.interactable = true;
        }

        yield return null;
    }

    // Creates new User account -> moves to the next scene
    public void OnRegisterClick()
    {
        alertText.text = "Creating new account....";
        signupButton.interactable = false;
        StartCoroutine(Registering());
    }
    private IEnumerator Registering()
    {
        string username = usernameInputField.text;
        string email = emailInputField.text;
        int newA = 1;
        LevelLoader levelloader = new LevelLoader();

        if (username.Length < 1 && email.Length < 2)
        {
            alertText.text = "Please fill in the blanks properly";
            signupButton.interactable = true;
            yield break;
        }

        if (username.Length < 1)
        {
            alertText.text = "Invalid username";
            signupButton.interactable = true;
            yield break;
        }

        if (email.Length < 2)
        {
            alertText.text = "Invalid email";
            signupButton.interactable = true;
            yield break;
        }
        GameAccount newAccount = new GameAccount(username, email);

        UnityWebRequest request = UnityWebRequest.Get($"{regEndPoint}?username={newAccount.username}&email={newAccount.email}&level_score={newAccount.score}&level_ach={newAccount.ach}&stage={newAccount.stage}&new_one={newA}");
        var handler = request.SendWebRequest();
        Debug.Log($"{username}:{email}");
        float startTime = 0.0f;
        while (!handler.isDone)
        {
            startTime += Time.deltaTime;

            if (startTime > 10.0f)
            {
                break;
            }

            yield return null;

        }

        if (request.result == UnityWebRequest.Result.Success)
        {

            if (request.downloadHandler.text == "Not New User.")
            {
                alertText.text = "Go to Returning User screen.";
                signupButton.interactable = true;
                Debug.Log($"old user!");
            }
            else if (request.downloadHandler.text != "Invalid credentials" && request.downloadHandler.text != "Already created." && request.downloadHandler.text != "Invalid address.")
            {
                alertText.text = "Welcome! " + username;
                signupButton.interactable = false;
                newAccount.SaveGameAccount();
                levelloader.LoadNextScene();
                Debug.Log($"new update{newAccount.stage} !");
                Debug.Log($"got user {username} !");

            }
            else if (request.downloadHandler.text == "Already created.")
            {
                alertText.text = "The email already exists.";
                signupButton.interactable = true;
                Debug.Log($"try new {email} !");

            }
            else
            {
                Debug.Log("no");
                alertText.text = "Incorrect email";
                signupButton.interactable = true;

            }

        }
        else
        {
            alertText.text = "Error connecting to the server...";
            signupButton.interactable = true;
        }

        yield return null;
    }

    // Reset the game data for Returning user 
    public void OnResetClick()
    {
        alertText2.text = "Logging in....";
        signinButton.interactable = false;
        StartCoroutine(UserReset());
    }
    private IEnumerator UserReset()
    {
        string username = usernameInputField2.text;
        string email = emailInputField2.text;
        int newA = 0;
        LevelLoader levelloader = new LevelLoader();

        if (username.Length < 1 && email.Length < 2)
        {
            alertText2.text = "Please fill in the blanks properly";
            signinButton.interactable = true;
            yield break;
        }

        if (username.Length < 1)
        {
            alertText2.text = "Invalid username";
            signinButton.interactable = true;
            yield break;
        }

        if (email.Length < 2)
        {
            alertText2.text = "Invalid email";
            signinButton.interactable = true;
            yield break;
        }
        GameAccount newAccount = new GameAccount(username, email);

        UnityWebRequest request = UnityWebRequest.Get($"{regEndPoint}?username={newAccount.username}&email={newAccount.email}&level_score={newAccount.score}&level_ach={newAccount.ach}&stage={newAccount.stage}&new_one={newA}");
        var handler = request.SendWebRequest();
        Debug.Log($"{username}:{email}");
        float startTime = 0.0f;
        while (!handler.isDone)
        {
            startTime += Time.deltaTime;

            if (startTime > 10.0f)
            {
                break;
            }

            yield return null;

        }

        if (request.result == UnityWebRequest.Result.Success)
        {

            if (request.downloadHandler.text == "Login Successful.")
            {
                alertText2.text = "Welcome again! " + username; ;
                signinButton.interactable = false;
                newAccount.SaveGameAccount();
                levelloader.LoadNextScene();
                Debug.Log($"new update{newAccount.stage} !");
                Debug.Log($"got user {username} !");

            }
            else if (request.downloadHandler.text == "Already created.")
            {
                alertText2.text = "Wrong username";
                signinButton.interactable = true;
                Debug.Log($"try correct one!");

            }
            else
            {
                Debug.Log("no");
                alertText2.text = "The user does not exist.";
                signinButton.interactable = true;

            }

        }
        else
        {
            alertText2.text = "Error connecting to the server...";
            signinButton.interactable = true;
        }

        yield return null;
    }
}