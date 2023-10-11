using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class authManager : MonoBehaviour
{
    
    public Button signInButton;

    async void Start()
    {
        await UnityServices.InitializeAsync();
    }

    public async void SignIn()
    {
        await SignInAnonymous();
    }

    async Task SignInAnonymous()
    {
        try
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();

            print("Sign in Success");
            print("Player Id:" + AuthenticationService.Instance.PlayerId);
            

            // Enable the Welcome button upon successful sign-in
            signInButton.interactable = true;

            // Change the scene after displaying the status
            GoToWelcomeScene();
        }
        catch (System.Exception ex)
        {
            print("Sign in Failed!");
            Debug.LogException(ex);
        }
    }

    // Method to handle scene transition
    public void GoToWelcomeScene()
    {
        SceneManager.LoadScene("District"); // Make sure "District" matches the name you gave to your new scene
    }
}
