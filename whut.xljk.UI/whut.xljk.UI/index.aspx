<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="EmptyProjectNet45_FineUI.index" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>武汉理工大学心理健康教育网站</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/p0_index.css" rel="stylesheet" type="text/css">
    <link href="css/common/reset.css" rel="stylesheet" type="text/css">
    <link href="css/common/common.css" rel="stylesheet" type="text/css">
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="//cdn.bootcss.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="//cdn.bootcss.com/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <!--[if IE 6]>
        <script type="text/javascript">
            alert("你使用的是IE6浏览器，这是IE的过期版本，是时候该升级了！");
        </script>
        <![endif]-->
    <!--[if lte IE 7]>
        <script type="text/javascript">
            alert("你使用的是IE7浏览器，这是IE的过期版本，是时候该升级了！");
        </script>
        <![endif]-->
    <style type="text/css">
        .button{
	width:24vw;
	height:23vw;
	float:right;
	background-color:rgba(225,225,225,0.2);
	border-radius:0.3vw;
	box-shadow:0vw 0vw 0.06vw 0vw #838383;
	}
.button img{
	width:16.5vw;
	height:auto;
	margin:3vw auto;
	display:block;
	}
 .carousel-indicators li {
     width:0.8vw;
     height:0.8vw;
     margin:0.06vw;
        }
        .carousel-indicators .active {
        width:1vw;
        height:1vw;
        }
    </style>
</head>

<body style="background-image: url(images/background.png);">

    <!--#include file="head.html"-->

    <!--------------------------------------数据显示部分----------------------------------------------->

    <div class="main" style="height:auto">
                <!--轮播图-->
                <div id="carousel-example-generic" class="carousel slide zxzl-carousel" data-ride="carousel">
                    <!-- Indicators -->              
                    <ol class="carousel-indicators">                     
                        <li  data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                        <li  data-target="#carousel-example-generic" data-slide-to="1"></li>
                        <li  data-target="#carousel-example-generic" data-slide-to="2"></li>
                        <li  data-target="#carousel-example-generic" data-slide-to="3"></li>
                    </ol>
                    
                    <!-- Wrapper for slides -->
                    <div class="carousel-inner" role="listbox">
                        <%=PreImg %>
                    </div>
                    <!-- Controls -->
                    <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev"></a>
                    <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next"></a>

                </div>

            <!--首页轮播图右侧的三个按钮 各个页面通用-->
    <!--#include file="imghref.html"-->

        <!--中心动态 2-->
        <div class="p0_news">
            <img src="images/xinwenIcon.png" class="newstittle" style="width: 7vw; height: auto">
            <hr style="border: 0.03vw solid gray;margin-top:0.7vw;margin-bottom:0.7vw;">
            <img src="images/centermain.png" style="display: block; width: 4vw;">
            <p style="color: #33d49d; margin-left: 44vw; cursor: pointer; font-size: 1.2vw;">more></p>
            <div class="newsleft">
                <%=xwdt_toutiao %>
            </div>

            <a href="articleList.aspx?articleCategory=2">
                
            </a>

            <!--心协动态 3-->
            <img src="images/xinxie.png" style="display: block; clear: left; width: 4vw;">
             <p style="color: #33d49d; margin-left: 44vw; cursor: pointer; font-size: 1.2vw;">more></p>
            
            <div class="xinxiecontent">
                <%=xinxie_toutiao%>
            </div>

            <a href="articleList.aspx?articleCategory=3">
               </a>
        </div>



        <!--问答案例 动态的，需要换文字-->
        <div class="p0_qa">
            <!--首页问答-->
            <img src="images/wendaIcon.png" style="width: 7vw; height: auto">
            <hr style="margin-top:0.8vw;margin-bottom:0.7vw;border-top: 0.06vw solid gray;">
            <p>
                <img src="images/wen.png">&nbsp;好方啊，大学好迷茫。。
           
            </p>
            <p>
                <img src="images/da.png">&nbsp;同学你好，美好的大学在向你招手，只要...
           
            </p>
            <p>
                <img src="images/wen.png">&nbsp;好方啊，大学好迷茫。。
           
            </p>
            <hr style="margin-top: 2vw;">
        </div>


        <!--心理美文 5-->
        <div class="p0_essay">
            <img src="images/xinliIcon.png" style="width: 7vw; height: auto;margin:1vw 0vw 0vw 2vw;">
            <hr style="margin:0.6vw auto 1vw; border: 0.03vw solid gray;width:73.5vw;">

            <div class="grid">
                <%=preMeiwen %>
            </div>

            <a href="articleList.aspx?articleCategory=5">
                <p style="color: #33d49d; cursor: pointer; font-size: 1.2vw; text-align: right">more></p>
            </a>

        </div>
    </div>


    <!--------------------------------------数据显示部分----------------------------------------------->
    <!--#include file="foot.html"-->

    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="js/jquery-1.9.1.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
    <script src="js/classie.js"></script>

</body>
</html>
