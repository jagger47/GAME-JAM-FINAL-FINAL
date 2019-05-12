using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForFinish : MonoBehaviour
{
    public List<Vector3> end = new List<Vector3>();

    private bool ended;
    private float time = 720f;

    public GameObject myGrid;
    public GameObject myCharacter;
    public GameObject myCanvas;
    public GameObject myHUDCanvas;
    public GameObject myBGM;
    public GameObject myLosingCanvas;
    public GameObject myWinningSound;

    
    // Start is called before the first frame update
    void Start()
    {
        ChangeObjects(true, true, true, false, true, false, false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckEnd();
    }

    void CheckEnd()
    {
        time -= Time.deltaTime;

        if ((transform.position.x >= end[0].x && transform.position.x <= end[1].x) && (transform.position.y >= end[0].y && transform.position.y <= end[1].y))
        {
            ChangeObjects(false, false, false, true, false, false, true);
        } else if ( time <= 0 )
        {
            ChangeObjects(false, false, false, false, false, true, false);
        }
    }

    void ChangeObjects(bool a, bool b, bool c, bool d, bool e, bool f, bool g)
    {
        myGrid.SetActive(a);
        myCharacter.SetActive(b);
        myCanvas.SetActive(c);
        myHUDCanvas.SetActive(d);
        myBGM.SetActive(e);
        myLosingCanvas.SetActive(f);
        myWinningSound.SetActive(g);
    }
}
