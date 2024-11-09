create table users
(
id int PRIMARY KEY IDENTITY(1,1),
email VARCHAR(MAX) null,
username VARCHAR(max) null,
password VARCHAR(MAX) null,
date_register DATE null

)

select * from users


create table books
(
id INT primary key identity(1,1),
book_title varchar(max) null,
author varchar(max) null,
published_date date null,
status varchar(max) null,
date_insert date null,
date_update date null,
date_delete date null
)



select * from books where date_delete is null;


alter table books
add image varchar(max) null

select * from books;


insert into books ()
VALUES("Math","Author","2023-01-01","Avaliable","2023-08-14");

INSERT INTO books (book_title,author,published_date,status,date_insert)
VALUES ('Book Ti', 'Book Title', '2023-08-17', 'Avaliable', '2023-08-16');



