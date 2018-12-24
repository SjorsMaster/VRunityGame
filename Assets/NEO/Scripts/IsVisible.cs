//Attach this script to a GameObject with a Renderer component attached
//If the GameObject is visible to the camera, the message is output to the console

using UnityEngine;

public class IsVisible : MonoBehaviour
{
    [SerializeField]
    AudioClip[] NoLook;
    bool seen;
    [SerializeField]
    AudioClip Looking;
    AudioSource audioSource;


    Renderer m_Renderer;
    // Use this for initialization
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        m_Renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!seen)
        {
            if (m_Renderer.isVisible)
            {
                seen = true;
                audioSource.clip = Looking;
                Debug.Log("I have been seen, Playing seen file..");
                audioSource.Play();
            }
            else
            {
                if (!audioSource.isPlaying)
                {
                    int Rdm = Random.Range(0, NoLook.Length);
                    audioSource.clip = NoLook[Rdm];
                    Debug.Log("Now Playing: NoLook" + Rdm);
                    audioSource.Play();
                }
                Debug.Log("There is audio playing..");
            }
        }
        if(seen && !audioSource.isPlaying)
        {
            GameObject.Find("NEO").GetComponent<NeoMove>().ChangeState();
        }
    }
}