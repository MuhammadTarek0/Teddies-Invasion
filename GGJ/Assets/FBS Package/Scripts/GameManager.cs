using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour {

	public PlayerFPS player;

	public GameObject canvasSetting;
	public GameObject NightVision_Camera;


    DeferredNightVisionEffect myLight;
    PostProcessLayer PPlayer;
    public bool isSetting;
	public bool NightVision;
	
    void Awake()
    {
        myLight = NightVision_Camera.GetComponent<DeferredNightVisionEffect>();
        PPlayer = NightVision_Camera.GetComponent<PostProcessLayer>();
    }
    void Start()
    {
        myLight.enabled = false;
        PPlayer.enabled = false;
    }
	void Update()
	{
        if (Input.GetKeyDown(KeyCode.F))
        {
            NightVision = !NightVision;
        }


        if (NightVision)
        {
            myLight.enabled = true;
            //PPlayer.enabled = true;
        }
        if (!NightVision)
        {
            myLight.enabled = false;
            //PPlayer.enabled = false;
        }

        if (Input.GetKeyDown (KeyCode.Escape))
			isSetting = !isSetting;
		
		if(isSetting)
		{
			player.enabled = false;
			canvasSetting.gameObject.SetActive(true);
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
		
		if(!isSetting)
		{
			player.enabled = true;
			canvasSetting.gameObject.SetActive(false);
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
	}

    public PostProcessLayer myPP()
    {
        return PPlayer;
    }
}
