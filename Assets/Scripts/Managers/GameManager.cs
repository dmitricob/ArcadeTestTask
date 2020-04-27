using Assets.Scripts.DataStuff;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // ToDo autoload prefabs
    public GameObject airEnemyPref; // flyer
    public GameObject groundEnemyPref; // grounder
    public GameObject bossPref; // boss

    public GameObject heroPref;

    public GameObject YouDiedScreen;
    public GameObject YouWinScreen;

    public GameObject activHero;
    public List<GameObject> enemies;

    AllGameDataPresets gamedata;

    void Start()
    {
        //InitializeManager();
                
        DataManager.LoadData();
        gamedata = DataManager.GetData();
        gamedata.SetHeroValues(heroPref);
        gamedata.SetAirEnemyValues(airEnemyPref);
        gamedata.SetGroundEnemyValues(groundEnemyPref);
        gamedata.SetBossValues(bossPref);
        SpawnHero();


        // move to scens
        switch(SceneManager.GetActiveScene().buildIndex )
        {
            case 0:
                InitEnemies1();
                break;
            default:
                InitEnemies2();
                break;
        }
    }
    private void InitializeManager()
    {
        if (!instance)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        //DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Debug.Log("Spawn");
            Instantiate(airEnemyPref, transform);
        }
    }

    public GameObject Spawn(GameObject gm, Vector3 position)
    {
        var inst = Instantiate(gm, position, Quaternion.identity);
        inst.GetComponent<Character>().onDie += OnEnemyDie;
        return inst;
    }

    private void OnEnemyDie(GameObject diedGameObject)
    {
        enemies.Remove(diedGameObject);
        if(enemies.Count == 0)
        {
            OnArenaWin();
        }
    }

    private void OnArenaWin()
    {
        Debug.Log(SceneManager.sceneCount);

        if (SceneManager.GetActiveScene().buildIndex + 1 < /*SceneManager.sceneCount*/2)
            Invoke("LoadNextScen", 3);
        else
            Invoke("OnHeroWin", 2);

    }

    private void LoadNextScen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public GameObject SpawnHero()
    {
        Vector3 heroSpawnPosition = new Vector3(0,0.5f,-12);
        var hero = Spawn(heroPref, heroSpawnPosition);
        hero.GetComponent<Character>().onDie += OnHeroDie;

        return hero;
    }

    private void OnHeroDie(GameObject diedGameObject)
    {
        YouDiedScreen.SetActive(true);
    }
    private void OnHeroWin()
    {
        YouWinScreen.SetActive(true);
    }

    public GameObject SpawnEnemy1(float x,float y,float z)
    {
        return SpawnEnemy1(new Vector3(x,y,z));
    }
    public GameObject SpawnEnemy1(Vector3 pos)
    {
        return Spawn(airEnemyPref, pos);
    }

    public GameObject SpawnEnemy2(float x, float y, float z)
    {
        return SpawnEnemy2(new Vector3(x, y, z));
    }
    public GameObject SpawnEnemy2(Vector3 pos)
    {
        return Spawn(groundEnemyPref, pos);
    }    
    public GameObject SpawnBoss()
    {
        Debug.Log("Boss spwaned");
        Vector3 spawnPosition = new Vector3(0,0.5f,12);
        return Spawn(bossPref, spawnPosition);
    }
    
    public void InitEnemies1()
    {
        enemies.Add(SpawnEnemy1(-10,0.6f,10));
        enemies.Add(SpawnEnemy1(10,0.6f,10));

        enemies.Add(SpawnEnemy2(0,0,6));
        enemies.Add(SpawnEnemy2(-7,0,0));
        enemies.Add(SpawnEnemy2(7,0,0));
    }
    public void InitEnemies2()
    {
        enemies.Add(SpawnBoss());
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
