<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AngularJS使用.Index" %>

<!DOCTYPE html >

<html  ng-app>
    <head runat="server">
        <title></title>
        <script src="js/angular.js" type="text/javascript"> </script>
        <script type="text/javascript">
            function ActivitiesListCtrl($scope) {
                $scope.activities = [
                    { "name": "Wake up" },
                    { "name": "Brush teeth" },
                    { "name": "Shower" },
                    { "name": "Have breakfast" },
                    { "name": "Go to work" },
                    { "name": "Write a Nettuts article" },
                    { "name": "Go to the gym" },
                    { "name": "Meet friends" },
                    { "name": "Go to bed" }
                ];
            }

        //或者你保存数据在服务器上，我们同样可以使用AJAX获取数据
            /*function ActivitiesListCtrl($scope){
                $http.get('activities/list.json').success(function(data) {
                    $scope.activities = data;
                });
            }*/
        </script>
    </head>
    <body ng-controller="ActivitiesListCtrl">
        <h1>Today's activities</h1>
        <ul>
            <li ng-repeat="activity in activities|orderBy:sortModel">
                {{activity.name}}
            </li>
        </ul>
       
       <%-- 静态的列表显示的很好，但是这里我们希望能够根据用户选择自动排序。这里我们添加一个简单的下拉菜单：--%> 
       <h3>Sort：</h3>
       <select ng-model="sortModel">
       <option value="name">Alphabetically</option>
       </select>
       
       </body>
</html>