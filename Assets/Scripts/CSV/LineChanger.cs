using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LineChanger : MonoBehaviour
{
    [SerializeField]
    [Header("CSVを読み込むクラス")]
    private CSVReader _csvReader;

    [SerializeField]
    [Header("行数")]
    private TextMeshProUGUI[] _lineTextField;

    [SerializeField]
    [Header("セレクトキャラクター")]
    private SelectCharacter _selectCharacter;

    [SerializeField]
    [Header("SceneLoader")]
    private SceneLoader _sceneLoader;

    private int[] _lineNum = new int[7];

    private void Start()
    {
        for (int i = 0; i < _lineTextField.Length; i++)
        {
            _lineTextField[i].text = "";
        }
    }

    /// <summary>
    /// キャラクターナンバーに応じて出すテキストを変える関数
    /// </summary>
    public void CharacterNumber()
    {
        if (_selectCharacter.CharaNum == -1) return;

        Debug.Log(_selectCharacter.CharaNum);
        string[] strings = _csvReader.GetLines(_selectCharacter.CharaNum);

        if (_lineNum[_selectCharacter.CharaNum] == strings.Length)
        {
            _sceneLoader.FadeInSceneChange("GameClear");
            return;
        }

        _lineTextField[_selectCharacter.CharaNum].text = strings[_lineNum[_selectCharacter.CharaNum]];
        _lineNum[_selectCharacter.CharaNum]++;
    }
}
