# BlockMonitor
[中文](#zh) [English](#en)

<a name="zh"></a>

NEO 区块监控程序

该仓库中有两个项目，BlockMonitor 和 BlockMonitor-WPF，前者是 .NET Core 框架的跨平台程序，后者是 Windows 窗口程序。两个项目的使用方式和配置文件是一样的。

程序逻辑：

程序每 5 分钟遍历种子节点的区块高度，取最大值，认为是当前区块高度，然后记录下当前时间和区块高度，将当前高度和上次高度进行对比，从而得知这段时间内系统是否正常出块。如果出块变慢或者停止出块则发邮件报警或者电话报警。

配置文件：

在 config.josn 文件中配置邮件账号密码、语音呼叫的账号、呼叫列表、邮件列表等信息

```
{
    "nodes":[
        "https://seed1.neo.org:10331",
        "http://seed2.neo.org:10332",
        "http://seed3.neo.org:10332",
        "http://seed4.neo.org:10332",
        "http://seed5.neo.org:10332"
    ],
    "email":{ //这里设置正确的邮件名和密码，仅限 hotmail 和 exchange 邮箱
        "username": "chris@neo.org",
        "password": "12345678" 
    },
    "yuntongxun":{ //这里设置云通讯的配置，详见 https://www.yuntongxun.com/
        "ACCOUNT SID": "",
        "AUTH TOKEN": "",
        "AppID": ""
    },
    "call":[ //这里设置管理员的电话号码列表
        "18612345678"
    ],
    "contact":[ //这里设置管理员的邮箱列表
        "chris@neo.org",
        "contact@neo.org"
    ]
}
```

如果想修改邮件和语音通知的内容，需要修改代码。

<a name="en"></a>

NEO Block Monitor Program

There are two projects in the repository, BlockMonitor and BlockMonitor-WPF, the first is cross-platform programs base on .NET Core, the second is a Windows program. Two projects have the same usage method and the same configuration file.

Program logic:

The program traverses the seed node's block height every 5 minutes, takes the maximum value, so it is the current block height, then records the current time and the block height, compares the current height to the last height, and then knows whether the system is properly generates block during this time. If it generates block slows or stops generating the block then send an email to admin or call admin.

Configuration file:

Configure e-mail account password, voice call account number, call list, mailing list, etc. in the config.josn file.

```
{
    "nodes":[
        "https://seed1.neo.org:10331",
        "http://seed2.neo.org:10332",
        "http://seed3.neo.org:10332",
        "http://seed4.neo.org:10332",
        "http://seed5.neo.org:10332"
    ],
    "email":{ //Set the correct message name and password here for Hotmail and Exchange mailboxes only
        "username": "chris@neo.org",
        "password": "12345678" 
    },
    "yuntongxun":{ //Set the configuration of yuntongxun here, see https://www.yuntongxun.com/
        "ACCOUNT SID": "",
        "AUTH TOKEN": "",
        "AppID": ""
    },
    "call":[ //Set the phone number list of admin
        "18612345678"
    ],
    "contact":[ //Set the email list of admin
        "chris@neo.org",
        "contact@neo.org"
    ]
}
```

If you want to modify the contents of the e-mail and voice notification, you need to modify the code.
