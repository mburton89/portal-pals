using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotadGameManager : MonoBehaviour
{
    public static NotadGameManager Instance;

    [HideInInspector] public int activeOrcs;
    public int dwarvesRemaining;
    public TextMeshProUGUI orcsRemainingText;
    public TextMeshProUGUI dwarvesRemainingText;

    public GameObject dwarfPrefab;
    public Transform dwarfSpawnPoint;

    public int min3BreadScore;
    public int min2BreadScore;
    public int currentPoints;

    public List<AudioClip> audioClips;
    public AudioSource audioSource;

    private bool _hasEndedSession = false;

    public MeshCollider spawnPlatform;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        activeOrcs = FindObjectsOfType<Orc>().Length;
        UpdateUI();
        SpawnDwarf();
        currentPoints = 0;

        audioSource.clip = audioClips[Random.Range(0, audioClips.Count)];
        audioSource.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!PauseMenuTwo.Instance.isActive)
            {
                if (GameOverMenu.Instance.isActive) return;
                PauseMenuTwo.Instance.Activate();
            }
            else
            {
                PauseMenuTwo.Instance.Resume();
            }
        }
    }

    void UpdateUI()
    {
        orcsRemainingText.SetText(activeOrcs.ToString());
        dwarvesRemainingText.SetText(dwarvesRemaining.ToString());
    }

    public void SpawnDwarf()
    {
        if (dwarvesRemaining > 0)
        {
            Instantiate(dwarfPrefab, dwarfSpawnPoint.position, dwarfSpawnPoint.rotation, null);
            dwarvesRemaining--;
            UpdateUI();
        }
        else
        {
            EndSession();
        }
    }

    public void DelaySpawnDwarf()
    {
        StartCoroutine(DelaySpawnDwarfCo());
    }

    private IEnumerator DelaySpawnDwarfCo()
    {
        yield return new WaitForSeconds(2);
        ActivateSpawnPlatform(true);
        SpawnDwarf();
    }

    public void HandleOrcDestroyed()
    {
        activeOrcs--;
        currentPoints += 100;
        UpdateUI();
        if (activeOrcs <= 0)
        {
            EndSession();
        }
    }

    public void ActivateSpawnPlatform(bool shouldBeActive)
    {
        spawnPlatform.enabled = shouldBeActive;
    }

    void EndSession()
    {
        if (_hasEndedSession) return;
        _hasEndedSession = true;
        currentPoints = currentPoints + (dwarvesRemaining + 1) * 100;
        if (activeOrcs > 0)
        {
            GameOverMenu.Instance.Activate(0);
        }
        else
        {
            if (currentPoints >= min3BreadScore)
            {
                GameOverMenu.Instance.Activate(3);
            }
            else if (currentPoints >= min2BreadScore)
            {
                GameOverMenu.Instance.Activate(2);
            }
            else
            {
                GameOverMenu.Instance.Activate(1);
            }
        }
    }
}
