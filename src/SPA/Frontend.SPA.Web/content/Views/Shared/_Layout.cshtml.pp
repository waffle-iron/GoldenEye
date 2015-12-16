﻿@using System.Web.Mvc.Html
@using System.Web.Optimization
@using System.Web.Mvc
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - Tasks Management</title>
    <base href='@(Request.ApplicationPath.Length == 1 ? Request.ApplicationPath : Request.ApplicationPath + "/")' />
    @Styles.Render("~/Content/css")

    <link href="~/Content/toastr.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="~/Content/misc.css">
    @Scripts.Render("~/bundles/modernizr")
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/knockout")
    @Scripts.Render("~/bundles/libs")
    @Scripts.Render("~/bundles/app")
</head>

<body>
    <div id="viewContainer">
        <div class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    @Html.ActionLink("Tasks Management", "Index", "Home", new { area = "" }, new { @class = "navbar-brand" })
                </div>
                <div class="navbar-collapse collapse">
                    <!-- ko component: "TopMenu-nc" -->
                    <!-- /ko -->
                    <!-- ko component: "LoginTopMenu" -->
                    <!-- /ko -->
                </div>
            </div>
        </div>
        <div class="container body-content">
            @RenderBody()
            <hr />
            <footer>
                <p>&copy; @DateTime.Now.Year - Author</p>
            </footer>
        </div>
    </div>

    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required: false)
</body>
</html>
