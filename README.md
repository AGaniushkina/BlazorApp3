# BlazorApp3

## ��������� ���������� ��� ��������� ������ �������

��� ���������� ������� ���������� ���������� ���������� [MongoDB](https://metanit.com/nosql/mongodb/1.2.php)

����� ������� ���� ������ � ������ Airport, ��� ����� � ������� mongoh ����� ��������� �������:
`use Airport`

���������� ������� ��������� Routes � ������� ����� �������:
`db.createCollection('Routes')`

��������� ��������� ������� ���� ����� ������ ������� � ������� ������� insertMany, ��������:
db.Routes.insertMany([{ "DepartureCity": "�������", "ArrivalCity": "������" }, { "DepartureCity": "�������", "ArrivalCity": "���������" }])
