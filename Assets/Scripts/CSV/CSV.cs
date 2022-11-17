using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CSV : MonoBehaviour
{
    int _csvCount;
    TextAsset csvFile; // CSVファイル
    List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト;

    [SerializeField]
    [Header("テキスト")]
    Text _Text;

    void Start()
    {
        csvFile = Resources.Load("testCSV") as TextAsset; // Resouces下のCSV読み込み
        StringReader reader = new StringReader(csvFile.text);

        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            csvDatas.Add(line.Split(',')); // , 区切りでリストに追加
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
                print("今最大");
            }
        }
    }
}