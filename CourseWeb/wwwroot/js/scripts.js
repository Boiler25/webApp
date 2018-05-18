    function DeleteBlog(id) {
        var request = new XMLHttpRequest();
        url = "/api/notes/" + id;
        request.open("DELETE", url, false);
        request.send();
        LoadTours();
    }

        function CreateBlog() {
            nText = document.getElementById("inputText").value;
            nUserId = document.getElementById("inputUserId").value;
            if (nText != "") {
                var xmlhttp = new XMLHttpRequest();   // new HttpRequest instance
                xmlhttp.open("POST", "/api/notes/");
                xmlhttp.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
                xmlhttp.send(JSON.stringify({
                    userId: nUserId,
                    text: nText,
                    user: null
                }));
                LoadBlogs();
            }
        }

        function LoadBlogs() {
            var myObj, i, nUserId, x = "";
            nUserId = document.getElementById("inputUserId").value;
            var request = new XMLHttpRequest();
            request.open("GET", "/api/notes/", false);
            request.send();

            myObj = JSON.parse(request.responseText);
            var x = "";
            for (i in myObj) {
                x += "<div class=\"noteRow\">";
                x += "<p>" + GetUserName(nUserId) + "</p>";
                x += "<h4> " + myObj[i].text + "</h4>";
                x += "<button type=\"button\" onclick=\"DeleteBlog(" + myObj[i].id + ")\">Удалить</button>"
                x += "</div>"
            }
            document.getElementById("blogsDiv").innerHTML = x;
        }

        function GetUserName(idOfUser) {
            var myObj, i, j, x = "";
            var request = new XMLHttpRequest();
            request.open("GET", "/api/users/" + idOfUser, false);
            request.send();

            myObj = JSON.parse(request.responseText);
            var x = myObj.login;

            return x;
        }
        window.setInterval(LoadBlogs, 5000);