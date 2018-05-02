using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEditor;
public class talk : MonoBehaviour {
	public static Flowchart flowchartManager;
	public Flowchart talkFlowchart;
	public string onCollosionEnter;
    public string onMouseDown="mouse";
    public string onMouseEnter = "mousein";
   Rigidbody playerRigidbody;
	// Use this for initialization
	void Awake () {
		flowchartManager = GameObject.Find ("talkcontrol").GetComponent<Flowchart> ();
        playerRigidbody = FindObjectOfType<player>().GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
	public static bool isTalking{
		get{ return flowchartManager.GetBooleanVariable ("ing");}
	}
    void PlayBlock(string targetBlockName)
    {
        Block targetBlock = talkFlowchart.FindBlock(targetBlockName);
        if (targetBlock != null)
        {
            talkFlowchart.ExecuteBlock(targetBlock);
        }
        else
        {
            Debug.LogError("找不到在 " + talkFlowchart.name + "裡的" + targetBlockName + "Block");
            Selection.activeGameObject = talkFlowchart.gameObject;
        }
    }
    private void OnCollisionEnter  (UnityEngine.Collision other)
	{
		if (!string.IsNullOrEmpty(onCollosionEnter) && !isTalking)
        {
            if (other.gameObject.CompareTag("player"))
            {
                playerRigidbody.Sleep();
                PlayBlock(onCollosionEnter);
            }
        }
		
	}
    private void OnMouseDown()
    {
        if (!string.IsNullOrEmpty(onMouseDown) && !isTalking)
        {
            PlayBlock(onMouseDown);
        }
    }
    private void OnMouseEnter()
    {
        if (!string.IsNullOrEmpty(onMouseEnter) && !isTalking)
        {
            PlayBlock(onMouseEnter);
        }
    }
}
