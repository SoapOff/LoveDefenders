using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDown : MonoBehaviour
{
    public AddRoom addRoom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown() {
        addRoom.SalleFini();
    }
    public void Destroy(){
        this.GetComponent<SpriteRenderer>().enabled=false;
    }
}
