using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadingScript : MonoBehaviour
{
    AsyncOperation loadingOperation;
   
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(LoadYourAsyncScene());
    }

    // Update is called once per frame
    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.
        yield return new WaitForSeconds(2);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
        asyncLoad.allowSceneActivation = false;
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            asyncLoad.allowSceneActivation = true;
            yield return  null;
        }
    }
}
