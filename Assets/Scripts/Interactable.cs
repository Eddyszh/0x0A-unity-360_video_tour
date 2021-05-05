using UnityEngine;
using UnityEngine.Video;

public class Interactable : MonoBehaviour
{
    private Vector3 normalScale;
    private readonly Vector3 highligthedScale = new Vector3(0.0065f, 0.0065f, 0.0065f);

    [SerializeField] private VideoPlayer playVideo;
    [SerializeField] private VideoPlayer stopVideo;

    // Start is called before the first frame update
    void Start()
    {
        normalScale = transform.localScale;
    }

    public void OnPointerEnter()
    {
        gameObject.transform.localScale = highligthedScale;
        Debug.Log("Got it!");
    }

    public void OnPointerExit()
    {
        gameObject.transform.localScale = normalScale;
        Debug.Log("Bye!");
    }

    public void OnPointerClick()
    {
        playVideo.Play();
        stopVideo.Stop();
    }
}
