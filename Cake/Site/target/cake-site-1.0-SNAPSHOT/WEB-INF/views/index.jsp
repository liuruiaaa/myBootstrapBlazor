<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt" %>
<html>
<head>
	<title>Home</title>
	<!-- Custom Theme files -->
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta name="keywords" content="" />
	<script type="application/x-javascript">
		addEventListener("load", function() {
		  setTimeout(hideURLbar, 0); }, false);
		  function hideURLbar(){ window.scrollTo(0,1); }
	</script>
	<!-- //Custom Theme files -->
	<link href="../../../css/bootstrap.css" type="text/css" rel="stylesheet" media="all">
	<link href="../../../css/style.css" type="text/css" rel="stylesheet" media="all">
	<!-- js -->
	<script src="../../../js/jquery.min.js"></script>
	<script type="text/javascript" src="../../../js/bootstrap-3.1.1.min.js"></script>
	<!-- //js -->
	<!-- cart -->
	<script src="../../../js/simpleCart.min.js"> </script>
	<!-- cart -->
	<script type="text/javascript">
        function submitMessageForm(flag) {
            if ('first' === flag) {
                document.getElementById('page').value = 1;
            } else if ('pre' === flag) {
                var current = Number(document.getElementById('page').value);
                if (current > 1) {
                    document.getElementById('page').value = current - 1;
                }
            } else if ('next' === flag) {
                var current = Number(document.getElementById('page').value);
                var last = Number(document.getElementById('last').value);
                if (current < last) {
                    document.getElementById('page').value = current + 1;
                }
            } else if ('last' === flag) {
                var last = Number(document.getElementById('last').value);
                document.getElementById('page').value = last < 1 ? 1 : last;
            }
            document.getElementById('cakeForm').submit();
        }
	</script>
</head>
<body>
	<!--header-->
	<div class="header">
		<div class="container">
			<nav class="navbar navbar-default" role="navigation">
				<div class="navbar-header">
					<button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
						<span class="sr-only">Toggle navigation</span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
					</button>
					<h1 class="navbar-brand"><a  href="/cake/list.do">IMOOC</a></h1>
				</div>
				<!--navbar-header-->
				<div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
					<ul class="nav navbar-nav">
						<li><a href="/cake/list.do" class="active">首页</a></li>
						<c:forEach var="item" items="${categories}">
							<li class="dropdown">
								<a href="/cake/list.do?categoryId=${item.id}">${item.name}</a>
							</li>
						</c:forEach>
					</ul>
				</div>
			</nav>
			<div class="header-info">
				<div class="header-right search-box">
					<a href="#"><span class="glyphicon glyphicon-search" aria-hidden="true"></span></a>				
					<div class="search">
						<form class="navbar-form">
							<input type="text" class="form-control">
							<button type="submit" class="btn btn-default" aria-label="Left Align">
								搜
							</button>
						</form>
					</div>	
				</div>
				<div class="header-right login">
					<a href="#"><span class="glyphicon glyphicon-user" aria-hidden="true"></span></a>
					<div id="loginBox">                
						<form id="loginForm">
							<fieldset id="body">
								<fieldset>
									<label for="email">Email</label>
									<input type="text" name="email" id="email">
								</fieldset>
								<fieldset>
									<label for="password">Password</label>
									<input type="password" name="password" id="password">
								</fieldset>
								<input type="submit" id="login" value="登录">
								<label for="checkbox"><input type="checkbox" id="checkbox"> <i>记住</i></label>
							</fieldset>
							<p>新用户 ? <a class="sign" href="account.html">注册</a><span><a href="#">忘记密码?</a></span></p>
						</form>
					</div>
				</div>
				<div class="header-right cart">
					<a href="#"><span class="glyphicon glyphicon-shopping-cart" aria-hidden="true"></span></a>
					<div class="cart-box">
						<h4><a href="checkout.html">
							<span class="simpleCart_total"> $0.00 </span> (<span id="simpleCart_quantity" class="simpleCart_quantity"> 0 </span>) 
						</a></h4>
						<p><a href="javascript:;" class="simpleCart_empty">空</a></p>
						<div class="clearfix"> </div>
					</div>
				</div>
				<div class="clearfix"> </div>
			</div>
			<div class="clearfix"> </div>
		</div>
	</div>
	<!--//header-->
	<!--banner-->
	<div class="banner">
		<div class="container">
			<h2 class="hdng">IMOOC <span>蛋糕</span></h2>
			<p>特别的日子，特别的你</p>
			<a href="#">SHOP NOW</a>
			<div class="banner-text">			
				<img src="../../../images/2.png" alt=""/>
			</div>
		</div>
	</div>			
	<!--//banner-->
	<!--gallery-->
	<div class="gallery">
		<div class="container">
			<div class="gallery-grids">
				<c:forEach items="${cakes}" var="cake">
					<div class="col-md-3 gallery-grid ">
						<a href="#">
								<img src="/cake/getImg.do?id=${cake.id}" class="img-responsive" alt=""/>
							<div class="gallery-info">
								<p><span class="glyphicon glyphicon-eye-open" aria-hidden="true"></span> view</p>
								<a class="shop" href="single.html">SHOP NOW</a>
								<div class="clearfix"> </div>
							</div>
						</a>
						<div class="galy-info">
							<p>${cake.name}</p>
							<div class="galry">
								<div class="prices">
									<h5 class="item_price">￥<fmt:formatNumber type="currency" pattern="#,#00.00#" value="${cake.price / 100}"/></h5>
								</div>
								<div class="rating">${cake.level}
									<span>☆</span>
									<span>☆</span>
									<span>☆</span>
									<span>☆</span>
									<span>☆</span>
								</div>
								<div class="clearfix"></div>
							</div>
						</div>
					</div>
				</c:forEach>
			</div>

		</div>
		<div align="right">
			<form id="cakeForm" action="/cake/list.do" method="post">
				<input type="hidden" id="page" name="page" value="${page}">
				<input type="hidden" id="last" name="last" value="${last}">
				<input type="hidden" id="categoryId" name="categoryId" value="${categoryId}">
				<ul class="pagination">
					<li><a href="javascript:void(0)" onclick="submitMessageForm('first')">首页</a></li>
					<li><a href="javascript:void(0)" onclick="submitMessageForm('pre')">上一页</a></li>
					<li><a href="javascript:void(0)">当前第${page}页</a></li>
					<li><a href="javascript:void(0)" onclick="submitMessageForm('next')">下一页</a></li>
					<li><a href="javascript:void(0)" onclick="submitMessageForm('last')">尾页</a></li>
				</ul>
			</form>
		</div>
	</div>
	<!--//gallery-->
	<!--subscribe-->
	<!--//subscribe-->
	<!--footer-->
	<!--//footer-->
	<div class="footer-bottom">
		<div class="container">
			<p>Copyright © 2017 imooc.com All Rights Reserved | 京ICP备 13046642号-2</p>
		</div>
	</div>
</body>
</html>