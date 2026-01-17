document.addEventListener('DOMContentLoaded', function() {
    //Кнопка в навбаре в мобильной версии открывает меню
    const menuToggle = document.querySelector('.menu-toggle');
    const navRight = document.querySelector('.nav-right');
            
    if (menuToggle && navRight) {
        menuToggle.addEventListener('click', function() {
            navRight.classList.toggle('active');
            menuToggle.textContent = navRight.classList.contains('active') ? '✕' : '☰';
        });
            // Закрыть меню при нажатии на ссылку
        document.querySelectorAll('.nav-right a').forEach(link => {
            link.addEventListener('click', function() {
                navRight.classList.remove('active');
                menuToggle.textContent = '☰';
            });
        });
    }   


    //Вывод имени пользователя
    let username = localStorage.getItem("username");
    console.log(username);
    if(!username) {
        username = "User";
    };
    const userPlace = document.querySelector("#username");
    if(userPlace) {
        userPlace.textContent = username;
        userPlace.addEventListener("click", function() {
            const splash = document.querySelector(".splashscreen");
            splash.classList.remove("invisible");
            const userCall = document.querySelector("#usercall");
            userCall.textContent = "Привет, " + username + "!";                             //Приветствие
        });
        document.querySelector("#save-username").addEventListener("click", function() {
            const newUsername = document.querySelector("#username-input").value;
            console.log(newUsername);
            if(newUsername) {
                username = newUsername;
                localStorage.setItem("username", username);
                document.querySelector("#username").textContent = newUsername;              //Сохранение нового имени
            }
        });
        let testRes = localStorage.getItem("testres");
        console.log(testRes);
        if(!testRes){
            testRes = 0;
        }
        document.querySelector("#testRes").textContent="Результат теста: " + testRes;       //Значение результата теста
    }

    // Закрытие диалогового окна
    const closeButton = document.querySelector("#close-dialog");
    if(closeButton) {
        closeButton.addEventListener("click", function() {
            document.querySelector(".splashscreen").classList.add("invisible");
        });
    }

    // Смена темы
    const themeSwitch = document.querySelector("#theme");
    let dark = localStorage.getItem("darkswitch");
    let currTheme;
    if(themeSwitch) {
        if(!dark){
            dark = (window.matchMedia('(prefers-color-scheme: dark)').matches ? 'true' : 'false');
            if (!dark){
                themeSwitch.textContent = "🌚";
                currTheme = 'light'
            } else {
            themeSwitch.textContent = "🌞";
            currTheme = 'dark';
            };
        } else {
            themeSwitch.textContent = "🌞";
            currTheme = 'dark';
        };
    };
    document.documentElement.setAttribute('data-theme', currTheme);
    document.querySelector("#theme").addEventListener('click', () => {
        currTheme = currTheme === 'dark' ? 'light' : 'dark';
        document.documentElement.setAttribute('data-theme', currTheme);
        localStorage.setItem('darkswitch', currTheme === 'dark' ? true : false);
        themeSwitch.textContent = currTheme === 'dark' ? '🌞' : '🌚';    
    });

});





