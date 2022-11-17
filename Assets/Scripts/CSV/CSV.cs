using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CSV : MonoBehaviour
{
    int _csvCount;
    TextAsset csvFile; // CSV�t�@�C��
    List<string[]> csvDatas = new List<string[]>(); // CSV�̒��g�����郊�X�g;

    [SerializeField]
    [Header("�e�L�X�g")]
    Text _Text;

    void Start()
    {
        csvFile = Resources.Load("testCSV") as TextAsset; // Resouces����CSV�ǂݍ���
        StringReader reader = new StringReader(csvFile.text);

        // , �ŕ�������s���ǂݍ���
        // ���X�g�ɒǉ����Ă���
        while (reader.Peek() != -1) // reader.Peaek��-1�ɂȂ�܂�
        {
            string line = reader.ReadLine(); // ��s���ǂݍ���
            csvDatas.Add(line.Split(',')); // , ��؂�Ń��X�g�ɒǉ�
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print(csvDatas[_csvCount][0]);
            _Text.text = csvDatas[_csvCount][0].ToString();
            _csvCount++;
            if (_csvCount == csvDatas.Count)
            {
                print("���ő�");
            }
        }
    }
}