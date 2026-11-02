

const postdata = async () => {
    const email = document.querySelector(".UserName").value;
    const firstName = document.querySelector(".FirstName").value;
    const password = document.querySelector(".Password").value;
    const lastName = document.querySelector(".LastName").value;
    const isPasswordValid = await passwordCheck();
    if (!isPasswordValid) {
        alert("cant continue with the sign up, your password is weak");
        return;
    }
    const PostUser = {
        email: email, firstname: firstName, lastname: lastName, password: password
    };


    const response = await fetch('api/Users', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(PostUser)
    });
    
    if (response.ok)
    {
        alert("your sign was succsed")
        const postres = await response.json();
    }
    else
    {
        alert ("register error")

    }
    
}
const login = async () => {

    const emaillogin = document.querySelector(".UserNamelogin");
    const passwordlogin = document.querySelector(".Passwordlogin");
    const LoginUser = {
        email: emaillogin.value, password: passwordlogin.value
    };


    const response = await fetch('api/Users/Login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(LoginUser)
    });

    if (response.ok) {
        alert("your login was succsed")
        const postres = await response.json();
        sessionStorage.setItem("CurrentUser", JSON.stringify(postres));
    }
    else {
        alert("login error")

    }


}
const passwordCheck = async () => {
    const UserDetails = [];
    UserDetails[0] = document.querySelector(".UserName").value;
    UserDetails[1] = document.querySelector(".FirstName").value;
    const password = document.querySelector(".Password").value;
    UserDetails[2] = document.querySelector(".LastName").value;
    const result = zxcvbn(password, UserDetails)
    const score = result.score;
    const progressBar = document.querySelector("progress");
    if (progressBar) {
        progressBar.value = score;
    }
    if (score < 2) {
        alert("הסיסמה חלשה מדי! יש להזין סיסמה חזקה יותר ציון נדרש: לפחות 2");
        return false; 
    }

    alert(`חוזק הסיסמה תקין (ציון: ${score})`);
    return true;
}
