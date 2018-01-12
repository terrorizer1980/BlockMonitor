# BlockMonitor
NEO区块监控程序

配置：

在 lockMonitor\BlockMonitor\Tools.cs 文件中设置发送报警邮件的发件人和用户名、密码

在 nodes.txt 中设置监控节点

在 contact.txt 中设置接受报警邮件的邮箱列表

程序每5分钟检测一次出块状态，如果出块变慢或者停止出块则发邮件报警
