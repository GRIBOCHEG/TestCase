
Api description
====

    BooksController
    ---

    -    GET localhost:5001/api/books/get - Гет запрос возвращает все книги из хранилища
        
    -    GET localhost:5001/api/books/getsorted?param=(name || year) - Гет запрос, возвращает все книги из хранилища отсортированные по заголовку или году, если параметр не валидный возвращает код 400

    -    POST localhost:5001/api/books/create - Пост запрос, создает новую книгу в хранилище, если уже есть книга с таким заголовком или кодом ISBN возвращает код 400, если тело запроса не прошло валидацию, возвращает код 400
            ContentType: application/json, Body:    {
                                                        "name": "Book#2",
                                                        "authors": [
                                                            {
                                                                "firstname":"Name#2",
                                                                "lastname":"Name##2"
                                                            }
                                                        ],
                                                        "numberOfPages": 200,
                                                        "publisher": "ACT2",
                                                        "publishyear": 2000,
                                                        "isbnNumber": "2-266-11156-6"
                                                    }

    -    POST localhost:5001/api/books/update - Пост запрос, обновляет существующую книгу в хранилище, если айди не указан возвращает код 400, если книга с таким айди не найдена, возвращает код 404, если тело запроса не прошло валидацию, возвращает код 400
            ContentType: application/json, Body:    {
                                                        "id":"1",
                                                        "name": "Book#2",
                                                        "authors": [
                                                            {
                                                                "firstname":"Name#2",
                                                                "lastname":"Name##2"
                                                            }
                                                        ],
                                                        "numberOfPages": 200,
                                                        "publisher": "ACT2",
                                                        "publishyear": 2000,
                                                        "isbnNumber": "2-266-11156-6"
                                                    }
            
    -    DELETE localhost:5001/api/books/delete?id=<id> - Запрос Delete, удаляет книгу с указанным айди из хранилища, если айди не указан возвращает код 400, если книга с таким айди не найдена, возвращает код 404

    -    GET localhost:5001/api/books/cover?id=<id> - Гет запрос, возвращает строку Base64 обложки, если айди не указан возвращает код 400, если книга с таким айди не найдена, возвращает код 404

    -    POST localhost:5001/api/books/addcover - Пост запрос, заменяет строку Base64 обложки книги с указанныи айди в хранилище, если айди не указан возвращает код 400, если книга с таким айди не найдена, возвращает код 404
            ContentType: application/json, Body:    {
                                                        "id":"1",
                                                        "cover":"ExampleBase64String"
                                                    }
    
    PolishController
    ---

    -    POST localhost:5001/api/polish/solve - Пост запрос, возвращает решение выражения записанного в обратной польской нотации из строки в теле запроса, если строка в теле запроса пустая возвращает код 400, если выражение невозможно решить возвращает код 400
            ContentType: application/json, Body: "10 4 2 / -"


    Так же в архиве с решением присутствуют юнит тесты в папке Tests.
