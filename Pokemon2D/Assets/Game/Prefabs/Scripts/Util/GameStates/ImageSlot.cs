
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSlot : MonoBehaviour
{

    [SerializeField] Image bgImage;

    private void Awake()
    {
        bgImage= GetComponent<Image>();
    }
    public void Clear()
    {
        throw new System.NotImplementedException();
    }

    public void Init()
    {
        throw new System.NotImplementedException();
    }

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
