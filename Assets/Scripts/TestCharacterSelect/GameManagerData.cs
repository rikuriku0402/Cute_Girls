using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName ="CharacterData")]
public class GameManagerData : ScriptableObject
{
    [SerializeField]
    [Header("次のシーン名")]
    string _nextSceneName;

    [SerializeField]
    [Header("助けるキャラ")]
    GameObject _character;

    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {
            _nextSceneName = "";
            _character = null;
        }
    }

    public void SetNextSceneName(string nextSceneName) => this._nextSceneName = nextSceneName;

    public string GetNextSceneName() => _nextSceneName;

    public void SetCharacter(GameObject character) => this._character = character;

    public GameObject GetCharacter() => _character;
}
