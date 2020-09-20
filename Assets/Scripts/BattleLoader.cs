using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleLoader : MonoBehaviour
{

    [SerializeField]
    GameObject background;

    [SerializeField]
    Canvas battleUI;

    [SerializeField]
    Canvas selectionScreen;

    [SerializeField]
    Sprite[] backgroundImages;

    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject[] enemies;

    [SerializeField]
    Transform playerPosition;

    [SerializeField]
    Transform enemyPosition;

    Dictionary<string, Sprite> backgroundImagesDictionary;
    Dictionary<string, GameObject> enemiesDictionary;
    SpriteRenderer backgroundRenderer;

    private void Awake()
    {
        backgroundRenderer = background.GetComponent<SpriteRenderer>();
        SetDictionaries();

        LoadBattleButton.OnButtonClicked += LoadBattle;
    }

    private void SetDictionaries()
    {
        backgroundImagesDictionary = new Dictionary<string, Sprite>();
        enemiesDictionary = new Dictionary<string, GameObject>();

        foreach (var background in backgroundImages)
        {
            backgroundImagesDictionary.Add(background.name, background);
        }
        foreach (var enemy in enemies)
        {
            enemiesDictionary.Add(enemy.name, enemy);
        }

    }

    public void LoadBattle(string battle)
    {
        Debug.Log("Battle loading " + battle);
        backgroundRenderer.sprite = backgroundImagesDictionary[battle];
        backgroundRenderer.enabled = true;
        selectionScreen.gameObject.SetActive(false);
        battleUI.gameObject.SetActive(true);

        Instantiate(player, playerPosition);
        Instantiate(enemiesDictionary[battle], enemyPosition);
    }

    public void LoadMainScreen()
    {
        backgroundRenderer.enabled = false;
        selectionScreen.gameObject.SetActive(true);
        battleUI.gameObject.SetActive(false);
    }
}
