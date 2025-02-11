using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;
using System.IO;




#if UNITY_EDITOR
using UnityEditor;
#endif
public class MapEditor
{
#if UNITY_EDITOR

    // 단축키 % (Ctrl), #(Shift), & (Alt)
    [MenuItem("Tools/GenerateMap")]
    private static void GenerateMap()
    {
        GameObject[] gameObjects = Resources.LoadAll<GameObject>("Prefabs/Map");

        foreach (GameObject go in gameObjects)
        {
            Tilemap tmbase = Util.FindChild<Tilemap>(go, "Tilemap_Base", true);
            Tilemap tm = Util.FindChild<Tilemap>(go, "Tilemap_Collision", true);

            using (var writer = File.CreateText($"Assets/Resources/Map/{go.name}.txt"))
            {
                // 맵의 크기
                writer.WriteLine(tmbase.cellBounds.xMin);
                writer.WriteLine(tmbase.cellBounds.xMax);
                writer.WriteLine(tmbase.cellBounds.yMin);
                writer.WriteLine(tmbase.cellBounds.yMax);


                // 타일을 찾아서 표시 있으면 1 없으면 0
                for (int y = tmbase.cellBounds.yMax; y >= tmbase.cellBounds.yMin; y--)
                {
                    for (int x = tmbase.cellBounds.xMin; x <= tmbase.cellBounds.xMax; x++)
                    {
                        TileBase tile = tm.GetTile(new Vector3Int(x, y, 0));
                        if (tile != null)
                            writer.Write("1");
                        else
                            writer.Write("0");
                    }
                    writer.WriteLine();

                }
            }
        }

        

    }



#endif
}
