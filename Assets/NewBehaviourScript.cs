using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    // Update is called once per frame
    public Text mText;
    public string prefabname;
    public RectTransform root;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mText.text = "Kun";
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            GameObject prefab = Resources.Load<GameObject>(prefabname);
            GameObject newobj = GameObject.Instantiate(prefab, root.transform);
        }
    }
}
