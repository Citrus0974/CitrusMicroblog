document.addEventListener('DOMContentLoaded', function() {
    const questions = [
        {
            question: "Какой оператор используется для строгого сравнения значения и типа данных?",
            options: ["==", "===", "=", "!="],
            correctAnswer: 1
        },
        {
            question: "Какое ключевое слово используется для объявления переменной в современном JavaScript?",
            options: ["var", "let", "const", "new"],
            correctAnswer: 1
        },
        {
            question: "Какой метод используется для округления числа до ближайшего целого?",
            options: ["floor", "ceil", "round", "trunc"],
            correctAnswer: 2
        },
        {
            question: "Как называется тип данных, представляющий логические значения?",
            options: ["string", "number", "object", "boolean"],
            correctAnswer: 3
        },
        {
            question:  "Какой метод возвращает длину строки?",
            options: ["size", "lenght", "count", "index"],
            correctAnswer: 1
        },
        {
            question:  "Как объявляется неизменяемая величина?",
            options: ["var", "let", "const", "index"],
            correctAnswer: 2
        },
        {
            question: "Какой метод добавляет элемент в конец массива?",
            options: ["unshift", "push", "pop", "shift"],
            correctAnswer: 1
        },
        {
            question:  "Какой метод добавляет элемент в начало массива?",
            options: ["unshift", "push", "pop", "shift"],
            correctAnswer: 0
        },
        {
            question: "Сколько типов данных в языке JavaScript?",
            options: ["5", "6", "7", "8"],
            correctAnswer: 3
        },
        {
            question: "Какой метод задаёт таймер перед выполнением операций?",
            options: ["setInterval", "setTimeout", "clearTimeout", "clearInterval"],
            correctAnswer: 1
        }
        ];

    const qContainer = document.querySelector(".question-container");
    let currQuestion = 0;
    let score = 0;
    let currAnswers = [];
    
    showQuestion(); //Первый вопрос


    function showQuestion(){
        if (currQuestion >= questions.length){
            showResults();                          //Если вопрос последний - вывод результата
            return;
        }
        let q = questions[currQuestion]
        let qDiv = document.createElement("div");           //Блок для вопросов
        qDiv.className = 'question';
        qDiv.dataset.questionIndex = currQuestion;          //Задаёт номер вопроса в значение атрибута
        
        const questionTitle = document.createElement('h3');
        questionTitle.textContent = q.question;

        const optionsDiv = document.createElement('div');
        optionsDiv.className = 'options';
        q.options.forEach((option, idx) => {                //Создание элементов для вариатов ответа
            const label = document.createElement('label');
            const radio = document.createElement('input');
            radio.type = 'radio';
            radio.name = `answer-${currQuestion}`;
            radio.value = idx;
            label.appendChild(radio);
            label.append(document.createTextNode(option));
            optionsDiv.appendChild(label);
        });
        const submitButton = document.createElement('button');      //Кнопка отправить
        submitButton.textContent = 'Ответить';
        submitButton.className = 'submit-answer';
        const resultDiv = document.createElement('div');            //Результат ответа
        resultDiv.className = 'result';
        qDiv.append(questionTitle, optionsDiv, submitButton, resultDiv);
        qContainer.appendChild(qDiv);
        submitButton.addEventListener('click', checkAnswer)
        
        function checkAnswer(e) {                                   
            const questionDiv = e.target.closest('.question');
            const questionIndex = Number(questionDiv.dataset.questionIndex);
            const q = questions[questionIndex];
            const selectedOption = questionDiv.querySelector(
                `input[name="answer-${questionIndex}"]:checked`
            );
            if (!selectedOption) {
                return;
            }
            const userAnswer = Number(selectedOption.value);
            const isCorrect = userAnswer === q.correctAnswer;           //Проверка на совпадение выбранного индекса с значением индекса правильного ответа
            currAnswers.push({  
                question: q.question,
                isCorrect: isCorrect
            });
            if (isCorrect){
                score++;
            };
            const resultDiv = questionDiv.querySelector('.result');
            resultDiv.innerHTML = isCorrect ?
                '<span style="color: green;">Верно!</span>' :
                '<span style="color: red;">Неверно!</span>';
                
            e.target.disabled = true;                                   //Поля становятся неактивными
            questionDiv.querySelectorAll('input').forEach(input => {
                input.disabled = true;
            });
            currQuestion++;
            if (currQuestion < questions.length) {
                showQuestion();
            } else {
                showResults();
            } 
        }

        function showResults() {                                    //Вывод и сохранение результата
            const heading2 = document.createElement('h2');
            heading2.textContent = 'Тест завершён!';
            const heading3 = document.createElement('h3');
            heading3.textContent = `Результат прохождения теста: ${score}`;
            resultDiv.appendChild(heading2);
            resultDiv.appendChild(heading3);
            localStorage.setItem('testres', score);
        }
    } 
})

