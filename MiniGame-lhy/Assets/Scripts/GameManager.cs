using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] keyBoardPrefabs;
    public KeyCode[] possibleKeys;

    public Transform keySpawnArea;
    public float xOffset = 1.5f; // X축 간격 조절 값

    public static int turn; //지금 어떤 오브젝트를 입력할 차례인지 (0에서 시작)

    private void Start()
    {
        turn = 0;
        SpawnKeyBoards(keySpawnArea);
    }

    void SpawnKeyBoards(Transform keySpawnArea)
    {
        int index = 0;   //현재 생성된 오브젝트 번호 나타내는 index변수

        for (float i = -3.0f; i <= 3.0f; i+=1.5f)
        {
            int randNum = Random.Range(0, possibleKeys.Length);

            float xPos = keySpawnArea.position.x + i * xOffset;
            Vector3 spawnPosition = new Vector3(xPos, keySpawnArea.position.y, keySpawnArea.position.z);

            GameObject selectedPrefab = keyBoardPrefabs[randNum];
            GameObject keyObject = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);

            KeyBoard keyScript = keyObject.GetComponent<KeyBoard>();
            keyScript.SetKeySprite(possibleKeys[randNum], index++); //index 변수 증가
        }
    }
}