using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReader : MonoBehaviour
{
    const string CSV_NAME = "CSV/Scenario";

    private TextAsset _csvFile;

    private List<string[]> _csvData = new List<string[]>();

    private List<string> _replacedData = new List<string>();

    private List<string[]> _lineData = new List<string[]>();
    
    private void Start()
    {
        _csvFile = Resources.Load(CSV_NAME) as TextAsset;

        StringReader reader = new StringReader(_csvFile.text);

        Debug.Log(_csvFile.text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            _csvData.Add(line.Split(','));
        }

        for (int y = 0; y < _csvData.Count; y++)
        {
            for (int x = 0; x < _csvData[y].Length; x++)
            {
                string arr = _csvData[y][x].Replace("<>", "\n");
                _replacedData.Add(arr);
            }
            string[] data = new string[_replacedData.Count];

            for (int i = 0; i < _replacedData.Count; i++)
            {
                data[i] = _replacedData[i];
            }

            _lineData.Add(data);

            _replacedData.Clear();
        }
    }

    public string[] GetLines(int charaNum)
    {
        return _lineData[charaNum];
    }
}