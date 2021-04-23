using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

using UnityEngine.UI;


public class Save : MonoBehaviour
{

    private string savePath;
    private GameManager GM;
    public Text text1;

   public Text text2;

    public Text text3;
    // Start is called before the first frame update
    void Start()
    {
     
        savePath = Application.dataPath + "/save.txt";
        GM = GameObject.FindObjectOfType<GameManager>();
        SaveData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Function that save and load data to and from a json
    /// </summary>
    public void SaveData()
    {
        var binaryFormatter = new BinaryFormatter();
        
        if (!File.Exists(savePath))
        {
           var save = new Data()
            {
                CarreraMax = GM.getCarrera(),
                CarreraTotal = 1,
                Victorias = GM.getCarrera()
            };
            string json = JsonUtility.ToJson(save);
            File.WriteAllText(savePath, json);
            Debug.Log(json);
            text1.text =save.CarreraMax.ToString() + " Top Rounds";
            text2.text = save.CarreraTotal.ToString() + " Total Times Play";
            text3.text = save.Victorias.ToString() + " Wins";
         

        }
        else
        {
            
           
            string saveString =File.ReadAllText(savePath);
            Data save = JsonUtility.FromJson<Data>(saveString);
            if (save.CarreraMax< GM.getCarrera())
                save.CarreraMax = GM.getCarrera();
            save.CarreraTotal += 1;
            save.Victorias += GM.getCarrera();
            text1.text = save.CarreraMax.ToString() + " Top Rounds";
            text2.text = save.CarreraTotal.ToString() + " Total Times Play";
            text3.text = save.Victorias.ToString() + " Wins";
            string json = JsonUtility.ToJson(save);
            File.WriteAllText(savePath, json);

        }
        
      
        Debug.Log("Data Saved");
    }

}
