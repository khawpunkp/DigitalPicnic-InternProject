using Photon.Pun;

public class CheckPhotonView : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
        if(!photonView.IsMine)
            Destroy(gameObject);
    }
}
