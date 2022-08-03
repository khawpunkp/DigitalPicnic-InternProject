using Photon.Pun;
using UnityEngine;

public class MiniGameInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public float _areaRadius = 7;
    public bool isActive = false;
    private GameObject[] players;
    private GameObject localPlayer;
    [SerializeField] private GameObject MiniGame;
    [SerializeField] private GameObject StartGameCanvas;
    [SerializeField] private GameObject EndGameCanvas;
    [SerializeField] private GameObject ScoreBoardCanvas;
    [SerializeField] private MiniGameSetUp MiniGameSetUp;
    [SerializeField] private PlayerHealth PlayerHealth;
    
    public string InteractionPrompt => _prompt;

    private void Start()
    {
        GetComponent<CapsuleCollider>().radius = _areaRadius;
        MiniGame.SetActive(false);
        MiniGameSetUp.StartCountDown(false);
    }

    private void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var p in players)
        {
            if (p.GetPhotonView().IsMine)
                localPlayer = p;
        }
    }

    public void Interaction(Interactor interactor)
    {
        MiniGame.SetActive(true);
        Cursor.visible = true;
        StartGameCanvas.SetActive(true);
        MiniGameSetUp.gameObject.SetActive(true);
        EndGameCanvas.SetActive(false);
        ScoreBoardCanvas.SetActive(false);
        PlayerDisplay(false);
    }

    private void PlayerDisplay(bool active)
    {
        localPlayer.GetComponent<ThirdPersonController>().enabled = active;
        localPlayer.GetComponent<Interactor>().enabled = active;
        localPlayer.transform.GetChild(0).gameObject.SetActive(active);
    }
    
    public void OnClick_ExitMiniGame()
    {
        Cursor.visible = false;
        PlayerDisplay(true);
        MiniGame.SetActive(false);
        localPlayer.SetActive(true);
    }

    public void OnClick_StartMiniGame()
    {
        PlayerHealth.SetPlayerMaxHealth();
        PlayerHealth.player.SetActive(true);
        MiniGameSetUp.StartCountDown(true);
        StartGameCanvas.SetActive(false);
        TimeManager.Instance.StartTimer();
        ScoreManager.Instance.StartScore();
    }
}
