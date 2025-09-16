create database PasswordHash
use passwordhash

create table Users(user_id int primary key identity(1,1),Username Varchar(50),Password Varchar(100),Name varchar(50),Salt varchar(20))
drop table Users
select * from users