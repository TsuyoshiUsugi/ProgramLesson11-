using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseManager : MonoBehaviour
{
    List<Iposable> _posable = new();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetPosableObj(Iposable posable)
    {
        _posable.Add(posable);
    }

    public void RemovePosableObj(Iposable posable)
    {
        if (_posable.Contains(posable))
        _posable.Remove(posable);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Time.timeScale = 1;
        }
    }
}
