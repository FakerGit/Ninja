using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using cn.bmob.api;
using cn.bmob.io;

using cn.bmob.tools;
using System.Net;
public class ScoreRank : BmobTable {

    //玩家名
    public string playerName { get; set; }

    //游戏分数
    public BmobInt score { get; set; }

    public override void readFields(BmobInput input)
    {
        base.readFields(input);
        //读取属性值
        this.playerName=input.getString("playerName");
        this.score = input.getInt("score");
    }

    public override void write(BmobOutput output, bool all)
    {
        base.write(output, all);
        //写到发送端
        output.Put("playerName", this.playerName);
        output.Put("score", this.score);
    }
	
}
