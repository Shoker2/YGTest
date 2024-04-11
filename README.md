# YGTest

При запуске прокта, будут ошибки в консоли [PluginYG](https://assetstore.unity.com/packages/add-ons/pluginyg-yandex-game-integration-235877). Чтобы устранить ошибки, следует импортировать [PluginYG](https://assetstore.unity.com/packages/add-ons/pluginyg-yandex-game-integration-235877) заного. Возможно также потребуется добавить Newtonsoft Json .NET, но об этом вы сможете [прочитать в документации PluginYG](https://ash-message-bf4.notion.site/PluginYG-d457b23eee604b7aa6076116aab647ed)

# Добавление вопросов и результатов

Зайдите на сцену `Assets -> Scenes -> SampleScene`. На `Main Camera` будет скрипт `DH`. В этом скрипте есть два массива: `Questions` - вопросы и `Results` - результаты.

Там есть несколько вопросов и результатов, лучше их удалите.

![image](https://github.com/Shoker2/YGTest/assets/66993983/29058abb-c841-4195-8776-0fe54683638a)

## Добавление Вопросов

Чтобы добавить вопрос, в массиве `Questions` добавите элемент.

Новый элемент будет содержать поля:

- `Title` - заголовок вопроса
- `Answer#` - Вариант ответа, где `#` номер варианта ответа (1 - 4)

## Добавление результатов

В папку `Assets -> Sprites` положите картинку, которая будет отображаться в окне с результатом. В массиве `Results` создайте новый элмент.

Новый элемент будет содержать поля:

- `Title` - имя результата
- `Image` - картинка результата
- `Right Border Value` - правая граница в бальной системе. То есть если у вас есть 2 результата: A и B и им заданы граница 10 и 20 соответственно, то результат A будет отображаться если набрать балов 'x <= 10', а B отобразится если набрать '10 < x <= 20'

# Изменение логотипа и заднего фона

В папке `Assets` есть 2 картинки: `logo.png` и `background.png`. Они будут отображаться в самой игре. А при загрузке игры будут использоваться `WebGL Template`. `background.png` используется на всех сценах в `Canvas -> Image`, компонент `Image -> Source Image`.