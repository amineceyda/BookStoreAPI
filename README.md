# Book Store API

This is a simple Book Store API built using ASP.NET Core. The API allows you to manage books, authors, genres, and their relationships.

## Getting Started

To run the API locally, follow these steps:

1. Clone the repository to your local machine.
2. Open the project in your preferred IDE (Visual Studio, Visual Studio Code, etc.).
3. Build and run the project.

The API will be accessible at `http://localhost:5225`.

## Endpoints

### Book Endpoints

#### Get All Books

- **URL:** `/api/Books`
- **Method:** `GET`
- **Description:** Retrieve a list of all books.
- **Response:** JSON array containing book details.

#### Get Book Detail

- **URL:** `/api/Books/{id}`
- **Method:** `GET`
- **Description:** Retrieve details of a specific book.
- **Response:** JSON object containing book details.

#### Add Book

- **URL:** `/api/Books`
- **Method:** `POST`
- **Description:** Add a new book.
- **Request Body:** JSON object with book details.

#### Update Book

- **URL:** `/api/Books/{id}`
- **Method:** `PUT`
- **Description:** Update an existing book.
- **Request Body:** JSON object with updated book details.

#### Delete Book

- **URL:** `/api/Books/{id}`
- **Method:** `DELETE`
- **Description:** Delete a book.
- **Response:** No content on success.

### Genre Endpoints

#### Get All Genres

- **URL:** `/api/Genres`
- **Method:** `GET`
- **Description:** Retrieve a list of all genres.
- **Response:** JSON array containing genre details.

#### Get Genre Detail

- **URL:** `/api/Genres/{id}`
- **Method:** `GET`
- **Description:** Retrieve details of a specific genre.
- **Response:** JSON object containing genre details.

#### Add Genre

- **URL:** `/api/Genres`
- **Method:** `POST`
- **Description:** Add a new genre.
- **Request Body:** JSON object with genre details.

#### Update Genre

- **URL:** `/api/Genres/{id}`
- **Method:** `PUT`
- **Description:** Update an existing genre.
- **Request Body:** JSON object with updated genre details.

#### Delete Genre

- **URL:** `/api/Genres/{id}`
- **Method:** `DELETE`
- **Description:** Delete a genre.
- **Response:** No content on success.

... (similar endpoints for managing authors) ...

## Data Models

### Author

- `Id`: Identifier of the author.
- `Name`: Name of the author.
- `DateOfBirth`: Date of birth of the author.

### Book

- `Id`: Identifier of the book.
- `Title`: Title of the book.
- `PageCount`: Number of pages in the book.
- `PublishDate`: Date of publication of the book.
- `Genre`: Genre of the book.
- `Author`: Author of the book.

### Genre

- `Id`: Identifier of the genre.
- `Name`: Name of the genre.

## Dependencies

- ASP.NET Core
- Entity Framework Core
- AutoMapper
- FluentValidation

## Contributing

Contributions are welcome! Feel free to open issues or pull requests if you encounter any problems or have improvements to suggest.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

