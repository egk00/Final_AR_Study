using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    public void DestroyObj()
    {
        Destroy(this.gameObject);//Game Object Attched to this script will be destroyed 
    }
    public void OnTriggerEnter(Collider other)
    {
        for (int x = 0; x < SaveLoad.Instance.Obstacles.Count; x++)
        {
            if (other.gameObject.tag == SaveLoad.Instance.Obstacles[x].type.ToString())//this will check aany game object tag.  if that tag has a shape obstacle tag it will be destroyed. 
            {
                Destroy(other.gameObject);// animate 
            }
        }
        if (other.gameObject.tag == "ground")
        {
            //Destroy(other.gameObject);// to use this line of code the follow two lines should be commented off  
            other.gameObject.GetComponent<Animator>().SetTrigger("delete");// this animation will scale ground down and then then call the "DestroyObj" mehtod to destroy the ground when animation is done 
            InfiniteGameObjManager.Instance.ActiveGround(1, false);// this method is being called to subtract 1 from the active ground amount; 
        }
        if (other.gameObject.tag == "Collectible")//just in case a collectible is missed 
        {
            Destroy(other.gameObject);//animate
        }
    }
}
