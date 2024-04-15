using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    //x轴偏离值
    public float Xoffset;
    //y轴偏离值
    public float Yoffset;

    public int rowIndex = 0;
    public int colIndex = 0;

    int blockType;                          //方格种类，0是粉，1白，2黑
    int formerType;                         //被黑色方块覆盖的棋盘原先方格的颜色

    public GameObject[] blockArray;         //方格数组

    public BlockGameController controller;  //与BlockGameController进行挂接
    private GameObject[] blackBlock;

    private GameObject blocks;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("GameController").GetComponent<BlockGameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePosition(int _rowIndex,int _colIndex)
    {
        rowIndex = _rowIndex;
        colIndex = _colIndex;
        this.transform.position = new Vector3(colIndex * 0.84f + Xoffset , rowIndex * 0.84f  + Yoffset , 0);
    }

    /// <summary>
    /// 棋盘的生成
    /// </summary>
    /// <param name="Ispink"></param>
    /// <param name="IsBlack"></param>
    public void RandomCreateBlocks(bool Ispink)
    {
        if (blocks != null) return;
        if(Ispink) blockType = 0;
        else blockType = 1;

        blocks = Instantiate(blockArray[blockType]) as GameObject;
        //blocks = Instantiate(blockArray[2]) as GameObject;          //生成一个黑色方块

        //Transform black = transform.Find("BlackBlocks(Clone)");     //并将黑色方块设置为false
        //black.gameObject.SetActive(false);
        blocks.transform.parent = this.transform;
        
    }
    /// <summary>
    /// 用于控制黑色方块的生成
    /// </summary>
    public void BlackBlockSpawn()
    {   
        blockType = 2;
        blocks = Instantiate(blockArray[2]) as GameObject;
        blocks.gameObject.SetActive(false);
        blocks.transform.parent = this.transform;
    }

    public void BlackBlockShow()
    {
        Transform black = transform.Find("BlackBlocks(Clone)");
        black.gameObject.SetActive(true);
    }


    public void OnMouseDown()                                           //按下键盘时将是黑色方块的进行SetActive为false
    {
        
        //Debug.Log("block： " + this.GetComponent<Blocks>().blockType);
        
        //Debug.Log("原先棋盘格子类型：" + this.formerType);
        Transform black = transform.Find("BlackBlocks(Clone)");
        if(black != null && black.gameObject.activeSelf)                //如果黑色方块没有被显示则按下会显示找不到对象
        {
            black.gameObject.SetActive(false);
            controller.ClickBlockNum++;                                 //点击方块++
            if(controller.curePercent < 100)
            {
                controller.curePercent += 5;
            }
            
        }
        else
        {
            if(controller.curePercent > 0)
            {
                controller.curePercent -= 5;
            }
            Debug.Log("找不到对象");
        }
            
        //this.gameObject.SetActive(false);
            
            
        
        
    }
}
