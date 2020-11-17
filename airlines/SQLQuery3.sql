CREATE TABLE USERS
(
Roles int primary key NOT NULL,
email Char(20) NOT NULL,
PasswordD Char(20) NOT NULL,
NAMEE Char(20),
LASTNAME Char(20),
CITY Char(20),
Дата_рождения Datetime,
ACTIVE CHAR(1)
);

CREATE TABLE РЕЙСЫ
(
Код_рейса int primary key NOT NULL,
Название_рейса  Char(20),
Место_локации Char(20),
);


CREATE TABLE Самолеты
(
Код_самолета int primary key NOT NULL,
номер Char(20) NOT NULL,
бортовой_номер Char(20) NOT NULL,
Лицензия Char(20),
специализация Char(20),
Компания_производитель Char(20),
Домашний_адрес Char(20),
номер_двигателя Char(20),
Начало_эксплуатации Datetime
);

CREATE TABLE Оформленный_рейс
(
Должность int NOT NULL,
Код_рейса int NOT NULL,
Дата_оформления Datetime,
PRIMARY KEY (Должность,Код_рейса),
FOREIGN KEY (Должность) REFERENCES USERS (Roles),
FOREIGN KEY (Код_рейса) REFERENCES Рейсы (Код_рейса)
);

CREATE TABLE Информация_о_рейсах
(
Код_самолета int NOT NULL,
Код_персонала int NOT NULL,
PRIMARY KEY (Код_самолета,Код_персонала),
FOREIGN KEY (Код_самолета) REFERENCES Самолеты (Код_самолета),
FOREIGN KEY (Код_персонала) REFERENCES Рейсы (Код_рейса)
);

CREATE TABLE Command 
(
Код_персонала int NOT NULL,
Код_экипажа int NOT NULL,
Дата_и_время date NOT NULL,
PRIMARY KEY (Код_персонала,Код_экипажа,Дата_и_время),
FOREIGN KEY ( Код_персонала,Код_экипажа) REFERENCES Информация_о_рейсах (Код_самолета,Код_персонала)
);