using UnityEngine;
using System.Collections;

public class guiManager : MonoBehaviour {

    float _timeStamp;

    private Rect m_PrincipalGroupBox = new Rect(19*Screen.width/20, 2*Screen.height/7 , Screen.width/20, 5*Screen.height/7 );
    private Rect m_PrincipalBox = new Rect(0, 0 * Screen.height / 7, Screen.width / 20, 5 * Screen.height / 7);

    private Rect m_Status5 = new Rect(0, 0 * Screen.height / 7, Screen.width / 20, 5 * Screen.height / 7);
    private Rect m_Status4 = new Rect(0, 1 * Screen.height / 7, Screen.width / 20, 4 * Screen.height / 7);
    private Rect m_Status3 = new Rect(0, 2 * Screen.height / 7, Screen.width / 20, 3 * Screen.height / 7);
    private Rect m_Status2 = new Rect(0, 3 * Screen.height / 7, Screen.width / 20, 2 * Screen.height / 7);
    private Rect m_Status1 = new Rect(0, 4 * Screen.height / 7, Screen.width / 20, 1 * Screen.height / 7);


    private Rect rectEnter = new Rect(1 * Screen.width / 20, 5 * Screen.height / 7,4 * Screen.width / 20, 2 * Screen.height / 7);
    private Rect rectTeclas = new Rect(7 * Screen.width / 20, 5 * Screen.height / 7, 4 * Screen.width / 20, 2 * Screen.height / 7);
    private Rect rectSpace = new Rect(13 * Screen.width / 20, 5 * Screen.height / 7, 4 * Screen.width / 20, 2 * Screen.height / 7);

    public int _status;

    public AudioClip[] StepSound;


    /*
    private Rect m_FirstBox = new Rect(2, 2, (Screen.width / 4), (Screen.height * 0.2f));
    private Rect m_SecondBox = new Rect((Screen.width / 4) + 2, 2, (Screen.width * 2 / 4), (Screen.height * 0.2f));
    private Rect m_ThirdBox = new Rect((Screen.width * 3 / 4) + 2, 2, (Screen.width / 4), (Screen.height * 0.2f));
    */

	// Use this for initialization

    public GUIStyle style;


    
    public GUIStyle SE;
    public GUIStyle ST;
    public GUIStyle SS;

    public TextAsset roja;
    Texture2D texture;

    void OnGUI()
    {
        //texture.LoadImage(roja.bytes);
        //style.normal.background = texture;

        if (_timeStamp < 5)
        {
            GUI.Box(rectEnter, "", SE);
            GUI.Box(rectTeclas, "", ST);
            GUI.Box(rectSpace, "", SS);
        }

        GUI.BeginGroup(m_PrincipalGroupBox );

            GUI.color = Color.black;
            //GUI.Box(m_PrincipalBox, "");
            GUI.color = Color.red;
            if (_status == 1){
                GUI.Box(m_Status1, "", style);
            } if (_status == 2){
                GUI.color = Color.yellow;
                GUI.Box(m_Status2, "", style);
            } if (_status == 3){
                GUI.color = Color.green;
                GUI.Box(m_Status3, "", style);
            }if (_status == 4){
                GUI.color = Color.yellow;
                GUI.Box(m_Status4, "", style);
            } if (_status == 5){
                GUI.color = Color.red;
                GUI.Box(m_Status5, "", style);
            }
         GUI.EndGroup();
    
    }
	void Start () {
        audio.clip = StepSound[_status - 1];
        audio.loop = true;
        audio.Play();

        _timeStamp = 0;
	}
	
	// Update is called once per frame
	void Update () {
        _timeStamp += Time.deltaTime;
	}

    public void changeStatus(int status){

        if (status == _status)
            return;


        _status = status;
      
        audio.Stop();

       audio.clip = StepSound[_status-1];


     //audio.loop = true;
       

        print(audio.clip.name);

        audio.Play();
    }
}
