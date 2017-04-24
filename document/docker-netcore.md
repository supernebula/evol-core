# Docker管理命令
*前提，已经安装了操作系统，并安装了docker*

docker 基本命令划分：


容器生命周期管理 — `docker [run|start|stop|restart|kill|rm|pause|unpause]`

容器操作运维 — `docker [ps|inspect|top|attach|events|logs|wait|export|port]`

容器rootfs命令 — `docker [commit|cp|diff]`

镜像仓库 — `docker [login|pull|push|search]`

本地镜像管理 — `docker [images|rmi|tag|build|history|save|import]`

其他命令 — `docker [info|version]`

![Docker变迁图](/images/docker_cli_stage.png)

# 命令说明

1. 从docker registry server 中下拉image或repository（pull）


   Usage: `docker pull [OPTIONS] NAME[:TAG]`

   例如：`# docker pull microsoft/dotnet`  


2. 列出机器上的镜像（images）
```ruby
# docker images 
REPOSITORY              TAG         IMAGE ID       CREATED         VIRTUAL SIZE
microsoft/dotnet        last        2185fd50e2ca    13 days ago     236.9 MB
…
```

3. 在docker index中搜索image（search）
```ruby
# docker search micro
NAME                DESCRIPTION           STARS     OFFICIAL   AUTOMATED
microsoft/dotnet   sean's docker repos         0
```

