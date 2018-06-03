using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll_2D_Shapes : MonoBehaviour {

    public GameObject[] shapes;

    public string shapeName = "none";

    public float delay = 3f;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnShapes());
	}

    // 코루틴 함수 적용
    IEnumerator SpawnShapes()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);

            // 다양한 도형을 스폰합니다.
            int ShapeIndex = Random.Range(0, shapes.Length);
            GameObject Shape = shapes[ShapeIndex];

            //도형 이름 설정
            switch(ShapeIndex)
            {
                case 0: shapeName = "Circle"; break;
                case 1: shapeName = "Oval"; break;
                case 2: shapeName = "Rectangle"; break;
                case 3: shapeName = "Triangle"; break;
                case 4: shapeName = "Distant_Rectangle"; break;
            }

            // 도형 스폰
            GameObject spawnedShape = Instantiate(Shape,gameObject.transform);
            Destroy(spawnedShape, delay);
        }
    }
}
