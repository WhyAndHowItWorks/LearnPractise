# LearnPractise
Данный репозиторий создан во время учебной практики. А также во время нее была создана программа, версии которой будут описаны ниже.
## Цель проекта
Необходимо создать программу. Задача программы состоит в том, чтобы загрузить из файла текст, разрезать его на слова, а затем отсортировать получившийся список при помощи метода Пузырька. Порядок сортировки следующий: цифры от 0 до 9, затем кириллица от а до я. Сортировка происходит только по первому символу, дальнейшей сортировки нет. Затем, программа перезаписывает или создает по указанному пути файл и заносит туда отсортированный список слов. Также, рограмма перезаписывает или создает файла по еще одному пути, где записывает анализ фильтрации.
## Особенности проекта
Из особенностей можно подчеркнуть простоту и оптимизированность. У программы нет никакого графического отображения кроме вывода в консоль, так что она работает максимально быстро и эффективно расходует ресурсы вашего компьютера.
## Как работать с программой
Чтобы при помощи программы отредактировать текст по параметрам, указанным выше, вам надо запустить программу и в консоль ввести путь до файла с исходным текстом, как показано на картинке. Если вы хотите изменить путь сохранения результата сортировки и анализа фильтрации, вам также в коде программе нужно ввести новые пути в текстовые переменные, указанные на картинке.

![](https://github.com/WhyAndHowItWorks/LearnPractise/blob/master/Путь%20к%20файлу%20с%20исходником.png?raw=true)

Как прописать путь к файлу

![](https://github.com/WhyAndHowItWorks/LearnPractise/blob/master/пути%20к%20файлам.png?raw=true)

Как изменить пути к файлам(pathToResult - путь к файлу результату соритровки, pathToAnalize - путь к файлу анализу сортировки)

## Результат работы
Если вы правильно ввели пути к файлам, то результат будет выгдядеть следующим образом.

![](https://github.com/WhyAndHowItWorks/LearnPractise/blob/master/вывод%20в%20консоль.png?raw=true)

Вывод в консоль

![](https://github.com/WhyAndHowItWorks/LearnPractise/blob/master/результат%20сортировки.png?raw=true)

Как выглядит файл записи итога сортировки

![](https://github.com/WhyAndHowItWorks/LearnPractise/blob/master/Анализ.png?raw=true)

Как выглядит файл анализа сортировки

Также, в проекте добавлен пример исходного файла, результата сортировки и анализа сортировки в расширении txt.
Если вы столкнулись с какой-либо ошибкой при работе с программой, напишите пожалуйста в комментариях проекта)

# Версии программы
## Первая - простое начало
В данной версии нету практически никаких названных функций. Программа получает от пользователя через консоль путь до файла, затем же она возвращает этот файл в консоль. 
По сути, простая читалка файлов без никаких плюшек.
## Вторая - добавляем фильтрацию
Здесь уже добавлена суть программы - функция, разрезающая текст и сортирующая его, затем выводящая его в консоль.
## Третья - добавляем анализ
Добавлен анализ получившийся фильтрации, также получившиеся информация и сам результат фильтрации записываются в два разных файла, указанных в коде программы.
## Четвертая - оптимизируем
Здесь были оптимизированы уже существующие алгоритмы.



