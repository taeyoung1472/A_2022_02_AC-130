using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoSingleton<GameManager>
{
    #region 프로피터
    public PoolManager PoolManager { get { return poolManager; } }
    public CamManager CamManager { get { return camManager; } }
    #endregion
    [SerializeField] private PoolManager poolManager;
    [SerializeField] private CamManager camManager;
    [SerializeField] private Transform player, mainCam;
    [SerializeField] private User user;
    public User currentUser { get { return user; } }
    public static Transform Player { get { return Instance.player; } }
    public static Transform MainCam { get { return Instance.mainCam; } }
    private void Awake()
    {
        Time.timeScale = 1;
        LoadUser();
        SaveUser();
    }
    public void Start()
    {

    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //일시중지
        }
    }
    public bool Purchase(int price)
    {
        if (user.coin > price)
        {
            user.coin -= price;
            SaveUser();
            return true;
        }
        else
        {
            SaveUser();
            return false;
        }
    }
    [ContextMenu("저장하기")]
    public void SaveUser()
    {
        print("저장");
        string jsonData = JsonUtility.ToJson(user, true);
        string path = Path.Combine(Application.persistentDataPath, "playerData.json");
        File.WriteAllText(path, jsonData);
    }
    [ContextMenu("불러오기")]
    public void LoadUser()
    {
        print("불러오기");
        string path = Path.Combine(Application.persistentDataPath, "playerData.json");
        string jsonData = File.ReadAllText(path);
        user = JsonUtility.FromJson<User>(jsonData);
    }
    private void OnDestroy()
    {
        SaveUser();
    }
    private void OnApplicationQuit()
    {
        SaveUser();
    }
}