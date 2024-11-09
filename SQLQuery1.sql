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