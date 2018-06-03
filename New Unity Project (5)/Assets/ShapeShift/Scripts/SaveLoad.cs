using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class SaveLoad : MonoBehaviour
{
    public static SaveLoad Instance;// Create An Instance of "this" script
    public List<Ground> Ground = new List<Ground>();
    public List<Obstacles> Obstacles = new List<Obstacles>();
    public List<Collectables> Collectables = new List<Collectables>();
    public List<Shapes> shapes = new List<Shapes>();
    private void Awake()
    {
        Instance = this;
        Load();
        StartCoroutine(GameObjPropertiesLoad());
      
    }
    public void Save()
    {
        BinaryFormatter binary = new BinaryFormatter();
        FileStream fstream = File.Create(Application.persistentDataPath + "/ShapeShift");
        SaveManager save = new SaveManager();
        save.BestScore = ScoreManager.Instance.bestScore;
        save.Collectible = ScoreManager.Instance.collectible;
        save.soundtoggle = ShapeShiftGameManager.Instance.soundindex;
        binary.Serialize(fstream, save);
        fstream.Close();
    }
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/ShapeShift"))
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream fStream = File.Open(Application.persistentDataPath + "/ShapeShift", FileMode.Open);
            SaveManager save = (SaveManager)binary.Deserialize(fStream);
            ScoreManager.Instance.bestScore = save.BestScore;
            ScoreManager.Instance.collectible = save.Collectible;
            ShapeShiftGameManager.Instance.soundindex = save.soundtoggle;
            fStream.Close();
        }
    }
    public IEnumerator GameObjPropertiesLoad()
    {
        Ground.Add(new Ground(Resources.Load<GameObject>("Prefabs/Ground/Ground")));
        Collectables.Add(new Collectables(Resources.Load<GameObject>("Prefabs/Collectibles/Collectible")));
        Obstacles.Add(new Obstacles(Resources.Load<GameObject>("Prefabs/Obstacles/obstacle_cube"),false, shape.Cube));
        Obstacles.Add(new Obstacles(Resources.Load<GameObject>("Prefabs/Obstacles/obstacle_cuboid"), false, shape.Cuboid));
        Obstacles.Add(new Obstacles(Resources.Load<GameObject>("Prefabs/Obstacles/obstacle_diamond "), false, shape.Diamond));
        Obstacles.Add(new Obstacles(Resources.Load<GameObject>("Prefabs/Obstacles/obstacle_l"), false, shape.l));
        Obstacles.Add(new Obstacles(Resources.Load<GameObject>("Prefabs/Obstacles/obstacle_cone"), false, shape.Cone));
        Obstacles.Add(new Obstacles(Resources.Load<GameObject>("Prefabs/Obstacles/obstacle_hemisphere"), false, shape.Hemisphere));
        Obstacles.Add(new Obstacles(Resources.Load<GameObject>("Prefabs/Obstacles/obstacle_sphere"), false, shape.Sphere));
        Obstacles.Add(new Obstacles(Resources.Load<GameObject>("Prefabs/Obstacles/obstacle_hexagonalprism"), false, shape.Hexagonalprism));
        shapes.Add(new Shapes(Resources.Load<GameObject>("Prefabs/Shapes/shape_cube"), shape.Cube,false));
        shapes.Add(new Shapes(Resources.Load<GameObject>("Prefabs/Shapes/shape_cuboid"), shape.Cuboid,false));
        shapes.Add(new Shapes(Resources.Load<GameObject>("Prefabs/Shapes/shape_diamond"), shape.Diamond,false));
        shapes.Add(new Shapes(Resources.Load<GameObject>("Prefabs/Shapes/shape_l"), shape.l, false));
        shapes.Add(new Shapes(Resources.Load<GameObject>("Prefabs/Shapes/shape_cone"), shape.Cone, false));
        shapes.Add(new Shapes(Resources.Load<GameObject>("Prefabs/Shapes/shape_hemisphere"), shape.Hemisphere, false));
        shapes.Add(new Shapes(Resources.Load<GameObject>("Prefabs/Shapes/Sphere"), shape.Sphere, false));
        shapes.Add(new Shapes(Resources.Load<GameObject>("Prefabs/Shapes/shape_hexagonalprism"), shape.Hexagonalprism, false));
        GUIManager.Instance.UpdateBestScore(ScoreManager.Instance.bestScore);
        GUIManager.Instance.UpdateCollectible(ScoreManager.Instance.collectible);
        InfiniteGameObjManager.Instance.InstantiateGameObjects();
        yield return new WaitForSeconds(1);
        ShapeShiftGameManager.Instance.SoundtoggleOnLoad(ShapeShiftGameManager.Instance.soundindex);
        yield return null;
    }
}
[Serializable]
class SaveManager
{
    public int BestScore;
    public int Collectible;
    public int soundtoggle;
}

