using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlockGameController : MonoBehaviour
{
    public Blocks blocks;               //与每一格的Blocks脚本进行挂接

    [Header("BOARDSPAWN")]
    public int rowNum = 16;             //棋盘行数                
    public int colNum = 16;             //棋盘列数
    public int blackBlockRemain = 4;    //黑色格子生成剩余数
    public int blackBlockProbability;   //黑色格子生成几率
    public int Probability = 5;         //生成几率

    [Header("GAMECONTROL")]
    public int gameRound = 4;           //游戏轮数
    public int curePercent = 0;      //治疗进度百分比
    public int ClickBlockNum;           //目前已点方块数
    public TMP_Text cureProcess;        //治疗进度

    ArrayList blockList;                //存格子的动态数组
    Blocks[] BlocksStorge;

    private bool Ispink;                //是否是粉格子


    // Start is called before the first frame update
    void Start()
    {
        blockList = new ArrayList();    //初始化
        BlocksStorge = new Blocks[rowNum * colNum];
        
        int i = 0;

        for(int rowIndex = 0; rowIndex < rowNum; rowIndex++)
        {
            
            ArrayList temp = new ArrayList();
            if (rowIndex % 2 == 0) Ispink = true;
            else Ispink = false;

            for (int colIndex = 0; colIndex < colNum; colIndex++)
            {
                
                Blocks b = AddBlocks(rowIndex,colIndex);
                BlocksStorge[i] = b;
                Debug.Log("第" + i + "个元素已经存入BlocksStorge");
                temp.Add(b);
                i++;
                
            }
            
            blockList.Add(temp);        //一行的所有元素存进temp后再存进

        }
        Debug.Log("目前BlocksStorge里的元素个数为" + BlocksStorge.Length);

    }
    /// <summary>
    /// 棋盘生成
    /// </summary>
    /// <param name="_rowIndex"></param>
    /// <param name="_colIndex"></param>
    /// <returns></returns>
    public Blocks AddBlocks(int _rowIndex,int _colIndex)
    {
        //棋盘生成
        Blocks b = Instantiate(blocks) as Blocks;
        b.transform.parent = this.transform;

        b.GetComponent<Blocks>().RandomCreateBlocks(Ispink);
        
        Ispink = !Ispink;

        b.GetComponent<Blocks>().BlackBlockSpawn();             //先把所有的黑色方块生成

        RandomAddBlackBlocks(_rowIndex, _colIndex,b);

        b.GetComponent<Blocks>().UpdatePosition(_rowIndex, _colIndex);

        
        return b;
    }

    /// <summary>
    /// 黑色方块生成
    /// </summary>
    /// <param name="_rowIndex"></param>
    /// <param name="_colIndex"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public void RandomAddBlackBlocks(int _rowIndex,int _colIndex,Blocks b)
    {
        //问题：因为生成概率低，有可能出现一个棋盘上生成少于4个黑色方块的情况
        Mathf.Clamp(blackBlockRemain, 0, 4);
        blackBlockProbability = Random.Range(0, 100);           //随机生成黑色方块概率
        if (blackBlockRemain > 0 && blackBlockProbability < Probability)
        {
            if (rowNum - _rowIndex == 5) Probability = 20;
            //b.GetComponent<Blocks>().BlackBlockController();
            //b.GetComponent<Blocks>().UpdatePosition(_rowIndex,_colIndex);
            b.GetComponent<Blocks>().BlackBlockShow();
            blackBlockRemain--;
            Debug.Log(blackBlockRemain);
        }

        //b.GetComponent<Blocks>().UpdatePosition(_rowIndex, _colIndex);

    }

    public void Erase(Blocks b)
    {
        Destroy(b.gameObject);
    }

    // Update is called once per frame
    // 问题：现在无法获取原先生成的blocks(Clone)里的方块信息导致每一次四个消除之后会再重新Instantiate一个棋盘导致
    // 在按下鼠标之后controller获取不到黑色方块进而无法删除
    void Update()
    {
        Mathf.Clamp(curePercent, 0, 100);
        if (ClickBlockNum == 4)
        {
            ClickBlockNum = 0;
            blackBlockRemain = 4;
            
            for(int i = 0;i < BlocksStorge.Length;i++)
            {
                Blocks b = BlocksStorge[i];
                if(b != null)
                {
                    RandomAddBlackBlocks(b.GetComponent<Blocks>().rowIndex, b.GetComponent<Blocks>().colIndex, b);
                }
                else
                {
                    Debug.LogError("BlocksStorge" + i + "找不到对象");
                }
                
                
            }

        }
        cureProcess.text = curePercent.ToString();

        if(curePercent == 100)
        {
            ProcessController.Instance.GoNextScene();
        }
    }


}
