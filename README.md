# oop_ict_fitmore
Система управления фитнес-клубом
## Команда
#17

Смирнова Глафира Денисовна

Наконечная Виктория Александровна

Дмитриева Лина Анатольевна

Кибенко Дарья Владимировна

Самойленко Ева Игоревна

Буякова Екатерина Сергеевна

## Доменные сущности

- Пользователь:
- Клиент: id клиента, ФИО, дата рождения, номер телефона, email, адрес, тип абонемента,статус клиента;
- Сотрудник: id сотрудника, ФИО, номер телефона, email, дата начала работы, рабочий график, должность, удаление аккаунта;
- Тренировка: id тренировки, id зала, кол-во человек, время начала, время конца, описание;
- Абонемент: id абонемента, id клиента, тип, цена, дата начала, длительность, категория (разовое посещение, месяц, полгода, год и тд), статус абонемента;
- Зал (бассейн, тренажёры, групповой зал, зал для аэробики): id зала, номер комнаты, площадь, температура, вместимость;
- Услуги фитнес-клуба (тренировка, массаж, солярий и тд): id услуги, id сотрудника, продолжительность, стоимость;
- Оплата: id платежа, id клиента, дата покупки, сумма покупки, статус(оплачено или нет)
- *Запись клиента на тренировку: id записи, id тренировки, id клиента, время записи, статус(подтверждено или нет)*

## ERD доменных сущностей

1. *Клиент* может *запрашивать информацию* о сотрудниках, тренировках, оборудовании, абонементе, зале, услугах, расписании
2. *Клиент* может *записаться* на тренировку, услугу
3. *Сотрудник* может *запрашивать информацию* о клиенте, тренировке, оборудовании, абонементе, зале, услугах, расписании

[](https://miro.com/app/board/uXjVNpPwofA=/)

## Методы работы приложения

```powershell
Регистрация пользователя - POST api/v1/register
request - {"fullName": "Иван Иванов", "birthDate":"01.01.1994", "phone": “+79002543709”, “email”: “ivanov94@gmail.com”}
response - {"userID": 29cbvqw7m2dso0}
```

```powershell
Создание заказа - POST api/v1/orders
request - {"name": "Тестовый товар", "article":"12234234", "price": 107.5, ...остальные поля}
response - {"orderId":"4w5l6jn4wlk5j6nw4lk56"}
```

```powershell
Авторизация - POST api/v1/auth
request - {"fullName": "Иван Иванов", "phone": “+79002543709”, "ID": 345678}
response - {"OK": 200}
```

```powershell
Запись на тренировку - POST api/v1/signup
request - {"trainingID": 1567, "clientID": 345678}
response - {"OK": 200}
```

```powershell
Получить инфо о тренере - GET api/v1/listEmployee/{EmployeeId}/info
request - {“employeeID”: qjs09whsa5i7gso}
response - {“fullName”: “Иван Иванов”, “phoneNumber”: “+79002543709”, “email”: “ivanov94@gmail.com”, “startDate”: “01.01.2024”, “workSchedule”: “?dict?”, “position”: “pool trainer”}
```

```powershell
Получить инфо о пользователе - GET api/v1/getUser
request - {"clientID": 345678}
response - {"fullName": "Иван Иванов", "birthDate":"01.01.1994", "phone": “+79002543709”, “email”: “ivanov94@gmail.com”, “address”: “”, “subscriptionType”: “basic”, “fitnessLevel”: “medium”, “lockerNumber”: 87}
```

```powershell
Получить инфо о тренировке - GET api/v1/listTraining/{trainingID}/info
request - {“trainingID”: “23hki8dm20nk3”}
response - {“roomID”: 5987, “employeeID”: 43748, “equipmentID”: 7580, “participantsNumber”: 30, “date”: “30.03.2024 17:00”, “duration”: “1 hour”, “description”: “hard cardio”, “equipmendID”: arrayEquipmentID”, “trainingSchedule”: array(TrainingSession)}
```

```powershell
Получить инфо о зале - GET api/v1/info/{roomID}
request - {"roomID”: 7931913}
response - {"roomNum": 251, “equipmentID”: arrayEquipmentID, “space”: 150, “temperature”: “+18”, “capacity”: 50, “isPool”: False, “HasFitnessEquipment”: True, “IsGroupExerciseRoom”: True, “IsAerobicsRoom”: True}
```

```powershell
Добавить сотрудника - POST api/v1/addEmployee
request - {“employeeID”: 2615, “fullName”: “Иван Иванов”, “phoneNumber”: “+79002543709”, “email”: “ivanov94@gmail.com”, “startDate”: “01.01.2024”, “workSchedule”: “?dict?”, “position”: “pool trainer”, “salary”: “39000.00”, “isOwner”: “False”, “type”: “?”}
response - {"employeeID": 57930}
```

```powershell
Добавить тренировку - POST api/v1/addTraining
request - {“roomID”: 5987, “employeeID”: 43748, “equipmentID”: 7580, “participantsNumber”: 30, “date”: “30.03.2024 17:00”, “duration”: “1 hour”, “description”: “hard cardio”, “equipmendID”: arrayEquipmentID}
response - {“trainingID”: “23hki8dm20nk3”}
```

```powershell
Добавить абонемент - POST api/v1/addSubscription
request - {“clientID”: 474930, “type”: “premium”, “price”: 8000.00, “startDate”: “08.03.2024”, “duration”: “200 days”, “category”: “full”}
response - {“subscriptionID”: “29d3njnkfi8sn2”}
```
