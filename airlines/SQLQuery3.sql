CREATE TABLE USERS
(
Roles int primary key NOT NULL,
email Char(20) NOT NULL,
PasswordD Char(20) NOT NULL,
NAMEE Char(20),
LASTNAME Char(20),
CITY Char(20),
����_�������� Datetime,
ACTIVE CHAR(1)
);

CREATE TABLE �����
(
���_����� int primary key NOT NULL,
��������_�����  Char(20),
�����_������� Char(20),
);


CREATE TABLE ��������
(
���_�������� int primary key NOT NULL,
����� Char(20) NOT NULL,
��������_����� Char(20) NOT NULL,
�������� Char(20),
������������� Char(20),
��������_������������� Char(20),
��������_����� Char(20),
�����_��������� Char(20),
������_������������ Datetime
);

CREATE TABLE �����������_����
(
��������� int NOT NULL,
���_����� int NOT NULL,
����_���������� Datetime,
PRIMARY KEY (���������,���_�����),
FOREIGN KEY (���������) REFERENCES USERS (Roles),
FOREIGN KEY (���_�����) REFERENCES ����� (���_�����)
);

CREATE TABLE ����������_�_������
(
���_�������� int NOT NULL,
���_��������� int NOT NULL,
PRIMARY KEY (���_��������,���_���������),
FOREIGN KEY (���_��������) REFERENCES �������� (���_��������),
FOREIGN KEY (���_���������) REFERENCES ����� (���_�����)
);

CREATE TABLE Command 
(
���_��������� int NOT NULL,
���_������� int NOT NULL,
����_�_����� date NOT NULL,
PRIMARY KEY (���_���������,���_�������,����_�_�����),
FOREIGN KEY ( ���_���������,���_�������) REFERENCES ����������_�_������ (���_��������,���_���������)
);