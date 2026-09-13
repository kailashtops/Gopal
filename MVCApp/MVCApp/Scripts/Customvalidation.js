    function ValidateInput() {
        var email = document.getElementById("Email").value;
        var add = document.getElementById("Address").value;
        var unm = document.getElementById("UserName").value;
        var pass = document.getElementById("Password").value;
        var str = '';
        if (email == "") {
            str = "Entet Email \n";
        }
        if (add == "") {
            str += "Enter Address \n";
        }
        if (unm == "") {
            str += "Enter UserName \n";
        }
        if (pass == "") {
            str += "Enter PAssword \n";
        }
        if (str != "") {
            alert(str);
        }
        

    }
    function checkLen() {
        var unm = document.getElementById("UserName").value;
        var charcode = event.keyCode;
        if (charcode >= 48 && charcode <= 58) {
            return false;
        }
        else {
            return true;
        }
        //alert(charcode);
       
    }


