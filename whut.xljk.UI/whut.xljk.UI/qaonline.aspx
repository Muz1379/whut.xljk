<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qaonline.aspx.cs" Inherits="EmptyProjectNet45_FineUI.qaonline" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>在线问答</title>
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/p5_qaonline.css" rel="stylesheet" type="text/css">
    <link href="css/common/reset.css" rel="stylesheet" type="text/css">
    <link href="css/common/common.css" rel="stylesheet" type="text/css">
</head>

<body>

    <!--#include file="head.html"-->
    
    <div style="height:1000px;">
    <form class="form-horizontal" role="form" runat="server">
        <!--首页主体部分 首页编码为p0-->
        <div class="main">
            <div class="p5_main">
                <img src="images/qaonline_icon.png" style="width: 9.5vw; height: auto;">
                <hr>
                <center><h1>在线咨询</h1></center>
                <p>
                    同学你好，这里是武汉理工大学心理健康教育中心的在线问答版块<br>
                    你可以在这里向我们的咨询师们倾诉你的问题，我们将尽力解答<br>
                    请同学在留言时，留下你的email或者QQ号或者手机号方便联系<br>
                    我们对这些信息将会严格保密。你的留言以及咨询师的回复将会向大家展示<br>
                    如果有需要请点击右上角粉色的在线预约按钮。预约到中心进行当面心理咨询<br>
                </p>

                <div id="contentform" style="display:none;">

                    <div class="form-group">
                        <label for="txb_NickName" class="col-sm-2 control-label">昵称</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txb_NickName" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txb_Grade" class="col-sm-2 control-label">年级</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txb_Grade" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="rbl_Sex" class="col-sm-2 control-label">性别</label>
                        <div class="col-sm-10">
                            <asp:RadioButtonList ID="rbl_Sex" runat="server">
                                <asp:ListItem Text="男" Value="1" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="女" Value="0"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>


                    <div class="form-group">
                        <label for="txb_Email" class="col-sm-2 control-label">邮箱</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txb_Email" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="ddl_TeacherName" class="col-sm-2 control-label">咨询老师</label>
                        <div class="col-sm-10">
                            <asp:DropDownList ID="ddl_TeacherName" runat="server" class="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txb_BriefQuestion" class="col-sm-2 control-label">问题简介</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txb_BriefQuestion" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txb_DetailQuestion" class="col-sm-2 control-label">详情咨询</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txb_DetailQuestion" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="rbl_Reference" class="col-sm-2 control-label">是否愿意将您的问题供其他同学参考？</label>
                        <div class="col-sm-10">
                            <asp:RadioButtonList ID="rbl_Reference" runat="server" RepeatDirection="Vertical">
                                <asp:ListItem Text="是" Value="1" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="否" Value="0"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <div class="btn-group">
                        <asp:Button ID="btn_Submit"  class="form-control" runat="server" Text="提交" CssClass="iwantq" OnClick="btn_Submit_Click"/>
                    </div>



                </div>

                <div class="btn-group">
                    <input type="button" id="iwantq" onclick="showtext()" class="btn btn-default" value="我要留言">
                </div>

                <script type="text/javascript">
                    var i = 1;
                    function showtext() {
                        var shide = document.getElementById("contentform");
                        var changevalue = document.getElementById("iwantq");
                        if (i % 2 == 1) {
                            shide.style.display = 'block';
                            changevalue.value = "收起";
                        }
                        if (i % 2 == 0) {
                            shide.style.display = 'none';
                            changevalue.value = "我要留言";
                        }
                        i++;
                    }
                </script>


                <div class="tags">
                    <a href="qaonline.aspx?category=1">
                        <img src="images/tags_1.png" class="tags_1"></a>
                    <a href="qaonline.aspx?category=2">
                        <img src="images/tags_2.png" class="tags_2"></a>
                    <a href="qaonline.aspx?category=3">
                        <img src="images/tags_3.png" class="tags_3"></a>
                    <a href="qaonline.aspx?category=4">
                        <img src="images/tags_4.png" class="tags_4"></a>
                    <a href="qaonline.aspx?category=5">
                        <img src="images/tags_5.png" class="tags_5"></a>
                    <a href="qaonline.aspx?category=6">
                        <img src="images/tags_6.png" class="tags_6"></a>
                    <a href="qaonline.aspx?category=7">
                        <img src="images/tags_7.png" class="tags_7"></a>
                    <a href="qaonline.aspx?category=8">
                        <img src="images/tags_8.png" class="tags_8"></a>
                    <a href="qaonline.aspx?category=9">
                        <img src="images/tags_9.png" class="tags_9"></a>
                    <a href="qaonline.aspx?category=10">
                        <img src="images/tags_10.png" class="tags_10"></a>
                </div>
                <%=MessageList %>
                <!--页面切换-->
                <div><%=NavHtml %></div>
                <!--页面切换-->
            </div>

            <!--首页轮播图右侧的三个按钮 各个页面通用-->
    <!--#include file="imghref.html"-->

        </div>

    </form>

    </div>

    <!--------------------------------------数据显示部分----------------------------------------------->
    <!--#include file="foot.html"-->

</body>
</html>
