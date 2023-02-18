using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineChanger : MonoBehaviour
{
    [SerializeField]
    private CSVReader _csvReader;

    [SerializeField]
    private Text[] _lineTextField;

    [SerializeField]
    SelectCharacter _selectCharacter;

    private int[] _lineNum = new int[6];

    private void Start()
    {
        for (int i = 0; i < _lineTextField.Length; i++)
        {
            _lineTextField[i].text = "";
        }
    }

    /// <summary>
    /// �L�����N�^�[�i���o�[�ɉ����ďo���e�L�X�g��ς���֐�
    /// </summary>
    public void CharacterNumber()
    {
        if (_selectCharacter.CharaNum == -1) return;

        Debug.Log(_selectCharacter.CharaNum);
        string[] strings = _csvReader.GetLines(_selectCharacter.CharaNum);


        if (_lineNum[_selectCharacter.CharaNum] == strings.Length)
        {
            Debug.Log("�V�[����ς��Ă�������");
            return;
        }

        _lineTextField[_selectCharacter.CharaNum].text = strings[_lineNum[_selectCharacter.CharaNum]];
        _lineNum[_selectCharacter.CharaNum]++;
    }
}
