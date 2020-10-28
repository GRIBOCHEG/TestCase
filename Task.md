С использованием языка программирования C# создать WEB API со следующими функциями
---
Управление книгами
	Поддерживаемые операции:
		- Добавление
		- Удаление по идентификатору
		- Изменение
		- Получение списка с сортировкой по году публикации или заголовку
		- Загрузка изображения обложки
	Контракт книги:
		- заголовок (обязательный параметр, не более 30 символов)
		- список авторов (книга должна содержать хотя бы одного автора
		- имя автора (обязательный параметр, не более 20 символов)
		- фамилия автора (обязательный параметр, не более 20 символов)
		- количество страниц (обязательный параметр, больше 0 и не более 10000)
		- год публикации (опциональный параметр, не раньше 1800)
		- название издательства (опциональный параметр, не более 30 символов)
		- ISBN с валидацией (обязательный параметр, http://en.wikipedia.org/wiki/International_Standard_Book_Number )
	Хранение данных – в памяти сервера (можно захардкодить несколько дефолтных записей).

Вычисление выражения в обратной польской записи
	Операторы: + - * / ^
	Операнды: числа
	Входной параметр: строка с выражением
	Из “10 4 2 / -“ должно получиться 8