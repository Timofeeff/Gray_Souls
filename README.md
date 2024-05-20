# Gray_Souls
## 2D-платформер, вдохновлённый играми серии Dark Souls.
____
### Уровни и сюжет
:small_blue_diamond: В игре пять уровней. Открытие происходит последовательно. Вернуться в пройденный уровень нельзя.

:small_blue_diamond: Присутствует система сохранений.

:small_blue_diamond: Возможность вариативного прохождения некоторых уровней (развилка из двух путей). В некоторых ситуациях, чтобы пройти по другому пути, необходима прокачка персонажа.

:small_blue_diamond: Сюжет подается постепенно, в течение всей игры, посредствам интерактивных табличек, расположенных на уровнях.
____
### Механики, сущности, взаимодействия
:small_orange_diamond: **Интерактивные таблички**. Через них подается сюжет, полезные советы, истории.

:small_orange_diamond: **Монеты**. Расположены на уровнях. С некоторой вероятностью выпадают из врагов. Нужны для повышения характеристик персонажа. При проигрыше игрок теряет все накопленные монеты.

:small_orange_diamond: **Сердца**. Расположены на уровнях. Нужны для восстановления утраченной ячейки здоровья персонажа. Одно сердце восстанавливает одну ячейку здоровья персонажа.

:small_orange_diamond: **Магазин**. Встречается на уровнях. Нужен для покупки улучшения характеристик персонажа за монеты.

:small_orange_diamond: **Двигающиеся платформы**. Встречаются на некоторых уровнях. Имеют разный размер и скорость движения.

:small_orange_diamond: **Ловушки**. Имеют разный внешний вид, но выполняют одну функцию - при попадании в них, персонаж получает урон, равный одной ячейке здоровья.

:small_orange_diamond: **Турели, выпускающие стрелы**. Встречаются на последнем уровне. Стреляют с разной скоростью. Имеют разную скорость перезарядки. Наносят персонажу урон, равный одной ячейке здоровья персонажа. 
____
### Враги
Скорость, здоровье, дальность атаки, область патрулирования врагов можно настраивать в редакторе Unity. Для разных вариантов атаки врагов созданы разные анимации. Так же, анимации созданы для разных состояний.

:japanese_ogre: **Пенек**. Реализован в трех вариантах:
* *статичный*;
* *патрулирующий определенную зону*;
* *патрулирующий определенную зону, с возможностью атаковать персонажа*.

:japanese_ogre: **Гриб**. Патрулирует определенную зону. Имеет возможность атаковать игрока.

:japanese_ogre: **Скелет**. Патрулирует определенную зону. Имеет возможность атаковать игрока. Реализован в двух вариантах, которые отличаются по размерам врага.

:japanese_ogre: **Циклоп**. Патрулирует определенную зону. Имеет возможность атаковать игрока. Реализован в двух вариантах, которые отличаются по дальности атаки.

:japanese_ogre: **Маг**. Летающий враг. Патрулирует определенную зону. Атакует игрока магическими снарядами.
____
### Боссы
Скорость, здоровье, дальность атаки, область патрулирования боссов можно настраивать в редакторе Unity. Для разных фаз боссов созданы разные анимации. Так же, анимации созданы для разных состояний. Бой с каждым боссом уникален, что заставляет игрока действовать с умом и разными способами, используя окружение на аренах.

:japanese_goblin: **Маленький Гриб**. Фазы боя:
1. *обычная скорость движения, обычная дальность атаки*;
2. *скорость движения и атаки увеличивается*.

:japanese_goblin: **Гоблин**. Имеет схожий мувсет с **Маленьким Грибом**, но здоровье увеличено.

:japanese_goblin: **Скелет**. Имеет схожий мувсет с **Гоблином**. Изменения:
* *большее здоровье*;
* *во второй фазе боя наносит двойной урон*;
* *на арене с боссом присутствует ловушка*.

:japanese_goblin: **Порождение тьмы**. Схожий мувсет с **Гоблином**. Изменения:
* *большее здоровье*;
* *во второй фазе боя скорость значительно увеличивается*;
* *на арене присутствуют: движущаяся платформа и два летающих врага, которые стреляют снарядами в игрока*.

:japanese_goblin: **Некромант**. Главный босс игры. Схожий мувсет с **Магом**. Изменения:
* *большее здоровье*;
* *во второй фазе становится очень быстрым*;
* *атакует огненными снарядами*;
* *на арене присутствуют: две платформы и турели, выпускающие стрелы*.
____
### Демонстрация платформинга
![](https://img.itch.zone/aW1nLzE2MTQ3NzE0LmdpZg==/original/ZVelFt.gif)
____
### Демонстрация битвы с врагом
![](https://img.itch.zone/aW1nLzE2MTQ3NzYzLmdpZg==/original/N9kepT.gif)
____
### Ночной уровень
![](https://img.itch.zone/aW1nLzE2MTQ3ODAwLmdpZg==/original/RO9OrD.gif)
____
### Демонстрация стреляющих турелей
![](https://img.itch.zone/aW1nLzE2MTQ3ODQ1LmdpZg==/original/9wdj5V.gif)
____
### Дополнительно
:large_blue_circle: Игра создана в стиле пиксель-арта.

:large_blue_circle: Используется 8-битное музыкальное сопровождение.

:large_blue_circle: В ночном уровне применяется динамическое освещение (как и в уровне "Замок"). Звездное небо из системы частиц. Добавлены звуки, для создания ночной атмосферы.

### [Ознакомиться с игрой поближе](https://tsa-productions-indie.itch.io/gray-souls)
