using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColorChanage : MonoBehaviour {

	public Image target;
    public GameObject textChange;
    public GameObject textChange1;

    public void SetWhite()
	{
		target.color = Color.white;
        textChange.gameObject.SetActive(false);
        textChange1.gameObject.SetActive(true);
    }

	public void SetRed()
	{
		target.color = Color.red;
        textChange.gameObject.SetActive(true);
        textChange1.gameObject.SetActive(false);
    }

	public void SetRandomColor()
	{
		//target.color = Random.ColorHSV();
        SceneManager.LoadScene("VRFPSGame");
	}
}
