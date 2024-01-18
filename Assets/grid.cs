using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int _width, _height;
    [SerializeField] private tile _tileprefab;
    [SerializeField] private tile wall;
    [SerializeField] private Transform _cam;
    [SerializeField] private Transform player;
    private List<List<int>> map;

    void Start()
    {
        map = new List<List<int>> { 
            new List<int> { 1, 1, 1, 1, 1, 1 }, 
            new List<int> { 1, 0, 1, 0, 1, 0 },
            new List<int> { 1, 1, 1, 1, 1, 1 },
            new List<int> { 1, 1, 1, 1, 1, 1 },
            new List<int> { 1, 1, 1, 1, 1, 1 },
            new List<int> { 1, 1, 1, 1, 1, 1 }};
        generate();
    }

    void generate()
    {

        for (int x = 0; x <map.Count; x++)
        {
            for (int y = 0; y < map[0].Count; y++)
            {
                if(map[x][y]==1)
                {
                    var spawnTile = Instantiate(_tileprefab, new Vector2(2.8f*x, 2.8f*y), Quaternion.identity);
                    spawnTile.count = Random.Range(1, 10);


                }
                if (map[x][y] == 0)
                {
                    var spawnTile = Instantiate(wall, new Vector2(2.8f * x, 2.8f * y), Quaternion.identity);
                    //spawnTile.count = Random.Range(1, 10);
                }

            }
        }

        //_cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
        player.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);


    }

}
