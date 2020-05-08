# Coronavirus CashFlow
Образовательная стратегическая игра, обучающая основам инвестирования и ведения личного бюджета с нотками мировой пандемии 2020-го года.
Игра по курсу <a href="https://ulearn.me/Course/BasicProgramming2">«Основы программирования»</a>, основанная на настольной игре <a href="https://www.richdad.com/products/cashflow-classic">CASHFLOW®</a> по книге Роберта Кийосаки «Богатый папа, бедный папа».

## Игровая модель
Вся игровая модель располагается в папке <a href="GameModel">GameModel</a>: класс игрока (`Player.cs`), классы игры и игрового поля (`GameModel.cs` и `PlayingField.cs`) и классы активов и пассивов (`Asset.cs` и `Liability.cs`).

## Запуск оконного приложения
Отрисовка формы и запуск приложения находятся в файле <a href="GameForm">GameForm</a>.<br>
##### Для запуска на Windows: `CoronavirusCashFlow.exe`
##### На MacOS (с помощью Mono): `mono --arch=32 CoronavirusCashFlow.exe`

## Тестирование
Файлы для автоматического тестирования лежат в папке <a href="https://github.com/nickavdeev/Coronavirus-CashFlow/tree/dev/Tests">Tests</a>. Они проверяют возможные взаимодействия с игроком, игровой моделью, классами активов и пассивов.
