# BlazorApp3

## Начальная подготовка для локальной работы проекта

Для локального запуска приложения необходимо установить [MongoDB](https://metanit.com/nosql/mongodb/1.2.php)

Нужно создать базу данных с именем Airport, для этого в консоли mongoh нужно выполнить команду:
`use Airport`

Необходимо создать коллекцию Routes с помощью такой команды:
`db.createCollection('Routes')`

Наполнить коллекцию данными пока можно только вручную с помощью команды insertMany, например:
db.Routes.insertMany([{ "DepartureCity": "Саратов", "ArrivalCity": "Москва" }, { "DepartureCity": "Саратов", "ArrivalCity": "Волгоград" }])
