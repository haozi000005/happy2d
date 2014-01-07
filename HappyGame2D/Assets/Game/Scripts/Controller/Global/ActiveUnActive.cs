using UnityEngine;
using System.Collections;

public class ActiveUnActive : MonoBehaviour
{
    /// <summary>
    /// 要激活的对象
    /// </summary>
    public GameObject[] Actives;

    /// <summary>
    /// 要关闭的对象
    /// </summary>
    public GameObject[] UnActives;

    /// <summary>
    /// 需要重置的对象
    /// </summary>
    public GameObject[] ReSetObjs;

    /// <summary>
    /// 需要添加的对象
    /// </summary>
    public GameObject[] AddObjs;

    /// <summary>
    /// 需要销毁的对象
    /// </summary>
    public GameObject[] DestoryObjs;

    /// <summary>
    /// 打开要激活的，关闭不要的
    /// </summary>
    public void OpenAndClose()
    {
        //打开
        foreach (GameObject active in Actives)
        {
            active.SetActive(true);
        }

        //关闭
        foreach (GameObject unActive in UnActives)
        {
            unActive.SetActive(false);
        }

        //重置
        foreach (GameObject reSetObj in ReSetObjs)
        {
            reSetObj.SendMessage("ReSetInfo",SendMessageOptions.DontRequireReceiver);
        }

        //添加
        foreach (GameObject addObj in AddObjs)
        {
            Instantiate(addObj);
        }

        //销毁
        foreach (GameObject destoryObj in DestoryObjs)
        {
            Destroy(destoryObj);
        }
    }
}
